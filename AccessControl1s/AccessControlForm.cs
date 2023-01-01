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
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace AccessControl1s
{
    public partial class AccessControlForm : Form
    {
        private static readonly string titleName = "AccessControl";
        private IntPtr m_LoginID = IntPtr.Zero;

        private const string CFG_CMD_ACCESS_EVENT = "AccessControl";
        private const int ALARM_START = 0;
        private const int ALARM_STOP = 1;
        private int nChm = 0;

        public static bool m_IsListen = false;
        public static bool m_bOnline = false;
        private NET_DEVICEINFO_Ex m_DeviceInfo;
        private const int m_WaitTime = 5000;
        private static int Alarm_Index = 1;
        private const int ListViewCount = 100;

        private static fDisConnectCallBack m_DisConnectCallBack;
        private static fHaveReConnectCallBack m_ReConnectCallBack;
        public static fMessCallBackEx m_AlarmCallBack;

        public event Action<IntPtr, NET_ALARM_CAPTURE_FINGER_PRINT_INFO, byte[]> MessCallBackEx;
        private void OnMessageCallBackEx(IntPtr id, NET_ALARM_CAPTURE_FINGER_PRINT_INFO message, byte[] data)
        {
            if (MessCallBackEx != null)
            {
                MessCallBackEx(id, message, data);
            }
        }

        public AccessControlForm()
        {
            InitializeComponent();
        }

        private void AccessControl1s_Load(object sender, EventArgs e)
        {
            Text = titleName;
            m_DisConnectCallBack = new fDisConnectCallBack(DisConnectCallBack);
            m_ReConnectCallBack = new fHaveReConnectCallBack(ReConnectCallBack);
            m_AlarmCallBack = new fMessCallBackEx(AlarmCallBack);

            try
            {
                //初始化
                NETClient.Init(m_DisConnectCallBack, IntPtr.Zero, null);
                InitOrLogoutUI();
                //打开日志
                NET_LOG_SET_PRINT_INFO logInfo = new NET_LOG_SET_PRINT_INFO()
                {
                    dwSize = (uint)Marshal.SizeOf(typeof(NET_LOG_SET_PRINT_INFO))
                };
               // NETClient.LogOpen(logInfo);
                //设置断线重连回调
                NETClient.SetAutoReconnect(m_ReConnectCallBack, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Process.GetCurrentProcess().Kill();
            }
        }

        #region Update UI

        private void UpdateDisConnectUI()
        {
            this.Text = titleName + " -- Offline(离线)";
            m_bOnline = false;
            InitOrCloseOtherUI();
        }

        private void UpdateReConnectUI()
        {
            this.Text = titleName + " -- Online(在线)";
            m_bOnline = true;
            OpenOtherUI();
        }


        private void InitOrLogoutUI()
        {
            this.Text = titleName;
            btn_Login.Text = "Login(登录)";
            InitOrCloseOtherUI();
        }

        private void LoginUI()
        {
            this.Text = titleName + " -- Online(在线)";
            btn_Login.Text = "Logout(登出)";

            m_bOnline = true;


            #region Query Access control caps 获取门禁能力

            int nCount = 0;
            CFG_CAP_ACCESSCONTROL info = new CFG_CAP_ACCESSCONTROL();
            object obj = info;
            string strCommand = SDK_DEVCONFIG_CMD.NET_CFG_CAP_CMD_ACCESSCONTROLMANAGER;
            try
            {
                bool bQuery = NETClient.QueryNewSystemInfo(m_LoginID, -1, strCommand, ref obj, typeof(CFG_CAP_ACCESSCONTROL), 3000);
                if (bQuery)
                {
                    nCount = ((CFG_CAP_ACCESSCONTROL)obj).nAccessControlGroups;
                    nChm = nCount;
                }
            }
            catch (NETClientExcetion ex)
            {
                Console.WriteLine("GetAccessCount error:" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAccessCount error:" + ex.Message);
            }
            #endregion

            OpenOtherUI();

        }

        private void InitOrCloseOtherUI()
        {
           //其他控件操作初始化
            Channel_comboBox.Items.Clear();
            Channel_comboBox.Enabled = false;
            btn_OpenDoor.Enabled = false;
            btn_CloseDoor.Enabled = false;
            btn_OpenAlways.Enabled = false;
            btn_CloseAlways.Enabled = false;
            btn_GetDoorState.Enabled = false;
            MenuTool_DevInfo.Enabled = false;
            MenuTool_Net.Enabled = false;
            MenuTool_DevTime.Enabled = false;
            MenuTool_ModifyPwd.Enabled = false;
            MenuTool_Reboot.Enabled = false;
            MenuTool_Reset.Enabled = false;
            MenuTool_Upgrade.Enabled = false;
            MenuTool_AutoMatrix.Enabled = false;
            MenuTool_UserMgmt.Enabled = false;
            ManuTool_TimeSchedule.Enabled = false;
            MenuTool_DoorCfg.Enabled = false;
            MenuTool_OpenDoorGroup.Enabled = false;
            MenuTool_FirstEnter.Enabled = false;
            MenuTool_ABLock.Enabled = false;
            MenuTool_OpenDoorRte.Enabled = false;
            MenuTool_AccessPwd.Enabled = false;
            MenuTool_DoorRecord.Enabled = false;
            MenuTool_Log.Enabled = false;
            btn_StartListen.Enabled = false;
        }

        private void OpenOtherUI()
        {
            //其他控件操作使能
            Channel_comboBox.Items.Clear();
            if (nChm > 0)
            {
                for (int i = 0; i < nChm; i++)
                {
                    Channel_comboBox.Items.Add(i + 1);
                }
                Channel_comboBox.SelectedIndex = 0;
            }

            Channel_comboBox.Enabled = true;
            btn_OpenDoor.Enabled = true;
            btn_CloseDoor.Enabled = true;
            btn_OpenAlways.Enabled = true;
            btn_CloseAlways.Enabled = true;
            btn_GetDoorState.Enabled = true;
            MenuTool_DevInfo.Enabled = true;
            MenuTool_Net.Enabled = true;
            MenuTool_DevTime.Enabled = true;
            MenuTool_ModifyPwd.Enabled = true;
            MenuTool_Reboot.Enabled = true;
            MenuTool_Reset.Enabled = true;
            MenuTool_Upgrade.Enabled = true;
            MenuTool_AutoMatrix.Enabled = true;
            MenuTool_UserMgmt.Enabled = true;
            ManuTool_TimeSchedule.Enabled = true;
            MenuTool_DoorCfg.Enabled = true;
            MenuTool_OpenDoorGroup.Enabled = true;
            MenuTool_FirstEnter.Enabled = true;
            MenuTool_ABLock.Enabled = true;
            MenuTool_OpenDoorRte.Enabled = true;
            MenuTool_AccessPwd.Enabled = true;
            MenuTool_DoorRecord.Enabled = true;
            MenuTool_Log.Enabled = true;
            btn_StartListen.Enabled = true;
        }

        #endregion

        #region CallBack

        private void DisConnectCallBack(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            this.BeginInvoke((Action)UpdateDisConnectUI);
        }

        private void ReConnectCallBack(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            this.BeginInvoke((Action)UpdateReConnectUI);
        }

        private bool AlarmCallBack(int lCommand, IntPtr lLoginID, IntPtr pBuf, uint dwBufLen, IntPtr pchDVRIP, int nDVRPort, bool bAlarmAckFlag, int nEventID, IntPtr dwUser)
        {
            EM_ALARM_TYPE type = (EM_ALARM_TYPE)lCommand;
            var item = new ListViewItem();
            switch (type)
            {
                case EM_ALARM_TYPE.ALARM_ACCESS_CTL_EVENT:
                    NET_ALARM_ACCESS_CTL_EVENT_INFO access_info = (NET_ALARM_ACCESS_CTL_EVENT_INFO)Marshal.PtrToStructure(pBuf, typeof(NET_ALARM_ACCESS_CTL_EVENT_INFO));
                    item.Text = Alarm_Index.ToString();
                    item.SubItems.Add(access_info.stuTime.ToString());
                    item.SubItems.Add("Entry");
                    item.SubItems.Add(Encoding.Default.GetString(access_info.szUserID));
                    item.SubItems.Add(access_info.szCardNo.ToString());
                    item.SubItems.Add(access_info.nDoor.ToString());
                    switch (access_info.emOpenMethod)
                    {
                        case EM_ACCESS_DOOROPEN_METHOD.CARD:
                            item.SubItems.Add("Card");
                            break;
                        case EM_ACCESS_DOOROPEN_METHOD.FINGERPRINT:
                            item.SubItems.Add("Finger");
                            break;
                        case EM_ACCESS_DOOROPEN_METHOD.PWD_ONLY:
                            item.SubItems.Add("Password");
                            break;
                        case EM_ACCESS_DOOROPEN_METHOD.CARD_FIRST:
                            item.SubItems.Add("CardFirst");
                            break;
                        case EM_ACCESS_DOOROPEN_METHOD.PWD_FIRST:
                            item.SubItems.Add("PasswordFirst");
                            break;
                        case EM_ACCESS_DOOROPEN_METHOD.REMOTE:
                            item.SubItems.Add("REMOTE");
                            break;
                        case EM_ACCESS_DOOROPEN_METHOD.BUTTON:
                            item.SubItems.Add("BUTTON");
                            break;
                        case EM_ACCESS_DOOROPEN_METHOD.PWD_CARD_FINGERPRINT:
                            item.SubItems.Add("PWD_CARD_FINGERPRINT");
                            break;
                        case EM_ACCESS_DOOROPEN_METHOD.PWD_FINGERPRINT:
                            item.SubItems.Add("PWD_FINGERPRINT");
                            break;
                        case EM_ACCESS_DOOROPEN_METHOD.CARD_FINGERPRINT:
                            item.SubItems.Add("CARD_FINGERPRINT");
                            break;
                        case EM_ACCESS_DOOROPEN_METHOD.PERSONS:
                            item.SubItems.Add("Multi-people");
                            break;
                        case EM_ACCESS_DOOROPEN_METHOD.KEY:
                            item.SubItems.Add("KEY");
                            break;
                        case EM_ACCESS_DOOROPEN_METHOD.COERCE_PWD:
                            item.SubItems.Add("COERCE_PWD");
                            break;
                        case EM_ACCESS_DOOROPEN_METHOD.FACE_RECOGNITION:
                            item.SubItems.Add("Face recognition(人脸识别)");
                            break;
                        default:
                            item.SubItems.Add("Unknown");
                            break;
                    }
                    if (access_info.bStatus)
                    {
                        item.SubItems.Add("Success");
                    }
                    else
                    {
                        item.SubItems.Add("Failure");
                    }

                    this.BeginInvoke(new Action(() =>
                    {
                        listView_Event.BeginUpdate();
                        listView_Event.Items.Insert(0, item);
                        if (listView_Event.Items.Count > ListViewCount)
                        {
                            listView_Event.Items.RemoveAt(ListViewCount);
                        }
                        listView_Event.EndUpdate();
                    }));
                    Alarm_Index++;
                    break;
                case EM_ALARM_TYPE.ALARM_ACCESS_CTL_NOT_CLOSE:
                    NET_ALARM_ACCESS_CTL_NOT_CLOSE_INFO notclose_info = (NET_ALARM_ACCESS_CTL_NOT_CLOSE_INFO)Marshal.PtrToStructure(pBuf, typeof(NET_ALARM_ACCESS_CTL_NOT_CLOSE_INFO));
                    item.Text = Alarm_Index.ToString();
                    item.SubItems.Add(notclose_info.stuTime.ToString());
                    item.SubItems.Add("NotClose(门未关)");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add(notclose_info.nDoor.ToString());
                    item.SubItems.Add("");
                    if (notclose_info.nAction == ALARM_START)
                    {
                        item.SubItems.Add("Start(开始)");
                    }
                    else if (notclose_info.nAction == ALARM_STOP)
                    {
                        item.SubItems.Add("Stop(结束)");
                    }
                    else
                    {
                        item.SubItems.Add("");
                    }

                    this.BeginInvoke(new Action(() =>
                    {
                        listView_Event.BeginUpdate();
                        listView_Event.Items.Insert(0, item);
                        if (listView_Event.Items.Count > ListViewCount)
                        {
                            listView_Event.Items.RemoveAt(ListViewCount);
                        }
                        listView_Event.EndUpdate();
                    }));
                    Alarm_Index++;
                    break;
                case EM_ALARM_TYPE.ALARM_ACCESS_CTL_BREAK_IN:
                    NET_ALARM_ACCESS_CTL_BREAK_IN_INFO breakin_info = (NET_ALARM_ACCESS_CTL_BREAK_IN_INFO)Marshal.PtrToStructure(pBuf, typeof(NET_ALARM_ACCESS_CTL_BREAK_IN_INFO));
                    item.Text = Alarm_Index.ToString();
                    item.SubItems.Add(breakin_info.stuTime.ToString());
                    item.SubItems.Add("BreakIn(闯入)");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add(breakin_info.nDoor.ToString());
                    item.SubItems.Add("");
                    item.SubItems.Add("");

                    this.BeginInvoke(new Action(() =>
                    {
                        listView_Event.BeginUpdate();
                        listView_Event.Items.Insert(0, item);
                        if (listView_Event.Items.Count > ListViewCount)
                        {
                            listView_Event.Items.RemoveAt(ListViewCount);
                        }
                        listView_Event.EndUpdate();
                    }));
                    Alarm_Index++;
                    break;
                case EM_ALARM_TYPE.ALARM_ACCESS_CTL_REPEAT_ENTER:
                    NET_ALARM_ACCESS_CTL_REPEAT_ENTER_INFO repeat_info = (NET_ALARM_ACCESS_CTL_REPEAT_ENTER_INFO)Marshal.PtrToStructure(pBuf, typeof(NET_ALARM_ACCESS_CTL_REPEAT_ENTER_INFO));
                    item.Text = Alarm_Index.ToString();
                    item.SubItems.Add(repeat_info.stuTime.ToString());
                    item.SubItems.Add("RepeakIn(反潜)");
                    item.SubItems.Add("");
                    item.SubItems.Add(repeat_info.szCardNo.ToString());
                    item.SubItems.Add(repeat_info.nDoor.ToString());
                    item.SubItems.Add("");
                    item.SubItems.Add("");

                    this.BeginInvoke(new Action(() =>
                    {
                        listView_Event.BeginUpdate();
                        listView_Event.Items.Insert(0, item);
                        if (listView_Event.Items.Count > ListViewCount)
                        {
                            listView_Event.Items.RemoveAt(ListViewCount);
                        }
                        listView_Event.EndUpdate();
                    }));
                    Alarm_Index++;
                    break;
                case EM_ALARM_TYPE.ALARM_ACCESS_CTL_DURESS:
                    NET_ALARM_ACCESS_CTL_DURESS_INFO duress_info = (NET_ALARM_ACCESS_CTL_DURESS_INFO)Marshal.PtrToStructure(pBuf, typeof(NET_ALARM_ACCESS_CTL_DURESS_INFO));
                    item.Text = Alarm_Index.ToString();
                    item.SubItems.Add(duress_info.stuTime.ToString());
                    item.SubItems.Add("Duress(胁迫)");
                    item.SubItems.Add(duress_info.szUserID.ToString());
                    item.SubItems.Add(duress_info.szCardNo.ToString());
                    item.SubItems.Add(duress_info.nDoor.ToString());
                    item.SubItems.Add("");
                    item.SubItems.Add("");

                    this.BeginInvoke(new Action(() =>
                    {
                        listView_Event.BeginUpdate();
                        listView_Event.Items.Insert(0, item);
                        if (listView_Event.Items.Count > ListViewCount)
                        {
                            listView_Event.Items.RemoveAt(ListViewCount);
                        }
                        listView_Event.EndUpdate();
                    }));
                    Alarm_Index++;
                    break;
                case EM_ALARM_TYPE.ALARM_CHASSISINTRUDED:
                    NET_ALARM_CHASSISINTRUDED_INFO chassisintruded_info = (NET_ALARM_CHASSISINTRUDED_INFO)Marshal.PtrToStructure(pBuf, typeof(NET_ALARM_CHASSISINTRUDED_INFO));
                    item.Text = Alarm_Index.ToString();
                    item.SubItems.Add(chassisintruded_info.stuTime.ToString());
                    if (chassisintruded_info.szReaderID.Length > 0)
                    {
                        item.SubItems.Add("CardreaderAntidemolition(读卡器防拆)");
                    }
                    else
                    {
                        item.SubItems.Add("ChassisIntruded(本机防拆)");
                    }
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add(chassisintruded_info.nChannelID.ToString());
                    item.SubItems.Add("");
                    if (chassisintruded_info.nAction == ALARM_START)
                    {
                        item.SubItems.Add("Start(开始)");
                    }
                    else if (chassisintruded_info.nAction == ALARM_STOP)
                    {
                        item.SubItems.Add("Stop(结束)");
                    }
                    else
                    {
                        item.SubItems.Add("");
                    }

                    this.BeginInvoke(new Action(() =>
                    {
                        listView_Event.BeginUpdate();
                        listView_Event.Items.Insert(0, item);
                        if (listView_Event.Items.Count > ListViewCount)
                        {
                            listView_Event.Items.RemoveAt(ListViewCount);
                        }
                        listView_Event.EndUpdate();
                    }));
                    Alarm_Index++;
                    break;
                case EM_ALARM_TYPE.ALARM_ALARM_EX2:
                    NET_ALARM_ALARM_INFO_EX2 alarm_info = (NET_ALARM_ALARM_INFO_EX2)Marshal.PtrToStructure(pBuf, typeof(NET_ALARM_ALARM_INFO_EX2));
                    item.Text = Alarm_Index.ToString();
                    item.SubItems.Add(alarm_info.stuTime.ToString());
                    item.SubItems.Add("AlarmEx2(外部报警)");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add(alarm_info.nChannelID.ToString());
                    item.SubItems.Add("");
                    if (alarm_info.nAction == ALARM_START)
                    {
                        item.SubItems.Add("Start(开始)");
                    }
                    else if (alarm_info.nAction == ALARM_STOP)
                    {
                        item.SubItems.Add("Stop(结束)");
                    }
                    else
                    {
                        item.SubItems.Add("");
                    }

                    this.BeginInvoke(new Action(() =>
                    {
                        listView_Event.BeginUpdate();
                        listView_Event.Items.Insert(0, item);
                        if (listView_Event.Items.Count > ListViewCount)
                        {
                            listView_Event.Items.RemoveAt(ListViewCount);
                        }
                        listView_Event.EndUpdate();
                    }));
                    Alarm_Index++;
                    break;
                default:
                    break;
            }

            return true;
        }

        #endregion

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_LoginID)
            {
                ushort port = 0;
                try
                {
                    port = Convert.ToUInt16(port_textBox.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Input port error(输入端口错误)");
                    return;
                }
                m_DeviceInfo = new NET_DEVICEINFO_Ex();

                m_LoginID = NETClient.LoginWithHighLevelSecurity(ip_textBox.Text.Trim(), port, user_textBox.Text.Trim(), pwd_textBox.Text.Trim(), EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref m_DeviceInfo);
                if (IntPtr.Zero == m_LoginID)
                {
                    MessageBox.Show(this, NETClient.GetLastError());    
                    return;
                }
                LoginUI();
            }
            else
            {
                if (m_IsListen)
                {
                    bool ret = NETClient.StopListen(m_LoginID);
                    if (!ret)
                    {
                        MessageBox.Show(this, NETClient.GetLastError());
                    }
                    Alarm_Index = 1;
                    m_IsListen = false;

                    listView_Event.Items.Clear();
                    btn_StartListen.Text = "StartListen(开启订阅)";
                }
                if (IntPtr.Zero != m_LoginID)
                {
                    bool result = NETClient.Logout(m_LoginID);
                    if (!result)
                    {
                        MessageBox.Show(this, NETClient.GetLastError());
                    }
                }

                m_LoginID = IntPtr.Zero;
                InitOrLogoutUI();
            }
        }

        private void Channel_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_OpenDoor_Click(object sender, EventArgs e)
        {
            #region Open door 门禁控制-开门
            GetConfig();
            if (cfg.emState != EM_CFG_ACCESS_STATE.NORMAL)
            {
                cfg.emState = EM_CFG_ACCESS_STATE.NORMAL;
                SetConfig(cfg);
            }
            NET_CTRL_ACCESS_OPEN openInfo = new NET_CTRL_ACCESS_OPEN();
            openInfo.dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_ACCESS_OPEN));
            openInfo.nChannelID = Channel_comboBox.SelectedIndex;
            openInfo.szTargetID = IntPtr.Zero;
  //          openInfo.emOpenDoorType = EM_OPEN_DOOR_TYPE.REMOTE;
            IntPtr inPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_CTRL_ACCESS_OPEN)));
                Marshal.StructureToPtr(openInfo, inPtr, true);
                bool ret = NETClient.ControlDevice(m_LoginID, EM_CtrlType.ACCESS_OPEN, inPtr, 10000);
                if (!ret)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
            }
            MessageBox.Show("Open Door success(开门成功)");
            #endregion
        }

        NET_CFG_ACCESS_EVENT_INFO cfg = new NET_CFG_ACCESS_EVENT_INFO();
        public NET_CFG_ACCESS_EVENT_INFO GetConfig()
        {
            try
            {
                object objTemp = new object();
                bool bRet = NETClient.GetNewDevConfig(m_LoginID, Channel_comboBox.SelectedIndex, "AccessControl", ref objTemp, typeof(NET_CFG_ACCESS_EVENT_INFO), 5000);
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
                bRet = NETClient.SetNewDevConfig(m_LoginID, Channel_comboBox.SelectedIndex, "AccessControl", (object)cfg, typeof(NET_CFG_ACCESS_EVENT_INFO), 5000);
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

        private void btn_CloseDoor_Click(object sender, EventArgs e)
        {
            #region Close door 门禁控制-关门

            GetConfig();
            if (cfg.emState != EM_CFG_ACCESS_STATE.NORMAL)
            {
                cfg.emState = EM_CFG_ACCESS_STATE.NORMAL;
                SetConfig(cfg);
            }
            NET_CTRL_ACCESS_CLOSE closeInfo = new NET_CTRL_ACCESS_CLOSE();
            closeInfo.dwSize = (uint)Marshal.SizeOf(typeof(NET_CTRL_ACCESS_CLOSE));
            closeInfo.nChannelID = Channel_comboBox.SelectedIndex;
            IntPtr inPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_CTRL_ACCESS_CLOSE)));
                Marshal.StructureToPtr(closeInfo, inPtr, true);
                bool ret = NETClient.ControlDevice(m_LoginID, EM_CtrlType.ACCESS_CLOSE, inPtr, 10000);
                if (!ret)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
            }
            MessageBox.Show("Close door success(关门成功)");

            #endregion


        }

        private void btn_OpenAlways_Click(object sender, EventArgs e)
        {
            #region Open always 门禁配置-常开

            GetConfig();
            cfg.emState = EM_CFG_ACCESS_STATE.OPENALWAYS;
            bool bRet = SetConfig(cfg);
            if (!bRet)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            MessageBox.Show("Always open success(常开成功)");

            #endregion
        }

        private void btn_CloseAlways_Click(object sender, EventArgs e)
        {
            #region Close always 门禁配置-常闭

            GetConfig();
            cfg.emState = EM_CFG_ACCESS_STATE.CLOSEALWAYS;
            bool bRet = SetConfig(cfg);
            if (!bRet)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            MessageBox.Show("Always close success(常闭成功)");

            #endregion
        }

        private void btn_GetDoorState_Click(object sender, EventArgs e)
        {
            #region Query door state 查询门磁状态
            NET_DOOR_STATUS_INFO info = new NET_DOOR_STATUS_INFO();
            info.dwSize = (uint)Marshal.SizeOf(typeof(NET_DOOR_STATUS_INFO));
            info.nChannel = Channel_comboBox.SelectedIndex;
            object objInfo = info;
            bool ret = NETClient.QueryDevState(m_LoginID, EM_DEVICE_STATE.DOOR_STATE, ref objInfo, typeof(NET_DOOR_STATUS_INFO), 10000);
            if (!ret)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            info = (NET_DOOR_STATUS_INFO)objInfo;
            
            switch (info.emStateType)
            {
                case EM_NET_DOOR_STATUS_TYPE.BREAK:
                    MessageBox.Show("Door abnormal unlock(门异常打开)");
                    break;
                case EM_NET_DOOR_STATUS_TYPE.CLOSE:
                    MessageBox.Show("Door closed(门关闭)");
                    break;
                case EM_NET_DOOR_STATUS_TYPE.OPEN:
                    MessageBox.Show("Door opened(门打开)");
                    break;
                case EM_NET_DOOR_STATUS_TYPE.UNKNOWN:
                    MessageBox.Show("Unknown");
                    break;
                default:
                    break;
            }
            #endregion
        }

        private void MenuTool_DevInfo_Click(object sender, EventArgs e)
        {
            DeviceInfo cm = new DeviceInfo(m_LoginID, this);
            cm.ShowDialog();
            cm.Dispose();

        }

        private void MenuTool_Net_Click(object sender, EventArgs e)
        {
            Network cm = new Network(m_LoginID, this);
            cm.ShowDialog();
            cm.Dispose();
        }

        private void MenuTool_DevTime_Click(object sender, EventArgs e)
        {
            DeviceTime cm = new DeviceTime(m_LoginID, this);
            cm.ShowDialog();
            cm.Dispose();
        }

        private void MenuTool_ModifyPwd_Click(object sender, EventArgs e)
        {
            ModifyPwd cm = new ModifyPwd(m_LoginID, this);
            cm.ShowDialog();
            cm.Dispose();
        }

        private void btn_StartListen_Click(object sender, EventArgs e)
        {
            if (!m_IsListen)
            {
                //设置报警回调
                NETClient.SetDVRMessCallBack(m_AlarmCallBack, IntPtr.Zero);
                bool ret = NETClient.StartListen(m_LoginID);
                if (!ret)
                {
                    MessageBox.Show(this, NETClient.GetLastError());
                    return;
                }
                m_IsListen = true;
                Alarm_Index = 1;
                btn_StartListen.Text = "StopListen(停止订阅)";
            }
            else
            {
                bool ret = NETClient.StopListen(m_LoginID);
                if (!ret)
                {
                    MessageBox.Show(this, NETClient.GetLastError());
                    return;
                }
                Alarm_Index = 1;
                m_IsListen = false;
                listView_Event.Items.Clear();
                btn_StartListen.Text = "StartListen(开启订阅)";
            }
        }

        private void MenuTool_Reboot_Click(object sender, EventArgs e)
        {
            Reboot cm = new Reboot(m_LoginID, this);
            cm.ShowDialog();
            cm.Dispose();
        }

        private void MenuTool_Reset_Click(object sender, EventArgs e)
        {
            Reset cm = new Reset(m_LoginID, this);
            cm.ShowDialog();
            cm.Dispose();
        }

        private void MenuTool_AutoMatrix_Click(object sender, EventArgs e)
        {
            AutoMatrix cm = new AutoMatrix(m_LoginID, this);
            cm.ShowDialog();
            cm.Dispose();
        }

        private void MenuTool_Upgrade_Click(object sender, EventArgs e)
        {
            Upgrade cm = new Upgrade(m_LoginID, this);
            cm.ShowDialog();
            cm.Dispose();
        }

        private void MenuTool_UserMgmt_Click(object sender, EventArgs e)
        {
            UserManagement cm = new UserManagement(m_LoginID, nChm, this);
            cm.ShowDialog();
            cm.Dispose();
        }

        private void ManuTool_TimeSchedule_Click(object sender, EventArgs e)
        {
            TimeSchedule cm = new TimeSchedule(m_LoginID, nChm, this);
            cm.ShowDialog();
            cm.Dispose();
        }

        private void MenuTool_DoorCfg_Click(object sender, EventArgs e)
        {
            DoorConfig cm = new DoorConfig(m_LoginID, nChm, this);
            cm.ShowDialog();
            cm.Dispose();
        }

        private void MenuTool_OpenDoorGroup_Click(object sender, EventArgs e)
        {
            OpenDoorGroup cm = new OpenDoorGroup(m_LoginID, nChm, this);
            cm.ShowDialog();
            cm.Dispose();
        }

        private void MenuTool_DoorRecord_Click(object sender, EventArgs e)
        {
            DoorRecord cm = new DoorRecord(m_LoginID, this);
            cm.ShowDialog();
            cm.Dispose();
        }

        private void MenuTool_Log_Click(object sender, EventArgs e)
        {
            Log cm = new Log(m_LoginID, this);
            cm.ShowDialog();
            cm.Dispose();
        }

        private void MenuTool_FirstEnter_Click(object sender, EventArgs e)
        {
            FirstEnter cm = new FirstEnter(m_LoginID, nChm, this);
            cm.ShowDialog();
            cm.Dispose();
        }

        private void MenuTool_ABLock_Click(object sender, EventArgs e)
        {
            ABLock cm = new ABLock(m_LoginID, this);
            cm.ShowDialog();
            cm.Dispose();
        }

        private void MenuTool_OpenDoorRte_Click(object sender, EventArgs e)
        {
            OpenDoorRoute cm = new OpenDoorRoute(m_LoginID, nChm, this);
            cm.ShowDialog();
            cm.Dispose();
        }

        private void MenuTool_AccessPwd_Click(object sender, EventArgs e)
        {
            AccessPwd cm = new AccessPwd(m_LoginID, nChm, this);
            cm.ShowDialog();
            cm.Dispose();
        }
    }
}
