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
using IO.Swagger.Api;
using IO.Swagger.Model;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Threading;
using System.Security.Cryptography;
using Gma.System.MouseKeyHook;

namespace AccessControl1s
{
    public partial class AccessControlForm : Form
    {
        private const string CARD_MASTER = "CB04F5AA";
        private const int GUEST_HOURS = 24;
        private readonly List<Tuple<string, DateTime>> guestList = new List<Tuple<string, DateTime>>();

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

        #region Video
        VideoCapture capture;
        Mat frame;
        byte[] image;
        #endregion

        #region Camera
        char cforKeyDown = '\0';
        int _lastKeystroke = DateTime.Now.Millisecond;
        List<char> _barcode = new List<char>(1);
        bool UseKeyboard = false;
        #endregion

        private IKeyboardMouseEvents m_GlobalHook;

        private const string BASE_URL = "http://192.168.1.200:5000/";
        public AccessControlForm()
        {
            InitializeComponent();

            //textBox1.KeyDown += new KeyEventHandler(BarcodeReader_KeyDown);
            //textBox1.KeyUp += new KeyEventHandler(BarcodeReader_KeyUp);

            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyPress += GlobalHookKeyPress;
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            /* check if keydown and keyup is not different
             * and keydown event is not fired again before the keyup event fired for the same key
             * and keydown is not null
             * Barcode never fired keydown event more than 1 time before the same key fired keyup event
             * Barcode generally finishes all events (like keydown > keypress > keyup) of single key at a time, if two different keys are pressed then it is with keyboard
             */
            //if (e.KeyChar == '\0')
            //{
            //    _barcode.Clear();
            //    return;
            //}

            // getting the time difference between 2 keys
            int elapsed = (DateTime.Now.Millisecond - _lastKeystroke);
            Console.WriteLine("KeyPress: \t{0} {1}", e.KeyChar, elapsed);

            /*
             * Barcode scanner usually takes less than 17 milliseconds to read, increase this if neccessary of your barcode scanner is slower
             * also assuming human can not type faster than 17 milliseconds
             */
            if (elapsed > 17)
                _barcode.Clear();


            // Do not push in array if Enter/Return is pressed, since it is not any Character that need to be read
            if (e.KeyChar != (char)Keys.Return)
            {
                _barcode.Add(e.KeyChar);
            }

            if (_barcode.Count == 8)
            {
                string BarCodeData = new String(_barcode.ToArray());
                SendTid(BarCodeData);
                _barcode.Clear();
            }

            // update the last key press strock time
            _lastKeystroke = DateTime.Now.Millisecond;
        }

