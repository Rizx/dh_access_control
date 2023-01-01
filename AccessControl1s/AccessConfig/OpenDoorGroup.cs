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
    public partial class OpenDoorGroup : Form
    {
        IntPtr loginID = IntPtr.Zero;

        private int m_Channel = 0;
        private NET_CFG_OPEN_DOOR_GROUP_INFO cfg_info = new NET_CFG_OPEN_DOOR_GROUP_INFO();

        private const string CFG_CMD_OPEN_DOOR_GROUP = "OpenDoorGroup";

        AccessControlForm mainWindow;

        public OpenDoorGroup(IntPtr id, int channel, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
            m_Channel = channel;
            mainWindow = main;
        }

        private void OpenDoorGroup_Load(object sender, EventArgs e)
        {
            comboBox_Door.Items.Clear();
            
            if (m_Channel > 0)
            {
                for (int i = 1; i <= m_Channel; i++)
                {
                    comboBox_Door.Items.Add(i);
                }
                comboBox_Door.SelectedIndex = 0;
            }

            if (GetConfig())
            {
           //     MessageBox.Show("Get successfully");

                if (cfg_info.nGroup >= 1)
                {
                    textBox_OpenNum1.Text = cfg_info.stuGroupInfo[0].nUserCount.ToString();

                    comboBox_UserNo1.SelectedIndex = 0;

                }
                if (cfg_info.nGroup >= 2)
                {
                    textBox_OpenNum2.Text = cfg_info.stuGroupInfo[1].nUserCount.ToString();
                    comboBox_UserNo2.SelectedIndex = 0;
                }
                if (cfg_info.nGroup >= 3)
                {
                    textBox_OpenNum3.Text = cfg_info.stuGroupInfo[2].nUserCount.ToString();
                    comboBox_UserNo3.SelectedIndex = 0;
                }
                if (cfg_info.nGroup >= 4)
                {
                    textBox_OpenNum4.Text = cfg_info.stuGroupInfo[3].nUserCount.ToString();
                    comboBox_UserNo4.SelectedIndex = 0;
                }
            }
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            UIClear();
            if (GetConfig())
            {
                MessageBox.Show("Get successfully");

                if (cfg_info.nGroup >= 1)
                {
                    textBox_OpenNum1.Text = cfg_info.stuGroupInfo[0].nUserCount.ToString();

                    comboBox_UserNo1.SelectedIndex = 0;
                    
                }
                if (cfg_info.nGroup >= 2)
                {
                    textBox_OpenNum2.Text = cfg_info.stuGroupInfo[1].nUserCount.ToString();
                    comboBox_UserNo2.SelectedIndex = 0;
                }
                if (cfg_info.nGroup >= 3)
                {
                    textBox_OpenNum3.Text = cfg_info.stuGroupInfo[2].nUserCount.ToString();
                    comboBox_UserNo3.SelectedIndex = 0;
                }
                if (cfg_info.nGroup >= 4)
                {
                    textBox_OpenNum4.Text = cfg_info.stuGroupInfo[3].nUserCount.ToString();
                    comboBox_UserNo4.SelectedIndex = 0;
                }
            }
        }

        private void button_Set_Click(object sender, EventArgs e)
        {
            try
            {
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                if (!string.IsNullOrEmpty(textBox_OpenNum1.Text.Trim())) 
                {
                    num1 = int.Parse(textBox_OpenNum1.Text);
                }
                if (!string.IsNullOrEmpty(textBox_OpenNum2.Text.Trim()))
                {
                    num2 = int.Parse(textBox_OpenNum2.Text);
                }
                if (!string.IsNullOrEmpty(textBox_OpenNum3.Text.Trim()))
                {
                    num3 = int.Parse(textBox_OpenNum3.Text);
                }
                if (!string.IsNullOrEmpty(textBox_OpenNum4.Text.Trim()))
                {
                    num4 = int.Parse(textBox_OpenNum4.Text);
                }

                if (num1 + num2 + num3 + num4 > 5)
                {
                    MessageBox.Show("The effective number cannot be greater than 5(有效数不能大于5)！");
                    return;
                }

                cfg_info.stuGroupInfo[0].nUserCount = num1;

                int select_num = comboBox_UserNo1.SelectedIndex;
                if (select_num >= 0)
                {
                    cfg_info.stuGroupInfo[0].stuGroupDetail[select_num].szUserID = textBox_UserID1.Text;
                    cfg_info.stuGroupInfo[0].stuGroupDetail[select_num].emMethod = GetOpenMethodEnum(comboBox_OpenMethod1.SelectedIndex);
                }

                for (int i = 0; i < cfg_info.stuGroupInfo[0].stuGroupDetail.Length; i++)
                {
                    if (string.IsNullOrEmpty(cfg_info.stuGroupInfo[0].stuGroupDetail[i].szUserID))
                    {
                        cfg_info.stuGroupInfo[0].nGroupNum = i;
                        break;
                    }
                }


                cfg_info.stuGroupInfo[1].nUserCount = num2;

                select_num = comboBox_UserNo2.SelectedIndex;
                if (select_num >= 0)
                {
                    cfg_info.stuGroupInfo[1].stuGroupDetail[select_num].szUserID = textBox_UserID2.Text;
                    cfg_info.stuGroupInfo[1].stuGroupDetail[select_num].emMethod = GetOpenMethodEnum(comboBox_OpenMethod2.SelectedIndex);
                }
                for (int i = 0; i < cfg_info.stuGroupInfo[1].stuGroupDetail.Length; i++)
                {
                    if (string.IsNullOrEmpty(cfg_info.stuGroupInfo[1].stuGroupDetail[i].szUserID))
                    {
                        cfg_info.stuGroupInfo[1].nGroupNum = i;
                        break;
                    }
                }


                cfg_info.stuGroupInfo[2].nUserCount = num3;

                select_num = comboBox_UserNo3.SelectedIndex;
                if (select_num >= 0)
                {
                    cfg_info.stuGroupInfo[2].stuGroupDetail[select_num].szUserID = textBox_UserID3.Text;
                    cfg_info.stuGroupInfo[2].stuGroupDetail[select_num].emMethod = GetOpenMethodEnum(comboBox_OpenMethod3.SelectedIndex);
                }
                for (int i = 0; i < cfg_info.stuGroupInfo[2].stuGroupDetail.Length; i++)
                {
                    if (string.IsNullOrEmpty(cfg_info.stuGroupInfo[2].stuGroupDetail[i].szUserID))
                    {
                        cfg_info.stuGroupInfo[2].nGroupNum = i;
                        break;
                    }
                }


                cfg_info.stuGroupInfo[3].nUserCount = num4;

                select_num = comboBox_UserNo4.SelectedIndex;
                if (select_num >= 0)
                {
                    cfg_info.stuGroupInfo[3].stuGroupDetail[select_num].szUserID = textBox_UserID4.Text;
                    cfg_info.stuGroupInfo[3].stuGroupDetail[select_num].emMethod = GetOpenMethodEnum(comboBox_OpenMethod4.SelectedIndex);
                }
                for (int i = 0; i < cfg_info.stuGroupInfo[3].stuGroupDetail.Length; i++)
                {
                    if (string.IsNullOrEmpty(cfg_info.stuGroupInfo[3].stuGroupDetail[i].szUserID))
                    {
                        cfg_info.stuGroupInfo[3].nGroupNum = i;
                        break;
                    }
                }

                cfg_info.nGroup = 4;
                for (int i = 0; i < 4; i++)
                {
                    if (cfg_info.stuGroupInfo[i].nGroupNum == 0)
                    {
                        cfg_info.nGroup = i;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (SetConfig(cfg_info))
            {
                MessageBox.Show("Set successfully");
            }
        }

        public bool GetConfig()
        {
            bool bRet = false;
            try
            {
                cfg_info.stuGroupInfo = new NET_CFG_OPEN_DOOR_GROUP[4];
                for (int i = 0; i < cfg_info.stuGroupInfo.Length; i++)
                {
                    cfg_info.stuGroupInfo[i].stuGroupDetail = new NET_CFG_OPEN_DOOR_GROUP_DETAIL[64];
                }

                object objTemp = cfg_info;
                bRet = NETClient.GetNewDevConfig(loginID, comboBox_Door.SelectedIndex, CFG_CMD_OPEN_DOOR_GROUP, ref objTemp, typeof(NET_CFG_OPEN_DOOR_GROUP_INFO), 10000);
                if (bRet)
                {
                    cfg_info = (NET_CFG_OPEN_DOOR_GROUP_INFO)objTemp;
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

        public bool SetConfig(NET_CFG_OPEN_DOOR_GROUP_INFO cfg)
        {
            bool bRet = false;
            try
            {
                bRet = NETClient.SetNewDevConfig(loginID, comboBox_Door.SelectedIndex, CFG_CMD_OPEN_DOOR_GROUP, (object)cfg, typeof(NET_CFG_OPEN_DOOR_GROUP_INFO), 5000);
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

        public int GetOpenMethodSelectedIndex(EM_CFG_OPEN_DOOR_GROUP_METHOD em)
        {
            int result = 0;
            switch (em)
            {
                case EM_CFG_OPEN_DOOR_GROUP_METHOD.CARD:
                    result = 1;
                    break;
                case EM_CFG_OPEN_DOOR_GROUP_METHOD.FINGERPRINT:
                    result = 2;
                    break;
                case EM_CFG_OPEN_DOOR_GROUP_METHOD.PWD:
                    result = 3;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

        public EM_CFG_OPEN_DOOR_GROUP_METHOD GetOpenMethodEnum(int index)
        {
            EM_CFG_OPEN_DOOR_GROUP_METHOD value = EM_CFG_OPEN_DOOR_GROUP_METHOD.UNKNOWN;
            switch (index)
            {
                case 1:
                    value = EM_CFG_OPEN_DOOR_GROUP_METHOD.CARD;
                    break;
                case 2:
                    value = EM_CFG_OPEN_DOOR_GROUP_METHOD.FINGERPRINT;
                    break;
                case 3:
                    value = EM_CFG_OPEN_DOOR_GROUP_METHOD.PWD;
                    break;
                default:
                    break;
            }
            return value;
        }

        public void UIClear()
        {
            textBox_OpenNum1.Text = "";
            textBox_OpenNum2.Text = "";
            textBox_OpenNum3.Text = "";
            textBox_OpenNum4.Text = "";

            textBox_UserID1.Text = "";
            textBox_UserID2.Text = "";
            textBox_UserID3.Text = "";
            textBox_UserID4.Text = "";
            comboBox_UserNo1.SelectedIndex = -1;
            comboBox_UserNo2.SelectedIndex = -1;
            comboBox_UserNo3.SelectedIndex = -1;
            comboBox_UserNo4.SelectedIndex = -1;
            comboBox_OpenMethod1.SelectedIndex = -1;
            comboBox_OpenMethod2.SelectedIndex = -1;
            comboBox_OpenMethod3.SelectedIndex = -1;
            comboBox_OpenMethod4.SelectedIndex = -1;
        }

        private void comboBox_UserNo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = comboBox_UserNo1.SelectedIndex;
            if (num < 0)
            {
                return;
            }
            if (cfg_info.nGroup >= 1)
            {
                textBox_UserID1.Text = cfg_info.stuGroupInfo[0].stuGroupDetail[num].szUserID;
                comboBox_OpenMethod1.SelectedIndex = GetOpenMethodSelectedIndex(cfg_info.stuGroupInfo[0].stuGroupDetail[num].emMethod);
            }
        }

        private void comboBox_UserNo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = comboBox_UserNo2.SelectedIndex;
            if (num < 0)
            {
                return;
            }
            if (cfg_info.nGroup >= 2)
            {
                textBox_UserID2.Text = cfg_info.stuGroupInfo[1].stuGroupDetail[num].szUserID;
                comboBox_OpenMethod2.SelectedIndex = GetOpenMethodSelectedIndex(cfg_info.stuGroupInfo[1].stuGroupDetail[num].emMethod);
            }
        }

        private void comboBox_UserNo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = comboBox_UserNo3.SelectedIndex;
            if (num < 0)
            {
                return;
            }
            if (cfg_info.nGroup >= 3)
            {
                textBox_UserID3.Text = cfg_info.stuGroupInfo[2].stuGroupDetail[num].szUserID;
                comboBox_OpenMethod3.SelectedIndex = GetOpenMethodSelectedIndex(cfg_info.stuGroupInfo[2].stuGroupDetail[num].emMethod);
            }
        }

        private void comboBox_UserNo4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = comboBox_UserNo4.SelectedIndex;
            if (num < 0)
            {
                return;
            }
            if (cfg_info.nGroup >= 4)
            {
                textBox_UserID4.Text = cfg_info.stuGroupInfo[3].stuGroupDetail[num].szUserID;
                comboBox_OpenMethod4.SelectedIndex = GetOpenMethodSelectedIndex(cfg_info.stuGroupInfo[3].stuGroupDetail[num].emMethod);
            }
        }
    }
}
