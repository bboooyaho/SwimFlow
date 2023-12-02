using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOForm
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MemberForm MemForm = new MemberForm();
            MemForm.Owner = this;
            MemForm.ShowDialog();
            MemForm.Dispose();
        }

        private void 종료ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timelabel.Text = DateTime.Now.ToString();
        }

        private void 인원ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        

        private void 정보확인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoForm infForm = new InfoForm();
            infForm.Owner = this;
            infForm.ShowDialog();
            infForm.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm MainForm = new MainForm();
            MainForm.Owner = this;
            MainForm.ShowDialog();
            MainForm.Dispose();

        }
    }
}
