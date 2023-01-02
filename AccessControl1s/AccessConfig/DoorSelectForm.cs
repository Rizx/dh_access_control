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
    public partial class DoorSelectForm : Form
    {
        private int m_CheckboxCount = 0;
        private CheckBox[] ckb;
        public List<int> SelectDoorsList = new List<int>();

        public DoorSelectForm()
        {
            InitializeComponent();
        }

        public DoorSelectForm(int count, List<int> doors)
        {
            InitializeComponent();
            m_CheckboxCount = count;
            SelectDoorsList = doors;
            ckb = new CheckBox[m_CheckboxCount];
        }

        private void DoorSelectForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < m_CheckboxCount; i++)
            {
                ckb[i] = new CheckBox();
                int x = i % 10;
                int y = i / 10;
                ckb[i].Location = new Point(10 + 50 * x, 20 + 20 * y);
                ckb[i].Text = (i + 1).ToString();
                ckb[i].Height = 20;
                ckb[i].Width = 50;
                Controls.Add(ckb[i]);
            }

            int rowNum = m_CheckboxCount / 10;
            if (m_CheckboxCount % 10 > 0)
            {
                rowNum++;
            }
            Height = 20 * (rowNum + 1) + 85;
            Button btn = new Button();
            btn.Location = new Point(205, Height - 75);
            btn.Size = new Size(120, 25);
            btn.Text = "Confirm(确定)";
            btn.Click += btn_Confirm_Click;
            Controls.Add(btn);

            if (null != SelectDoorsList)
            {
                for (int i = 0; i < SelectDoorsList.Count; i++)
                {
                    if (SelectDoorsList[i] >= 0 && SelectDoorsList[i] < m_CheckboxCount)
                    {
                        ckb[SelectDoorsList[i]].Checked = true;
                    }
                }
            }
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            SelectDoorsList.Clear();
            for (int i = 0; i < m_CheckboxCount; i++)
            {
                if (ckb[i].Checked)
                {
                    SelectDoorsList.Add(i);
                }
            }
            DialogResult = DialogResult.OK;
        }
    }
}
