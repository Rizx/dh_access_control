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
    public partial class Network : Form
    {
        IntPtr loginID = IntPtr.Zero;
        private CFG_NETWORK_INFO cfg = new CFG_NETWORK_INFO();
        private NET_CFG_DVRIP_INFO cfg_Dvrip = new NET_CFG_DVRIP_INFO();

        AccessControlForm mainWindow;
        public Network(IntPtr id, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
            mainWindow = main;
        }


        private void Network_Load(object sender, EventArgs e)
        {
            #region load network config 加载网络配置信息
            GetConfig_Network();
            for (int i = 0; i < cfg.nInterfaceNum; i++)
            {
                if (string.Equals(System.Text.Encoding.Default.GetString(cfg.szDefInterface), System.Text.Encoding.Default.GetString(cfg.stuInterfaces[i].szName)))
                {           
                    if (System.Text.Encoding.Default.GetString(cfg.stuInterfaces[i].szIP)[0] == 0
                        || System.Text.Encoding.Default.GetString(cfg.stuInterfaces[i].szSubnetMask)[0] == 0
                        || System.Text.Encoding.Default.GetString(cfg.stuInterfaces[i].szDefGateway)[0] == 0)
                    {
                        return;
                    }
                    else
                    {
                        this.textBox_IPNet.Text = System.Text.Encoding.Default.GetString(cfg.stuInterfaces[i].szIP);
                        this.textBox_Mask.Text = System.Text.Encoding.Default.GetString(cfg.stuInterfaces[i].szSubnetMask);
                        this.textBox_GateWay.Text = System.Text.Encoding.Default.GetString(cfg.stuInterfaces[i].szDefGateway);
                    }
                    
                }
            }
            #endregion


            #region load auto register config 加载主动注册配置信息

            object obj = cfg_Dvrip;
            bool ret = NETClient.GetNewDevConfig(loginID, -1, "DVRIP", ref obj, typeof(NET_CFG_DVRIP_INFO), 5000);
            if (!ret)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            cfg_Dvrip = (NET_CFG_DVRIP_INFO)obj;
            checkBox_Enable.Checked = cfg_Dvrip.stuRegister[0].bEnable;
            this.textBox_DevID.Text = cfg_Dvrip.stuRegister[0].szDeviceID;
            this.textBox_Port.Text = cfg_Dvrip.stuRegister[0].stuServers[0].nPort.ToString();
            this.textBox_DvripIP.Text = cfg_Dvrip.stuRegister[0].stuServers[0].szAddress;
            #endregion

        }

        private void button_SetNet_Click(object sender, EventArgs e)
        {
            #region Set network config 设置网络配置
            if (textBox_IPNet.Text == null || textBox_IPNet.Text == "")
            {
                MessageBox.Show("Please input IP address(请输入IP地址)");
                return;
            }
            if (textBox_Mask.Text == null || textBox_Mask.Text == "")
            {
                MessageBox.Show("Please input Mask(请输入子网掩码)");
                return;
            }
            if (textBox_GateWay.Text == null || textBox_GateWay.Text == "")
            {
                MessageBox.Show("Please input Gate Way(请输入网关地址)");
                return;
            }

    //        GetConfig_Network();
            for (int i = 0; i < cfg.nInterfaceNum; i++)
            {
                if (string.Equals("eth0", Encoding.Default.GetString(cfg.stuInterfaces[i].szName).Trim('\0')))
                {
                    cfg.stuInterfaces[i].szIP = new byte[256];
                    cfg.stuInterfaces[i].szSubnetMask = new byte[256];
                    cfg.stuInterfaces[i].szDefGateway = new byte[256];
                    Encoding.Default.GetBytes(textBox_IPNet.Text.Trim(), 0, textBox_IPNet.Text.Trim().Length, cfg.stuInterfaces[i].szIP, 0);
                    Encoding.Default.GetBytes(textBox_Mask.Text.Trim(), 0, textBox_Mask.Text.Trim().Length, cfg.stuInterfaces[i].szSubnetMask, 0);
                    Encoding.Default.GetBytes(textBox_GateWay.Text.Trim(), 0, textBox_GateWay.Text.Trim().Length, cfg.stuInterfaces[i].szDefGateway, 0);
                } 
            }
            bool bRet = SetConfig_Network(cfg);
            if (!bRet)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            MessageBox.Show("Set Success(设置成功)");

            #endregion
        }

        private void button_GetNet_Click(object sender, EventArgs e)
        {
            #region Get network config 获取网络配置信息
            GetConfig_Network();
            for (int i = 0; i < cfg.nInterfaceNum; i++)
            {
                if (string.Equals(System.Text.Encoding.Default.GetString(cfg.szDefInterface), System.Text.Encoding.Default.GetString(cfg.stuInterfaces[i].szName)))
                {
                    if (System.Text.Encoding.Default.GetString(cfg.stuInterfaces[i].szIP)[0] == 0
                        || System.Text.Encoding.Default.GetString(cfg.stuInterfaces[i].szSubnetMask)[0] == 0
                        || System.Text.Encoding.Default.GetString(cfg.stuInterfaces[i].szDefGateway)[0] == 0)
                    {
                        return;
                    }
                    else
                    {
                        this.textBox_IPNet.Text = System.Text.Encoding.Default.GetString(cfg.stuInterfaces[i].szIP);
                        this.textBox_Mask.Text = System.Text.Encoding.Default.GetString(cfg.stuInterfaces[i].szSubnetMask);
                        this.textBox_GateWay.Text = System.Text.Encoding.Default.GetString(cfg.stuInterfaces[i].szDefGateway);
                    }

                }
            }
            #endregion
        }

        
        public CFG_NETWORK_INFO GetConfig_Network()
        {
            try
            {
                object objTemp = new object();
                bool bRet = NETClient.GetNewDevConfig(loginID, -1, "Network", ref objTemp, typeof(CFG_NETWORK_INFO), 5000);
                if (!bRet)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return cfg;
                }
                cfg = (CFG_NETWORK_INFO)objTemp;
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


        public bool SetConfig_Network(CFG_NETWORK_INFO cfg)
        {
            bool bRet = false;
            try
            {
                bRet = NETClient.SetNewDevConfig(loginID, -1, "Network", (object)cfg, typeof(CFG_NETWORK_INFO), 5000);
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



  //      NET_CFG_DVRIP_INFO cfg_Dvrip = new NET_CFG_DVRIP_INFO();
        public NET_CFG_DVRIP_INFO GetConfig_Dvrip()
        {
            try
            {
                object objTemp = new object();
                bool bRet = NETClient.GetNewDevConfig(loginID, -1, "DVRIP", ref objTemp, typeof(NET_CFG_DVRIP_INFO), 5000);
                if (bRet)
                {
                    cfg_Dvrip = (NET_CFG_DVRIP_INFO)objTemp;
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
            return cfg_Dvrip;
        }


        public bool SetConfig_Dvrip(NET_CFG_DVRIP_INFO cfg_Dvrip)
        {
            bool bRet = false;
            try
            {
                bRet = NETClient.SetNewDevConfig(loginID, -1, "DVRIP", (object)cfg_Dvrip, typeof(NET_CFG_DVRIP_INFO), 5000);
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

        private void button_SetAutoCfg_Click(object sender, EventArgs e)
        {
            #region Set Dvrip config 设置主动注册配置
            if (textBox_DvripIP.Text == null || textBox_DvripIP.Text == "")
            {
                MessageBox.Show("Please input register IP(请输入注册IP地址)");
                return;
            }
            if (textBox_DevID.Text == null || textBox_DevID.Text == "")
            {
                MessageBox.Show("Please input device ID(请输入设备ID)");
                return;
            }
            if (textBox_Port.Text == null || textBox_Port.Text == "")
            {
                MessageBox.Show("Please input register Port(请输入注册端口号)");
                return;
            }
            ushort port;
            try
            {
                port = Convert.ToUInt16(textBox_Port.Text.Trim());
            }
            catch
            {
                MessageBox.Show("The register port is error,the value must be 1-65535(注册端口号错误，值为1-65535)");
                return;
            }
        //    GetConfig_Dvrip();
            cfg_Dvrip.nRegistersNum = 1;
            cfg_Dvrip.stuRegister[0].szDeviceID = textBox_DevID.Text.Trim();
            cfg_Dvrip.stuRegister[0].stuServers[0].szAddress = textBox_DvripIP.Text.Trim();
            cfg_Dvrip.stuRegister[0].stuServers[0].nPort = port;
            cfg_Dvrip.stuRegister[0].bEnable = this.checkBox_Enable.Checked;
            cfg_Dvrip.stuRegister[0].nServersNum = 1;
            bool bRet = SetConfig_Dvrip(cfg_Dvrip);
            if (!bRet)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            MessageBox.Show("Set Success(设置成功)");
            #endregion
        }

        private void button_GetAutoCfg_Click(object sender, EventArgs e)
        {
            #region Get auto register config 获取主动注册配置信息

            object obj = cfg_Dvrip;
            bool ret = NETClient.GetNewDevConfig(loginID, -1, "DVRIP", ref obj, typeof(NET_CFG_DVRIP_INFO), 5000);
            if (!ret)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            cfg_Dvrip = (NET_CFG_DVRIP_INFO)obj;
            checkBox_Enable.Checked = cfg_Dvrip.stuRegister[0].bEnable;
            this.textBox_DevID.Text = cfg_Dvrip.stuRegister[0].szDeviceID;
            this.textBox_Port.Text = cfg_Dvrip.stuRegister[0].stuServers[0].nPort.ToString();
            this.textBox_DvripIP.Text = cfg_Dvrip.stuRegister[0].stuServers[0].szAddress;
            #endregion
        }
    }
}
