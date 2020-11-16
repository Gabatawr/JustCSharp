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
    public partial class Tab : UserControl
    {
        public string FolderName => History[hIndex].Name;
        public string Path => History[hIndex].FullName;

        public List<DirectoryInfo> History = new List<DirectoryInfo>();
        public int hIndex;

        public Tab(string path, EventHandler handler)
        {
            InitializeComponent();

            content.DoubleClick += handler;

            History.Add(new DirectoryInfo(path));

            content.Columns.AddRange(new[]
            {
                new ColumnHeader()
                {
                    Text = "Name",
                    Width = 612
                },
                new ColumnHeader()
                {
                    Text = "Type",
                    Width = 64
                },
                new ColumnHeader()
                {
                    Text = "Size Mb",
                    Width = 64
                }
            });

            content.View = MainForm.ViewMode;

            ReList();
        }

        public void ReList()
        {
            content.Items.Clear();

            foreach (DirectoryInfo directory in History[hIndex].GetDirectories())
            {
                content.Items.Add(new ListViewItem(new[]
                {
                    directory.Name,
                    ".dir",
                    ""
                })
                {
                    Font = new Font(FontFamily.GenericSansSerif, 10F)
                });
            }

            foreach (FileInfo file in History[hIndex].GetFiles())
            {
                content.Items.Add(new ListViewItem(new[]
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
