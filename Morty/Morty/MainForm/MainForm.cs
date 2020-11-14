using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morty
{
    partial class MainForm
    {
        public MainForm()
        {
            InitializeComponent();

            _menuUpInit();

            _navPanelInit();

            _tabLogicInit();
            _tabHeaderPanelInit();
            _tabContentPanelInit();

            _navPanelPath.Text = @"D:\downloads";
            _tabCreate();
        }
    }
}
