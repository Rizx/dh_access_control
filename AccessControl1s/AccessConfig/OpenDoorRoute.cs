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
    public partial class OpenDoorRoute : Form
    {
        IntPtr loginID = IntPtr.Zero;

        private int m_Channel = 0;

        private NET_CFG_OPEN_DOOR_ROUTE_INFO cfg = new NET_CFG_OPEN_DOOR_ROUTE_INFO();

        private const string CFG_CMD_OPEN_DOOR_ROUTE = "OpenDoorRoute";

        AccessControlForm mainWindow;

        public OpenDoorRoute(IntPtr id, int nChm, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
            m_Channel = nChm;
            mainWindow = main;
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            UIClear();
            if (GetConfig())
            {
                MessageBox.Show("Get successfully(获取成功)");

                if (cfg.nDoorList >= 1)
                {

                    textBox_Time1.Text = cfg.stuDoorList[0].nResetTime.ToString();
                    if (cfg.stuDoorList[0].nDoors >= 1)
                    {

                        textBox_ID11.Text = cfg.stuDoorList[0].stuDoors[0].szReaderID;
                    }
                    if (cfg.stuDoorList[0].nDoors >= 2)
                    {
                        textBox_ID12.Text = cfg.stuDoorList[0].stuDoors[1].szReaderID;
                    }
                    if (cfg.stuDoorList[0].nDoors >= 3)
                    {
                        textBox_ID13.Text = cfg.stuDoorList[0].stuDoors[2].szReaderID;
                    }
                    if (cfg.stuDoorList[0].nDoors >= 4)
                    {
                        textBox_ID14.Text = cfg.stuDoorList[0].stuDoors[3].szReaderID;
                    }
                    if (cfg.stuDoorList[0].nDoors >= 5)
                    {
                        textBox_ID15.Text = cfg.stuDoorList[0].stuDoors[4].szReaderID;
                    }
                    if (cfg.stuDoorList[0].nDoors >= 6)
                    {
                        textBox_ID16.Text = cfg.stuDoorList[0].stuDoors[5].szReaderID;
                    }
                    if (cfg.stuDoorList[0].nDoors >= 7)
                    {
                        textBox_ID17.Text = cfg.stuDoorList[0].stuDoors[6].szReaderID;
                    }
                    if (cfg.stuDoorList[0].nDoors >= 8)
                    {
                        textBox_ID18.Text = cfg.stuDoorList[0].stuDoors[7].szReaderID;
                    }
                }
                if (cfg.nDoorList >= 2)
                {
                    textBox_Time2.Text = cfg.stuDoorList[1].nResetTime.ToString();
                    if (cfg.stuDoorList[1].nDoors >= 1)
                    {
                        textBox_ID21.Text = cfg.stuDoorList[1].stuDoors[0].szReaderID;
                    }
                    if (cfg.stuDoorList[1].nDoors >= 2)
                    {
                        textBox_ID22.Text = cfg.stuDoorList[1].stuDoors[1].szReaderID;
                    }
                    if (cfg.stuDoorList[1].nDoors >= 3)
                    {
                        textBox_ID23.Text = cfg.stuDoorList[1].stuDoors[2].szReaderID;
                    }
                    if (cfg.stuDoorList[1].nDoors >= 4)
                    {
                        textBox_ID24.Text = cfg.stuDoorList[1].stuDoors[3].szReaderID;
                    }
                    if (cfg.stuDoorList[1].nDoors >= 5)
                    {
                        textBox_ID25.Text = cfg.stuDoorList[1].stuDoors[4].szReaderID;
                    }
                    if (cfg.stuDoorList[1].nDoors >= 6)
                    {
                        textBox_ID26.Text = cfg.stuDoorList[1].stuDoors[5].szReaderID;
                    }
                    if (cfg.stuDoorList[1].nDoors >= 7)
                    {
                        textBox_ID27.Text = cfg.stuDoorList[1].stuDoors[6].szReaderID;
                    }
                    if (cfg.stuDoorList[1].nDoors >= 8)
                    {
                        textBox_ID28.Text = cfg.stuDoorList[1].stuDoors[7].szReaderID;
                    }
                }
            }
        }

        private void button_Set_Click(object sender, EventArgs e)
        {
            try
            {
                cfg.stuDoorList[0].nDoors = 0;
                cfg.stuDoorList[0].stuDoors[0].szReaderID = "";
                cfg.stuDoorList[0].stuDoors[1].szReaderID = "";
                cfg.stuDoorList[0].stuDoors[2].szReaderID = "";
                cfg.stuDoorList[0].stuDoors[3].szReaderID = "";
                cfg.stuDoorList[0].stuDoors[4].szReaderID = "";
                cfg.stuDoorList[0].stuDoors[5].szReaderID = "";
                cfg.stuDoorList[0].stuDoors[6].szReaderID = "";
                cfg.stuDoorList[0].stuDoors[7].szReaderID = "";

                cfg.stuDoorList[1].nDoors = 0;
                cfg.stuDoorList[1].stuDoors[0].szReaderID = "";
                cfg.stuDoorList[1].stuDoors[1].szReaderID = "";
                cfg.stuDoorList[1].stuDoors[2].szReaderID = "";
                cfg.stuDoorList[1].stuDoors[3].szReaderID = "";
                cfg.stuDoorList[1].stuDoors[4].szReaderID = "";
                cfg.stuDoorList[1].stuDoors[5].szReaderID = "";
                cfg.stuDoorList[1].stuDoors[6].szReaderID = "";
                cfg.stuDoorList[1].stuDoors[7].szReaderID = "";

                if (!string.IsNullOrEmpty(textBox_ID11.Text.Trim()))
                {
                    cfg.stuDoorList[0].nDoors = 1;
                    cfg.stuDoorList[0].stuDoors[0].szReaderID = textBox_ID11.Text.Trim();
                }
                if (!string.IsNullOrEmpty(textBox_ID12.Text.Trim()))
                {
                    cfg.stuDoorList[0].nDoors = 2;
                    cfg.stuDoorList[0].stuDoors[1].szReaderID = textBox_ID12.Text.Trim();
                }
                if (!string.IsNullOrEmpty(textBox_ID13.Text.Trim()))
                {
                    cfg.stuDoorList[0].nDoors = 3;
                    cfg.stuDoorList[0].stuDoors[2].szReaderID = textBox_ID13.Text.Trim();
                }
                if (!string.IsNullOrEmpty(textBox_ID14.Text.Trim()))
                {
                    cfg.stuDoorList[0].nDoors = 4;
                    cfg.stuDoorList[0].stuDoors[3].szReaderID = textBox_ID14.Text.Trim();
                }
                if (!string.IsNullOrEmpty(textBox_ID15.Text.Trim()))
                {
                    cfg.stuDoorList[0].nDoors = 5;
                    cfg.stuDoorList[0].stuDoors[4].szReaderID = textBox_ID15.Text.Trim();
                }
                if (!string.IsNullOrEmpty(textBox_ID16.Text.Trim()))
                {
                    cfg.stuDoorList[0].nDoors = 6;
                    cfg.stuDoorList[0].stuDoors[5].szReaderID = textBox_ID16.Text.Trim();
                }
                if (!string.IsNullOrEmpty(textBox_ID17.Text.Trim()))
                {
                    cfg.stuDoorList[0].nDoors = 7;
                    cfg.stuDoorList[0].stuDoors[6].szReaderID = textBox_ID17.Text.Trim();
                }
                if (!string.IsNullOrEmpty(textBox_ID18.Text.Trim()))
                {
                    cfg.stuDoorList[0].nDoors = 8;
                    cfg.stuDoorList[0].stuDoors[7].szReaderID = textBox_ID18.Text.Trim();
                }
                if (cfg.stuDoorList[0].nDoors > 0)
                {
                    cfg.nDoorList = 1;
                }
                cfg.stuDoorList[0].nResetTime = uint.Parse(textBox_Time1.Text.Trim());

                if (!string.IsNullOrEmpty(textBox_ID21.Text.Trim()))
                {
                    cfg.stuDoorList[1].nDoors = 1;
                    cfg.stuDoorList[1].stuDoors[0].szReaderID = textBox_ID21.Text.Trim();
                }
                if (!string.IsNullOrEmpty(textBox_ID22.Text.Trim()))
                {
                    cfg.stuDoorList[1].nDoors = 2;
                    cfg.stuDoorList[1].stuDoors[1].szReaderID = textBox_ID22.Text.Trim();
                }
                if (!string.IsNullOrEmpty(textBox_ID23.Text.Trim()))
                {
                    cfg.stuDoorList[1].nDoors = 3;
                    cfg.stuDoorList[1].stuDoors[2].szReaderID = textBox_ID23.Text.Trim();
                }
                if (!string.IsNullOrEmpty(textBox_ID24.Text.Trim()))
                {
                    cfg.stuDoorList[1].nDoors = 4;
                    cfg.stuDoorList[1].stuDoors[3].szReaderID = textBox_ID24.Text.Trim();
                }
                if (!string.IsNullOrEmpty(textBox_ID25.Text.Trim()))
                {
                    cfg.stuDoorList[1].nDoors = 5;
                    cfg.stuDoorList[1].stuDoors[4].szReaderID = textBox_ID25.Text.Trim();
                }
                if (!string.IsNullOrEmpty(textBox_ID26.Text.Trim()))
                {
                    cfg.stuDoorList[1].nDoors = 6;
                    cfg.stuDoorList[1].stuDoors[5].szReaderID = textBox_ID26.Text.Trim();
                }
                if (!string.IsNullOrEmpty(textBox_ID27.Text.Trim()))
                {
                    cfg.stuDoorList[1].nDoors = 7;
                    cfg.stuDoorList[1].stuDoors[6].szReaderID = textBox_ID27.Text.Trim();
                }
                if (!string.IsNullOrEmpty(textBox_ID28.Text.Trim()))
                {
                    cfg.stuDoorList[1].nDoors = 8;
                    cfg.stuDoorList[1].stuDoors[7].szReaderID = textBox_ID28.Text.Trim();
                }
                if (cfg.stuDoorList[1].nDoors > 0)
                {
                    cfg.nDoorList = 2;
                }
                cfg.stuDoorList[1].nResetTime = uint.Parse(textBox_Time2.Text.Trim());
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
                bRet = NETClient.GetNewDevConfig(loginID, -1, CFG_CMD_OPEN_DOOR_ROUTE, ref objTemp, typeof(NET_CFG_OPEN_DOOR_ROUTE_INFO), 5000);
                if (bRet)
                {
                    cfg = (NET_CFG_OPEN_DOOR_ROUTE_INFO)objTemp;
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

        public bool SetConfig(NET_CFG_OPEN_DOOR_ROUTE_INFO cfg)
        {
            bool bRet = false;
            try
            {
                for (int i = 0; i < m_Channel; i++)
                {
                    bRet = NETClient.SetNewDevConfig(loginID, i, CFG_CMD_OPEN_DOOR_ROUTE, (object)cfg, typeof(NET_CFG_OPEN_DOOR_ROUTE_INFO), 5000);
                    if (!bRet)
                    {
                        MessageBox.Show(NETClient.GetLastError());
                        return false;
                    }
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

        public void UIClear()
        {
            textBox_Time1.Text = "";
            textBox_Time2.Text = "";
            textBox_ID11.Text = "";
            textBox_ID12.Text = "";
            textBox_ID13.Text = "";
            textBox_ID14.Text = "";
            textBox_ID15.Text = "";
            textBox_ID16.Text = "";
            textBox_ID17.Text = "";
            textBox_ID18.Text = "";
            textBox_ID21.Text = "";
            textBox_ID22.Text = "";
            textBox_ID23.Text = "";
            textBox_ID24.Text = "";
            textBox_ID25.Text = "";
            textBox_ID26.Text = "";
            textBox_ID27.Text = "";
            textBox_ID28.Text = "";
        }

        private void OpenDoorRoute_Load(object sender, EventArgs e)
        {
            if (GetConfig())
            {
      //          MessageBox.Show("Get successfully(获取成功)");

                if (cfg.nDoorList >= 1)
                {

                    textBox_Time1.Text = cfg.stuDoorList[0].nResetTime.ToString();
                    if (cfg.stuDoorList[0].nDoors >= 1)
                    {

                        textBox_ID11.Text = cfg.stuDoorList[0].stuDoors[0].szReaderID;
                    }
                    if (cfg.stuDoorList[0].nDoors >= 2)
                    {
                        textBox_ID12.Text = cfg.stuDoorList[0].stuDoors[1].szReaderID;
                    }
                    if (cfg.stuDoorList[0].nDoors >= 3)
                    {
                        textBox_ID13.Text = cfg.stuDoorList[0].stuDoors[2].szReaderID;
                    }
                    if (cfg.stuDoorList[0].nDoors >= 4)
                    {
                        textBox_ID14.Text = cfg.stuDoorList[0].stuDoors[3].szReaderID;
                    }
                    if (cfg.stuDoorList[0].nDoors >= 5)
                    {
                        textBox_ID15.Text = cfg.stuDoorList[0].stuDoors[4].szReaderID;
                    }
                    if (cfg.stuDoorList[0].nDoors >= 6)
                    {
                        textBox_ID16.Text = cfg.stuDoorList[0].stuDoors[5].szReaderID;
                    }
                    if (cfg.stuDoorList[0].nDoors >= 7)
                    {
                        textBox_ID17.Text = cfg.stuDoorList[0].stuDoors[6].szReaderID;
                    }
                    if (cfg.stuDoorList[0].nDoors >= 8)
                    {
                        textBox_ID18.Text = cfg.stuDoorList[0].stuDoors[7].szReaderID;
                    }
                }
                if (cfg.nDoorList >= 2)
                {
                    textBox_Time2.Text = cfg.stuDoorList[1].nResetTime.ToString();
                    if (cfg.stuDoorList[1].nDoors >= 1)
                    {
                        textBox_ID21.Text = cfg.stuDoorList[1].stuDoors[0].szReaderID;
                    }
                    if (cfg.stuDoorList[1].nDoors >= 2)
                    {
                        textBox_ID22.Text = cfg.stuDoorList[1].stuDoors[1].szReaderID;
                    }
                    if (cfg.stuDoorList[1].nDoors >= 3)
                    {
                        textBox_ID23.Text = cfg.stuDoorList[1].stuDoors[2].szReaderID;
                    }
                    if (cfg.stuDoorList[1].nDoors >= 4)
                    {
                        textBox_ID24.Text = cfg.stuDoorList[1].stuDoors[3].szReaderID;
                    }
                    if (cfg.stuDoorList[1].nDoors >= 5)
                    {
                        textBox_ID25.Text = cfg.stuDoorList[1].stuDoors[4].szReaderID;
                    }
                    if (cfg.stuDoorList[1].nDoors >= 6)
                    {
                        textBox_ID26.Text = cfg.stuDoorList[1].stuDoors[5].szReaderID;
                    }
                    if (cfg.stuDoorList[1].nDoors >= 7)
                    {
                        textBox_ID27.Text = cfg.stuDoorList[1].stuDoors[6].szReaderID;
                    }
                    if (cfg.stuDoorList[1].nDoors >= 8)
                    {
                        textBox_ID28.Text = cfg.stuDoorList[1].stuDoors[7].szReaderID;
                    }
                }
            }
        }



    }
}
