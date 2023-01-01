using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using NetSDKCS;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AccessControl1s
{
    public partial class DeviceInfo : Form
    {
        IntPtr loginID = IntPtr.Zero;

        AccessControlForm mainWindow;

        public DeviceInfo(IntPtr id, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
           
            mainWindow = main;
        }

        private void DeviceInfo_Load(object sender, EventArgs e)
        {

        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            #region Query Access control caps

            textBox_Caps.Text = "";
            textBox_Version.Text = "";

            int nCount = 0;
            CFG_CAP_ACCESSCONTROL info = new CFG_CAP_ACCESSCONTROL();
            object obj = info;
            string strCommand = SDK_DEVCONFIG_CMD.NET_CFG_CAP_CMD_ACCESSCONTROLMANAGER;
            try
            {
                bool bQuery = NETClient.QueryNewSystemInfo(loginID, -1, strCommand, ref obj, typeof(CFG_CAP_ACCESSCONTROL), 3000);
                if (bQuery)
                {
                    nCount = ((CFG_CAP_ACCESSCONTROL)obj).nAccessControlGroups;
                    textBox_Caps.Text = "Access Control Caps:" + System.Environment.NewLine + "Access Control Num(门禁个数)=" + nCount.ToString() + System.Environment.NewLine + System.Environment.NewLine;
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

            #region Query Record Finder caps
            NET_CFG_CAP_RECORDFINDER_INFO RecordInfo = new NET_CFG_CAP_RECORDFINDER_INFO();
            obj = RecordInfo;
            strCommand = SDK_DEVCONFIG_CMD.NET_CFG_CAP_CMD_RECORDFINDER;
            try
            {
                bool bQuery = NETClient.QueryNewSystemInfo(loginID, 0, strCommand, ref obj, typeof(NET_CFG_CAP_RECORDFINDER_INFO), 3000);
                if (bQuery)
                {
                    int nMaxPageSize = ((NET_CFG_CAP_RECORDFINDER_INFO)obj).nMaxPageSize;
                    textBox_Caps.Text += "RecordSetFinder Cap:" + System.Environment.NewLine + "MaxPageSize=" + nMaxPageSize.ToString() + System.Environment.NewLine + System.Environment.NewLine;
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

            #region Query log caps
            NET_CFG_CAP_LOG LogInfo = new NET_CFG_CAP_LOG();
            obj = LogInfo;
            strCommand = SDK_DEVCONFIG_CMD.NET_CFG_CAP_CMD_LOG;
            try
            {
                bool bQuery = NETClient.QueryNewSystemInfo(loginID, 0, strCommand, ref obj, typeof(NET_CFG_CAP_LOG), 3000);

                if (bQuery)
                {
                    int dwMaxLogItems = (int)((NET_CFG_CAP_LOG)obj).dwMaxLogItems;
                    int dwMaxPageItems = (int)((NET_CFG_CAP_LOG)obj).dwMaxPageItems;
                    string strSupportStartNo = "";
                    if (((NET_CFG_CAP_LOG)obj).bSupportStartNo)
                    {
                        strSupportStartNo = "Yes";
                    }
                    else
                    {
                        strSupportStartNo = "No";   
                    }

                    string strSupportTypeFilter = "";
                    if (((NET_CFG_CAP_LOG)obj).bSupportTypeFilter)
                    {
                        strSupportTypeFilter = "Yes";
                    }
                    else
                    {
                        strSupportTypeFilter = "No";   
                    }

                    string strSupportTimeFilter = "";
                    if (((NET_CFG_CAP_LOG)obj).bSupportTimeFilter)
                    {
                        strSupportTimeFilter = "Yes";
                    }
                    else
                    {
                        strSupportTimeFilter = "No";
                    }
                    textBox_Caps.Text += "Log Cap:" + System.Environment.NewLine + "LogMaxItem=" + dwMaxLogItems.ToString() + System.Environment.NewLine;
                    textBox_Caps.Text += "MaxPageLogItem=" + dwMaxPageItems.ToString() + System.Environment.NewLine;
                    textBox_Caps.Text += "IsSupportStartNo=" + strSupportStartNo + System.Environment.NewLine;
                    textBox_Caps.Text += "IsSupportTypeFilter=" + strSupportTypeFilter + System.Environment.NewLine;
                    textBox_Caps.Text += "IsSupportTimeFilter=" + strSupportTimeFilter + System.Environment.NewLine;
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

            #region Query Version info
            if (AccessControlForm.m_bOnline)
            {
                NET_DEV_VERSION_INFO VersionInfo = new NET_DEV_VERSION_INFO();
                object objInfo = VersionInfo;
                bool ret = NETClient.QueryDevState(loginID, EM_DEVICE_STATE.SOFTWARE, ref objInfo, typeof(NET_DEV_VERSION_INFO), 10000);
                if (ret)
                {
                    VersionInfo = (NET_DEV_VERSION_INFO)objInfo;

                    textBox_Version.Text += "SerialNo：" + VersionInfo.szDevSerialNo + System.Environment.NewLine;
                    textBox_Version.Text += "SoftwareVersion：" + VersionInfo.szSoftWareVersion + System.Environment.NewLine;
                    textBox_Version.Text += "ReleaseTime：" + ((VersionInfo.dwSoftwareBuildDate >> 16) & 0xffff) + "-" + ((VersionInfo.dwSoftwareBuildDate >> 8) & 0xff) + "-" + (VersionInfo.dwSoftwareBuildDate & 0xff) + System.Environment.NewLine;
                }
            }


            // Query MAC address
            NET_DEV_NETINTERFACE_INFO[] stuNetInfo = new NET_DEV_NETINTERFACE_INFO[64];
            
            for (int i = 0; i < 64; i++)
			{
                stuNetInfo[i].dwSize = (int)Marshal.SizeOf(stuNetInfo[i].GetType());			 
			}
            object[] objInfo2 = new object[64];
            for (int i = 0; i < 64; i++)
            {
                objInfo2[i] = stuNetInfo[i];
            }
            bool Macret = NETClient.QueryDevState(loginID, (int)EM_DEVICE_STATE.NETINTERFACE, ref objInfo2, typeof(NET_DEV_NETINTERFACE_INFO), 5000);
            if (Macret)
            {
                for (int i = 0; i < objInfo2.Length; i++)
                {
                    stuNetInfo[i] = (NET_DEV_NETINTERFACE_INFO)objInfo2[i];
                }
                textBox_Version.Text += "MAC：" + stuNetInfo[0].szMAC + System.Environment.NewLine;
            }


            /*
            // Query MCUVersion 获取单片机软件版本号
            IntPtr inSysPtr = IntPtr.Zero;
            IntPtr outSysPtr = IntPtr.Zero;
            NET_IN_SYSTEM_INFO stuSysInfo = new NET_IN_SYSTEM_INFO();
            stuSysInfo.dwSize = (uint)Marshal.SizeOf(typeof(NET_IN_SYSTEM_INFO));
            inSysPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_IN_SYSTEM_INFO)));
            Marshal.StructureToPtr(stuSysInfo, inSysPtr, true);

            NET_OUT_SYSTEM_INFO stuSysOut = new NET_OUT_SYSTEM_INFO();
            stuSysOut.dwSize = (uint)Marshal.SizeOf(typeof(NET_OUT_SYSTEM_INFO));
            outSysPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_OUT_SYSTEM_INFO)));
            Marshal.StructureToPtr(stuSysOut, outSysPtr, true);
            
            bool bSys = NETClient.QueryDevInfo(loginID, EM_QUERY_DEV_INFO.SYSTEM_INFO, inSysPtr, outSysPtr, 5000);
            if (!bSys)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            stuSysOut = (NET_OUT_SYSTEM_INFO)Marshal.PtrToStructure(outSysPtr, typeof(NET_OUT_SYSTEM_INFO));
   //         textBox_Version.Text += "MCUVersion(芯片版本):" + stuSysOut.szMCUVersion[0].szMCUVersion;
            */
            #endregion
        }
    }
}
