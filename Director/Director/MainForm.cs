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

namespace Director
{
    public partial class MainForm : Form
    {
        public static int Active { get; private set; }
        public static View ViewMode { get; private set; } = View.Details;

        public MainForm()
        {
            InitializeComponent();

            _headers.btnNew.MouseClick += btnAdd_MouseClick;

            _nav.path.KeyDown += path_KeyDown;
            _nav.btnPrev.MouseClick += btnPrev_MouseClick;
            _nav.btnNext.MouseClick += btnNext_MouseClick;
        }

        public void dirItem_DoubleClick(object sender, EventArgs eventArgs)
        {
            Tab tab = (Tab)_tabPanel.Controls[Active];

            if (tab.content.SelectedItems.Count == 1)
            {
                string path = tab.History[tab.hIndex].FullName
                              + @"\"
                              + tab.content.SelectedItems[0].SubItems[0].Text;

                if (tab.content.SelectedItems[0].SubItems[1].Text == ".dir")
                {
                    if (tab.hIndex < tab.History.Count - 1)
                    {
                        tab.History.RemoveRange
                        (
                            tab.hIndex + 1,
                            tab.History.Count - (tab.hIndex + 1)
                        );
                    }

                    tab.History.Add(new DirectoryInfo(path));
                    _nav.path.Text = path;

                    tab.hIndex++;
                    tab.ReList();
                    ((Head) _headers.box.Controls[Active]).folderName.Text = tab.FolderName;
                }
                else System.Diagnostics.Process.Start(path);
            }
        }
        private void btnPrev_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Tab tab = (Tab) _tabPanel.Controls[Active];

                if (tab.hIndex - 1 >= 0)
                {
                    tab.hIndex--;
                    tab.ReList();
                    _nav.path.Text = tab.Path;
                    ((Head)_headers.box.Controls[Active]).folderName.Text = tab.FolderName;
                }
            }
        }
        private void btnNext_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Tab tab = (Tab)_tabPanel.Controls[Active];

                if (tab.hIndex < tab.History.Count - 1)
                {
                    tab.hIndex++;
                    tab.ReList();
                    _nav.path.Text = tab.Path;
                    ((Head)_headers.box.Controls[Active]).folderName.Text = tab.FolderName;
                }
            }
        }

        private void btnAdd_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_folderDialog.ShowDialog() == DialogResult.OK)
                    AddTab(_folderDialog.SelectedPath);
            }
        }
        private void path_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (Directory.Exists(_nav.path.Text))
                    AddTab(_nav.path.Text);
                else _nav.path.ForeColor = Color.Red;
            }
            else if (Directory.Exists(_nav.path.Text))
            {
                _nav.path.ForeColor = Color.Black;
            }
        }
        private void AddTab(string path)
        {
            Tab newTab = new Tab(path, dirItem_DoubleClick) { Dock = DockStyle.Fill };
            _tabPanel.Controls.Add(newTab);

            Head newHead = new Head();
            newHead.folderName.Text = newTab.FolderName;
            newHead.BackColor = Color.Gainsboro;

            newHead.SubMouseClick(head_MouseClick);
            newHead.btnClose.MouseClick += btnClose_MouseClick;
            
            _headers.box.Controls.Add(newHead);

            ReActive(_tabPanel.Controls.Count - 1);
        }
        private void head_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Head head = null;

                if (sender is TableLayoutPanel table) head = (Head)table.Parent;
                else if (sender is Label label) head = (Head)label.Parent.Parent;

                if (head != _headers.box.Controls[Active])
                    ReActive(_headers.box.Controls.IndexOf(head));
            }
        }
        private void btnClose_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int indDel = _headers.box.Controls.IndexOf((Head)((Button)sender).Parent.Parent);

                void _del()
                {
                    _headers.box.Controls.RemoveAt(indDel);
                    _tabPanel.Controls.RemoveAt(indDel);
                }

                if (_tabPanel.Controls.Count - 1 > 0)
                {
                    if (Active == indDel)
                    {
                        _del();
                        ReActive(_tabPanel.Controls.Count - 1);
                    }
                    else if (Active > indDel)
                    {
                        _del();
                        Active--;
                    }
                    else _del();
                }
                else
                {
                    _del();
                    _nav.path.Text = "";
                }
            }
        }
        private void ReActive(int newActive)
        {
            if (newActive == -1) return;

            if (Active < _tabPanel.Controls.Count)
            {
                ((Head)_headers.box.Controls[Active]).BackColor = Color.White;
                _tabPanel.Controls[Active].Visible = false;
            }

            Active = newActive;

            ((Head)_headers.box.Controls[Active]).BackColor = Color.Gainsboro;
            _tabPanel.Controls[Active].Visible = true;

            _nav.path.Text = ((Tab)_tabPanel.Controls[Active]).Path;
        }
    }
}
