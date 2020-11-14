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

namespace Morty
{
    partial class MainForm
    {
        private void KeyDown_Alt(object sender, KeyEventArgs e)
        {
            Point Shift(Point p) => new Point(p.X, p.Y + (_menuUp.Visible ? _menuUp.Height : -_menuUp.Height));
            if (e.Alt)
            {
                _menuUp.Visible = !_menuUp.Visible;

                _navPanel.Location = Shift(_navPanel.Location);
                _tabHeaderPanel.Location = Shift(_tabHeaderPanel.Location);
                _tabContentPanel.Location = Shift(_tabContentPanel.Location);
            }
        }

        private void KeyDown_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Directory.Exists(_navPanelPath.Text))
                {

                }
            }
        }

        private void DoubleClick_DirItem(object sender, EventArgs eventArgs)
        {
            string path = _tabDirBox[_tabDirBoxInd][_tabHistoryInd].FullName
                          + @"\"
                          + _tabContentBox[_tabDirBoxInd].SelectedItems[0].Text;

            if (_tabContentBox[_tabDirBoxInd].SelectedItems[0].SubItems[1].Text == ".dir")
            {
                if (_tabHistoryInd < _tabDirBox[_tabDirBoxInd].Count - 1)
                {
                    _tabDirBox[_tabDirBoxInd].RemoveRange
                    (
                        _tabHistoryInd + 1,
                        _tabDirBox[_tabDirBoxInd].Count - (_tabHistoryInd + 1)
                    );
                }

                _tabDirBox[_tabDirBoxInd].Add(new DirectoryInfo(path));
                _navPanelPath.Text = path;

                _tabHistoryInd++;
                _tabContentUpdate();
                _tabHeaderUpdate();
            }
            else System.Diagnostics.Process.Start(path);
        }
    }
}
