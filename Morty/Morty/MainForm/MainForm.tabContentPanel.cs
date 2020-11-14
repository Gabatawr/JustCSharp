using System;
using System.Collections.Generic;
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
        private Panel _tabContentPanel;

        private void _tabContentPanelInit()
        {
            // Panel
            _tabContentPanel = new Panel()
            {
                Size = new Size(Width - 32, Height - 46 - 24 - 46),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                Margin = Padding.Empty,
                Padding = new Padding(1),
                Location = new Point(8, 71),
                TabIndex = 1,
            };

            // Form
            Controls.Add(_tabContentPanel);

            // Event
            _tabContentPanel.KeyDown += KeyDown_Alt;
        }

        private void _tabContentCreate()
        {
            ListView lb = new ListView()
            {
                Dock = DockStyle.Fill,
                View = _tabViewMode,
                FullRowSelect = true,
                Columns = 
                {
                    new ColumnHeader()
                    {
                        Text = "Name",
                        Width = Width / 3
                    },
                    new ColumnHeader()
                    {
                        Text = "Type",
                        Width = 64
                    },
                    new ColumnHeader()
                    {
                        Text = "Size Mb",
                        Width = 86
                    }
                }
            };

            _tabContentBox.Add(lb);
            _tabContentUpdate();

            // ContentPanel
            _tabContentPanel.Controls.Add(lb);

            // Event
            lb.DoubleClick += DoubleClick_DirItem;
            lb.KeyDown += KeyDown_Alt;
        }

        void _tabContentUpdate()
        {
            _tabContentBox[_tabDirBoxInd].Items.Clear();

            foreach (DirectoryInfo directory in _tabDirBox[_tabDirBoxInd][_tabHistoryInd].GetDirectories())
            {
                _tabContentBox[_tabDirBoxInd].Items.Add(new ListViewItem(new[]
                {
                    directory.Name,
                    ".dir",
                    ""
                })
                {
                    Font = new Font(FontFamily.GenericSansSerif, 10F)
                });
            }

            foreach (FileInfo file in _tabDirBox[_tabDirBoxInd][_tabHistoryInd].GetFiles())
            {
                _tabContentBox[_tabDirBoxInd].Items.Add(new ListViewItem(new[]
                {
                    file.Name,
                    file.Extension,
                    Math.Round((double)file.Length / 1048576, 2).ToString()
                })
                {
                    Font = new Font(FontFamily.GenericSansSerif, 10F)
                });
            }
        }
    }
}
