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


    public partial class ModifyPwd : Form
    {
        IntPtr loginID = IntPtr.Zero;

        AccessControlForm mainWindow;

        public ModifyPwd(IntPtr id, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
            mainWindow = main;
        }

        private void ModifyPwd_Load(object sender, EventArgs e)
        {

        }

        private void button_Modify_Click(object sender, EventArgs e)
        {
            #region Modify Password 修改密码
            if (textBox_User.Text == null || textBox_User.Text == "")
            {
                MessageBox.Show("Please input user name(请输入用户名)");
                return;
            }
            if (textBox_OldPasswd.Text == null || textBox_OldPasswd.Text == "")
            {
                MessageBox.Show("Please input old password(请输入旧用户名)");
                return;
            }
            if (textBox_NewPasswd.Text == null || textBox_NewPasswd.Text == "")
            {
                MessageBox.Show("Please input new password(请输入新密码)");
                return;
            }
            if (textBox_Repeat.Text == null || textBox_Repeat.Text == "")
            {
                MessageBox.Show("Please input check password(请输入确认密码)");
                return;
            }
            if (textBox_Repeat.Text != textBox_NewPasswd.Text)
            {
                MessageBox.Show("Two passwords are different, please check again.(两个密码不一致，请确认)");
                return;
            }

            NET_USER_INFO_NEW userInfo = new NET_USER_INFO_NEW();
            userInfo.dwSize = (uint)Marshal.SizeOf(typeof(NET_USER_INFO_NEW));
            userInfo.name =  textBox_User.Text.Trim();
            userInfo.passWord = textBox_OldPasswd.Text.Trim();
            IntPtr inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_USER_INFO_NEW)));


            NET_USER_INFO_NEW stuModifyInfo = new NET_USER_INFO_NEW();
            stuModifyInfo.dwSize = (uint)Marshal.SizeOf(typeof(NET_USER_INFO_NEW));
            stuModifyInfo.passWord = textBox_NewPasswd.Text.Trim();
            IntPtr insubPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_USER_INFO_NEW)));
            try
            {

                Marshal.StructureToPtr(userInfo, inPtr, true);

                Marshal.StructureToPtr(stuModifyInfo, insubPtr, true);

                bool ret = NETClient.OperateUserInfoNew(loginID, EM_OPERATE_USER_TYPE.MODIFY_PASSWORD, insubPtr, inPtr, 10000);
                if (!ret)
                {
                    MessageBox.Show( NETClient.GetLastError());
                    return;
                }
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
                Marshal.FreeHGlobal(insubPtr);
            }
            MessageBox.Show("Modify password successfully.(修改密码成功)");

            #endregion
        }
    }
}
