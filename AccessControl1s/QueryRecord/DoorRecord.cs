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
    public partial class DoorRecord : Form
    {
       IntPtr loginID = IntPtr.Zero;
       private IntPtr m_FindDoorRecordID = IntPtr.Zero;
       private IntPtr m_FindAlarmRecordID = IntPtr.Zero;
       private IntPtr m_FindLogID = IntPtr.Zero;
       private int m_LogNum = 0;

        AccessControlForm mainWindow;
        public DoorRecord(IntPtr id, AccessControlForm main)
        {
            InitializeComponent();
            loginID = id;
            mainWindow = main;
        }

        private void btn_StartQuery_Click(object sender, EventArgs e)
        {
            m_LogNum = 0;
            if (IntPtr.Zero == m_FindDoorRecordID)
            {
                NET_FIND_RECORD_ACCESSCTLCARDREC_CONDITION_EX condition = new NET_FIND_RECORD_ACCESSCTLCARDREC_CONDITION_EX();
                condition.dwSize = (uint)Marshal.SizeOf(typeof(NET_FIND_RECORD_ACCESSCTLCARDREC_CONDITION_EX));
                condition.bTimeEnable = true;
                condition.stStartTime = NET_TIME.FromDateTime(dateTimePicker_Start.Value);
                condition.stEndTime = NET_TIME.FromDateTime(dateTimePicker_End.Value);
                object obj = condition;

                bool ret = NETClient.FindRecord(loginID, EM_NET_RECORD_TYPE.ACCESSCTLCARDREC_EX, obj, typeof(NET_FIND_RECORD_ACCESSCTLCARDREC_CONDITION_EX), ref m_FindDoorRecordID, 10000);
                if (!ret)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
                btn_StartQuery.Text = "StopQuery";
                btn_NextFind.Enabled = true;
                btn_GetRecordCount.Enabled = true;
                dateTimePicker_Start.Enabled = false;
                dateTimePicker_End.Enabled = false;
            }
            else
            {
                NETClient.FindRecordClose(m_FindDoorRecordID);
                m_FindDoorRecordID = IntPtr.Zero;
                btn_StartQuery.Text = "StartQuery";
                btn_NextFind.Enabled = false;
                btn_GetRecordCount.Enabled = false;
                dateTimePicker_Start.Enabled = true;
                dateTimePicker_End.Enabled = true;
                textBox_Count.Text = "";
                
                listView_DoorRecord.Items.Clear();
            }
        }

        private void btn_GetRecordCount_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_FindDoorRecordID)
            {
                return;
            }

            int nCount = 0;
            try
            {
                if (NETClient.QueryRecordCount(m_FindDoorRecordID, ref nCount, 3000))
                {
                    textBox_Count.Text = nCount.ToString();
                }
                else
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
            }
            catch (NETClientExcetion ex)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btn_NextFind_Click(object sender, EventArgs e)
        {
            listView_DoorRecord.Items.Clear();
            int max = 10;
            int retNum = 0;
            List<object> ls = new List<object>();
            for (int i = 0; i < max; i++)
            {
                NET_RECORDSET_ACCESS_CTL_CARDREC cardrec = new NET_RECORDSET_ACCESS_CTL_CARDREC();
                cardrec.dwSize = (uint)Marshal.SizeOf(typeof(NET_RECORDSET_ACCESS_CTL_CARDREC));
                ls.Add(cardrec);
            }
            NETClient.FindNextRecord(m_FindDoorRecordID, max, ref retNum, ref ls, typeof(NET_RECORDSET_ACCESS_CTL_CARDREC), 10000);
            BeginInvoke(new Action(() =>
            {
                foreach (var item in ls)
                {
                    NET_RECORDSET_ACCESS_CTL_CARDREC info = (NET_RECORDSET_ACCESS_CTL_CARDREC)item;
                    var listitem = new ListViewItem();
                    listitem.Text = info.nRecNo.ToString();
                    listitem.SubItems.Add(info.stuTime.ToString());
                    listitem.SubItems.Add(info.szCardNo);
                    listitem.SubItems.Add(info.bStatus.ToString());
                    listitem.SubItems.Add(info.nDoor.ToString());
                    listitem.SubItems.Add(info.emMethod.ToString());
                    if (listView_DoorRecord != null)
                    {
                        listView_DoorRecord.BeginUpdate();
                        listView_DoorRecord.Items.Add(listitem);
                        listView_DoorRecord.EndUpdate();
                    }
                }
            }));
        }

        private void DoorRecord_Load(object sender, EventArgs e)
        {
            btn_NextFind.Enabled = false;
            btn_GetRecordCount.Enabled = false;
            dateTimePicker_Start.Enabled = true;
            dateTimePicker_End.Enabled = true;
        }
    }
}
