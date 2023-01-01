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
    public partial class AutoMatrix : Form
    {
        IntPtr loginID = IntPtr.Zero;

        AccessControlForm mainWindow;
        public AutoMatrix(IntPtr id, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
            mainWindow = main;
        }

        private void AutoMatrix_Load(object sender, EventArgs e)
        {
            #region load auto matrix config 
            GetDevConfig_AutoMT();
            comboBox_RebootDay.SelectedIndex = cfg_AutoMT.byAutoRebootDay;
            comboBox_RebootTime.SelectedIndex = cfg_AutoMT.byAutoRebootTime;
            #endregion

        }

        private void button_GetAutoMatrix_Click(object sender, EventArgs e)
        {
            #region Get auto matrix config
            GetDevConfig_AutoMT();
            comboBox_RebootDay.SelectedIndex = cfg_AutoMT.byAutoRebootDay;
            comboBox_RebootTime.SelectedIndex = cfg_AutoMT.byAutoRebootTime;
            #endregion
        }

        private void button_SetAutoMatrix_Click(object sender, EventArgs e)
        {
            #region Set auto matrix config
     //       GetDevConfig_AutoMT();
            cfg_AutoMT.byAutoRebootDay = (byte)comboBox_RebootDay.SelectedIndex;
            cfg_AutoMT.byAutoRebootTime = (byte)comboBox_RebootTime.SelectedIndex;
            IntPtr inPtr = IntPtr.Zero;
            inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_DEV_AUTOMT_CFG)));
            Marshal.StructureToPtr(cfg_AutoMT, inPtr, true);
            bool result = NETClient.SetDevConfig(loginID, EM_DEV_CFG_TYPE.AUTOMTCFG, 0, inPtr, (uint)Marshal.SizeOf(typeof(NET_DEV_AUTOMT_CFG)), 5000);
            if (!result)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
 //           MessageBox.Show("Set successfully.");
            #endregion

        }

        NET_DEV_AUTOMT_CFG cfg_AutoMT = new NET_DEV_AUTOMT_CFG();
        public NET_DEV_AUTOMT_CFG GetDevConfig_AutoMT()
        {
            uint ret = 0;
            IntPtr inPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_DEV_AUTOMT_CFG)));
                Marshal.StructureToPtr(cfg_AutoMT, inPtr, true);
                bool result = NETClient.GetDevConfig(loginID, EM_DEV_CFG_TYPE.AUTOMTCFG, 0, inPtr, (uint)Marshal.SizeOf(typeof(NET_DEV_AUTOMT_CFG)), ref ret, 5000);
                if (result && ret == (uint)Marshal.SizeOf(typeof(NET_DEV_AUTOMT_CFG)))
                {
                    cfg_AutoMT = (NET_DEV_AUTOMT_CFG)Marshal.PtrToStructure(inPtr, typeof(NET_DEV_AUTOMT_CFG));
                }
                else
                {
                    MessageBox.Show(NETClient.GetLastError());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
            }
            return cfg_AutoMT;
        }
    }
}
