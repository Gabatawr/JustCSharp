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
        private List<Label> _tabHeaderText;
        private List<TableLayoutPanel> _tabHeaderBox;

        private List<ListView> _tabContentBox;
        private View _tabViewMode;

        private List<List<DirectoryInfo>> _tabDirBox;

        private int _tabDirBoxInd;
        private int _tabHistoryInd;

        private void _tabLogicInit()
        {
            _tabHeaderText = new List<Label>();
            _tabHeaderBox = new List<TableLayoutPanel>();

            _tabContentBox = new List<ListView>();
            _tabViewMode = View.Details;

            _tabDirBox = new List<List<DirectoryInfo>>();
        }

        private void _tabCreate()
        {
            _tabDirBox.Add(new List<DirectoryInfo>());
            _tabDirBox[_tabDirBoxInd].Add(new DirectoryInfo(_navPanelPath.Text));

            _tabHeaderCreate();
            _tabContentCreate();
        }
    }
}
