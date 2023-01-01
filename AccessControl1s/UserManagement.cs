using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NetSDKCS;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AccessControl1s
{

    public partial class UserManagement : Form
    {
        IntPtr loginID = IntPtr.Zero;
        private int m_Channel = 0;

        private static fMessCallBackEx m_MessCallBack;
        public int PacketLen { get; set; }
        public byte[] FingerPrintInfo { get; set; }
        public byte[] FingerPrintInfo2 { get; set; }
        private Timer m_Timer;
        private bool m_IsListen = false;
        private bool m_IsCollectionFailed = false;
        private bool m_IsCollection = false;
        private bool m_IsFinger1 = false;
        private bool m_IsFinger2 = false;
        private List<int> m_selectDoorsList = new List<int>();
        private List<int> m_selectTimesList = new List<int>();
        private int[] m_SelectTimeAry;
        int cmbOperateType;

        NET_RECORDSET_ACCESS_CTL_CARD m_stuInfo = new NET_RECORDSET_ACCESS_CTL_CARD();

        AccessControlForm mainWindow;
        public UserManagement(IntPtr id, int channel, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
            m_Channel = channel;
            mainWindow = main;
            m_Timer = new Timer();
            m_Timer.Interval = 30000;
            m_Timer.Tick += new EventHandler(Timer_Tick);
            m_MessCallBack = new fMessCallBackEx(MessCallBack);
            m_IsListen = AccessControlForm.m_IsListen;
            if (m_IsListen)
            {
                m_MessCallBack += AccessControlForm.m_AlarmCallBack;
            }
            NETClient.SetDVRMessCallBack(m_MessCallBack, IntPtr.Zero);
            this.button_GetPrint.Enabled = false;
            this.label_result.Text = "";
            comboBox_FirPrint.SelectedIndex = 0;

            OnChangeUIState(0);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            m_Timer.Stop();
            this.label_result.Text = "Collection failed(采集失败)";
            if(comboBox_FirPrint.SelectedIndex == 0)
            {
                FingerPrintInfo = new byte[1];
                m_IsFinger1 = false;
            }
            if (comboBox_FirPrint.SelectedIndex == 1)
            {
                FingerPrintInfo2 = new byte[1];
                m_IsFinger2 = false;
            }
            this.button_GetPrint.Enabled = true;
            m_IsCollectionFailed = true;
            if (!AccessControlForm.m_IsListen && m_IsListen)
            {
                NETClient.StopListen(loginID);
                m_IsListen = false;
            }
        }

        private bool MessCallBack(int lCommand, IntPtr lLoginID, IntPtr pBuf, uint dwBufLen, IntPtr pchDVRIP, int nDVRPort, bool bAlarmAckFlag, int nEventID, IntPtr dwUser)
        {
            if ((EM_ALARM_TYPE)lCommand == EM_ALARM_TYPE.ALARM_FINGER_PRINT)
            {
                string str_result = "";
                NET_ALARM_CAPTURE_FINGER_PRINT_INFO info = (NET_ALARM_CAPTURE_FINGER_PRINT_INFO)Marshal.PtrToStructure(pBuf, typeof(NET_ALARM_CAPTURE_FINGER_PRINT_INFO));
                if (info.bCollectResult)
                {
                    byte[] data = new byte[info.nPacketLen * info.nPacketNum];
                    Marshal.Copy(info.szFingerPrintInfo, data, 0, data.Length);
                    PacketLen = info.nPacketLen * info.nPacketNum;
                    BeginInvoke(new Action(() =>
                    {
                        if (0 == comboBox_FirPrint.SelectedIndex)
                        {
                            FingerPrintInfo = data;
                            m_IsFinger1 = true;
                        }
                        else
                        {
                            FingerPrintInfo2 = data;
                            m_IsFinger2 = true;
                        }
                        label_result.Text = "Collection Completed(采集完成)";
                        button_GetPrint.Enabled = true;
                    }));


                }
                else
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (comboBox_FirPrint.SelectedIndex == 0)
                        {
                            FingerPrintInfo = new byte[1];
                            m_IsFinger1 = false;
                        }
                        if (comboBox_FirPrint.SelectedIndex == 1)
                        {
                            FingerPrintInfo2 = new byte[1];
                            m_IsFinger2 = false;
                        }
                        label_result.Text = "Collection failed(采集失败)";
                        m_IsCollectionFailed = true;
                        button_GetPrint.Enabled = true;
                    }));

                }

                m_Timer.Stop();
            }
            return true; 
        }

        #region Update UI UI更新
        private void OnChangeUIState(int nState)
        {
            // load
            textBox_RecNo.Enabled = true;
            dateTimePicker_CreateTime.Enabled = false;
            button_GetUpdate.Visible = false;
            
            textBox_CardNo.Enabled = true;
            textBox_UserID.Enabled = true;
            comboBox_CardStatus.Enabled = true;
            comboBox_CardType.Enabled = true;
            textBox_CardPwd.Enabled = true;
            button_Door.Enabled = true;
            button_TimeSec.Enabled = true;

            textBox_UseTimes.Enabled = true;
            dateTimePicker_ValidStart.Enabled = true;
            dateTimePicker_ValidEnd.Enabled = true;
            checkBox_First.Enabled = true;
            comboBox_FirPrint.Enabled = true;
            button_GetPrint.Enabled = true;
            button_GetUpdate.Visible = false;
            button_GetUpdate.Enabled = true;
            button_Insert.Enabled = true;
            label_result.Text = "";
            label_CardNo.Text = "";
            

            switch (nState)
            {
                case 0:
                    {
                        textBox_RecNo.Enabled = false;
                        textBox_RecNo.Text = "";
                        dateTimePicker_CreateTime.Enabled = false;
                        comboBox_FirPrint.Enabled = false;
                        button_GetPrint.Enabled = false;
                        button_Insert.Text = "Insert(添加)";
                        textBox_CardNo.Text = "";
                        textBox_UserID.Text = "";
                        textBox_CardPwd.Text = "";
                        textBox_UseTimes.Text = "";
                        comboBox_CardStatus.SelectedIndex = -1;
                        comboBox_CardType.SelectedIndex = -1;
                    }
                    break;
                case 1:
                    {
                        dateTimePicker_CreateTime.Enabled = false;
                        comboBox_CardType.Enabled = false;
                        comboBox_CardStatus.Enabled = false;
                        textBox_CardPwd.Enabled = false;
                        textBox_UseTimes.Enabled = false;
                        dateTimePicker_ValidStart.Enabled = false;
                        dateTimePicker_ValidEnd.Enabled = false;
                        checkBox_First.Enabled = false;
                        comboBox_FirPrint.Enabled = false;
                        button_GetPrint.Enabled = false;
                        button_Insert.Text = "Get(获取)";

                        textBox_RecNo.Text = "";
                        textBox_CardNo.Text = "";
                        textBox_UserID.Text = "";
                        textBox_CardPwd.Text = "";
                        textBox_UseTimes.Text = "";
                        comboBox_CardStatus.SelectedIndex = -1;
                        comboBox_CardType.SelectedIndex = -1;
                    }
                    break;
                case 2:
                case 6:
                    {
                        dateTimePicker_CreateTime.Enabled = false;
                        textBox_CardNo.Enabled = false;
                        textBox_UserID.Enabled = false;
                        comboBox_CardStatus.Enabled = false;
                        comboBox_CardType.Enabled = false;
                        textBox_CardPwd.Enabled = false;
                        button_Door.Enabled = false;
                        button_TimeSec.Enabled = false;
                        textBox_UseTimes.Enabled = false;
                        dateTimePicker_ValidStart.Enabled = false;
                        dateTimePicker_ValidEnd.Enabled = false;
                        checkBox_First.Enabled = false;
                        comboBox_FirPrint.Enabled = false;
                        button_GetPrint.Enabled = false;
                        button_Insert.Enabled = false;
                        button_GetUpdate.Visible = true;
                        button_Insert.Text = "Update(更新)";

                        textBox_RecNo.Text = "";
                        textBox_CardNo.Text = "";
                        textBox_UserID.Text = "";
                        textBox_CardPwd.Text = "";
                        textBox_UseTimes.Text = "";
                        comboBox_CardStatus.SelectedIndex = -1;
                        comboBox_CardType.SelectedIndex = -1;
                        label_CardNo.Text = "Unchangeable(不可改)";

                    }
                    break;
                case 3:
                    {
                        dateTimePicker_CreateTime.Enabled = false;
                        textBox_CardNo.Enabled = false;
                        textBox_UserID.Enabled = false;
                        comboBox_CardStatus.Enabled = false;
                        comboBox_CardType.Enabled = false;
                        textBox_CardPwd.Enabled = false;
                        button_Door.Enabled = false;
                        button_TimeSec.Enabled = false;
                        textBox_UseTimes.Enabled = false;
                        dateTimePicker_ValidStart.Enabled = false;
                        dateTimePicker_ValidEnd.Enabled = false;
                        checkBox_First.Enabled = false;
                        comboBox_FirPrint.Enabled = false;
                        button_GetPrint.Enabled = false;
                        button_GetUpdate.Visible = false;
                        button_Insert.Text = "Remove(移除)";

                        textBox_RecNo.Text = "";
                        textBox_CardNo.Text = "";
                        textBox_UserID.Text = "";
                        textBox_CardPwd.Text = "";
                        textBox_UseTimes.Text = "";
                        comboBox_CardStatus.SelectedIndex = -1;
                        comboBox_CardType.SelectedIndex = -1;
                    }
                    break;
                case 4:
                    {
                        textBox_RecNo.Enabled = false;
                        dateTimePicker_CreateTime.Enabled = false;
                        textBox_CardNo.Enabled = false;
                        textBox_UserID.Enabled = false;
                        comboBox_CardStatus.Enabled = false;
                        comboBox_CardType.Enabled = false;
                        textBox_CardPwd.Enabled = false;
                        button_Door.Enabled = false;
                        button_TimeSec.Enabled = false;
                        textBox_UseTimes.Enabled = false;
                        dateTimePicker_ValidStart.Enabled = false;
                        dateTimePicker_ValidEnd.Enabled = false;
                        checkBox_First.Enabled = false;
                        comboBox_FirPrint.Enabled = false;
                        button_GetPrint.Enabled = false;
                        button_GetUpdate.Visible = false;
                        button_Insert.Text = "Clear(清空)";
                        textBox_RecNo.Text = "";
                        textBox_CardNo.Text = "";
                        textBox_UserID.Text = "";
                        textBox_CardPwd.Text = "";
                        textBox_UseTimes.Text = "";
                    }
                    break;
                case 5:
                    {
                        textBox_RecNo.Enabled = false;
                        dateTimePicker_CreateTime.Enabled = false;
                        button_GetUpdate.Visible = false;
                        button_Insert.Text = "InsertEx(添加)";
                        label_result.Text = "";
                        textBox_RecNo.Text = "";
                        textBox_CardNo.Text = "";
                        textBox_UserID.Text = "";
                        textBox_CardPwd.Text = "";
                        textBox_UseTimes.Text = "";

                    }
                    break;
                case 7: // Update Step2
                    {
                        textBox_RecNo.Enabled = false;
                        comboBox_FirPrint.Enabled = false;
                        button_GetPrint.Enabled = false;
                        button_GetUpdate.Visible = true;
                        button_GetUpdate.Enabled = false;
                        button_Insert.Enabled = true;
                        label_CardNo.Text = "Unchangeable(不可改)";
                    }
                    break;
                case 8: // UpdateEx Step2
                    {
                        textBox_RecNo.Enabled = false;
                        comboBox_FirPrint.Enabled = true;
                        button_GetPrint.Enabled = true;
                        button_GetUpdate.Visible = true;
                        button_GetUpdate.Enabled = false;
                        button_Insert.Enabled = true;
                        label_CardNo.Text = "Unchangeable(不可改)";
                    }
                    break;
                default:
                    break;
            }



        }
        #endregion

        private void comboBox_OperateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbOperateType = comboBox_OperateType.SelectedIndex;
            OnChangeUIState(cmbOperateType);
        }

        private void button_TimeSec_Click(object sender, EventArgs e)
        {
            
            List<int> times = new List<int>();
            for (int i = 0; i < m_stuInfo.nNewTimeSectionNum; i++)
            {
                times.Add(m_stuInfo.nNewTimeSectionNo[i]);
            }
            TimeSec timeForm = new TimeSec(128, times);
            timeForm.ShowDialog();
            if (timeForm.DialogResult == DialogResult.OK)
            {
                m_selectTimesList.Clear();
                m_selectTimesList = timeForm.SelectTimesList;
            }
            timeForm.Dispose();
        }

        private void button_Insert_Click(object sender, EventArgs e)
        {
            int nCtlType = comboBox_OperateType.SelectedIndex;
            if (-1 == nCtlType)
            {
                return;             
            }
            m_stuInfo.dwSize =  (uint)Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD));
            if (0 == nCtlType)
            {
                #region Insert record 添加卡记录
                NET_CTRL_RECORDSET_INSERT_PARAM stuInfo = new NET_CTRL_RECORDSET_INSERT_PARAM();
                stuInfo.dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_INSERT_PARAM));

                stuInfo.stuCtrlRecordSetInfo.dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_INSERT_IN));
                stuInfo.stuCtrlRecordSetInfo.emType = EM_NET_RECORD_TYPE.ACCESSCTLCARD;
                
                stuInfo.stuCtrlRecordSetInfo.nBufLen = (int)Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD));

                stuInfo.stuCtrlRecordSetResult.dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_INSERT_OUT));

                m_stuInfo.stuCreateTime.dwYear = (uint)DateTime.Now.Year;
                m_stuInfo.stuCreateTime.dwMonth = (uint)DateTime.Now.Month;
                m_stuInfo.stuCreateTime.dwDay = (uint)DateTime.Now.Day;
                m_stuInfo.stuCreateTime.dwHour = (uint)DateTime.Now.Hour;
                m_stuInfo.stuCreateTime.dwMinute = (uint)DateTime.Now.Minute;
                m_stuInfo.stuCreateTime.dwSecond = (uint)DateTime.Now.Second;
                m_stuInfo.szCardNo = this.textBox_CardNo.Text.Trim();
                m_stuInfo.szUserID = this.textBox_UserID.Text.Trim();
                m_stuInfo.szPsw = this.textBox_CardPwd.Text.Trim();
                try
                {

                   m_stuInfo.emStatus = (EM_ACCESSCTLCARD_STATE)comboBox_CardStatus.SelectedIndex - 1;
                    m_stuInfo.emType = (EM_ACCESSCTLCARD_TYPE)comboBox_CardType.SelectedIndex - 1;
                    m_stuInfo.nUseTime = Convert.ToInt32(textBox_UseTimes.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                m_stuInfo.bNewDoor = true;

                if (m_selectDoorsList.Count > 0)
                {
                    if(m_stuInfo.nNewDoors == null)
                    {
                        m_stuInfo.nNewDoors = new int[128];
                    }
                    for (int i = 0; i < m_selectDoorsList.Count; i++)
                    {
                        m_stuInfo.nNewDoors[i] = m_selectDoorsList[i];
                    }
                }
                m_stuInfo.nNewDoorNum = m_selectDoorsList.Count;

                if (m_selectTimesList.Count > 0) 
                {
                    if (m_stuInfo.nNewTimeSectionNo == null)
                    {
                        m_stuInfo.nNewTimeSectionNo = new int[128];
                    }
                    for (int i = 0; i < m_selectTimesList.Count; i++)
                    {
                        m_stuInfo.nNewTimeSectionNo[i] = m_selectTimesList[i];
                    }
                }
                m_stuInfo.nNewTimeSectionNum = m_selectTimesList.Count;

                m_stuInfo.stuValidStartTime.dwYear = (uint)dateTimePicker_ValidStart.Value.Year;
                m_stuInfo.stuValidStartTime.dwMonth = (uint)dateTimePicker_ValidStart.Value.Month;
                m_stuInfo.stuValidStartTime.dwDay = (uint)dateTimePicker_ValidStart.Value.Day;
                m_stuInfo.stuValidStartTime.dwHour = (uint)dateTimePicker_ValidStart.Value.Hour;
                m_stuInfo.stuValidStartTime.dwMinute = (uint)dateTimePicker_ValidStart.Value.Minute;
                m_stuInfo.stuValidStartTime.dwSecond = (uint)dateTimePicker_ValidStart.Value.Second;

                m_stuInfo.stuValidEndTime.dwYear = (uint)dateTimePicker_ValidEnd.Value.Year;
                m_stuInfo.stuValidEndTime.dwMonth = (uint)dateTimePicker_ValidEnd.Value.Month;
                m_stuInfo.stuValidEndTime.dwDay = (uint)dateTimePicker_ValidEnd.Value.Day;
                m_stuInfo.stuValidEndTime.dwHour = (uint)dateTimePicker_ValidEnd.Value.Hour;
                m_stuInfo.stuValidEndTime.dwMinute = (uint)dateTimePicker_ValidEnd.Value.Minute;
                m_stuInfo.stuValidEndTime.dwSecond = (uint)dateTimePicker_ValidEnd.Value.Second;
                m_stuInfo.bFirstEnter = this.checkBox_First.Checked; 


                IntPtr inPtr = IntPtr.Zero;
                IntPtr ptr = IntPtr.Zero;
                try
                {
                    inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD)));
                    Marshal.StructureToPtr(m_stuInfo, inPtr, true);

                    stuInfo.stuCtrlRecordSetInfo.pBuf = inPtr;
                    stuInfo.stuCtrlRecordSetInfo.nBufLen = (int)Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD));
                    ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_INSERT_PARAM)));
                    Marshal.StructureToPtr(stuInfo, ptr, true);
                    bool ret = NETClient.ControlDevice(loginID, EM_CtrlType.RECORDSET_INSERT, ptr, 10000);
                    if (!ret)
                    {
                        MessageBox.Show(NETClient.GetLastError());
                        return;
                    }
                    stuInfo = (NET_CTRL_RECORDSET_INSERT_PARAM)Marshal.PtrToStructure(ptr, typeof(NET_CTRL_RECORDSET_INSERT_PARAM));
                    MessageBox.Show("Execute Success(操作成功)\n RecNo=" + stuInfo.stuCtrlRecordSetResult.nRecNo.ToString());
                }
                finally
                {
                    Marshal.FreeHGlobal(inPtr);
                    Marshal.FreeHGlobal(ptr);
                }
                #endregion

            }
            else if (1 == nCtlType)
            {
                #region Get Card Info 获取卡记录 

                int temp;
                if (!int.TryParse(textBox_RecNo.Text, out temp))
                {
                    MessageBox.Show("Num is illegal(记录编号非法)！");
                    return;
                }

                NET_CTRL_RECORDSET_PARAM inp = new NET_CTRL_RECORDSET_PARAM();

            //    NET_RECORDSET_ACCESS_CTL_CARD info = new NET_RECORDSET_ACCESS_CTL_CARD();

                IntPtr infoPtr = IntPtr.Zero;

                try
                {

                    infoPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD)));
                    m_stuInfo.dwSize = (uint)Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD));
                    m_stuInfo.nRecNo = Convert.ToInt32(textBox_RecNo.Text.Trim());
                    m_stuInfo.bEnableExtended = true;

                    m_stuInfo.stuFingerPrintInfoEx = new NET_ACCESSCTLCARD_FINGERPRINT_PACKET_EX();
                    m_stuInfo.stuFingerPrintInfoEx.nPacketLen = 2000;
                    m_stuInfo.stuFingerPrintInfoEx.pPacketData = IntPtr.Zero;
                    m_stuInfo.stuFingerPrintInfoEx.pPacketData = Marshal.AllocHGlobal(m_stuInfo.stuFingerPrintInfoEx.nPacketLen);
                    Marshal.StructureToPtr(m_stuInfo, infoPtr, true);
                    inp.pBuf = infoPtr;
                    inp.nBufLen = Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD));
                    inp.dwSize = (uint)Marshal.SizeOf(inp);
                    inp.emType = EM_NET_RECORD_TYPE.ACCESSCTLCARD;
                    object objInp = inp;
                    bool ret = NETClient.QueryDevState(loginID, (int)EM_DEVICE_STATE.DEV_RECORDSET_EX, ref objInp, typeof(NET_CTRL_RECORDSET_PARAM), 10000);
                    if (!ret)
                    {
                        MessageBox.Show(NETClient.GetLastError());
                        return;
                    }
                    inp = (NET_CTRL_RECORDSET_PARAM)objInp;
                    m_stuInfo = (NET_RECORDSET_ACCESS_CTL_CARD)Marshal.PtrToStructure(inp.pBuf, typeof(NET_RECORDSET_ACCESS_CTL_CARD));
                    try
                    {
                        dateTimePicker_CreateTime.Value = m_stuInfo.stuCreateTime.ToDateTime();
                        textBox_CardNo.Text = m_stuInfo.szCardNo;
                        textBox_UserID.Text = m_stuInfo.szUserID;
                        comboBox_CardStatus.SelectedIndex = (int)m_stuInfo.emStatus + 1;
                        comboBox_CardType.SelectedIndex = (int)m_stuInfo.emType + 1;
                        textBox_CardPwd.Text = m_stuInfo.szPsw;

                        m_SelectTimeAry = m_stuInfo.nNewTimeSectionNo;
                        textBox_UseTimes.Text = m_stuInfo.nUseTime.ToString();
                        dateTimePicker_ValidStart.Value = m_stuInfo.stuValidStartTime.ToDateTime();
                        dateTimePicker_ValidEnd.Value = m_stuInfo.stuValidEndTime.ToDateTime();

                        checkBox_First.Checked = m_stuInfo.bFirstEnter;   
                    }
                    catch (Exception exc)
                    {

                        MessageBox.Show(exc.Message);
                        return;
                    }
                

                    MessageBox.Show("Query Success(获取成功)");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Marshal.FreeHGlobal(infoPtr);
                }
                #endregion 
            }
            else if (2 == nCtlType)
            {
                #region Update record 更新卡记录 
                NET_CTRL_RECORDSET_PARAM stuInfo = new NET_CTRL_RECORDSET_PARAM();
                stuInfo.dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_PARAM));
                stuInfo.emType = EM_NET_RECORD_TYPE.ACCESSCTLCARD;

                m_stuInfo.stuCreateTime.dwYear = (uint)DateTime.Now.Year;
                m_stuInfo.stuCreateTime.dwMonth = (uint)DateTime.Now.Month;
                m_stuInfo.stuCreateTime.dwDay = (uint)DateTime.Now.Day;
                m_stuInfo.stuCreateTime.dwHour = (uint)DateTime.Now.Hour;
                m_stuInfo.stuCreateTime.dwMinute = (uint)DateTime.Now.Minute;
                m_stuInfo.stuCreateTime.dwSecond = (uint)DateTime.Now.Second;

                m_stuInfo.szCardNo = this.textBox_CardNo.Text.Trim();
                m_stuInfo.szUserID = this.textBox_UserID.Text.Trim();

                m_stuInfo.szPsw = this.textBox_CardPwd.Text.Trim();
                try
                {
                    m_stuInfo.nRecNo = Convert.ToInt32(textBox_RecNo.Text.Trim());
                    m_stuInfo.emStatus = (EM_ACCESSCTLCARD_STATE)comboBox_CardStatus.SelectedIndex - 1;
                    m_stuInfo.emType = (EM_ACCESSCTLCARD_TYPE)comboBox_CardType.SelectedIndex - 1;
                    m_stuInfo.nUseTime = Convert.ToInt32(textBox_UseTimes.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                m_stuInfo.bNewDoor = true;
                if (m_selectDoorsList.Count > 0)
                {
                    if (m_stuInfo.nNewDoors == null)
                    {
                        m_stuInfo.nNewDoors = new int[128];
                    }
                    for (int i = 0; i < m_selectDoorsList.Count; i++)
                    {
                        m_stuInfo.nNewDoors[i] = m_selectDoorsList[i];
                    }
                }
                m_stuInfo.nNewDoorNum = m_selectDoorsList.Count;

                if (m_selectTimesList.Count > 0)
                {
                    if (m_stuInfo.nNewTimeSectionNo == null)
                    {
                        m_stuInfo.nNewTimeSectionNo = new int[128];
                    }
                    for (int i = 0; i < m_selectTimesList.Count; i++)
                    {
                        m_stuInfo.nNewTimeSectionNo[i] = m_selectTimesList[i];
                    }
                }
                m_stuInfo.nNewTimeSectionNum = m_selectTimesList.Count;
                m_stuInfo.stuValidStartTime.dwYear = (uint)dateTimePicker_ValidStart.Value.Year;
                m_stuInfo.stuValidStartTime.dwMonth = (uint)dateTimePicker_ValidStart.Value.Month;
                m_stuInfo.stuValidStartTime.dwDay = (uint)dateTimePicker_ValidStart.Value.Day;
                m_stuInfo.stuValidStartTime.dwHour = (uint)dateTimePicker_ValidStart.Value.Hour;
                m_stuInfo.stuValidStartTime.dwMinute = (uint)dateTimePicker_ValidStart.Value.Minute;
                m_stuInfo.stuValidStartTime.dwSecond = (uint)dateTimePicker_ValidStart.Value.Second;

                m_stuInfo.stuValidEndTime.dwYear = (uint)dateTimePicker_ValidEnd.Value.Year;
                m_stuInfo.stuValidEndTime.dwMonth = (uint)dateTimePicker_ValidEnd.Value.Month;
                m_stuInfo.stuValidEndTime.dwDay = (uint)dateTimePicker_ValidEnd.Value.Day;
                m_stuInfo.stuValidEndTime.dwHour = (uint)dateTimePicker_ValidEnd.Value.Hour;
                m_stuInfo.stuValidEndTime.dwMinute = (uint)dateTimePicker_ValidEnd.Value.Minute;
                m_stuInfo.stuValidEndTime.dwSecond = (uint)dateTimePicker_ValidEnd.Value.Second;
                m_stuInfo.bFirstEnter = this.checkBox_First.Checked;

                m_stuInfo.bEnableExtended = false;

                IntPtr inPtr = IntPtr.Zero;
                IntPtr ptr = IntPtr.Zero;
                try
                {
                    inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD)));
                    Marshal.StructureToPtr(m_stuInfo, inPtr, true);

                    stuInfo.pBuf = inPtr;
                    stuInfo.nBufLen = (int)Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD));

                    ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_PARAM)));
                    Marshal.StructureToPtr(stuInfo, ptr, true);
                    bool ret = NETClient.ControlDevice(loginID, EM_CtrlType.RECORDSET_UPDATE, ptr, 10000);
                    if (!ret)
                    {
                        MessageBox.Show(NETClient.GetLastError());
                        return;
                    }
                //    MessageBox.Show("Execute Success(操作成功)" );
                    stuInfo = (NET_CTRL_RECORDSET_PARAM)Marshal.PtrToStructure(ptr, typeof(NET_CTRL_RECORDSET_PARAM));
                    m_stuInfo = (NET_RECORDSET_ACCESS_CTL_CARD)Marshal.PtrToStructure(stuInfo.pBuf, typeof(NET_RECORDSET_ACCESS_CTL_CARD));
                    MessageBox.Show("Execute Success(操作成功)\n RecNo=" + m_stuInfo.nRecNo.ToString());
                }
                finally
                {
                    Marshal.FreeHGlobal(inPtr);
                    Marshal.FreeHGlobal(ptr);
                }
                OnChangeUIState(nCtlType);
                #endregion
            }
            else if (3 == nCtlType)
            {
                #region Remove record 移除卡记录 
                NET_CTRL_RECORDSET_PARAM stuInfo = new NET_CTRL_RECORDSET_PARAM();
                stuInfo.dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_PARAM));
                stuInfo.emType = EM_NET_RECORD_TYPE.ACCESSCTLCARD;
                try
                {
                    m_stuInfo.nRecNo = Convert.ToInt32(textBox_RecNo.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                

                IntPtr inPtr = IntPtr.Zero;
                IntPtr ptr = IntPtr.Zero;
                try
                {
                    inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)));
                    Marshal.StructureToPtr(m_stuInfo.nRecNo, inPtr, true);

                    stuInfo.pBuf = inPtr;
                    stuInfo.nBufLen = (int)Marshal.SizeOf(typeof(int));

                    ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_PARAM)));
                    Marshal.StructureToPtr(stuInfo, ptr, true);
                    bool ret = NETClient.ControlDevice(loginID, EM_CtrlType.RECORDSET_REMOVE, ptr, 10000);
                    if (!ret)
                    {
                        MessageBox.Show(NETClient.GetLastError());
                        return;
                    }
                    MessageBox.Show("Execute Success(操作成功)" );
                }
                finally
                {
                    Marshal.FreeHGlobal(inPtr);
                    Marshal.FreeHGlobal(ptr);
                }

                #endregion
            }
            else if (4 == nCtlType)
            {
                #region Clear card record 清除卡记录
                NET_CTRL_RECORDSET_PARAM inParam = new NET_CTRL_RECORDSET_PARAM();
                inParam.dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_PARAM));
                inParam.emType = EM_NET_RECORD_TYPE.ACCESSCTLCARD;
                IntPtr inPtr = IntPtr.Zero;
                try
                {
                    inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_PARAM)));
                    Marshal.StructureToPtr(inParam, inPtr, true);
                    bool ret = NETClient.ControlDevice(loginID, EM_CtrlType.RECORDSET_CLEAR, inPtr, 10000);
                    if (!ret)
                    {
                        MessageBox.Show(NETClient.GetLastError());
                        return;
                    }
                    MessageBox.Show("Execute Success(操作成功)");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Marshal.FreeHGlobal(inPtr);
                }
                #endregion
            }
            else if (5 == nCtlType)
            {
                #region Insert card record with finger 添加带指纹

                if (FingerPrintInfo == null && FingerPrintInfo2 == null || PacketLen == 0)
                {
                    if (m_IsCollection == false)
                    {
                        MessageBox.Show("Did not start collecting(没有开始采集)");
                    }
                    else if (m_IsCollectionFailed)
                    {
                        MessageBox.Show("No fingerprint data,because collection failed(没有指纹数据,因为采集失败)");
                    }
                    else if (m_IsListen)
                    {
                        MessageBox.Show("In the collection(采集中)");
                    }
                    else
                    {
                        MessageBox.Show("Unknow Error(未知错误)");
                    }
                    return;
                }

                NET_CTRL_RECORDSET_INSERT_PARAM stuInfo = new NET_CTRL_RECORDSET_INSERT_PARAM();
                stuInfo.dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_INSERT_PARAM));

                stuInfo.stuCtrlRecordSetInfo.dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_INSERT_IN));
                stuInfo.stuCtrlRecordSetInfo.emType = EM_NET_RECORD_TYPE.ACCESSCTLCARD;

                stuInfo.stuCtrlRecordSetInfo.nBufLen = (int)Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD));

                stuInfo.stuCtrlRecordSetResult.dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_INSERT_OUT));

                m_stuInfo.stuCreateTime.dwYear = (uint)DateTime.Now.Year;
                m_stuInfo.stuCreateTime.dwMonth = (uint)DateTime.Now.Month;
                m_stuInfo.stuCreateTime.dwDay = (uint)DateTime.Now.Day;
                m_stuInfo.stuCreateTime.dwHour = (uint)DateTime.Now.Hour;
                m_stuInfo.stuCreateTime.dwMinute = (uint)DateTime.Now.Minute;
                m_stuInfo.stuCreateTime.dwSecond = (uint)DateTime.Now.Second;

                m_stuInfo.szCardNo = this.textBox_CardNo.Text.Trim();
                m_stuInfo.szUserID = this.textBox_UserID.Text.Trim();
                m_stuInfo.szPsw = this.textBox_CardPwd.Text.Trim();
                try
                {
                    m_stuInfo.emStatus = (EM_ACCESSCTLCARD_STATE)comboBox_CardStatus.SelectedIndex - 1;
                    m_stuInfo.emType = (EM_ACCESSCTLCARD_TYPE)comboBox_CardType.SelectedIndex - 1;
                    m_stuInfo.nUseTime = Convert.ToInt32(textBox_UseTimes.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                m_stuInfo.bNewDoor = true;
                if (m_selectDoorsList.Count > 0)
                {
                    if (m_stuInfo.nNewDoors == null)
                    {
                        m_stuInfo.nNewDoors = new int[128];
                    }
                    for (int i = 0; i < m_selectDoorsList.Count; i++)
                    {
                        m_stuInfo.nNewDoors[i] = m_selectDoorsList[i];
                    }
                }
                m_stuInfo.nNewDoorNum = m_selectDoorsList.Count;

                if (m_selectTimesList.Count > 0)
                {
                    if (m_stuInfo.nNewTimeSectionNo == null)
                    {
                        m_stuInfo.nNewTimeSectionNo = new int[128];
                    }
                    for (int i = 0; i < m_selectTimesList.Count; i++)
                    {
                        m_stuInfo.nNewTimeSectionNo[i] = m_selectTimesList[i];
                    }
                }
                m_stuInfo.nNewTimeSectionNum = m_selectTimesList.Count;
                m_stuInfo.stuValidStartTime.dwYear = (uint)dateTimePicker_ValidStart.Value.Year;
                m_stuInfo.stuValidStartTime.dwMonth = (uint)dateTimePicker_ValidStart.Value.Month;
                m_stuInfo.stuValidStartTime.dwDay = (uint)dateTimePicker_ValidStart.Value.Day;
                m_stuInfo.stuValidStartTime.dwHour = (uint)dateTimePicker_ValidStart.Value.Hour;
                m_stuInfo.stuValidStartTime.dwMinute = (uint)dateTimePicker_ValidStart.Value.Minute;
                m_stuInfo.stuValidStartTime.dwSecond = (uint)dateTimePicker_ValidStart.Value.Second;

                m_stuInfo.stuValidEndTime.dwYear = (uint)dateTimePicker_ValidEnd.Value.Year;
                m_stuInfo.stuValidEndTime.dwMonth = (uint)dateTimePicker_ValidEnd.Value.Month;
                m_stuInfo.stuValidEndTime.dwDay = (uint)dateTimePicker_ValidEnd.Value.Day;
                m_stuInfo.stuValidEndTime.dwHour = (uint)dateTimePicker_ValidEnd.Value.Hour;
                m_stuInfo.stuValidEndTime.dwMinute = (uint)dateTimePicker_ValidEnd.Value.Minute;
                m_stuInfo.stuValidEndTime.dwSecond = (uint)dateTimePicker_ValidEnd.Value.Second;
                m_stuInfo.bFirstEnter = this.checkBox_First.Checked;

                m_stuInfo.bEnableExtended = true;

                m_stuInfo.stuFingerPrintInfoEx.nCount = 2;
                m_stuInfo.stuFingerPrintInfoEx.nLength = PacketLen;
                m_stuInfo.stuFingerPrintInfoEx.nPacketLen = m_stuInfo.stuFingerPrintInfoEx.nLength * m_stuInfo.stuFingerPrintInfoEx.nCount;
                m_stuInfo.stuFingerPrintInfoEx.pPacketData =  Marshal.AllocHGlobal(m_stuInfo.stuFingerPrintInfoEx.nPacketLen);

                IntPtr pDst = IntPtr.Zero;
                if (m_IsFinger1)
                {
                    pDst = IntPtr.Add(m_stuInfo.stuFingerPrintInfoEx.pPacketData, 0);
                    Marshal.Copy(FingerPrintInfo, 0, pDst, m_stuInfo.stuFingerPrintInfoEx.nLength);
                }
                if (m_IsFinger2)
                {
                    pDst = IntPtr.Add(m_stuInfo.stuFingerPrintInfoEx.pPacketData, m_stuInfo.stuFingerPrintInfoEx.nLength);
                    Marshal.Copy(FingerPrintInfo2, 0, pDst, m_stuInfo.stuFingerPrintInfoEx.nLength);
                }

                IntPtr inPtr = IntPtr.Zero;
                IntPtr ptr = IntPtr.Zero;
                try
                {
                    inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD)));
                    Marshal.StructureToPtr(m_stuInfo, inPtr, true);

                    stuInfo.stuCtrlRecordSetInfo.pBuf = inPtr;
                    stuInfo.stuCtrlRecordSetInfo.nBufLen = (int)Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD));
                    ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_INSERT_PARAM)));
                    Marshal.StructureToPtr(stuInfo, ptr, true);
                    bool ret = NETClient.ControlDevice(loginID, EM_CtrlType.RECORDSET_INSERTEX, ptr, 10000);
                    if (!ret)
                    {
                        MessageBox.Show(NETClient.GetLastError());
                        return;
                    }
                    stuInfo = (NET_CTRL_RECORDSET_INSERT_PARAM)Marshal.PtrToStructure(ptr, typeof(NET_CTRL_RECORDSET_INSERT_PARAM));
                    MessageBox.Show("Execute Success(操作成功)\n RecNo=" + stuInfo.stuCtrlRecordSetResult.nRecNo.ToString());
                    PacketLen = 0;
                    m_IsFinger1 = false;
                    m_IsFinger2 = false;
                    m_IsCollection = false;

                }
                finally
                {
                    Marshal.FreeHGlobal(m_stuInfo.stuFingerPrintInfoEx.pPacketData);
                    m_stuInfo.stuFingerPrintInfoEx.pPacketData = IntPtr.Zero;
                    Marshal.FreeHGlobal(inPtr);
                    Marshal.FreeHGlobal(ptr);
                }
                #endregion

            }
            else if (6 == nCtlType)
            {
                #region Update record with finger 更新带指纹
                NET_CTRL_RECORDSET_PARAM stuInfo = new NET_CTRL_RECORDSET_PARAM();
                stuInfo.dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_PARAM));
                stuInfo.emType = EM_NET_RECORD_TYPE.ACCESSCTLCARD;

                m_stuInfo.stuCreateTime.dwYear = (uint)DateTime.Now.Year;
                m_stuInfo.stuCreateTime.dwMonth = (uint)DateTime.Now.Month;
                m_stuInfo.stuCreateTime.dwDay = (uint)DateTime.Now.Day;
                m_stuInfo.stuCreateTime.dwHour = (uint)DateTime.Now.Hour;
                m_stuInfo.stuCreateTime.dwMinute = (uint)DateTime.Now.Minute;
                m_stuInfo.stuCreateTime.dwSecond = (uint)DateTime.Now.Second;

                m_stuInfo.szCardNo = this.textBox_CardNo.Text.Trim();
                m_stuInfo.szUserID = this.textBox_UserID.Text.Trim();

                m_stuInfo.szPsw = this.textBox_CardPwd.Text.Trim();

                try
                {
                    m_stuInfo.nRecNo = Convert.ToInt32(textBox_RecNo.Text.Trim());
                    m_stuInfo.emStatus = (EM_ACCESSCTLCARD_STATE)comboBox_CardStatus.SelectedIndex - 1;
                    m_stuInfo.emType = (EM_ACCESSCTLCARD_TYPE)comboBox_CardType.SelectedIndex - 1;
                    m_stuInfo.nUseTime = Convert.ToInt32(textBox_UseTimes.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                m_stuInfo.bNewDoor = true;
                if (m_selectDoorsList.Count > 0)
                {
                    if (m_stuInfo.nNewDoors == null)
                    {
                        m_stuInfo.nNewDoors = new int[128];
                    }
                    for (int i = 0; i < m_selectDoorsList.Count; i++)
                    {
                        m_stuInfo.nNewDoors[i] = m_selectDoorsList[i];
                    }
                }
                m_stuInfo.nNewDoorNum = m_selectDoorsList.Count;

                if (m_selectTimesList.Count > 0)
                {
                    if (m_stuInfo.nNewTimeSectionNo == null)
                    {
                        m_stuInfo.nNewTimeSectionNo = new int[128];
                    }
                    for (int i = 0; i < m_selectTimesList.Count; i++)
                    {
                        m_stuInfo.nNewTimeSectionNo[i] = m_selectTimesList[i];
                    }
                }
                m_stuInfo.nNewTimeSectionNum = m_selectTimesList.Count;
                m_stuInfo.stuValidStartTime.dwYear = (uint)dateTimePicker_ValidStart.Value.Year;
                m_stuInfo.stuValidStartTime.dwMonth = (uint)dateTimePicker_ValidStart.Value.Month;
                m_stuInfo.stuValidStartTime.dwDay = (uint)dateTimePicker_ValidStart.Value.Day;
                m_stuInfo.stuValidStartTime.dwHour = (uint)dateTimePicker_ValidStart.Value.Hour;
                m_stuInfo.stuValidStartTime.dwMinute = (uint)dateTimePicker_ValidStart.Value.Minute;
                m_stuInfo.stuValidStartTime.dwSecond = (uint)dateTimePicker_ValidStart.Value.Second;

                m_stuInfo.stuValidEndTime.dwYear = (uint)dateTimePicker_ValidEnd.Value.Year;
                m_stuInfo.stuValidEndTime.dwMonth = (uint)dateTimePicker_ValidEnd.Value.Month;
                m_stuInfo.stuValidEndTime.dwDay = (uint)dateTimePicker_ValidEnd.Value.Day;
                m_stuInfo.stuValidEndTime.dwHour = (uint)dateTimePicker_ValidEnd.Value.Hour;
                m_stuInfo.stuValidEndTime.dwMinute = (uint)dateTimePicker_ValidEnd.Value.Minute;
                m_stuInfo.stuValidEndTime.dwSecond = (uint)dateTimePicker_ValidEnd.Value.Second;
                m_stuInfo.bFirstEnter = this.checkBox_First.Checked;

                m_stuInfo.bEnableExtended = true;
                m_stuInfo.stuFingerPrintInfoEx.nCount = 2;


                IntPtr pDst = IntPtr.Zero;
                if (m_IsFinger1)
                {
                    m_stuInfo.stuFingerPrintInfoEx.nLength = PacketLen;
                    m_stuInfo.stuFingerPrintInfoEx.nPacketLen = m_stuInfo.stuFingerPrintInfoEx.nLength * m_stuInfo.stuFingerPrintInfoEx.nCount;
                    if (m_stuInfo.stuFingerPrintInfoEx.pPacketData == IntPtr.Zero)
                    {
                         m_stuInfo.stuFingerPrintInfoEx.pPacketData = Marshal.AllocHGlobal(m_stuInfo.stuFingerPrintInfoEx.nPacketLen);
                    }
                    pDst = IntPtr.Add(m_stuInfo.stuFingerPrintInfoEx.pPacketData, 0);
                    Marshal.Copy(FingerPrintInfo, 0, pDst, m_stuInfo.stuFingerPrintInfoEx.nLength);
                }
                if (m_IsFinger2)
                {
                    m_stuInfo.stuFingerPrintInfoEx.nLength = PacketLen;
                    m_stuInfo.stuFingerPrintInfoEx.nPacketLen = m_stuInfo.stuFingerPrintInfoEx.nLength * m_stuInfo.stuFingerPrintInfoEx.nCount;
                    if (m_stuInfo.stuFingerPrintInfoEx.pPacketData == IntPtr.Zero)
                    {
                        m_stuInfo.stuFingerPrintInfoEx.pPacketData = Marshal.AllocHGlobal(m_stuInfo.stuFingerPrintInfoEx.nPacketLen);
                    }
                    pDst = IntPtr.Add(m_stuInfo.stuFingerPrintInfoEx.pPacketData, m_stuInfo.stuFingerPrintInfoEx.nLength);
                    Marshal.Copy(FingerPrintInfo2, 0, pDst, m_stuInfo.stuFingerPrintInfoEx.nLength);
                }

                IntPtr inPtr = IntPtr.Zero;
                IntPtr ptr = IntPtr.Zero;
                try
                {
                    inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD)));
                    Marshal.StructureToPtr(m_stuInfo, inPtr, true);

                    stuInfo.pBuf = inPtr;
                    stuInfo.nBufLen = (int)Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD));

                    ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_PARAM)));
                    Marshal.StructureToPtr(stuInfo, ptr, true);
                    bool ret = NETClient.ControlDevice(loginID, EM_CtrlType.RECORDSET_UPDATEEX, ptr, 10000);
                    if (!ret)
                    {
                        MessageBox.Show(NETClient.GetLastError());
                        return;
                    }
                    stuInfo = (NET_CTRL_RECORDSET_PARAM)Marshal.PtrToStructure(ptr, typeof(NET_CTRL_RECORDSET_PARAM));
                    m_stuInfo = (NET_RECORDSET_ACCESS_CTL_CARD)Marshal.PtrToStructure(stuInfo.pBuf, typeof(NET_RECORDSET_ACCESS_CTL_CARD));
                    MessageBox.Show("Execute Success(操作成功)\n RecNo=" + m_stuInfo.nRecNo.ToString());
                }
                finally
                {
                    Marshal.FreeHGlobal(m_stuInfo.stuFingerPrintInfoEx.pPacketData);
                    m_stuInfo.stuFingerPrintInfoEx.pPacketData = IntPtr.Zero;
                    Marshal.FreeHGlobal(inPtr);
                    Marshal.FreeHGlobal(ptr);
                }
                OnChangeUIState(nCtlType);
                #endregion

            }

        }

        private void button_GetUpdate_Click(object sender, EventArgs e)
        {
            #region Get Card Info 获取卡记录

            int temp;
            if (!int.TryParse(textBox_RecNo.Text, out temp))
            {
                MessageBox.Show("Num is illegal(记录编号非法)！");
                return;
            }

            NET_CTRL_RECORDSET_PARAM inp = new NET_CTRL_RECORDSET_PARAM();
            inp.dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_RECORDSET_PARAM));
            inp.emType = EM_NET_RECORD_TYPE.ACCESSCTLCARD;

 //           NET_RECORDSET_ACCESS_CTL_CARD info = new NET_RECORDSET_ACCESS_CTL_CARD();
            m_stuInfo.dwSize = (uint)Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD));
            m_stuInfo.nRecNo = Convert.ToInt32(textBox_RecNo.Text.Trim());
            m_stuInfo.bEnableExtended = true;

            m_stuInfo.stuFingerPrintInfoEx = new NET_ACCESSCTLCARD_FINGERPRINT_PACKET_EX();
            m_stuInfo.stuFingerPrintInfoEx.nPacketLen = 2000;
            m_stuInfo.stuFingerPrintInfoEx.pPacketData = IntPtr.Zero;
            m_stuInfo.stuFingerPrintInfoEx.pPacketData = Marshal.AllocHGlobal(m_stuInfo.stuFingerPrintInfoEx.nPacketLen);

            IntPtr infoPtr = IntPtr.Zero;

            try
            {
                infoPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD)));
                Marshal.StructureToPtr(m_stuInfo, infoPtr, true);
                inp.pBuf = infoPtr;
                inp.nBufLen = Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARD));
                object objInp = inp;
                bool ret = NETClient.QueryDevState(loginID, (int)EM_DEVICE_STATE.DEV_RECORDSET_EX, ref objInp, typeof(NET_CTRL_RECORDSET_PARAM), 10000);
                if (!ret)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
                inp = (NET_CTRL_RECORDSET_PARAM)objInp;
                m_stuInfo = (NET_RECORDSET_ACCESS_CTL_CARD)Marshal.PtrToStructure(inp.pBuf, typeof(NET_RECORDSET_ACCESS_CTL_CARD));

                dateTimePicker_CreateTime.Value = m_stuInfo.stuCreateTime.ToDateTime();
                textBox_CardNo.Text = m_stuInfo.szCardNo;
                textBox_UserID.Text = m_stuInfo.szUserID;
                comboBox_CardStatus.SelectedIndex = (int)m_stuInfo.emStatus + 1;
                comboBox_CardType.SelectedIndex = (int)m_stuInfo.emType + 1;
                textBox_CardPwd.Text = m_stuInfo.szPsw;
                m_SelectTimeAry = m_stuInfo.nNewTimeSectionNo;
                textBox_UseTimes.Text = m_stuInfo.nUseTime.ToString();
                dateTimePicker_ValidStart.Value = m_stuInfo.stuValidStartTime.ToDateTime();
                dateTimePicker_ValidEnd.Value = m_stuInfo.stuValidEndTime.ToDateTime();

                m_selectDoorsList.Clear();
                for (int i = 0; i < m_stuInfo.nNewDoorNum; i++)
                {
                    m_selectDoorsList.Add(m_stuInfo.nNewDoors[i]);
                }

                m_selectTimesList.Clear();
                for (int i = 0; i < m_stuInfo.nNewTimeSectionNum; i++)
                {
                    m_selectTimesList.Add(m_stuInfo.nNewTimeSectionNo[i]);
                }

                checkBox_First.Checked = m_stuInfo.bFirstEnter;

                int nCtlType = comboBox_OperateType.SelectedIndex;

                if (2 == nCtlType)
                {
                    OnChangeUIState(7);
                }
                else
                {
                    OnChangeUIState(8);
                }

              //  MessageBox.Show("Query Success(获取成功)");
            }
            finally
            {
              //     Marshal.FreeHGlobal(infoPtr);
            }
            #endregion
        }

        private void button_GetPrint_Click(object sender, EventArgs e)
        {
            #region collect friger print 采集指纹
            m_IsListen = NETClient.StartListen(loginID);
            if (m_IsListen == false)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            m_IsCollection = true;
            m_IsCollectionFailed = false;
            int nFingerPrintNo = comboBox_FirPrint.SelectedIndex;
            if (comboBox_FirPrint.SelectedIndex == 0)
            {
                FingerPrintInfo = new byte[1];
                m_IsFinger1 = false;
            }
            if (comboBox_FirPrint.SelectedIndex == 1)
            {
                FingerPrintInfo2 = new byte[1];
                m_IsFinger2 = false;
            }
            NET_CTRL_CAPTURE_FINGER_PRINT capture = new NET_CTRL_CAPTURE_FINGER_PRINT();
            capture.dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_CAPTURE_FINGER_PRINT));
            capture.nChannelID = 0;
            capture.szReaderID = "1";
            IntPtr inPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_CTRL_CAPTURE_FINGER_PRINT)));
                Marshal.StructureToPtr(capture, inPtr, true);
                bool ret = NETClient.ControlDevice(loginID, EM_CtrlType.CAPTURE_FINGER_PRINT, inPtr, 60000);
                if (!ret)
                {
                    MessageBox.Show("Start collection failed(开始采集失败)");
                    return;
                }
                
                m_Timer.Start();
                this.label_result.Text = "Start Collection(开始采集)";
                this.button_GetPrint.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
            }

            #endregion
        }

        private void button_Door_Click(object sender, EventArgs e)
        {            
            List<int> doors = new List<int>();
            for (int i = 0; i < m_stuInfo.nNewDoorNum; i++)
            {
                doors.Add(m_stuInfo.nNewDoors[i]);
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

        protected override void OnClosed(EventArgs e)
        {
            m_MessCallBack = null;
            if (AccessControlForm.m_IsListen) 
            {
                NETClient.SetDVRMessCallBack(AccessControlForm.m_AlarmCallBack, IntPtr.Zero);
            }
            else
            {
                NETClient.SetDVRMessCallBack(null, IntPtr.Zero);
                if (m_IsListen)
                {
                    NETClient.StopListen(loginID);
                    m_IsListen = false;
                }
            }
            m_Timer.Stop();
            m_Timer.Dispose();
            base.OnClosed(e);
        }

        /*
        protected override void OnClosing(CancelEventArgs e)
        {
            if (IntPtr.Zero == result)
            {
                return;
            }
            try
            {
                bool ret = NETClient.StopUpgrade(result);
            }
            catch (Exception)
            {

            }

            base.OnClosing(e);
        }
        */
    }




}
