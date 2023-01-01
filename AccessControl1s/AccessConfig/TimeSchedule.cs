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
    public partial class TimeSchedule : Form
    {
        IntPtr loginID = IntPtr.Zero;
        private int m_Channel = 0;
        private readonly string CFG_CMD_ACCESSTIMESCHEDULE = "AccessTimeSchedule";
        private NET_CFG_ACCESS_TIMESCHEDULE_INFO timeSchedule = new NET_CFG_ACCESS_TIMESCHEDULE_INFO();

        private List<int> m_selectDoorsList = new List<int>();
        private NET_RECORDSET_HOLIDAY update_holiday = new NET_RECORDSET_HOLIDAY();

        AccessControlForm mainWindow;

        public TimeSchedule(IntPtr id, int channel, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
            m_Channel = channel;
            mainWindow = main;
        }

        private void TimeSchedule_Load(object sender, EventArgs e)
        {
            comboBox_Index.Items.Clear();
            for (int i = 1; i < 129; i++)
            {
                comboBox_Index.Items.Add(i);
            }
            comboBox_Index.SelectedIndex = 0;

            comboBox_DoorNo.Items.Clear(); 
            if (m_Channel > 0)
            {
                for (int i = 1; i <= m_Channel; i++)
                {
                    comboBox_DoorNo.Items.Add(i);
                }
                comboBox_DoorNo.SelectedIndex = 0;
            }

            comboBox_OperateType.SelectedIndex = 0;

           
            #region load TimeSchedule1 加载时间段1
     //       timeSchedule = new NET_CFG_ACCESS_TIMESCHEDULE_INFO();
      //      object objInfo = timeSchedule;
            object objInfo = new object();
            bool ret = NETClient.GetNewDevConfig(loginID, comboBox_Index.SelectedIndex, CFG_CMD_ACCESSTIMESCHEDULE, ref objInfo, typeof(NET_CFG_ACCESS_TIMESCHEDULE_INFO), 5000);
            if (ret)
            {
                timeSchedule = (NET_CFG_ACCESS_TIMESCHEDULE_INFO)objInfo;
                textBox_Name.Text = timeSchedule.szName;
                comboBox_Week.SelectedIndex = 0;
            }
           

           #endregion
            

            #region load TimeSchedule2 加载时间段2
            cfg = (NET_CFG_ACCESS_EVENT_INFO)GetConfig();
            textBox_OpenAlways.Text = cfg.nOpenAlwaysTimeIndex.ToString();
            textBox_CloseAlways.Text = cfg.nCloseAlwaysTimeIndex.ToString();
            textBox_RemoteTime.Text = cfg.stuAutoRemoteCheck.nTimeSechdule.ToString();
            checkBox_RemoteEnable.Checked = cfg.stuAutoRemoteCheck.bEnable;
            #endregion
        }

        private void button_GetTime1_Click(object sender, EventArgs e)
        {
     //       timeSchedule = new NET_CFG_ACCESS_TIMESCHEDULE_INFO();
            object objInfo = new object();
            bool ret = NETClient.GetNewDevConfig(loginID, comboBox_Index.SelectedIndex, CFG_CMD_ACCESSTIMESCHEDULE, ref objInfo, typeof(NET_CFG_ACCESS_TIMESCHEDULE_INFO), 10000);
            if (!ret)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            timeSchedule = (NET_CFG_ACCESS_TIMESCHEDULE_INFO)objInfo;

            textBox_Name.Text = timeSchedule.szName;
            comboBox_Week.SelectedIndex = 0;

            MessageBox.Show("Get success(获取成功)");

        }

        private void button_SetTime1_Click(object sender, EventArgs e)
        {
            byte[] nameArray = Encoding.Default.GetBytes(textBox_Name.Text);
            int nameCount = nameArray.Length < 128 ? nameArray.Length : 128;
            byte[] tempArray = new byte[128];
            for (int i = 0; i < nameCount; i++)
            {
                tempArray[i] = nameArray[i];
            }
            timeSchedule.szName = Encoding.Default.GetString(tempArray);
            try
            {
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4].nBeginHour = dateTimePicker_Start1.Value.Hour;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4].nBeginMin = dateTimePicker_Start1.Value.Minute;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4].nBeginSec = dateTimePicker_Start1.Value.Second;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4].nEndHour = dateTimePicker_End1.Value.Hour;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4].nEndMin = dateTimePicker_End1.Value.Minute;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4].nEndSec = dateTimePicker_End1.Value.Second;

                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 1].nBeginHour = dateTimePicker_Start2.Value.Hour;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 1].nBeginMin = dateTimePicker_Start2.Value.Minute;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 1].nBeginSec = dateTimePicker_Start2.Value.Second;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 1].nEndHour = dateTimePicker_End2.Value.Hour;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 1].nEndMin = dateTimePicker_End2.Value.Minute;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 1].nEndSec = dateTimePicker_End2.Value.Second;

                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 2].nBeginHour = dateTimePicker_Start3.Value.Hour;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 2].nBeginMin = dateTimePicker_Start3.Value.Minute;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 2].nBeginSec = dateTimePicker_Start3.Value.Second;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 2].nEndHour = dateTimePicker_End3.Value.Hour;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 2].nEndMin = dateTimePicker_End3.Value.Minute;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 2].nEndSec = dateTimePicker_End3.Value.Second;

                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 3].nBeginHour = dateTimePicker_Start4.Value.Hour;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 3].nBeginMin = dateTimePicker_Start4.Value.Minute;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 3].nBeginSec = dateTimePicker_Start4.Value.Second;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 3].nEndHour = dateTimePicker_End4.Value.Hour;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 3].nEndMin = dateTimePicker_End4.Value.Minute;
                timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 3].nEndSec = dateTimePicker_End4.Value.Second;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            object objInfo = timeSchedule;
            bool ret = NETClient.SetNewDevConfig(loginID, comboBox_Index.SelectedIndex, CFG_CMD_ACCESSTIMESCHEDULE, objInfo, typeof(NET_CFG_ACCESS_TIMESCHEDULE_INFO), 10000);
            if (!ret)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            MessageBox.Show("Set success(设置成功)");
        }

        private void button_Get2_Click(object sender, EventArgs e)
        {
            #region Get TimeSchedule2 获取时间段2
            cfg = (NET_CFG_ACCESS_EVENT_INFO)GetConfig();
            textBox_OpenAlways.Text = cfg.nOpenAlwaysTimeIndex.ToString();
            textBox_CloseAlways.Text = cfg.nCloseAlwaysTimeIndex.ToString();
            textBox_RemoteTime.Text = cfg.stuAutoRemoteCheck.nTimeSechdule.ToString();
            checkBox_RemoteEnable.Checked = cfg.stuAutoRemoteCheck.bEnable;
            #endregion
        }

        private void button_Set2_Click(object sender, EventArgs e)
        {
            #region Set Accesscontrol event config TimeSchedule2 设置时间段2

            try
            {
                cfg.nOpenAlwaysTimeIndex = int.Parse(textBox_OpenAlways.Text);
                cfg.nCloseAlwaysTimeIndex = int.Parse(textBox_CloseAlways.Text);
                cfg.stuAutoRemoteCheck.nTimeSechdule = int.Parse(textBox_RemoteTime.Text);
                cfg.stuAutoRemoteCheck.bEnable = checkBox_RemoteEnable.Checked;
            }
            catch (Exception)
            {
                MessageBox.Show("数据转换出错！");
                return;
            }

            if (SetConfig(cfg))
            {
                MessageBox.Show("Set successfully(设置成功)!");
            }
            #endregion
        }

        NET_CFG_ACCESS_EVENT_INFO cfg = new NET_CFG_ACCESS_EVENT_INFO();
        public NET_CFG_ACCESS_EVENT_INFO? GetConfig()
        {
            try
            {
                object objTemp = new object();
                bool bRet = NETClient.GetNewDevConfig(loginID, comboBox_DoorNo.SelectedIndex, "AccessControl", ref objTemp, typeof(NET_CFG_ACCESS_EVENT_INFO), 5000);
                if (bRet)
                {
                    cfg = (NET_CFG_ACCESS_EVENT_INFO)objTemp;
                }
                else
                {
                    MessageBox.Show(NETClient.GetLastError());
                }
            }
            catch (NETClientExcetion nex)
            {
                MessageBox.Show(nex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return cfg;
        }

        public bool SetConfig(NET_CFG_ACCESS_EVENT_INFO cfg)
        {
            bool bRet = false;
            try
            {
                bRet = NETClient.SetNewDevConfig(loginID, comboBox_DoorNo.SelectedIndex, "AccessControl", (object)cfg, typeof(NET_CFG_ACCESS_EVENT_INFO), 5000);
                if (!bRet)
                {
                    MessageBox.Show(NETClient.GetLastError());
                }
            }
            catch (NETClientExcetion nex)
            {
                MessageBox.Show(nex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return bRet;
        }

        private void button_Operate_Click(object sender, EventArgs e)
        {
            int nCtlType = comboBox_OperateType.SelectedIndex;
            if (-1 == nCtlType)
            {
                return;              
            }

            if (0 == nCtlType)
            {
                InsterRecordSet();
            }
            else if (1 == nCtlType)
            {
                GetRecordSet();
                textBox_HolidayNo.Enabled = true;
            }
            else if (2 == nCtlType)
            {
                UpdateRecordSet();

            }
            else if (3 == nCtlType)
            {
                RemoveRecordSet();
            }
            else if (4 == nCtlType)
            {
                ClearRecordSet();
            }
        }


        #region Update UI UI更新
        private void OnChangeUIState(int nState)
        {
            // load
            textBox_RecNo.Enabled = true;
            dateTimePicker_StartTime.Enabled = true;
            dateTimePicker_EndTime.Enabled = true;
            button_Door.Enabled = true;
            textBox_HolidayNo.Enabled = true;

            button_GetHoliday.Visible = false;
            button_GetHoliday.Enabled = true;
            button_Operate.Enabled = true;

            switch (nState)
            {
                case 0:
                    {
                        textBox_RecNo.Enabled = false;
                        textBox_RecNo.Text = "";
                        checkBox_HolidayEnable.Checked = false;
                        button_Operate.Text = "Insert(添加)";
                    }
                    break;
                case 1: // Get
                    {
                        dateTimePicker_StartTime.Enabled = false;
                        dateTimePicker_EndTime.Enabled = false;
                        textBox_HolidayNo.Enabled = false;
                        textBox_HolidayNo.Text = "";
                        textBox_RecNo.Text = "";
                        checkBox_HolidayEnable.Checked = false;
                        button_Operate.Text = "Get(获取)";
                    }
                    break;
                case 2: // Update step1
                    {
                        dateTimePicker_StartTime.Enabled = false;
                        dateTimePicker_EndTime.Enabled = false;
                        textBox_HolidayNo.Enabled = false;
                        textBox_HolidayNo.Text = "";
                        textBox_RecNo.Text = "";
                        checkBox_HolidayEnable.Checked = false;
                        button_Operate.Text = "Update(更新)";
                        button_Operate.Enabled = false;
                        button_GetHoliday.Visible = true;
                        button_GetHoliday.Enabled = true;
                    }
                    break;
                case 3: // Remove
                    {
                        dateTimePicker_StartTime.Enabled = false;
                        dateTimePicker_EndTime.Enabled = false;
                        textBox_HolidayNo.Enabled = false;
                        textBox_HolidayNo.Text = "";
                        textBox_RecNo.Text = "";
                        checkBox_HolidayEnable.Checked = false;
                        button_Operate.Text = "Remove(移除)";
                    }
                    break;
                case 4: // Clear
                    {
                        textBox_RecNo.Enabled = false;
                        dateTimePicker_StartTime.Enabled = false;
                        dateTimePicker_EndTime.Enabled = false;
                        textBox_HolidayNo.Enabled = false;
                        checkBox_HolidayEnable.Checked = false;
                        textBox_HolidayNo.Text = "";
                        textBox_RecNo.Text = "";
                        button_Operate.Text = "Clear(清除)";
                    }
                    break;
                case 5: // Update step2
                    {
                        textBox_RecNo.Enabled = false;
                        dateTimePicker_StartTime.Enabled = true;
                        dateTimePicker_EndTime.Enabled = true;
                        button_Door.Enabled = true;
                        textBox_HolidayNo.Enabled = true;

                        button_GetHoliday.Visible = true;
                        button_GetHoliday.Enabled = false;
                        button_Operate.Enabled = true;

                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void comboBox_OperateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearData();
            int nCtlType = comboBox_OperateType.SelectedIndex;
            OnChangeUIState(nCtlType);
        }

        private void button_GetHoliday_Click(object sender, EventArgs e)
        {
            int temp;
            if (!int.TryParse(textBox_RecNo.Text, out temp))
            {
                MessageBox.Show("Num is illegal(记录编号非法)！");
                return;
            }
            IntPtr pBuf = IntPtr.Zero;

            NET_RECORDSET_HOLIDAY result = new NET_RECORDSET_HOLIDAY();
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
                stuParam.emType = EM_NET_RECORD_TYPE.ACCESSCTLHOLIDAY;
                stuParam.dwSize = (uint)Marshal.SizeOf(stuParam);
                object obj = stuParam;

                bool bRet = NETClient.QueryDevState(loginID, (int)EM_DEVICE_STATE.DEV_RECORDSET, ref obj, typeof(NET_CTRL_RECORDSET_PARAM), 3000);
                if (bRet)
                {
                    update_holiday = (NET_RECORDSET_HOLIDAY)Marshal.PtrToStructure(pBuf, typeof(NET_RECORDSET_HOLIDAY));

                    dateTimePicker_StartTime.Value = update_holiday.stuStartTime.ToDateTime();
                    dateTimePicker_EndTime.Value = update_holiday.stuEndTime.ToDateTime();
                    textBox_HolidayNo.Text = update_holiday.szHolidayNo;
                    checkBox_HolidayEnable.Checked = update_holiday.bEnable;

                    m_selectDoorsList.Clear();
                    for (int i = 0; i < update_holiday.nDoorNum; i++)
                    {
                        m_selectDoorsList.Add(update_holiday.sznDoors[i]);
                    }
                    MessageBox.Show("Get succeed(获取成功)。");
                    OnChangeUIState(5);
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

            NET_RECORDSET_HOLIDAY stuHoliday = new NET_RECORDSET_HOLIDAY();
            object obj = stuHoliday;
            InitStruct(ref obj);
            stuHoliday = (NET_RECORDSET_HOLIDAY)obj;
            stuHoliday.dwSize = (uint)Marshal.SizeOf(stuHoliday);

            stuHoliday.stuStartTime.dwYear = (uint)dateTimePicker_StartTime.Value.Year;
            stuHoliday.stuStartTime.dwMonth = (uint)dateTimePicker_StartTime.Value.Month;
            stuHoliday.stuStartTime.dwDay = (uint)dateTimePicker_StartTime.Value.Day;

            stuHoliday.stuEndTime.dwYear = (uint)dateTimePicker_EndTime.Value.Year;
            stuHoliday.stuEndTime.dwMonth = (uint)dateTimePicker_EndTime.Value.Month;
            stuHoliday.stuEndTime.dwDay = (uint)dateTimePicker_EndTime.Value.Day;

            stuHoliday.szHolidayNo = textBox_HolidayNo.Text;
            stuHoliday.bEnable = checkBox_HolidayEnable.Checked;

            if (m_selectDoorsList.Count > 0)
            {
                if (stuHoliday.sznDoors == null)
                {
                    stuHoliday.sznDoors = new int[32];
                }
                for (int i = 0; i < m_selectDoorsList.Count; i++)
                {
                    stuHoliday.sznDoors[i] = m_selectDoorsList[i];
                }
            }
            stuHoliday.nDoorNum = m_selectDoorsList.Count;

            try
            {
                pParam = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_INSERT_PARAM)));
                pBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_RECORDSET_HOLIDAY)));

                Marshal.StructureToPtr(stuHoliday, pBuf, true);

                //package stuInsertParam
                stuInsertParam.stuCtrlRecordSetInfo.pBuf = pBuf;
                stuInsertParam.stuCtrlRecordSetInfo.nBufLen = Marshal.SizeOf(stuHoliday);
                stuInsertParam.dwSize = (uint)Marshal.SizeOf(stuInsertParam);
                stuInsertParam.stuCtrlRecordSetInfo.dwSize = (uint)Marshal.SizeOf(stuInsertParam.stuCtrlRecordSetInfo);
                stuInsertParam.stuCtrlRecordSetInfo.emType = EM_NET_RECORD_TYPE.ACCESSCTLHOLIDAY;
                stuInsertParam.stuCtrlRecordSetResult.dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_INSERT_OUT));
                Marshal.StructureToPtr(stuInsertParam, pParam, true);


                bool bRet = NETClient.ControlDevice(loginID, EM_CtrlType.RECORDSET_INSERT, pParam, 3000);

                stuOutParam = (NET_CTRL_RECORDSET_INSERT_PARAM)Marshal.PtrToStructure(pParam, typeof(NET_CTRL_RECORDSET_INSERT_PARAM));
                if (bRet)
                {
                    MessageBox.Show("Inster succeed(添加成功)。RecNO(记录号):" + stuOutParam.stuCtrlRecordSetResult.nRecNo);
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
                MessageBox.Show("Num is illegal(记录编号非法)！");
                return;
            }
            IntPtr pBuf = IntPtr.Zero;

            NET_RECORDSET_HOLIDAY result = new NET_RECORDSET_HOLIDAY();
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
                stuParam.emType = EM_NET_RECORD_TYPE.ACCESSCTLHOLIDAY;
                stuParam.dwSize = (uint)Marshal.SizeOf(stuParam);
                object obj = stuParam;

                bool bRet = NETClient.QueryDevState(loginID, (int)EM_DEVICE_STATE.DEV_RECORDSET, ref obj, typeof(NET_CTRL_RECORDSET_PARAM), 3000);
                if (bRet)
                {
                    update_holiday = (NET_RECORDSET_HOLIDAY)Marshal.PtrToStructure(pBuf, typeof(NET_RECORDSET_HOLIDAY));
                    dateTimePicker_StartTime.Value = update_holiday.stuStartTime.ToDateTime();
                    dateTimePicker_EndTime.Value = update_holiday.stuEndTime.ToDateTime();
                    textBox_HolidayNo.Text = update_holiday.szHolidayNo;
                    checkBox_HolidayEnable.Checked = update_holiday.bEnable;
                    MessageBox.Show("Get succeed(获取成功)。");
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
            update_holiday.stuStartTime.dwYear = (uint)dateTimePicker_StartTime.Value.Year;
            update_holiday.stuStartTime.dwMonth = (uint)dateTimePicker_StartTime.Value.Month;
            update_holiday.stuStartTime.dwDay = (uint)dateTimePicker_StartTime.Value.Day;

            update_holiday.stuEndTime.dwYear = (uint)dateTimePicker_EndTime.Value.Year;
            update_holiday.stuEndTime.dwMonth = (uint)dateTimePicker_EndTime.Value.Month;
            update_holiday.stuEndTime.dwDay = (uint)dateTimePicker_EndTime.Value.Day;

            update_holiday.szHolidayNo = textBox_HolidayNo.Text;
            update_holiday.bEnable = checkBox_HolidayEnable.Checked;
            if (m_selectDoorsList.Count > 0)
            {
                if (update_holiday.sznDoors == null)
                {
                    update_holiday.sznDoors = new int[32];
                }
                for (int i = 0; i < m_selectDoorsList.Count; i++)
                {
                    update_holiday.sznDoors[i] = m_selectDoorsList[i];
                }
            }
            update_holiday.nDoorNum = m_selectDoorsList.Count;


            bool bRet = false;
            IntPtr pParam = IntPtr.Zero;
            IntPtr pBuf = IntPtr.Zero;
            NET_CTRL_RECORDSET_PARAM stuParam = new NET_CTRL_RECORDSET_PARAM();
            try
            {
                pParam = Marshal.AllocHGlobal(Marshal.SizeOf(stuParam));
                pBuf = Marshal.AllocHGlobal(Marshal.SizeOf(update_holiday));


                Marshal.StructureToPtr(update_holiday, pBuf, true);
                stuParam.pBuf = pBuf;
                stuParam.nBufLen = Marshal.SizeOf(update_holiday);
                stuParam.emType = EM_NET_RECORD_TYPE.ACCESSCTLHOLIDAY;
                stuParam.dwSize = (uint)Marshal.SizeOf(stuParam);
                Marshal.StructureToPtr(stuParam, pParam, true);

                bRet = NETClient.ControlDevice(loginID, EM_CtrlType.RECORDSET_UPDATE, pParam, 3000);
                if (bRet)
                {
                    MessageBox.Show("Update succeed(更新成功)。");
                    OnChangeUIState(2);
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
                MessageBox.Show("Num is illegal(记录编号非法)！");
                return;
            }

            bool result = false;
            IntPtr pParam = IntPtr.Zero;
            IntPtr pBuf = IntPtr.Zero;
            NET_CTRL_RECORDSET_PARAM stuParam = new NET_CTRL_RECORDSET_PARAM();
            stuParam.emType = EM_NET_RECORD_TYPE.ACCESSCTLHOLIDAY;
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
            stuParam.emType = EM_NET_RECORD_TYPE.ACCESSCTLHOLIDAY;
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

        private void button_Door_Click(object sender, EventArgs e)
        {           
            List<int> doors = new List<int>();
            for (int i = 0; i < update_holiday.nDoorNum; i++)
            {
                doors.Add(update_holiday.sznDoors[i]);
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

        private void comboBox_Index_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_Name.Text = "";
            comboBox_Week.SelectedIndex = -1;
            dateTimePicker_Start1.Value = new DateTime(2020, 1, 1, 0, 0, 0);
            dateTimePicker_End1.Value = new DateTime(2020, 1, 1, 0, 0, 0);
            dateTimePicker_Start2.Value = new DateTime(2020, 1, 1, 0, 0, 0);
            dateTimePicker_End2.Value = new DateTime(2020, 1, 1, 0, 0, 0);
            dateTimePicker_Start3.Value = new DateTime(2020, 1, 1, 0, 0, 0);
            dateTimePicker_End3.Value = new DateTime(2020, 1, 1, 0, 0, 0);
            dateTimePicker_Start4.Value = new DateTime(2020, 1, 1, 0, 0, 0);
            dateTimePicker_End4.Value = new DateTime(2020, 1, 1, 0, 0, 0);

         //   timeSchedule = new NET_CFG_ACCESS_TIMESCHEDULE_INFO();
         //   object objInfo = timeSchedule;
            object objInfo = new object();
            bool ret = NETClient.GetNewDevConfig(loginID, comboBox_Index.SelectedIndex, CFG_CMD_ACCESSTIMESCHEDULE, ref objInfo, typeof(NET_CFG_ACCESS_TIMESCHEDULE_INFO), 10000);
            if (!ret)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            timeSchedule = (NET_CFG_ACCESS_TIMESCHEDULE_INFO)objInfo;

            textBox_Name.Text = timeSchedule.szName;
            comboBox_Week.SelectedIndex = 0;
        }

        private void comboBox_Week_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Week.SelectedIndex == -1)
            {
                return;
            }
            try
            {
                var temp = timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4];
                dateTimePicker_Start1.Value = new DateTime(2020, 1, 1, temp.nBeginHour, temp.nBeginMin, temp.nBeginSec);
                dateTimePicker_End1.Value = new DateTime(2020, 1, 1, temp.nEndHour, temp.nEndMin, temp.nEndSec);

                temp = timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 1];
                dateTimePicker_Start2.Value = new DateTime(2020, 1, 1, temp.nBeginHour, temp.nBeginMin, temp.nBeginSec);
                dateTimePicker_End2.Value = new DateTime(2020, 1, 1, temp.nEndHour, temp.nEndMin, temp.nEndSec);

                temp = timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 2];
                dateTimePicker_Start3.Value = new DateTime(2020, 1, 1, temp.nBeginHour, temp.nBeginMin, temp.nBeginSec);
                dateTimePicker_End3.Value = new DateTime(2020, 1, 1, temp.nEndHour, temp.nEndMin, temp.nEndSec);

                temp = timeSchedule.stuTime[comboBox_Week.SelectedIndex * 4 + 3];
                dateTimePicker_Start4.Value = new DateTime(2020, 1, 1, temp.nBeginHour, temp.nBeginMin, temp.nBeginSec);
                dateTimePicker_End4.Value = new DateTime(2020, 1, 1, temp.nEndHour, temp.nEndMin, temp.nEndSec);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearData()
        {
            textBox_RecNo.Text = "";
            textBox_HolidayNo.Text = "";
            m_selectDoorsList.Clear();
            update_holiday = new NET_RECORDSET_HOLIDAY();
        }
    }
}