        private void SendTid(string tid)
        {
            Thread.Sleep(2000);
            HistoryApi api = new HistoryApi(BASE_URL);
            frame = new Mat();
            capture = new VideoCapture(0);
            capture.Open(0);
            if (capture.IsOpened())
            {
                capture.Read(frame);
                ImageConverter converter = new ImageConverter();
                var bitmap = BitmapConverter.ToBitmap(frame);
                image = (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
            }

            frame = null;
            textBox1.Text = "";
            capture.Dispose();
        }

        private void BarcodeReader_KeyUp(object sender, KeyEventArgs e)
        {
            /* check if keydown and keyup is not different
             * and keydown event is not fired again before the keyup event fired for the same key
             * and keydown is not null
             * Barcode never fired keydown event more than 1 time before the same key fired keyup event
             * Barcode generally finishes all events (like keydown > keypress > keyup) of single key at a time, if two different keys are pressed then it is with keyboard
             */
            if ((cforKeyDown != (char)e.KeyCode) || (cforKeyDown == '\0'))
            {
                cforKeyDown = '\0';
                _barcode.Clear();
                return;
            }

            // getting the time difference between 2 keys
            int elapsed = (DateTime.Now.Millisecond - _lastKeystroke);

            /*
             * Barcode scanner usually takes less than 17 milliseconds to read, increase this if neccessary of your barcode scanner is slower
             * also assuming human can not type faster than 17 milliseconds
             */
            if (elapsed > 17)
                _barcode.Clear();

            // Do not push in array if Enter/Return is pressed, since it is not any Character that need to be read
            if (e.KeyCode != Keys.Return)
            {
                _barcode.Add((char)e.KeyData);
            }

            // Barcode scanner hits Enter/Return after reading barcode
            if (e.KeyCode == Keys.Return && _barcode.Count > 0)
            {
                string BarCodeData = new String(_barcode.ToArray());
                if (!UseKeyboard)
                    SendTid(BarCodeData);
                _barcode.Clear();
            }

            // update the last key press strock time
            _lastKeystroke = DateTime.Now.Millisecond;
        }

        private void BarcodeReader_KeyDown(object sender, KeyEventArgs e)
        {
            cforKeyDown = (char)e.KeyCode;
        }

        private void AccessControl1s_Load(object sender, EventArgs e)
        {
            Text = titleName;
            m_DisConnectCallBack = new fDisConnectCallBack(DisConnectCallBack);
            m_ReConnectCallBack = new fHaveReConnectCallBack(ReConnectCallBack);
            m_AlarmCallBack = new fMessCallBackEx(AlarmCallBack);

            try
            {
                NETClient.Init(m_DisConnectCallBack, IntPtr.Zero, null);
                InitOrLogoutUI();
                NET_LOG_SET_PRINT_INFO logInfo = new NET_LOG_SET_PRINT_INFO()
                {
                    dwSize = (uint)Marshal.SizeOf(typeof(NET_LOG_SET_PRINT_INFO))
                };
                //NETClient.LogOpen(logInfo);
                NETClient.SetAutoReconnect(m_ReConnectCallBack, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Process.GetCurrentProcess().Kill();
            }

            btn_Login_Click(sender, e);
        }

        #region Update UI

        private void UpdateDisConnectUI()
        {
            this.Text = titleName + " -- Offline";
            m_bOnline = false;
            InitOrCloseOtherUI();

            if (m_IsListen)
            {
                BackColor = Color.LightCoral;
                bool ret = NETClient.StopListen(m_LoginID);
                if (!ret)
                {
                    MessageBox.Show(this, NETClient.GetLastError());
                    return;
                }
                Alarm_Index = 1;
                m_IsListen = false;
                listView_Event.Items.Clear();
                btn_StartListen.Text = "StartListen";
            }
        }

        private void UpdateReConnectUI()
        {
            this.Text = titleName + " -- Online";
            m_bOnline = true;
            OpenOtherUI();

            if (m_IsListen)
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
                btn_StartListen.Text = "StartListen";
                BackColor = Color.LightCoral;
            }

            if (!m_IsListen)
            {
                NETClient.SetDVRMessCallBack(m_AlarmCallBack, IntPtr.Zero);
                bool ret = NETClient.StartListen(m_LoginID);
                if (!ret)
                {
                    MessageBox.Show(this, NETClient.GetLastError());
                    return;
                }
                m_IsListen = true;
                Alarm_Index = 1;
                btn_StartListen.Text = "StopListen";
                BackColor = SystemColors.Control;
            }
        }


        private void InitOrLogoutUI()
        {
            this.Text = titleName;
            btn_Login.Text = "Login";
            BackColor = Color.LightCoral;
            InitOrCloseOtherUI();
        }

        private void LoginUI()
        {
            this.Text = titleName + " -- Online";
            btn_Login.Text = "Logout";
            BackColor = SystemColors.Control;

            m_bOnline = true;


            #region Query Access control caps

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

        private static bool _running;
        private bool AlarmCallBack(int lCommand, IntPtr lLoginID, IntPtr pBuf, uint dwBufLen, IntPtr pchDVRIP, int nDVRPort, bool bAlarmAckFlag, int nEventID, IntPtr dwUser)
        {
            if (_running)
                return true;
            _running = true;

            EM_ALARM_TYPE type = (EM_ALARM_TYPE)lCommand;
            var item = new ListViewItem();
            switch (type)
            {
                case EM_ALARM_TYPE.ALARM_ACCESS_CTL_EVENT:
                    NET_ALARM_ACCESS_CTL_EVENT_INFO access_info = (NET_ALARM_ACCESS_CTL_EVENT_INFO)Marshal.PtrToStructure(pBuf, typeof(NET_ALARM_ACCESS_CTL_EVENT_INFO));
                    item.Text = Alarm_Index.ToString();
                    item.SubItems.Add(access_info.stuTime.ToString());
                    if (access_info.nDoor.ToString() == "1")
                        item.SubItems.Add("Entry");
                    else item.SubItems.Add("Exit");
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

                    this.BeginInvoke(new Action(() =>
                    {
                        SendActivityToAPI(item);
                    }));

                    Alarm_Index++;
                    break;
                case EM_ALARM_TYPE.ALARM_ACCESS_CTL_NOT_CLOSE:
                    NET_ALARM_ACCESS_CTL_NOT_CLOSE_INFO notclose_info = (NET_ALARM_ACCESS_CTL_NOT_CLOSE_INFO)Marshal.PtrToStructure(pBuf, typeof(NET_ALARM_ACCESS_CTL_NOT_CLOSE_INFO));
                    item.Text = Alarm_Index.ToString();
                    item.SubItems.Add(notclose_info.stuTime.ToString());
                    item.SubItems.Add("NotClose");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add(notclose_info.nDoor.ToString());
                    item.SubItems.Add("");
                    if (notclose_info.nAction == ALARM_START)
                    {
                        item.SubItems.Add("Start");
                    }
                    else if (notclose_info.nAction == ALARM_STOP)
                    {
                        item.SubItems.Add("Stop");
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
                    item.SubItems.Add("BreakIn");
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
                    item.SubItems.Add("RepeakIn");
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
                    item.SubItems.Add("Duress");
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
                        item.SubItems.Add("CardreaderAntidemolition");
                    }
                    else
                    {
                        item.SubItems.Add("ChassisIntruded");
                    }
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add(chassisintruded_info.nChannelID.ToString());
                    item.SubItems.Add("");
                    if (chassisintruded_info.nAction == ALARM_START)
                    {
                        item.SubItems.Add("Start");
                    }
                    else if (chassisintruded_info.nAction == ALARM_STOP)
                    {
                        item.SubItems.Add("Stop");
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
                    item.SubItems.Add("AlarmEx2");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add(alarm_info.nChannelID.ToString());
                    item.SubItems.Add("");
                    if (alarm_info.nAction == ALARM_START)
                    {
                        item.SubItems.Add("Start");
                    }
                    else if (alarm_info.nAction == ALARM_STOP)
                    {
                        item.SubItems.Add("Stop");
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

            _running = false;
            return true;
        }

        private async void SendActivityToAPI(ListViewItem item)
        {
            var time = item.SubItems[1];
            var type = item.SubItems[2];
            var person = item.SubItems[3];
            var card = item.SubItems[4];
            var door = item.SubItems[5];
            var opentype = item.SubItems[6];
            var state = item.SubItems[7];

            HistoryApi api = new HistoryApi(BASE_URL);

            // open portal if guest
            if (state.Text.ToLower() != "success" && type.Text == "Entry" && image != null)
            {
                guestList.Insert(0, new Tuple<string, DateTime>(card.Text, DateTime.Now));
                if (guestList.Count > 100)
                {
                    guestList.RemoveAt(100);
                }

                try
                {
                    await api.ApiHistoryPostAsync(new HistoryRequest("Entry", card.Text, true, "success", image));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SendActivity.Guest.Entry : " + ex.Message);
                }

                Channel_comboBox.SelectedIndex = 1;
                btn_OpenDoor_Click(null, null);
                image = null;
            }
            // open portal if guest
            else if (state.Text.ToLower() != "success" && type.Text == "Exit")
            {
                Tuple<string, DateTime> guestSelected = null;
                foreach (var guest in guestList)
                {
                    if (guest.Item1 == card.Text && guest.Item2.AddHours(GUEST_HOURS) > DateTime.Now)
                    {
                        guestSelected = guest;

                        Channel_comboBox.SelectedIndex = 0;
                        btn_OpenDoor_Click(null, null);

                        try
                        {
                            await api.ApiHistoryPostAsync(new HistoryRequest(type.Text, card.Text, true, "success"));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("SendActivity.Guest.Exit : " + ex.Message);
                        }

                        break;
                    }
                    else if (guest.Item1 == card.Text && guest.Item2.AddHours(GUEST_HOURS) < DateTime.Now)
                    { 
                        guestSelected = guest;
                    }
                }

                if (guestSelected != null)
                {
                    guestList.RemoveAll(x => x.Item1 == guestSelected.Item1);
                }
            }
            else if (card.Text != "00000000" && state.Text.ToLower() == "success")
            {
                try
                {
                    await api.ApiHistoryPostAsync(new HistoryRequest(type.Text, card.Text, false, "success"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SendActivity.Success : " + ex.Message);
                }
            }
        }

        private void OpenPortalGuest(ListViewItem item)
        {
            var time = item.SubItems[0];
            var type = item.SubItems[1];
            var person = item.SubItems[2];
            var card = item.SubItems[3];
            var door = item.SubItems[4];
            var opentype = item.SubItems[5];
            var state = item.SubItems[6];

            if (type.Text == "Exit")
            {

            }
            

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
                    MessageBox.Show("Input port error");
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

                if (!m_IsListen)
                {
                    NETClient.SetDVRMessCallBack(m_AlarmCallBack, IntPtr.Zero);
                    bool ret = NETClient.StartListen(m_LoginID);
                    if (!ret)
                    {
                        MessageBox.Show(this, NETClient.GetLastError());
                        return;
                    }
                    m_IsListen = true;
                    Alarm_Index = 1;
                    btn_StartListen.Text = "StopListen";
                }
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
                    btn_StartListen.Text = "StartListen";
                    BackColor = Color.LightCoral;
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
            #region Open door
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
            #region Close door

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
            MessageBox.Show("Close door success");

            #endregion


        }

        private void btn_OpenAlways_Click(object sender, EventArgs e)
        {
            #region Open always

            GetConfig();
            cfg.emState = EM_CFG_ACCESS_STATE.OPENALWAYS;
            bool bRet = SetConfig(cfg);
            if (!bRet)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            MessageBox.Show("Always open success");

            #endregion
        }

        private void btn_CloseAlways_Click(object sender, EventArgs e)
        {
            #region Close always

            GetConfig();
            cfg.emState = EM_CFG_ACCESS_STATE.CLOSEALWAYS;
            bool bRet = SetConfig(cfg);
            if (!bRet)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            MessageBox.Show("Always close success");

            #endregion
        }

        private void btn_GetDoorState_Click(object sender, EventArgs e)
        {
            #region Query door state
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
                    MessageBox.Show("Door abnormal unlock");
                    break;
                case EM_NET_DOOR_STATUS_TYPE.CLOSE:
                    MessageBox.Show("Door closed");
                    break;
                case EM_NET_DOOR_STATUS_TYPE.OPEN:
                    MessageBox.Show("Door opened");
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
                NETClient.SetDVRMessCallBack(m_AlarmCallBack, IntPtr.Zero);
                bool ret = NETClient.StartListen(m_LoginID);
                if (!ret)
                {
                    MessageBox.Show(this, NETClient.GetLastError());
                    return;
                }
                m_IsListen = true;
                Alarm_Index = 1;
                btn_StartListen.Text = "StopListen";
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
                btn_StartListen.Text = "StartListen";
                BackColor = Color.LightCoral;
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

        private void AccessControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_GlobalHook.KeyPress -= GlobalHookKeyPress;
            m_GlobalHook.Dispose();

            Application.ExitThread();
        }
    }
}
