using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSDKCS;
using System.Windows.Forms;

namespace AccessControl1s
{

    public partial class DoorConfig : Form
    {
        IntPtr loginID = IntPtr.Zero;
        private int m_Channel = 0;

        AccessControlForm mainWindow;

        public DoorConfig(IntPtr id, int channel, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
            m_Channel = channel;
            mainWindow = main;
        }

        private void DoorConfig_Load(object sender, EventArgs e)
        {
            try
            {
                cmbBox_DoorIndex.Items.Clear();

                if (m_Channel > 0)
                {
                    for (int i = 1; i <= m_Channel; i++)
                    {
                        cmbBox_DoorIndex.Items.Add(i);
                    }
                    cmbBox_DoorIndex.SelectedIndex = 0;
                }

                //    comboBox_Week.SelectedIndex = 0;
                #region load door config 加载门配置
                if (GetConfig())
                {
                    if ((int)cfg.emDoorOpenMethod > 13)
                    {
                        cmbBox_OpenMethod.SelectedIndex = -1;
                    }
                    else
                    {
                        cmbBox_OpenMethod.SelectedIndex = (int)cfg.emDoorOpenMethod;
                    }
                    textBox_UnlockHold.Text = cfg.nUnlockHoldInterval.ToString();
                    textBox_CloseTimeout.Text = cfg.nCloseTimeout.ToString();
                    textBox_HolidayNo.Text = cfg.nHolidayTimeRecoNo.ToString();
                    cmbBox_AccessState.SelectedIndex = (int)cfg.emState;

                    checkBox_RepearAlarm.Checked = cfg.abRepeatEnterAlarmEnable == 1 && cfg.bRepeatEnterAlarm;
                    checkBox_NotCloseAlarm.Checked = cfg.abDoorNotClosedAlarmEnable == 1 && cfg.bDoorNotClosedAlarmEnable;
                    checkBox_DuressAlarm.Checked = cfg.abDuressAlarmEnable == 1 && cfg.bDuressAlarmEnable;
                    checkBox_Sensor.Checked = cfg.abSensorEnable == 1 && cfg.bSensorEnable;
                    checkBox_BreakAlarm.Checked = cfg.abBreakInAlarmEnable == 1 && cfg.bBreakInAlarmEnable;
                    comboBox_Week.Enabled = true;
                    comboBox_Week.SelectedIndex = 0;
                }

                #endregion
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        NET_CFG_ACCESS_EVENT_INFO cfg = new NET_CFG_ACCESS_EVENT_INFO();
        public bool GetConfig()
        {
            bool bRet = false;
            try
            {
                object objTemp = new object();
                bRet = NETClient.GetNewDevConfig(loginID, cmbBox_DoorIndex.SelectedIndex, "AccessControl", ref objTemp, typeof(NET_CFG_ACCESS_EVENT_INFO), 5000);
                if (!bRet)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return bRet;
                }
                cfg = (NET_CFG_ACCESS_EVENT_INFO)objTemp;
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

        public bool SetConfig(NET_CFG_ACCESS_EVENT_INFO cfg)
        {
            bool bRet = false;
            try
            {
                bRet = NETClient.SetNewDevConfig(loginID, cmbBox_DoorIndex.SelectedIndex, "AccessControl", (object)cfg, typeof(NET_CFG_ACCESS_EVENT_INFO), 5000);
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

        private void btn_Get_Click(object sender, EventArgs e)
        {
            #region Get Accesscontrol event config
            try
            {
                comboBox_Week.SelectedIndex = -1;
                if (GetConfig())
                {
                    MessageBox.Show("Get successfully!");
                    if ((int)cfg.emDoorOpenMethod > 13)
                    {
                        cmbBox_OpenMethod.SelectedIndex = -1;
                    }
                    else
                    {
                        cmbBox_OpenMethod.SelectedIndex = (int)cfg.emDoorOpenMethod;
                    }

                    textBox_UnlockHold.Text = cfg.nUnlockHoldInterval.ToString();
                    textBox_CloseTimeout.Text = cfg.nCloseTimeout.ToString();
                    textBox_HolidayNo.Text = cfg.nHolidayTimeRecoNo.ToString();
                    cmbBox_AccessState.SelectedIndex = (int)cfg.emState;


                    checkBox_RepearAlarm.Checked = cfg.abRepeatEnterAlarmEnable == 1 && cfg.bRepeatEnterAlarm;
                    checkBox_NotCloseAlarm.Checked = cfg.abDoorNotClosedAlarmEnable == 1 && cfg.bDoorNotClosedAlarmEnable;
                    checkBox_DuressAlarm.Checked = cfg.abDuressAlarmEnable == 1 && cfg.bDuressAlarmEnable;
                    checkBox_Sensor.Checked = cfg.abSensorEnable == 1 && cfg.bSensorEnable;
                    checkBox_BreakAlarm.Checked = cfg.abBreakInAlarmEnable == 1 && cfg.bBreakInAlarmEnable;
                    comboBox_Week.Enabled = true;
                    comboBox_Week.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            #endregion

        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            #region Set Accesscontrol event config
            cfg.emDoorOpenMethod = (EM_CFG_DOOR_OPEN_METHOD)cmbBox_OpenMethod.SelectedIndex; 
            try
            {
                cfg.nUnlockHoldInterval = Int32.Parse(textBox_UnlockHold.Text);
                cfg.nCloseTimeout = Int32.Parse(textBox_CloseTimeout.Text);
                cfg.nHolidayTimeRecoNo = Int32.Parse(textBox_HolidayNo.Text);   // 对应时间段序号，从0开始。 corresponding CFG_CMD_ACCESSTIMESCHEDULE Channel Number
            }
            catch (Exception)
            {
                MessageBox.Show("数据转换出错！");
                return;
            }
            cfg.emState = (EM_CFG_ACCESS_STATE)cmbBox_AccessState.SelectedIndex;

            cfg.bRepeatEnterAlarm = checkBox_RepearAlarm.Checked;
            cfg.bDoorNotClosedAlarmEnable = checkBox_NotCloseAlarm.Checked;
            cfg.bDuressAlarmEnable = checkBox_DuressAlarm.Checked;
            cfg.bSensorEnable = checkBox_Sensor.Checked;
            cfg.bBreakInAlarmEnable = checkBox_BreakAlarm.Checked;

            if (SetConfig(cfg))
            {
                MessageBox.Show("Set successfully(设置成功)!");
            }
            #endregion
        }

        private void comboBox_Week_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Week.SelectedIndex < 0 || comboBox_Week.SelectedIndex > 6)
            {
                return;
            }
            var temp = cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4];
            StartTime1.Value = new DateTime(2020, 1, 1, (int)temp.stuTime.stuStartTime.dwHour, (int)temp.stuTime.stuStartTime.dwMinute, (int)temp.stuTime.stuStartTime.dwSecond);
            EndTime1.Value = new DateTime(2020, 1, 1, (int)temp.stuTime.stuEndTime.dwHour, (int)temp.stuTime.stuEndTime.dwMinute, (int)temp.stuTime.stuEndTime.dwSecond);
            if ((int)temp.emDoorOpenMethod > 13)
            {
                cmbBox_OpenDoorMethod1.SelectedIndex = -1;
            }
            else
            {
                cmbBox_OpenDoorMethod1.SelectedIndex = (int)temp.emDoorOpenMethod;
            }

            temp = cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 1];
            StartTime2.Value = new DateTime(2020, 1, 1, (int)temp.stuTime.stuStartTime.dwHour, (int)temp.stuTime.stuStartTime.dwMinute, (int)temp.stuTime.stuStartTime.dwSecond);
            EndTime2.Value = new DateTime(2020, 1, 1, (int)temp.stuTime.stuEndTime.dwHour, (int)temp.stuTime.stuEndTime.dwMinute, (int)temp.stuTime.stuEndTime.dwSecond);
      //      cmbBox_OpenDoorMethod2.SelectedIndex = (int)temp.emDoorOpenMethod;
            if ((int)temp.emDoorOpenMethod > 13)
            {
                cmbBox_OpenDoorMethod2.SelectedIndex = -1;
            }
            else
            {
                cmbBox_OpenDoorMethod2.SelectedIndex = (int)temp.emDoorOpenMethod;
            }

            temp = cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 2];
            StartTime3.Value = new DateTime(2020, 1, 1, (int)temp.stuTime.stuStartTime.dwHour, (int)temp.stuTime.stuStartTime.dwMinute, (int)temp.stuTime.stuStartTime.dwSecond);
            EndTime3.Value = new DateTime(2020, 1, 1, (int)temp.stuTime.stuEndTime.dwHour, (int)temp.stuTime.stuEndTime.dwMinute, (int)temp.stuTime.stuEndTime.dwSecond);
    //        cmbBox_OpenDoorMethod3.SelectedIndex = (int)temp.emDoorOpenMethod;
            if ((int)temp.emDoorOpenMethod > 13)
            {
                cmbBox_OpenDoorMethod3.SelectedIndex = -1;
            }
            else
            {
                cmbBox_OpenDoorMethod3.SelectedIndex = (int)temp.emDoorOpenMethod;
            }

            temp = cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 3];
            StartTime4.Value = new DateTime(2020, 1, 1, (int)temp.stuTime.stuStartTime.dwHour, (int)temp.stuTime.stuStartTime.dwMinute, (int)temp.stuTime.stuStartTime.dwSecond);
            EndTime4.Value = new DateTime(2020, 1, 1, (int)temp.stuTime.stuEndTime.dwHour, (int)temp.stuTime.stuEndTime.dwMinute, (int)temp.stuTime.stuEndTime.dwSecond);
  //          cmbBox_OpenDoorMethod4.SelectedIndex = (int)temp.emDoorOpenMethod;
            if ((int)temp.emDoorOpenMethod > 13)
            {
                cmbBox_OpenDoorMethod4.SelectedIndex = -1;
            }
            else
            {
                cmbBox_OpenDoorMethod4.SelectedIndex = (int)temp.emDoorOpenMethod;
            }

        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (comboBox_Week.SelectedIndex < 0 || comboBox_Week.SelectedIndex > 6) 
            {
                return;
            }

            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4].stuTime.stuStartTime.dwHour = (uint)StartTime1.Value.Hour;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4].stuTime.stuStartTime.dwMinute = (uint)StartTime1.Value.Minute;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4].stuTime.stuStartTime.dwSecond = (uint)StartTime1.Value.Second;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4].stuTime.stuEndTime.dwHour = (uint)EndTime1.Value.Hour;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4].stuTime.stuEndTime.dwMinute = (uint)EndTime1.Value.Minute;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4].stuTime.stuEndTime.dwSecond = (uint)EndTime1.Value.Second;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4].emDoorOpenMethod = (EM_CFG_DOOR_OPEN_METHOD)cmbBox_OpenDoorMethod1.SelectedIndex; 

            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 1].stuTime.stuStartTime.dwHour = (uint)StartTime2.Value.Hour;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 1].stuTime.stuStartTime.dwMinute = (uint)StartTime2.Value.Minute;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 1].stuTime.stuStartTime.dwSecond = (uint)StartTime2.Value.Second;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 1].stuTime.stuEndTime.dwHour = (uint)EndTime2.Value.Hour;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 1].stuTime.stuEndTime.dwMinute = (uint)EndTime2.Value.Minute;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 1].stuTime.stuEndTime.dwSecond = (uint)EndTime2.Value.Second;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 1].emDoorOpenMethod = (EM_CFG_DOOR_OPEN_METHOD)cmbBox_OpenDoorMethod2.SelectedIndex;

            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 2].stuTime.stuStartTime.dwHour = (uint)StartTime3.Value.Hour;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 2].stuTime.stuStartTime.dwMinute = (uint)StartTime3.Value.Minute;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 2].stuTime.stuStartTime.dwSecond = (uint)StartTime3.Value.Second;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 2].stuTime.stuEndTime.dwHour = (uint)EndTime3.Value.Hour;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 2].stuTime.stuEndTime.dwMinute = (uint)EndTime3.Value.Minute;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 2].stuTime.stuEndTime.dwSecond = (uint)EndTime3.Value.Second;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 2].emDoorOpenMethod = (EM_CFG_DOOR_OPEN_METHOD)cmbBox_OpenDoorMethod3.SelectedIndex;

            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 3].stuTime.stuStartTime.dwHour = (uint)StartTime4.Value.Hour;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 3].stuTime.stuStartTime.dwMinute = (uint)StartTime4.Value.Minute;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 3].stuTime.stuStartTime.dwSecond = (uint)StartTime4.Value.Second;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 3].stuTime.stuEndTime.dwHour = (uint)EndTime4.Value.Hour;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 3].stuTime.stuEndTime.dwMinute = (uint)EndTime4.Value.Minute;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 3].stuTime.stuEndTime.dwSecond = (uint)EndTime4.Value.Second;
            cfg.stuDoorTimeSection[comboBox_Week.SelectedIndex * 4 + 3].emDoorOpenMethod = (EM_CFG_DOOR_OPEN_METHOD)cmbBox_OpenDoorMethod4.SelectedIndex;
        }
        
    }
}
