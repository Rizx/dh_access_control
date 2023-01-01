using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetSDKCS;
using System.Runtime.InteropServices;

namespace AccessControl1s
{
    public partial class AccessPwd : Form
    {
        IntPtr loginID = IntPtr.Zero;
        private int m_Channel = 0;
        private string m_UserID = "";
        private List<int> m_selectDoorsList = new List<int>();
        private NET_RECORDSET_ACCESS_CTL_PWD update_pwd = new NET_RECORDSET_ACCESS_CTL_PWD();

        AccessControlForm mainWindow;

        public AccessPwd(IntPtr id, int channel, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
            m_Channel = channel;
            comboBox_OperateType.SelectedIndex = 0;
            mainWindow = main;
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            GetRecordSet();

        }

        private void comboBox_OperateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearData();

            button_Get.Visible = false;
            button_Operate.Enabled = true;
 //           textBox_RecNo.Text = "";
 //           textBox_OpenPwd.Text = "";
            textBox_UserID.Text = "";
          //  textBox_OpenPwd.ReadOnly = false;
            textBox_UserID.Enabled = true;
            textBox_OpenPwd.Enabled = true;
            button_Doors.Enabled = true;

            switch (comboBox_OperateType.SelectedIndex)
            {
                case 0:
                    {
                        textBox_RecNo.Enabled = false;
                      
                        button_Operate.Text = "Insert";
                    }
                    break;
                case 1:
                    {
                        textBox_RecNo.Enabled = true;
                        textBox_UserID.Enabled = false;
                        textBox_OpenPwd.Enabled = false;
                        //button_Doors.Enabled = false;
                        button_Operate.Text = "Get";
                    }
                    break;
                case 2:
                    {
                        textBox_RecNo.Enabled = true;
                        textBox_UserID.Enabled = false;
                        textBox_OpenPwd.Enabled = false;
                        button_Doors.Enabled = false; 
                        button_Operate.Text = "Update";
                        button_Operate.Enabled = false;
                        button_Get.Visible = true;
                        button_Get.Enabled = true;
                    }
                    break;
                case 3:
                    {
                        textBox_RecNo.Enabled = true;
                        textBox_UserID.Enabled = false;
                        textBox_OpenPwd.Enabled = false;
                        button_Doors.Enabled = false;
                        button_Get.Visible = false;
                        button_Operate.Enabled = true;
                        button_Operate.Text = "Remove";
                    }
                    break;
                case 4:
                    {
                        textBox_RecNo.Enabled = false;
                        textBox_UserID.Enabled = false;
                        textBox_OpenPwd.Enabled = false;
                        button_Doors.Enabled = false;
                        button_Get.Visible = false;
                        button_Operate.Enabled = true;
                        button_Operate.Text = "Clear";
                    }
                    break;
                default:
                    break;
            }
        }

