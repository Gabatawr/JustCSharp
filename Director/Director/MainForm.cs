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

        private List<string> buffer;
        private bool isCopy;
        private bool isCut;

        public MainForm()
        {
            InitializeComponent();

            _nav.path.KeyDown += path_KeyDown;
            _nav.btnPrev.MouseClick += btnPrev_MouseClick;
            _nav.btnNext.MouseClick += btnNext_MouseClick;

            _headers.btnNew.MouseClick += btnAdd_MouseClick;
        }

        private void dirItem_DoubleClick(object sender, EventArgs eventArgs)
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

        private void tab_ListChanged(object sender, EventArgs e)
        {
            if (sender is Tab tab)
            {
                _infoDirectoryCount.Text = Directory.GetDirectories(tab.Path).Length.ToString();
                _infoFileCount.Text = Directory.GetFiles(tab.Path).Length.ToString();
            }
        }
        private void AddTab(string path)
        {
            Tab newTab = new Tab(path, tab_ListChanged) { Dock = DockStyle.Fill };
            newTab.SubTab(dirItem_DoubleClick, item_KeyDown);
            _tabPanel.Controls.Add(newTab);
            

            Head newHead = new Head();
            newHead.folderName.Text = newTab.FolderName;
            newHead.BackColor = Color.Gainsboro;

            newHead.SubMouseClick(head_MouseClick);
            newHead.btnClose.MouseClick += btnClose_MouseClick;
            
            _headers.box.Controls.Add(newHead);

            ReActive(_tabPanel.Controls.Count - 1);
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
            ((Tab)_tabPanel.Controls[Active]).ReList();

            _nav.path.Text = ((Tab)_tabPanel.Controls[Active]).Path;
        }
        private void item_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == (Keys.Control | Keys.C) || e.KeyData == (Keys.Control | Keys.X))
                && _tabPanel.Controls[Active] is Tab tab 
                && tab.content.SelectedItems.Count > 0)
            {
                if (e.KeyData == (Keys.Control | Keys.C)) 
                    isCopy = true;
                else isCut = true;
                
                buffer = new List<string>(tab.content.SelectedItems.Count);

                foreach (ListViewItem item in tab.content.SelectedItems)
                    buffer.Add(tab.Path + @"\" + item.Text);
            }
            else if (e.KeyData == (Keys.Control | Keys.V) && buffer.Count > 0)
            {
                bool overwrite(string newFile)
                {
                    var res = MessageBox.Show
                    (
                        newFile.Substring(newFile.LastIndexOf('\\') + 1) + " is exists, overwrite?",
                        "Oops!",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (res == DialogResult.Yes) return true;
                    return false;
                }
                string pathItem(string path, string item)
                {
                    return path + '\\' + item.Substring(item.LastIndexOf('\\') + 1);
                }

                if (isCopy)
                {
                    void ReqCopy(string pathOut, string pathIn)
                    {
                        
                        string newDir = pathItem(pathOut, pathIn);
                        if (!Directory.Exists(newDir))
                            Directory.CreateDirectory(newDir);

                        foreach (var file in Directory.GetFiles(pathOut))
                        {
                            string newFile = pathItem(newDir, file);
                            if (File.Exists(newFile))
                            {
                                if (overwrite(newFile))
                                {
                                    File.Delete(newFile);
                                    File.Copy(file, newFile);
                                }
                            }
                            else File.Copy(file, newFile);
                        }

                        foreach (var dir in Directory.GetDirectories(pathOut))
                            ReqCopy(dir, newDir);
                    }

                    foreach (var item in buffer)
                    {
                        if (Directory.Exists(item)) ReqCopy(item, ((Tab)_tabPanel.Controls[Active]).Path);
                        else if (File.Exists(item))
                        {
                            string newFile = pathItem(((Tab)_tabPanel.Controls[Active]).Path, item);
                            if (File.Exists(newFile))
                            {
                                if (overwrite(newFile))
                                {
                                    File.Delete(newFile);
                                    File.Copy(item, newFile);
                                }
                            }
                            else File.Copy(item, newFile);
                        }
                    }

                    isCopy = false;
                }
                else if (isCut)
                {
                    foreach (var item in buffer)
                    {
                        string newItem = pathItem(((Tab)_tabPanel.Controls[Active]).Path, item);

                        if (Directory.Exists(item))
                            Directory.Move(item, newItem);
                        
                        else if (File.Exists(item))
                        {
                            if (File.Exists(newItem))
                            {
                                if (overwrite(newItem))
                                {
                                    File.Delete(newItem);
                                    File.Move(item, newItem);
                                }
                            }
                            else File.Move(item, newItem);
                        }
                    }

                    isCopy = false;
                }

                ((Tab)_tabPanel.Controls[Active]).ReList();
            }
            else if (e.KeyData == Keys.Delete
                     && _tabPanel.Controls[Active] is Tab t
                     && t.content.SelectedItems.Count > 0)
            {
                var res = MessageBox.Show
                (
                    "Delete all selected items?",
                    "Are you sure?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (res == DialogResult.Yes)
                {
                    foreach (ListViewItem item in t.content.SelectedItems)
                    {
                        string path = t.Path + @"\" + item.Text;

                        if (Directory.Exists(path)) Directory.Delete(path);
                        else if (File.Exists(path)) File.Delete(path);
                    }

                    ((Tab)_tabPanel.Controls[Active]).ReList();
                }
            }
        }
    }
}
