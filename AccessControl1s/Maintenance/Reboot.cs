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

namespace AccessControl1s
{

    public partial class Reboot : Form
    {
        IntPtr loginID = IntPtr.Zero;

        AccessControlForm mainWindow;
        public Reboot(IntPtr id, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
            mainWindow = main;
        }

        private void button_RebootYes_Click(object sender, EventArgs e)
        {
            #region Reboot Device

            IntPtr inPtr = IntPtr.Zero;

            bool ret = NETClient.ControlDevice(loginID, EM_CtrlType.REBOOT, inPtr, 10000);
            if (!ret)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            this.Hide();
//            MessageBox.Show("Open Door success(开门成功)");
            #endregion
        }

        private void button_RebootNo_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
