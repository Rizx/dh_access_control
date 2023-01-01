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

namespace AccessControl1s
{
    public partial class FirstEnter : Form
    {
        IntPtr loginID = IntPtr.Zero;

        private int m_Channel = 0;
        private NET_CFG_ACCESS_EVENT_INFO cfg = new NET_CFG_ACCESS_EVENT_INFO();

        private const string CFG_CMD_ACCESS_EVENT = "AccessControl";

        AccessControlForm mainWindow;

        public FirstEnter(IntPtr id, int channel,  AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
            m_Channel = channel;
            mainWindow = main;
        }

        private void FirstEnter_Load(object sender, EventArgs e)
        {
            comboBox_Channel.Items.Clear();
            if (m_Channel > 0)
            {
                for (int i = 1; i <= m_Channel; i++)
                {
                    comboBox_Channel.Items.Add(i);
                }
                comboBox_Channel.SelectedIndex = 0;
            }

            if (GetConfig())
            {
              //  MessageBox.Show("Get successfully");

                if (cfg.abFirstEnterEnable == 1 && cfg.stuFirstEnterInfo.bEnable)
                {
                    checkBox_EnableFirst.Checked = true;
                }
                else
                {
                    checkBox_EnableFirst.Checked = false;
                }

                comboBox_Status.SelectedIndex = (int)cfg.stuFirstEnterInfo.emStatus;

                textBox_TimeIndex.Text = cfg.stuFirstEnterInfo.nTimeIndex.ToString();
            }
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            if (GetConfig())
            {
                MessageBox.Show("Get successfully");

                if (cfg.abFirstEnterEnable == 1 && cfg.stuFirstEnterInfo.bEnable)
                {
                    checkBox_EnableFirst.Checked = true;
                }
                else
                {
                    checkBox_EnableFirst.Checked = false;
                }

                comboBox_Status.SelectedIndex = (int)cfg.stuFirstEnterInfo.emStatus;

                textBox_TimeIndex.Text = cfg.stuFirstEnterInfo.nTimeIndex.ToString();
            }
        }

        private void button_Set_Click(object sender, EventArgs e)
        {
            try
            {
                cfg.abFirstEnterEnable = 1;
                if (checkBox_EnableFirst.Checked)
                {
                    cfg.stuFirstEnterInfo.bEnable = true;
                }
                else
                {
                    cfg.stuFirstEnterInfo.bEnable = false;
                }
                cfg.stuFirstEnterInfo.emStatus = (EM_CFG_ACCESS_FIRSTENTER_STATUS)comboBox_Status.SelectedIndex;
                cfg.stuFirstEnterInfo.nTimeIndex = int.Parse(textBox_TimeIndex.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (SetConfig(cfg))
            {
                MessageBox.Show("Set successfully(设置成功)");
            }

        }
        public bool GetConfig()
        {
            bool bRet = false;
            try
            {
                object objTemp = new object();
                bRet = NETClient.GetNewDevConfig(loginID, comboBox_Channel.SelectedIndex, CFG_CMD_ACCESS_EVENT, ref objTemp, typeof(NET_CFG_ACCESS_EVENT_INFO), 5000);
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
            return bRet;
        }

        public bool SetConfig(NET_CFG_ACCESS_EVENT_INFO cfg)
        {
            bool bRet = false;
            try
            {
                bRet = NETClient.SetNewDevConfig(loginID, comboBox_Channel.SelectedIndex, CFG_CMD_ACCESS_EVENT, (object)cfg, typeof(NET_CFG_ACCESS_EVENT_INFO), 5000);
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
    }
}
