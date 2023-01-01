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
    public partial class Log : Form
    {
       IntPtr loginID = IntPtr.Zero;
       private IntPtr m_FindDoorRecordID = IntPtr.Zero;
       private IntPtr m_FindAlarmRecordID = IntPtr.Zero;
       private IntPtr m_FindLogID = IntPtr.Zero;
       private int m_LogNum = 0;

       AccessControlForm mainWindow;
        public Log(IntPtr id, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
            mainWindow = main;
        }

        private void Log_Load(object sender, EventArgs e)
        {
            btn_NextLog.Enabled = false;
            btn_GetLogCount.Enabled = false;
        }

        private void btn_StartQuery_Click(object sender, EventArgs e)
        {
            m_LogNum = 0;
            if (IntPtr.Zero == m_FindLogID)
            {
                NET_IN_START_QUERYLOG stuIn = new NET_IN_START_QUERYLOG();
                stuIn.dwSize = (uint)Marshal.SizeOf(typeof(NET_IN_START_QUERYLOG));
                NET_OUT_START_QUERYLOG stuOut = new NET_OUT_START_QUERYLOG();
                stuOut.dwSize = (uint)Marshal.SizeOf(typeof(NET_OUT_START_QUERYLOG));

                m_FindLogID = NETClient.StartQueryLog(loginID, ref stuIn, ref stuOut, 5000); //CLIENT_StartQueryLog(m_lLoginID, &stuIn, &stuOut, SDK_API_WAIT);
                if (IntPtr.Zero == m_FindLogID)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }

                btn_StartQuery.Text = "StopQuery";
                
                btn_NextLog.Enabled = true;
                btn_GetLogCount.Enabled = true;
            }
            else
            {
                NETClient.StopQueryLog(m_FindLogID);
                m_FindLogID = IntPtr.Zero;
                btn_StartQuery.Text = "StartQuery";
                btn_NextLog.Enabled = false;
                btn_GetLogCount.Enabled = false;
                textBox_LogCount.Text = "";

                listView_Log.Items.Clear();
            }
        }

        private void btn_GetLogCount_Click(object sender, EventArgs e)
        {
            NET_IN_GETCOUNT_LOG_PARAM stuIn = new NET_IN_GETCOUNT_LOG_PARAM();
            stuIn.dwSize = (uint)Marshal.SizeOf(typeof(NET_IN_GETCOUNT_LOG_PARAM));
            NET_OUT_GETCOUNT_LOG_PARAM stuOut = new NET_OUT_GETCOUNT_LOG_PARAM();
            stuOut.dwSize = (uint)Marshal.SizeOf(typeof(NET_OUT_GETCOUNT_LOG_PARAM));
            if (NETClient.QueryDevLogCount(loginID, ref stuIn, ref stuOut, 5000))
            {
                textBox_LogCount.Text = stuOut.nLogCount.ToString();
            }
            else
            {
                MessageBox.Show(NETClient.GetLastError());
            }
        }

        private void btn_NextQuery_Click(object sender, EventArgs e)
        {
            listView_Log.Items.Clear();
            int max = 10;
            NET_IN_QUERYNEXTLOG stuIn = new NET_IN_QUERYNEXTLOG();
            stuIn.dwSize = (uint)Marshal.SizeOf(typeof(NET_IN_QUERYNEXTLOG));
            stuIn.nGetCount = max;

            NET_OUT_QUERYNEXTLOG stuOut = new NET_OUT_QUERYNEXTLOG();
            stuOut.dwSize = (uint)Marshal.SizeOf(typeof(NET_OUT_QUERYNEXTLOG));
            stuOut.nMaxCount = max;
            stuOut.pstuLogInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_LOG_INFO)) * stuOut.nMaxCount);

            NET_LOG_INFO[] logInfo = new NET_LOG_INFO[stuOut.nMaxCount];
            for (int i = 0; i < stuOut.nMaxCount; i++)
            {
                logInfo[i].dwSize = (uint)Marshal.SizeOf(typeof(NET_LOG_INFO));
                logInfo[i].stuLogMsg.dwSize = (uint)Marshal.SizeOf(typeof(NET_LOG_MESSAGE));
                IntPtr pDst = IntPtr.Add(stuOut.pstuLogInfo, Marshal.SizeOf(typeof(NET_LOG_INFO)) * i);
                Marshal.StructureToPtr(logInfo[i], pDst, true);
            }

            if (NETClient.QueryNextLog(m_FindLogID, ref stuIn, ref stuOut, 5000))
            {
                if (stuOut.nRetCount > 0)
                {
                    BeginInvoke(new Action(() =>
                    {
                        for (int i = 0; i < stuOut.nRetCount; i++)
                        {
                            IntPtr pDst = IntPtr.Add(stuOut.pstuLogInfo, Marshal.SizeOf(typeof(NET_LOG_INFO)) * i);
                            NET_LOG_INFO retInfo = (NET_LOG_INFO)Marshal.PtrToStructure(pDst, typeof(NET_LOG_INFO));

                            m_LogNum += 1;
                            var listitem = new ListViewItem();
                            listitem.Text = m_LogNum.ToString();
                            listitem.SubItems.Add(retInfo.stuTime.ToString());
                            listitem.SubItems.Add(retInfo.szUserName);
                            listitem.SubItems.Add(retInfo.szLogType);
                            listitem.SubItems.Add(retInfo.stuLogMsg.szLogMessage);
                            if (listView_Log != null)
                            {
                                listView_Log.BeginUpdate();
                                listView_Log.Items.Add(listitem);
                                listView_Log.EndUpdate();
                            }
                        }
                    }));


                }
            }
            else
            {
                MessageBox.Show(NETClient.GetLastError());
            }
        }
    }
}
