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
    public partial class ABLock : Form
    {
        IntPtr loginID = IntPtr.Zero;
        private NET_CFG_ACCESS_GENERAL_INFO cfg = new NET_CFG_ACCESS_GENERAL_INFO();

        private const string CFG_CMD_ACCESS_GENERAL = "AccessControlGeneral";

        AccessControlForm mainWindow;

        public ABLock(IntPtr id, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
            mainWindow = main;
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            UIClear();
            if (GetConfig())
            {
                MessageBox.Show("Get successfully");
                checkBox_Enable.Checked = cfg.stuABLockInfo.bEnable;
                comboBox_Door.SelectedIndex = 0;
            }
        }

        private void button_Set_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_Enable.Checked)
                {
                    cfg.abABLockInfo = 1;
                    cfg.stuABLockInfo.bEnable = true;
                }
                else
                {
                    cfg.abABLockInfo = 0;
                    cfg.stuABLockInfo.bEnable = false;
                }

                int num = comboBox_Door.SelectedIndex;
                int temp;
                if (!string.IsNullOrEmpty(textBox_Door1.Text.Trim()) && int.TryParse(textBox_Door1.Text.Trim(), out temp))
                {
                    cfg.stuABLockInfo.stuDoors[num].nDoor = 1;
                    cfg.stuABLockInfo.stuDoors[num].anDoor[0] = temp;
                }
                if (!string.IsNullOrEmpty(textBox_Door2.Text.Trim()) && int.TryParse(textBox_Door2.Text.Trim(), out temp))
                {
                    cfg.stuABLockInfo.stuDoors[num].nDoor = 2;
                    cfg.stuABLockInfo.stuDoors[num].anDoor[1] = temp;
                }
                if (!string.IsNullOrEmpty(textBox_Door3.Text.Trim()) && int.TryParse(textBox_Door3.Text.Trim(), out temp))
                {
                    cfg.stuABLockInfo.stuDoors[num].nDoor = 3;
                    cfg.stuABLockInfo.stuDoors[num].anDoor[2] = temp;
                }
                if (!string.IsNullOrEmpty(textBox_Door4.Text.Trim()) && int.TryParse(textBox_Door4.Text.Trim(), out temp))
                {
                    cfg.stuABLockInfo.stuDoors[num].nDoor = 4;
                    cfg.stuABLockInfo.stuDoors[num].anDoor[3] = temp;
                }
                if (!string.IsNullOrEmpty(textBox_Door5.Text.Trim()) && int.TryParse(textBox_Door5.Text.Trim(), out temp))
                {
                    cfg.stuABLockInfo.stuDoors[num].nDoor = 5;
                    cfg.stuABLockInfo.stuDoors[num].anDoor[4] = temp;
                }
                if (!string.IsNullOrEmpty(textBox_Door6.Text.Trim()) && int.TryParse(textBox_Door6.Text.Trim(), out temp))
                {
                    cfg.stuABLockInfo.stuDoors[num].nDoor = 6;
                    cfg.stuABLockInfo.stuDoors[num].anDoor[5] = temp;
                }
                if (!string.IsNullOrEmpty(textBox_Door7.Text.Trim()) && int.TryParse(textBox_Door7.Text.Trim(), out temp))
                {
                    cfg.stuABLockInfo.stuDoors[num].nDoor = 7;
                    cfg.stuABLockInfo.stuDoors[num].anDoor[6] = temp;
                }
                if (!string.IsNullOrEmpty(textBox_Door8.Text.Trim()) && int.TryParse(textBox_Door8.Text.Trim(), out temp))
                {
                    cfg.stuABLockInfo.stuDoors[num].nDoor = 8;
                    cfg.stuABLockInfo.stuDoors[num].anDoor[7] = temp;
                }

                cfg.stuABLockInfo.nDoors = 0;
                for (int i = 0; i < 8; i++)
                {
                    int ndoor = cfg.stuABLockInfo.stuDoors[i].nDoor;
                    if (ndoor == 0)
                    {
                        cfg.stuABLockInfo.nDoors = i;
                        break;
                    }
                    else if (i == 7)
                    {
                        cfg.stuABLockInfo.nDoors = 8;
                    }
                } 
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
                bRet = NETClient.GetNewDevConfig(loginID, -1, CFG_CMD_ACCESS_GENERAL, ref objTemp, typeof(NET_CFG_ACCESS_GENERAL_INFO), 5000);
                if (bRet)
                {
                    cfg = (NET_CFG_ACCESS_GENERAL_INFO)objTemp;
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

        public bool SetConfig(NET_CFG_ACCESS_GENERAL_INFO cfg)
        {
            bool bRet = false;
            try
            {
                bRet = NETClient.SetNewDevConfig(loginID, -1, CFG_CMD_ACCESS_GENERAL, (object)cfg, typeof(NET_CFG_ACCESS_GENERAL_INFO), 5000);
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

        private void comboBox_Door_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = comboBox_Door.SelectedIndex;

  //          if (cfg.stuABLockInfo.stuDoors[num].nDoor < 1)
  //          {

                textBox_Door1.Text = "";
                textBox_Door2.Text = "";
                textBox_Door3.Text = "";
                textBox_Door4.Text = "";
                textBox_Door5.Text = "";
                textBox_Door6.Text = "";
                textBox_Door7.Text = "";
                textBox_Door8.Text = "";
  //          }

            if (num < 0)
            {
                return;
            }
            if (num > cfg.stuABLockInfo.nDoors || cfg.stuABLockInfo.nDoors < 1)
            {
                return;
            }
            if (cfg.stuABLockInfo.stuDoors[num].nDoor >= 1)
            {
                textBox_Door1.Text = cfg.stuABLockInfo.stuDoors[num].anDoor[0].ToString();
            }
            if (cfg.stuABLockInfo.stuDoors[num].nDoor >= 2)
            {
                textBox_Door2.Text = cfg.stuABLockInfo.stuDoors[num].anDoor[1].ToString();
            }
            if (cfg.stuABLockInfo.stuDoors[num].nDoor >= 3)
            {
                textBox_Door3.Text = cfg.stuABLockInfo.stuDoors[num].anDoor[2].ToString();
            }
            if (cfg.stuABLockInfo.stuDoors[num].nDoor >= 4)
            {
                textBox_Door4.Text = cfg.stuABLockInfo.stuDoors[num].anDoor[3].ToString();
            }
            if (cfg.stuABLockInfo.stuDoors[num].nDoor >= 5)
            {
                textBox_Door5.Text = cfg.stuABLockInfo.stuDoors[num].anDoor[4].ToString();
            }
            if (cfg.stuABLockInfo.stuDoors[num].nDoor >= 6)
            {
                textBox_Door6.Text = cfg.stuABLockInfo.stuDoors[num].anDoor[5].ToString();
            }
            if (cfg.stuABLockInfo.stuDoors[num].nDoor >= 7)
            {
                textBox_Door7.Text = cfg.stuABLockInfo.stuDoors[num].anDoor[6].ToString();
            }
            if (cfg.stuABLockInfo.stuDoors[num].nDoor >= 8)
            {
                textBox_Door8.Text = cfg.stuABLockInfo.stuDoors[num].anDoor[7].ToString();
            }
        }
        public void UIClear()
        {

            checkBox_Enable.Checked = false;
            comboBox_Door.SelectedIndex = -1;
            textBox_Door1.Text = "";
            textBox_Door2.Text = "";
            textBox_Door3.Text = "";
            textBox_Door4.Text = "";
            textBox_Door5.Text = "";
            textBox_Door6.Text = "";
            textBox_Door7.Text = "";
            textBox_Door8.Text = "";
        }

        private void ABLock_Load(object sender, EventArgs e)
        {
            if (GetConfig())
            {
           //     MessageBox.Show("Get successfully");
                checkBox_Enable.Checked = cfg.stuABLockInfo.bEnable;
                comboBox_Door.SelectedIndex = 0;
            }
        }
    }
}
