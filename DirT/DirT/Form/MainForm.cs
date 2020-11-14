using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirT
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            tabBox.InitForm(this);
        }

        public void SetTextBox(string text)
        {
            textBox1.Text = text;
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGo_Click(textBox1, EventArgs.Empty);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox1.Text))
            {
                tabBox.AddTab(textBox1.Text);
            }
            else
            {
                textBox1.ForeColor = Color.Brown;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ResetForeColor();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            tabBox.PrevTab();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabBox.NextTab();
        }
    }
}