        //constructing arrays in the struct. this method can make sure the array's size is right
        public void InitStruct(ref object stu)
        {
            IntPtr p_stu = IntPtr.Zero;
            Type type = stu.GetType();
            try
            {
                p_stu = Marshal.AllocHGlobal(Marshal.SizeOf(type));
                Marshal.StructureToPtr(stu, p_stu, true);
                stu = Marshal.PtrToStructure(p_stu, type);
            }
            finally
            {
                Marshal.FreeHGlobal(p_stu);
            }
        }
        private void InsterRecordSet()
        {
            IntPtr pParam = IntPtr.Zero;
            IntPtr pBuf = IntPtr.Zero;
            NET_CTRL_RECORDSET_INSERT_PARAM stuInsertParam = new NET_CTRL_RECORDSET_INSERT_PARAM();
            NET_CTRL_RECORDSET_INSERT_PARAM stuOutParam = new NET_CTRL_RECORDSET_INSERT_PARAM();

            NET_RECORDSET_ACCESS_CTL_PWD stuPwd = new NET_RECORDSET_ACCESS_CTL_PWD();
            object obj = stuPwd;
            InitStruct(ref obj);
            stuPwd = (NET_RECORDSET_ACCESS_CTL_PWD)obj;
            stuPwd.dwSize = (uint)Marshal.SizeOf(stuPwd);

            Encoding.Default.GetBytes( textBox_UserID.Text, 0, textBox_UserID.Text.Length, stuPwd.szUserID, 0);
            byte[] pwdArray = Encoding.Default.GetBytes(textBox_OpenPwd.Text);
            if (pwdArray.Length > 64)
            {
                MessageBox.Show("Password length cannot be greater than 64(密码长度不能大于64)。");
                return;
            }
            Encoding.Default.GetBytes(textBox_OpenPwd.Text, 0, textBox_OpenPwd.Text.Length, stuPwd.szDoorOpenPwd, 0);
            if (m_selectDoorsList.Count > 0)
            {
                if (stuPwd.sznDoors == null)
                {
                    stuPwd.sznDoors = new int[32];
                }
                for (int i = 0; i < m_selectDoorsList.Count; i++)
                {
                    stuPwd.sznDoors[i] = m_selectDoorsList[i];
                }
            }
            stuPwd.nDoorNum = m_selectDoorsList.Count;

            try
            {
                pParam = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_INSERT_PARAM)));
                pBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_PWD)));

                Marshal.StructureToPtr(stuPwd, pBuf, true);

                //package stuInsertParam
                stuInsertParam.stuCtrlRecordSetInfo.pBuf = pBuf;
                stuInsertParam.stuCtrlRecordSetInfo.nBufLen = Marshal.SizeOf(stuPwd);
                stuInsertParam.dwSize = (uint)Marshal.SizeOf(stuInsertParam);
                stuInsertParam.stuCtrlRecordSetInfo.dwSize = (uint)Marshal.SizeOf(stuInsertParam.stuCtrlRecordSetInfo);
                stuInsertParam.stuCtrlRecordSetInfo.emType = EM_NET_RECORD_TYPE.ACCESSCTLPWD;
                stuInsertParam.stuCtrlRecordSetResult.dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_INSERT_OUT));
                Marshal.StructureToPtr(stuInsertParam, pParam, true);


                bool bRet = NETClient.ControlDevice(loginID, EM_CtrlType.RECORDSET_INSERT, pParam, 3000);

                stuOutParam = (NET_CTRL_RECORDSET_INSERT_PARAM)Marshal.PtrToStructure(pParam, typeof(NET_CTRL_RECORDSET_INSERT_PARAM));
                if (bRet)
                {
                    MessageBox.Show("Insert succeed(添加成功)。RecNO(记录号):" + stuOutParam.stuCtrlRecordSetResult.nRecNo);
                    ClearData();
                }
                else
                {
                    MessageBox.Show(NETClient.GetLastError());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //free resource
            finally
            {
                Marshal.FreeHGlobal(pParam);
                Marshal.FreeHGlobal(pBuf);
            }
        }

        private void GetRecordSet()
        {
            int temp;
            if (!int.TryParse(textBox_RecNo.Text, out temp))
            {
                MessageBox.Show("Num is illegal！");
                return;
            }
            IntPtr pBuf = IntPtr.Zero;

            NET_RECORDSET_ACCESS_CTL_PWD result = new NET_RECORDSET_ACCESS_CTL_PWD();
            NET_CTRL_RECORDSET_PARAM stuParam = new NET_CTRL_RECORDSET_PARAM();

            try
            {
                pBuf = Marshal.AllocHGlobal(Marshal.SizeOf(result));

                //package for pwd
                result.nRecNo = Convert.ToInt32(textBox_RecNo.Text.Trim());
                
                result.dwSize = (uint)Marshal.SizeOf(result);
                Marshal.StructureToPtr(result, pBuf, true);

                //package stuParam
                stuParam.pBuf = pBuf;
                stuParam.nBufLen = Marshal.SizeOf(result);
                stuParam.emType = EM_NET_RECORD_TYPE.ACCESSCTLPWD;
                stuParam.dwSize = (uint)Marshal.SizeOf(stuParam);
                object obj = stuParam;

                bool bRet = NETClient.QueryDevState(loginID, (int)EM_DEVICE_STATE.DEV_RECORDSET, ref obj, typeof(NET_CTRL_RECORDSET_PARAM), 3000);
                if (bRet)
                {
                    update_pwd = (NET_RECORDSET_ACCESS_CTL_PWD)Marshal.PtrToStructure(pBuf, typeof(NET_RECORDSET_ACCESS_CTL_PWD));
                    textBox_OpenPwd.Text = Encoding.UTF8.GetString(update_pwd.szDoorOpenPwd);
                    textBox_UserID.Text = Encoding.UTF8.GetString(update_pwd.szUserID);

                    m_selectDoorsList.Clear();
                    for (int i = 0; i < update_pwd.nDoorNum; i++)
                    {
                        m_selectDoorsList.Add(update_pwd.sznDoors[i]);
                    }
                    MessageBox.Show("Get succeed。");

                    textBox_RecNo.Enabled = false;
                    textBox_UserID.Enabled = true;
                    textBox_OpenPwd.Enabled = true;
                    button_Get.Enabled = false;
                    button_Operate.Enabled = true;
                    button_Doors.Enabled = true; 
                }
                else
                {
                    MessageBox.Show(NETClient.GetLastError());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Marshal.FreeHGlobal(pBuf);
            }
        }

        private void UpdateRecordSet()
        {
            update_pwd.szUserID = new byte[32];

            Encoding.Default.GetBytes(textBox_UserID.Text, 0, textBox_UserID.Text.Length, update_pwd.szUserID, 0);
            byte[] pwdArray = Encoding.Default.GetBytes(textBox_OpenPwd.Text);
            if (pwdArray.Length > 64)
            {
                MessageBox.Show("Password length cannot be greater than 64(密码长度不能大于64)。");
                return;
            }
            update_pwd.szDoorOpenPwd = new byte[64];
            Encoding.Default.GetBytes(textBox_OpenPwd.Text, 0, textBox_OpenPwd.Text.Length, update_pwd.szDoorOpenPwd, 0);
            if (m_selectDoorsList.Count > 0)
            {
                if (update_pwd.sznDoors == null)
                {
                    update_pwd.sznDoors = new int[32];
                }
                for (int i = 0; i < m_selectDoorsList.Count; i++)
                {
                    update_pwd.sznDoors[i] = m_selectDoorsList[i];
                }
            }
            update_pwd.nDoorNum = m_selectDoorsList.Count;


            bool bRet = false;
            IntPtr pParam = IntPtr.Zero;
            IntPtr pBuf = IntPtr.Zero;
            NET_CTRL_RECORDSET_PARAM stuParam = new NET_CTRL_RECORDSET_PARAM();
            try
            {
                pParam = Marshal.AllocHGlobal(Marshal.SizeOf(stuParam));
                pBuf = Marshal.AllocHGlobal(Marshal.SizeOf(update_pwd));


                Marshal.StructureToPtr(update_pwd, pBuf, true);
                stuParam.pBuf = pBuf;
                stuParam.nBufLen = Marshal.SizeOf(update_pwd);
                stuParam.emType = EM_NET_RECORD_TYPE.ACCESSCTLPWD;
                stuParam.dwSize = (uint)Marshal.SizeOf(stuParam);
                Marshal.StructureToPtr(stuParam, pParam, true);

                bRet = NETClient.ControlDevice(loginID, EM_CtrlType.RECORDSET_UPDATE, pParam, 3000);
                if (bRet)
                {
                    MessageBox.Show("Update succeed(更新成功)。");
                    textBox_RecNo.Text = "";
                    textBox_OpenPwd.Text = "";
                    textBox_UserID.Text = "";
                    textBox_RecNo.Enabled = true;
                    textBox_UserID.Enabled = false;
                    textBox_OpenPwd.Enabled = false;
                    button_Doors.Enabled = false;
                    // button_Operate.Text = "Update";
                    button_Operate.Enabled = false;
                    button_Get.Enabled = true;
                    ClearData();
                }
                else
                {
                    MessageBox.Show(NETClient.GetLastError());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Marshal.FreeHGlobal(pParam);
                Marshal.FreeHGlobal(pBuf);
            }
        }

        private void RemoveRecordSet()
        {
            int temp;
            if (!int.TryParse(textBox_RecNo.Text, out temp))
            {
                MessageBox.Show("Num is illegal！");
                return;
            }

            bool result = false;
            IntPtr pParam = IntPtr.Zero;
            IntPtr pBuf = IntPtr.Zero;
            NET_CTRL_RECORDSET_PARAM stuParam = new NET_CTRL_RECORDSET_PARAM();
            stuParam.emType = EM_NET_RECORD_TYPE.ACCESSCTLPWD;
            stuParam.dwSize = (uint)Marshal.SizeOf(stuParam);
            stuParam.pBuf = IntPtr.Zero;
            stuParam.nBufLen = 0;
            try
            {
                pParam = Marshal.AllocHGlobal(Marshal.SizeOf(stuParam));
                pBuf = Marshal.AllocHGlobal(Marshal.SizeOf(int.Parse(textBox_RecNo.Text)));
                Marshal.StructureToPtr(int.Parse(textBox_RecNo.Text), pBuf, true);
                stuParam.pBuf = pBuf;
                stuParam.nBufLen = Marshal.SizeOf(int.Parse(textBox_RecNo.Text));
                Marshal.StructureToPtr(stuParam, pParam, true);

                result = NETClient.ControlDevice(loginID, EM_CtrlType.RECORDSET_REMOVE, pParam, 3000);
                if (result)
                {
                    MessageBox.Show("Remove succeed(删除成功)。");
                    ClearData();
                }
                else
                {
                    MessageBox.Show(NETClient.GetLastError());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Marshal.FreeHGlobal(pBuf);
                Marshal.FreeHGlobal(pParam);
            }
        }

        private void ClearRecordSet()
        {
            IntPtr pParam = IntPtr.Zero;
            NET_CTRL_RECORDSET_PARAM stuParam = new NET_CTRL_RECORDSET_PARAM();
            stuParam.emType = EM_NET_RECORD_TYPE.ACCESSCTLPWD;
            stuParam.dwSize = (uint)Marshal.SizeOf(stuParam);

            pParam = Marshal.AllocHGlobal(Marshal.SizeOf(stuParam));
            Marshal.StructureToPtr(stuParam, pParam, true);

            bool result = NETClient.ControlDevice(loginID, EM_CtrlType.RECORDSET_CLEAR, pParam, 3000);
            if (result)
            {
                MessageBox.Show("Clear succeed(清空成功)。");
            }
            else
            {
                MessageBox.Show(NETClient.GetLastError());
            }
        }

        private void button_Operate_Click(object sender, EventArgs e)
        {
            switch (comboBox_OperateType.SelectedIndex)
            {
                case 0:
                    InsterRecordSet();
                    break;
                case 1:
                    GetRecordSet();
 //                   textBox_UserID.Enabled = true;
  //                  textBox_OpenPwd.Enabled = true;
                    break;
                case 2:
                    {
                        UpdateRecordSet();

                    }
                    break;
                case 3:
                    RemoveRecordSet();
                    break;
                case 4:
                    ClearRecordSet();
                    break;

                default:
                    break;
            }

        }

        private void button_Doors_Click(object sender, EventArgs e)
        {
            List<int> doors = new List<int>();
            for (int i = 0; i < update_pwd.nDoorNum; i++)
            {
                doors.Add(update_pwd.sznDoors[i]);
            }
            DoorSelectForm doorForm = new DoorSelectForm(m_Channel, doors);
            doorForm.ShowDialog();
            if (doorForm.DialogResult == DialogResult.OK)
            {
                m_selectDoorsList.Clear();
                m_selectDoorsList = doorForm.SelectDoorsList;
            }
            doorForm.Dispose();
        }

        private void ClearData()
        {

            textBox_RecNo.Text = "";
            textBox_UserID.Text = "";
            textBox_OpenPwd.Text = "";
            m_selectDoorsList.Clear();
            update_pwd = new NET_RECORDSET_ACCESS_CTL_PWD();
        }
    }
}
