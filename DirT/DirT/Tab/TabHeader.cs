using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirT
{
    public partial class TabHeader : UserControl
    {
        private TabBox _tabBox;

        public TabHeader(TabBox tab, string dirName)
        {
            _tabBox = tab;

            InitializeComponent();
            this.dirName.Text = dirName;
        }
        private void btnTabClose_MouseMove(object sender, MouseEventArgs e)
        {
            btnTabClose.ForeColor = Color.Brown;
        }
        private void btnTabClose_MouseLeave(object sender, EventArgs e)
        {
            btnTabClose.ForeColor = Color.Silver;
        }

        private void btnTabClose_Click(object sender, EventArgs e)
        {
            _tabBox.DelTab(this);
        }

        private void TabHeader_Click(object sender, EventArgs e)
        {
            _tabBox.ReActive(this);
        }

        public void Rename(string name)
        {
            dirName.Text = name;
        }
    }
}
