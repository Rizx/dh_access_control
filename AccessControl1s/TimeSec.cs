using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessControl1s
{
    public partial class TimeSec : Form
    {
        IntPtr loginID = IntPtr.Zero;

        UserManagement mainWindow;
        private int m_CheckboxCount = 0;
        private CheckBox[] ckb;
        public List<int> SelectTimesList = new List<int>();

        public TimeSec(int count, List<int> times)
        {
            InitializeComponent();
            m_CheckboxCount = count;
            SelectTimesList = times;
            ckb = new CheckBox[m_CheckboxCount];
        }

        private void TimeSec_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < m_CheckboxCount; i++)
            {
                ckb[i] = new CheckBox();
                int x = i % 4;
                int y = i / 4;
                var loc = new Point(20 + 100 * x, 20 + 20 * y);
                ckb[i].Location = loc;
                ckb[i].Text = (i + 1).ToString();
                ckb[i].Height = 20;
                ckb[i].Width = 50;
                Controls.Add(ckb[i]);
            }

            if (null != SelectTimesList)
            {
                for (int i = 0; i < SelectTimesList.Count; i++)
                {
                    if (SelectTimesList[i] >= 0 && SelectTimesList[i] <= m_CheckboxCount)
                    {
                        ckb[SelectTimesList[i]].Checked = true;
                    }
                }
            }

            int rowNum = 0;
            rowNum = m_CheckboxCount / 4;
            if (m_CheckboxCount % 4 > 0)
            {
                rowNum++;
            }
            Height = 20 * (rowNum + 1) + 85;
            Button btn = new Button();
            btn.Location = new Point(80, Height - 75);
            btn.Size = new Size(120, 25);
            btn.Text = "Confirm";
            btn.Click += btn_Confirm_Click;
            Controls.Add(btn);

            Button btn_cancel = new Button();
            btn_cancel.Location = new Point(250, Height - 75);
            btn_cancel.Size = new Size(120, 25);
            btn_cancel.Text = "Cancel";
            btn_cancel.Click += btn_Cancel_Click;
            Controls.Add(btn_cancel);
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            SelectTimesList.Clear();
            for (int i = 0; i < m_CheckboxCount; i++)
            {
                if (ckb[i].Checked)
                {
                    SelectTimesList.Add(i);
                }
            }
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


    }
}
