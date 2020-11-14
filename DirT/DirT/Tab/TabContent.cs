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
    public partial class TabContent : UserControl
    {
        private TabBox _tabBox;

        private List<DirectoryInfo> _history;
        private int _active;

        private DirectoryInfo[] _directories;
        private FileInfo[] _files;

        private void _reDraw()
        {
            _directories = _history[_active].GetDirectories();
            _files = _history[_active].GetFiles();

            listView1.Items.Clear();

            foreach (var d in _directories)
            {
                this.listView1.Items.Add
                (
                    new System.Windows.Forms.ListViewItem
                    (
                        new string[]
                        {
                            d.Name, "/dir/", ""
                        }
                    )
                );
            }
            foreach (var f in _files)
            {
                this.listView1.Items.Add
                (
                    new System.Windows.Forms.ListViewItem
                    (
                        new string[]
                        {
                            f.Name, f.Extension, Math.Round(f.Length / 1048576D, 2).ToString()
                        }
                    )
                );
            }
        }

        public TabContent(TabBox tab, DirectoryInfo directory)
        {
            _tabBox = tab;

            _history = new List<DirectoryInfo>();
            _history.Add(directory);

            InitializeComponent();

            _reDraw();
        }
        public void PrevTab()
        {
            if (_active - 1 >= 0)
            {
                _active--;
                _reDraw();
                _tabBox.RePath(_history[_active].FullName);
            }
        }
        public void NextTab()
        {
            if (_active < _history.Count - 1)
            {
                _active++;
                _reDraw();
                _tabBox.RePath(_history[_active].FullName);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];

            int ind = item.Index;
            if (ind < _directories.Length)
            {
                if (_active < _history.Count - 1) 
                    _history.RemoveRange(_active + 1, _history.Count - (_active + 1));

                _history.Add(_directories[ind]);
                _active++;
                _reDraw();
                _tabBox.RePath(_history[_active].FullName);
            }
            else
            {
                ind -= _directories.Length;
                System.Diagnostics.Process.Start(_files[ind].FullName);
            }
        }
    }
}
