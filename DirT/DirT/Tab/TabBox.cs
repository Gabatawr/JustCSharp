using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirT
{
    public partial class TabBox : UserControl
    {
        private List<DirectoryInfo> _directories = new List<DirectoryInfo>();
        private int _active;

        private MainForm _form;
        public void InitForm(Form form)
        {
            _form = form as MainForm;
        }
        public TabBox()
        {
            InitializeComponent();
        }
        public void ReActive(TabHeader header)
        {
            panelHeaders.Controls[_active].ResetBackColor();
            panelContents.Controls[_active].Visible = false;

            _active = panelHeaders.Controls.GetChildIndex(header);
            _form.SetTextBox(_directories[_active].FullName);

            panelHeaders.Controls[_active].BackColor = Color.LightGray;
            panelContents.Controls[_active].Visible = true;
        }
        public void AddTab(string path = @"D:\downloads")
        {
            _directories.Add(new DirectoryInfo(path));

            TabHeader header = new TabHeader(tab: this, dirName: _directories.Last().Name);
            TabContent content = new TabContent(tab: this, directory: _directories.Last()) { Dock = DockStyle.Fill };
            

            this.panelHeaders.Width += header.Width + 1;

            this.panelContents.Controls.Add(content);
            this.panelHeaders.Controls.Add(header);

            ReActive(panelHeaders.Controls[panelHeaders.Controls.Count - 1] as TabHeader);
        }
        public void DelTab(TabHeader header)
        {
            this.panelHeaders.Width -= header.Width + 1;

            int indDel = panelHeaders.Controls.GetChildIndex(header);
            _directories.RemoveAt(indDel);

            void _del()
            {
                this.panelHeaders.Controls.RemoveAt(indDel);
                this.panelContents.Controls.RemoveAt(indDel);
            }

            if (_directories.Count > 0)
            {
                if (_active == indDel)
                {
                    _del();
                    _active = panelHeaders.Controls.Count - 1;
                    ReActive(panelHeaders.Controls[_active] as TabHeader);
                }
                else if (_active > indDel)
                {
                    _del();
                    _active--;
                }
                else _del();
            }
            else
            {
                _del();
                _form.SetTextBox("");
            }
        }
        private void btnTabCreate_Click(object sender, EventArgs e)
        {
            AddTab();
        }

        public void RePath(string path)
        {
            _directories[_active] = new DirectoryInfo(path);
            (panelHeaders.Controls[_active] as TabHeader).Rename(_directories[_active].Name);
            _form.SetTextBox(_directories[_active].FullName);
        }
        public void PrevTab()
        {
            (panelContents.Controls[_active] as TabContent).PrevTab();
        }
        public void NextTab()
        {
            (panelContents.Controls[_active] as TabContent).NextTab();
        }
    }
}