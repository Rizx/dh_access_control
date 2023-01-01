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
    public partial class DeviceTime : Form
    {
        IntPtr loginID = IntPtr.Zero;
        private NET_AV_CFG_Locales cfg_Locales = new NET_AV_CFG_Locales() { nStructSize = Marshal.SizeOf(typeof(NET_AV_CFG_Locales)) };
        AccessControlForm mainWindow;
        public DeviceTime(IntPtr id, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
            mainWindow = main;
        }


        private void DeviceTime_Load(object sender, EventArgs e)
        {

            try
            {
                #region time pick 时间选择显示
                cmb_StartYear.Items.Clear();
                cmb_StartMonth.Items.Clear();
                cmb_StartHour.Items.Clear();
                cmb_StartMin.Items.Clear();

                for (int i = 2000; i <= 2038; i++)
                {
                    cmb_StartYear.Items.Add(i);
                }
                for (int i = 1; i <= 12; i++)
                {
                    cmb_StartMonth.Items.Add(i);
                }
                for (int i = 0; i < 24; i++)
                {
                    cmb_StartHour.Items.Add(i);
                }
                for (int i = 0; i < 60; i++)
                {
                    cmb_StartMin.Items.Add(i);
                }
                cmb_StartDay.Items.Clear();
                for (int i = 1; i <= 31; i++)
                {
                    cmb_StartDay.Items.Add(i);
                }

                cmb_StopYear.Items.Clear();
                cmb_StopMonth.Items.Clear();
                cmb_StopHour.Items.Clear();
                cmb_StopMin.Items.Clear();
                for (int i = 2000; i <= 2038; i++)
                {
                    cmb_StopYear.Items.Add(i);
                }
                for (int i = 1; i <= 12; i++)
                {
                    cmb_StopMonth.Items.Add(i);
                }
                for (int i = 0; i < 24; i++)
                {
                    cmb_StopHour.Items.Add(i);
                }
                for (int i = 0; i < 60; i++)
                {
                    cmb_StopMin.Items.Add(i);
                }
                cmb_StopDay.Items.Clear();
                for (int i = 1; i <= 31; i++)
                {
                    cmb_StopDay.Items.Add(i);
                }

            #endregion
                #region load Deice Time 加载设备时间
                NET_TIME stuInfo = new NET_TIME();

                bool ret = NETClient.QueryDeviceTime(loginID, ref stuInfo, 5000);
                if (!ret)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
                dateTimePicker_DevTime.Value = stuInfo.ToDateTime();
                #endregion

                #region load NTP config 时间同步配置
                GetConfig_NTP();
                checkBox_NTPEnabled.Checked = cfg.bEnable;
                this.textBox_NTPiP.Text = cfg.szAddress;
                this.textBox_Port.Text = cfg.nPort.ToString();
                this.textBox_UpdatePeriod.Text = cfg.nUpdatePeriod.ToString();
                this.comboBox_TimeZone.SelectedIndex = (int)cfg.emTimeZoneType;
                this.textBox_Descrip.Text = cfg.szTimeZoneDesc;
                #endregion

                #region load Locales config 加载夏令时配置
                bool bRet = GetConfig_Locales();
                if (!bRet)
                {
                    return;
                }
                comboBox_WeekNoBegin.Enabled = true;
                comboBox_WeekBegin.Enabled = true;
                comboBox_WeekStop.Enabled = true;
                comboBox_WeekNoStop.Enabled = true;

                checkBox_DSTEnabled.Checked = cfg_Locales.bDSTEnable;


                // 开始时间
                if (cfg_Locales.stuDstStart.nYear < 1999)
                {
                    return;
                }
                cmb_StartYear.SelectedIndex = cfg_Locales.stuDstStart.nYear - 2000;
                cmb_StartMonth.SelectedIndex = cfg_Locales.stuDstStart.nMonth - 1;
                cmb_StartHour.SelectedIndex = cfg_Locales.stuDstStart.nHour;
                cmb_StartMin.SelectedIndex = cfg_Locales.stuDstStart.nMinute;

                if (cfg_Locales.stuDstStart.nWeek == 0) // 日期
                {
                    comboBox_DSTType.SelectedIndex = 0;
                    comboBox_WeekNoBegin.Enabled = false;
                    comboBox_WeekBegin.Enabled = false;
                    comboBox_WeekStop.Enabled = false;
                    comboBox_WeekNoStop.Enabled = false;
                }
                else
                {
                    comboBox_DSTType.SelectedIndex = 1;
                }

                if (cfg_Locales.stuDstStart.nWeek == 0) // 日期
                {
                    comboBox_WeekNoBegin.Enabled = false;
                    cmb_StartDay.SelectedIndex = cfg_Locales.stuDstStart.nDay - 1;
                }
                else
                {
                    if (cfg_Locales.stuDstStart.nWeek == -1)
                    {
                        comboBox_WeekNoBegin.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBox_WeekNoBegin.SelectedIndex = cfg_Locales.stuDstStart.nWeek;
                    }
                    comboBox_WeekBegin.SelectedIndex = cfg_Locales.stuDstStart.nDay;
                    cmb_StartDay.Enabled = false;
                }

                // 结束时间
                cmb_StopYear.SelectedIndex = cfg_Locales.stuDstEnd.nYear - 2000;
                cmb_StopMonth.SelectedIndex = cfg_Locales.stuDstEnd.nMonth - 1;
                cmb_StopHour.SelectedIndex = cfg_Locales.stuDstEnd.nHour;
                cmb_StopMin.SelectedIndex = cfg_Locales.stuDstEnd.nMinute;
                if (cfg_Locales.stuDstEnd.nWeek == 0)
                {
                    comboBox_WeekStop.Enabled = false;
                    cmb_StopDay.SelectedIndex = cfg_Locales.stuDstEnd.nDay - 1;
                }
                else
                {
                    if (cfg_Locales.stuDstEnd.nWeek == -1)
                    {
                        comboBox_WeekNoStop.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBox_WeekNoStop.SelectedIndex = cfg_Locales.stuDstEnd.nWeek;
                    }
                    comboBox_WeekStop.SelectedIndex = cfg_Locales.stuDstEnd.nDay;
                    cmb_StopDay.Enabled = false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_GetTime_Click(object sender, EventArgs e)
        {
            #region Get Deice Time 获取设备时间
            NET_TIME stuInfo = new NET_TIME();

            bool ret = NETClient.QueryDeviceTime(loginID, ref stuInfo, 5000);
            if (!ret)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            dateTimePicker_DevTime.Value = stuInfo.ToDateTime();
            MessageBox.Show("Get Success(获取成功)");
            #endregion
        }

        private void btn_SetTime_Click(object sender, EventArgs e)
        {
            #region Set Device Time设置设备时间
            NET_TIME stuSet = new NET_TIME();
            stuSet.dwYear = (uint)dateTimePicker_DevTime.Value.Year;
            stuSet.dwMonth = (uint)dateTimePicker_DevTime.Value.Month;
            stuSet.dwDay = (uint)dateTimePicker_DevTime.Value.Day;
            stuSet.dwHour = (uint)dateTimePicker_DevTime.Value.Hour;
            stuSet.dwMinute = (uint)dateTimePicker_DevTime.Value.Minute;
            stuSet.dwSecond = (uint)dateTimePicker_DevTime.Value.Second;

            bool ret = NETClient.SetupDeviceTime(loginID, stuSet);
            if (!ret)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            MessageBox.Show("Set Success(设置成功)");
            #endregion
        }

        private void btn_GetNTP_Click(object sender, EventArgs e)
        {
            #region Get NTP config 获取时间同步配置
            try
            {
                GetConfig_NTP();
                checkBox_NTPEnabled.Checked = cfg.bEnable;
                this.textBox_NTPiP.Text = cfg.szAddress;
                this.textBox_Port.Text = cfg.nPort.ToString();
                this.textBox_UpdatePeriod.Text = cfg.nUpdatePeriod.ToString();
                this.comboBox_TimeZone.SelectedIndex = (int)cfg.emTimeZoneType;
                this.textBox_Descrip.Text = cfg.szTimeZoneDesc;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            #endregion
        }

        private void btn_SetNTP_Click(object sender, EventArgs e)
        {
            #region Set NTP config 设置时间同步配置

            try
            {
                cfg.bEnable = this.checkBox_NTPEnabled.Checked;
                cfg.szAddress = textBox_NTPiP.Text.Trim();
                cfg.nPort = int.Parse(textBox_Port.Text);
                cfg.nUpdatePeriod = int.Parse(textBox_UpdatePeriod.Text);
                cfg.emTimeZoneType = (EM_CFG_TIME_ZONE_TYPE)comboBox_TimeZone.SelectedIndex;
                cfg.szTimeZoneDesc = textBox_Descrip.Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


            bool bRet = SetConfig_NTP(cfg);
            if (!bRet)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            MessageBox.Show("Set Success(设置成功)");
            #endregion
        }

        // NTP 配置
        NET_CFG_NTP_INFO cfg = new NET_CFG_NTP_INFO();

        public NET_CFG_NTP_INFO GetConfig_NTP()
        {
            try
            {
                object objTemp = new object();
                bool bRet = NETClient.GetNewDevConfig(loginID, -1, "NTP", ref objTemp, typeof(NET_CFG_NTP_INFO), 5000);
                if (bRet)
                {
                    cfg = (NET_CFG_NTP_INFO)objTemp;
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


        public bool SetConfig_NTP(NET_CFG_NTP_INFO cfg)
        {
            bool bRet = false;
            try
            {
                bRet = NETClient.SetNewDevConfig(loginID, -1, "NTP", (object)cfg, typeof(NET_CFG_NTP_INFO), 5000);
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

        // Locales 配置

        public bool GetConfig_Locales()
        {
            bool bRet = false;
            try
            {
                cfg_Locales = new NET_AV_CFG_Locales() { nStructSize = Marshal.SizeOf(typeof(NET_AV_CFG_Locales)) };
                cfg_Locales.stuDstStart.nStructSize = Marshal.SizeOf(typeof(AV_CFG_DSTTime));
                cfg_Locales.stuDstEnd.nStructSize = Marshal.SizeOf(typeof(AV_CFG_DSTTime));
            //    object objTemp = new object();
                object objTemp = (object)cfg_Locales;
                bRet = NETClient.GetNewDevConfig(loginID, -1, "Locales", ref objTemp, typeof(NET_AV_CFG_Locales), 5000);
                if (bRet)
                {
                    cfg_Locales = (NET_AV_CFG_Locales)objTemp;
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
            return bRet;
        }


        public bool SetConfig_Locales(NET_AV_CFG_Locales cfg_Locales)
        {
            bool bRet = false;
            try
            {
                bRet = NETClient.SetNewDevConfig(loginID, -1, "Locales", (object)cfg_Locales, typeof(NET_AV_CFG_Locales), 5000);
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

        private void comboBox_DSTType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_WeekNoBegin.Enabled = true;
            comboBox_WeekBegin.Enabled = true;
            comboBox_WeekStop.Enabled = true;
            comboBox_WeekNoStop.Enabled = true;
            cmb_StartDay.Enabled = true;
            cmb_StopDay.Enabled = true;

            if (comboBox_DSTType.SelectedIndex == 0)
            {
                comboBox_WeekNoBegin.Enabled = false;
                comboBox_WeekNoBegin.SelectedIndex = -1;
                comboBox_WeekBegin.SelectedIndex = -1;
                comboBox_WeekBegin.Enabled = false;
                comboBox_WeekStop.Enabled = false;
                comboBox_WeekStop.SelectedIndex = -1;
                comboBox_WeekNoStop.SelectedIndex = -1;
                comboBox_WeekNoStop.Enabled = false;
                cmb_StartDay.SelectedIndex = 0;
                cmb_StopDay.SelectedIndex = 0;
            }
            else if (comboBox_DSTType.SelectedIndex == 1)
            {
                cmb_StartDay.Enabled = false;
                cmb_StartDay.SelectedIndex = -1;
                cmb_StopDay.SelectedIndex = -1;
                cmb_StopDay.Enabled = false;
                comboBox_WeekNoBegin.SelectedIndex = 0;
                comboBox_WeekNoStop.SelectedIndex = 0;
                comboBox_WeekBegin.SelectedIndex = 0;
                comboBox_WeekStop.SelectedIndex = 0;               
            }
        }

        private void button_SetDST_Click(object sender, EventArgs e)
        {
            #region Set Locales config 设置夏令时配置
         //   GetConfig_Locales();
            cfg_Locales.bDSTEnable = checkBox_DSTEnabled.Checked;
            if (comboBox_DSTType.SelectedIndex == 0)
            {
                cfg_Locales.stuDstStart.nWeek = 0;
                cfg_Locales.stuDstStart.nDay = cmb_StartDay.SelectedIndex + 1;
                cfg_Locales.stuDstEnd.nWeek = 0;
                cfg_Locales.stuDstEnd.nDay = cmb_StopDay.SelectedIndex + 1;
            }
            else
            {
                if (comboBox_WeekNoBegin.SelectedIndex == 0)
                {
                    cfg_Locales.stuDstStart.nWeek = -1;
                }
                else
                {
                    cfg_Locales.stuDstStart.nWeek = comboBox_WeekNoBegin.SelectedIndex;
                }
                cfg_Locales.stuDstStart.nDay = comboBox_WeekBegin.SelectedIndex;

                if (comboBox_WeekNoStop.SelectedIndex == 0)
                {
                    cfg_Locales.stuDstEnd.nWeek = -1;
                }
                else
                {
                    cfg_Locales.stuDstEnd.nWeek = comboBox_WeekNoStop.SelectedIndex;
                }
                cfg_Locales.stuDstEnd.nDay = comboBox_WeekStop.SelectedIndex;
            }
            cfg_Locales.stuDstStart.nYear = cmb_StartYear.SelectedIndex + 2000;
            cfg_Locales.stuDstStart.nMonth = cmb_StartMonth.SelectedIndex + 1;
            cfg_Locales.stuDstStart.nHour = cmb_StartHour.SelectedIndex;
            cfg_Locales.stuDstStart.nMinute = cmb_StartMin.SelectedIndex;

            cfg_Locales.stuDstEnd.nYear = cmb_StopYear.SelectedIndex + 2000;
            cfg_Locales.stuDstEnd.nMonth = cmb_StopMonth.SelectedIndex + 1;
            cfg_Locales.stuDstEnd.nHour = cmb_StopHour.SelectedIndex;
            cfg_Locales.stuDstEnd.nMinute = cmb_StopMin.SelectedIndex;

            bool bRet = SetConfig_Locales(cfg_Locales);
            if (!bRet)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            MessageBox.Show("Set Success(设置成功)");
            #endregion
        }

        private void button_GetDST_Click(object sender, EventArgs e)
        {
            #region Get Locales config 获取夏令时配置
            try
            {
                ResetDSTShow();
                bool bRet = GetConfig_Locales();
                if (!bRet)
                {
                    return;
                }
                comboBox_WeekNoBegin.Enabled = true;
                comboBox_WeekBegin.Enabled = true;
                comboBox_WeekStop.Enabled = true;
                comboBox_WeekNoStop.Enabled = true;

                checkBox_DSTEnabled.Checked = cfg_Locales.bDSTEnable;
                // 开始时间
                if (cfg_Locales.stuDstStart.nYear < 1999)
                {
                    return;
                }
                cmb_StartYear.SelectedIndex = cfg_Locales.stuDstStart.nYear - 2000;
                cmb_StartMonth.SelectedIndex = cfg_Locales.stuDstStart.nMonth - 1;
                cmb_StartHour.SelectedIndex = cfg_Locales.stuDstStart.nHour;
                cmb_StartMin.SelectedIndex = cfg_Locales.stuDstStart.nMinute;

                if (cfg_Locales.stuDstStart.nWeek == 0) // 日期
                {
                    comboBox_DSTType.SelectedIndex = 0;
                    comboBox_WeekNoBegin.Enabled = false;
                    comboBox_WeekBegin.Enabled = false;
                    comboBox_WeekStop.Enabled = false;
                    comboBox_WeekNoStop.Enabled = false;
                }
                else
                {
                    comboBox_DSTType.SelectedIndex = 1;
                }

                if (cfg_Locales.stuDstStart.nWeek == 0) // 日期
                {
                    comboBox_WeekNoBegin.Enabled = false;
                    cmb_StartDay.SelectedIndex = cfg_Locales.stuDstStart.nDay - 1;
                }
                else
                {
                    if (cfg_Locales.stuDstStart.nWeek == -1)
                    {
                        comboBox_WeekNoBegin.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBox_WeekNoBegin.SelectedIndex = cfg_Locales.stuDstStart.nWeek;
                    }
                    comboBox_WeekBegin.SelectedIndex = cfg_Locales.stuDstStart.nDay;
                    cmb_StartDay.Enabled = false;
                }

                // 结束时间
                cmb_StopYear.SelectedIndex = cfg_Locales.stuDstEnd.nYear - 2000;
                cmb_StopMonth.SelectedIndex = cfg_Locales.stuDstEnd.nMonth - 1;
                cmb_StopHour.SelectedIndex = cfg_Locales.stuDstEnd.nHour;
                cmb_StopMin.SelectedIndex = cfg_Locales.stuDstEnd.nMinute;
                if (cfg_Locales.stuDstEnd.nWeek == 0)
                {
                    comboBox_WeekStop.Enabled = false;
                    cmb_StopDay.SelectedIndex = cfg_Locales.stuDstEnd.nDay - 1;
                }
                else
                {
                    if (cfg_Locales.stuDstEnd.nWeek == -1)
                    {
                        comboBox_WeekNoStop.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBox_WeekNoStop.SelectedIndex = cfg_Locales.stuDstEnd.nWeek;
                    }
                    comboBox_WeekStop.SelectedIndex = cfg_Locales.stuDstEnd.nDay;
                    cmb_StopDay.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void cmb_StartDay_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmb_StopDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_StartMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int monthdays = 0;
            int month = cmb_StartMonth.SelectedIndex + 1;
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                monthdays = 31;
            }
            else if (month == 2)
            {
                monthdays = 29;
            }
            else
            {
                monthdays = 30;
            }
            cmb_StartDay.Items.Clear();
            for (int i = 1; i <= monthdays; i++)
            {
                cmb_StartDay.Items.Add(i);
            }
        }

        private void cmb_StopMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int monthdays = 0;
            int month = cmb_StopMonth.SelectedIndex + 1;
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                monthdays = 31;
            }
            else if (month == 2)
            {
                monthdays = 29;
            }
            else
            {
                monthdays = 30;
            }
            cmb_StopDay.Items.Clear();
            for (int i = 1; i <= monthdays; i++)
            {
                cmb_StopDay.Items.Add(i);
            }
        }

        private void ResetDSTShow()
        {
            try
            {
                checkBox_DSTEnabled.Checked = false;
                comboBox_DSTType.SelectedIndex = -1;
                cmb_StartYear.SelectedIndex = -1;
                cmb_StartMonth.SelectedIndex = -1;
                cmb_StartDay.SelectedIndex = -1;
                cmb_StartHour.SelectedIndex = -1;
                cmb_StartMin.SelectedIndex = -1;
                comboBox_WeekBegin.SelectedIndex = -1;
                comboBox_WeekNoBegin.SelectedIndex = -1;
                cmb_StopYear.SelectedIndex = -1;
                cmb_StopMonth.SelectedIndex = -1;
                cmb_StopDay.SelectedIndex = -1;
                cmb_StopHour.SelectedIndex = -1;
                cmb_StopMin.SelectedIndex = -1;
                comboBox_WeekNoStop.SelectedIndex = -1;
                comboBox_WeekStop.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
