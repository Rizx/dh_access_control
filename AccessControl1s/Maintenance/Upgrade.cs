using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetSDKCS;
using System.Threading;

namespace AccessControl1s
{

    public partial class Upgrade : Form
    {
        IntPtr loginID = IntPtr.Zero;

        IntPtr result = IntPtr.Zero;

        AccessControlForm mainWindow;

        private static fUpgradeCallBack m_UpgradeCallBack;

        
       // public byte[] imageData;

        public Upgrade(IntPtr id, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id; 
            mainWindow = main;
            m_UpgradeCallBack = new fUpgradeCallBack(UpgradeCallBack);
        }

        private void button_OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "所有文件(*.*)|*.*";
            var ret = openFileDialog.ShowDialog();
            if (ret == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string path = openFileDialog.FileName;
                    textBox_Path.Text = openFileDialog.FileName;
                    button_Upgrade.Enabled = true;
                    button_StopUpgrade.Enabled = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            openFileDialog.Dispose();
        }

        #region CallBack 回调
        void UpgradeCallBack(IntPtr lLoginID, IntPtr lUpgradechannel, int nTotalSize, int nSendSize, IntPtr dwUser)
        {
            try
            {
             if (lLoginID != null && lUpgradechannel != null)
            {
                this.BeginInvoke(new Action(() =>
                {
                    if (nTotalSize == 0)
                    {
                        if (nSendSize == -1)
                        {
                            textBox_UpgrageState.Text = DateTime.Now.ToString("HH:mm:ss") + "Upgrade succeed(升级成功)";
                            button_Upgrade.Enabled = true;
                            button_StopUpgrade.Enabled = false;
                        
                        }
                        else if (nSendSize == -2)
                        {
                            textBox_UpgrageState.Text = DateTime.Now.ToString("HH:mm:ss") + "Upgrade failed(升级失败)";
                            button_Upgrade.Enabled = true;
                            button_StopUpgrade.Enabled = false;
                        }

                        if (IntPtr.Zero == result)
                        {
                            return;
                        }
                        try
                        {
                            NETClient.StopUpgrade(result);
                            result = IntPtr.Zero;
                        }
                        catch (Exception)
                        {
                        }
                    
                    }
                    else if (nTotalSize > 0)
                    {
                        double dProgress = 0;
                        dProgress = nSendSize / (double)nTotalSize * 100;
                        dProgress = (int)dProgress;
                        if (dProgress <= 0)
                        {
                            dProgress = 0;
                        }
                        if (dProgress > 99)
                        {
                            dProgress = 100;                       
                        }

                        textBox_UpgrageState.Text = DateTime.Now.ToString("HH:mm:ss") + "Upgrade Progress(升级进度)：" + dProgress.ToString() + "%" + nSendSize.ToString() + "/" + nTotalSize.ToString();
                        progressBar_Upgrade.Value = (int)dProgress;
                    }
                })); 
            }

            }
            catch (Exception )
            {

            }
        }
        #endregion

        private void button_Upgrade_Click(object sender, EventArgs e)
        {
            #region upgrade device 升级设备
            button_Upgrade.Enabled = false;
            button_StopUpgrade.Enabled = true;

            if (IntPtr.Zero != result)
            {
                try
                {
                    bool ret = NETClient.StopUpgrade(result);
                    if (ret)
                    {
                        result = IntPtr.Zero;
                    }
                }
                catch (Exception)
                {

                }
            }

            if (textBox_Path.Text == null || textBox_Path.Text == "")
            {
                MessageBox.Show("please choose a upgrade packet file.(请选择远程升级包)");
                return;
            }

            IntPtr inPtr = IntPtr.Zero;

            result = NETClient.StartUpgrade(loginID, EM_UPGRADE_TYPE.BIOS_TYPE, textBox_Path.Text, m_UpgradeCallBack, inPtr);
            if (result != null && result != IntPtr.Zero)
            {
                bool bRet = NETClient.SendUpgrade(result);
                if (!bRet)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    button_Upgrade.Enabled = true;
                    button_StopUpgrade.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show(NETClient.GetLastError());
                button_Upgrade.Enabled = true;
                button_StopUpgrade.Enabled = false;
            }
            #endregion
        }

        private void button_StopUpgrade_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == result)
            {
                return;
            }
            bool ret = NETClient.StopUpgrade(result);
            if (ret)
            {
                result = IntPtr.Zero;
                button_Upgrade.Enabled = true;
                button_StopUpgrade.Enabled = false;
            }
            else
            {
                MessageBox.Show(NETClient.GetLastError());
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (IntPtr.Zero == result)
            {
                return;
            }
            try
            {
                bool ret = NETClient.StopUpgrade(result);
                if (ret)
                {
                    result = IntPtr.Zero;
                }
            }
            catch (Exception)
            {

            }

            base.OnClosing(e);
        }
    }

}
