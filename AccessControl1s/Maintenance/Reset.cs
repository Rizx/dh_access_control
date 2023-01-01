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

    public partial class Reset : Form
    {
        IntPtr loginID = IntPtr.Zero;

        AccessControlForm mainWindow;
        public Reset(IntPtr id, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
            mainWindow = main;
        }

        private void button_ResetYes_Click(object sender, EventArgs e)
        {
            #region Reset Device
            NET_IN_RESET_SYSTEM stuResetIn = new NET_IN_RESET_SYSTEM();
            stuResetIn.dwSize = (uint)Marshal.SizeOf(typeof(NET_IN_USERINFO_START_FIND));

            NET_OUT_RESET_SYSTEM stuResetOut = new NET_OUT_RESET_SYSTEM();
            stuResetOut.dwSize = (uint)Marshal.SizeOf(typeof(NET_OUT_USERINFO_START_FIND));
            bool nRet = NETClient.ResetSystem(loginID, ref stuResetIn, ref stuResetOut, 5000);
            if (!nRet)
            {
                IntPtr inPtr = IntPtr.Zero;
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_RESTORE_TEMPSTRUCT)));
                NET_RESTORE_TEMPSTRUCT temp = new NET_RESTORE_TEMPSTRUCT() { value = NET_RESTORE.ALL };
                Marshal.StructureToPtr(temp, inPtr, true);
                bool ret = NETClient.ControlDevice(loginID, EM_CtrlType.RESTOREDEFAULT, inPtr, 10000);
                if (!ret)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
            }
            this.Hide();
            #endregion
        }

        private void button_ResetNo_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    } 
}
