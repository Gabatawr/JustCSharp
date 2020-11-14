using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morty
{
    partial class MainForm
    {
        
        private TableLayoutPanel _tabHeaderPanel;
        private Button _tabHeaderPanelBtnNew;

        private void _tabHeaderPanelInit()
        {
            // Panel
            _tabHeaderPanel = new TableLayoutPanel()
            {
                Size = new Size(Width - 32, 46),
                Margin = new Padding(0),
                Location = new Point(8, 24),
                TabIndex = 1,
                RowCount = 1,
                ColumnCount = 2,
            };

            _navPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0F));
            _navPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 34F));

            // Box
            FlowLayoutPanel p = new FlowLayoutPanel()
            {
                AutoSize = true,
                Margin = new Padding(0),
                Location = new Point(8, 24),
                TabIndex = 0,
            };

            _tabHeaderPanel.Controls.Add(p, 0, 0);

            // New
            _tabHeaderPanelBtnNew = new Button
            {
                Size = new Size(34, 34),
                Margin = new Padding(1,6,1,1),
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                TabIndex = 1,
                Image = Image.FromFile("new.png"),
                FlatStyle = FlatStyle.Flat
            };
            _tabHeaderPanelBtnNew.FlatAppearance.BorderSize = 1;
            _tabHeaderPanelBtnNew.FlatAppearance.BorderColor = Color.Gray;
            _tabHeaderPanelBtnNew.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            _tabHeaderPanelBtnNew.FlatAppearance.MouseDownBackColor = Color.Silver;

            _tabHeaderPanel.Controls.Add(_tabHeaderPanelBtnNew, 1, 0);

            // Form
            Controls.Add(_tabHeaderPanel);

            // Event
            p.KeyDown += KeyDown_Alt;
            _tabHeaderPanelBtnNew.KeyDown += KeyDown_Alt;
            _tabHeaderPanelBtnNew.KeyDown += KeyDown_Alt;
        }

        private void _tabHeaderCreate()
        {
            // Panel
            TableLayoutPanel p = new TableLayoutPanel()
            {
                AutoSize = true,
                Margin = new Padding(1, 4, 2,0),
                BorderStyle = BorderStyle.FixedSingle,
                RowCount = 1,
                ColumnCount = 2,
            };

            _tabHeaderBox.Add(p);

            // Text
            Label l = new Label()
            {
                AutoSize = true,
                Location = new Point(1, 4),
                Text = _tabDirBox[_tabDirBoxInd][_tabHistoryInd].Name,
                Margin = new Padding(4,11,1,11)
            };

            p.Controls.Add(l, 0, 0);
            _tabHeaderText.Add(l);

            // Del
            Button b = new Button()
            {
                Size = new Size(16, 16),
                Padding = new Padding(0,0,2,2),
                Margin = new Padding(0, 10, 4, 10),
                TabIndex = 0,
                Image = Image.FromFile("del.png"),
                FlatStyle = FlatStyle.Flat
            };
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            b.FlatAppearance.MouseDownBackColor = Color.Silver;

            p.Controls.Add(b, 1, 0);

            // HeaderFlowPanel
            _tabHeaderPanel.Controls[0].Controls.Add(p);

            // Event
            p.KeyDown += KeyDown_Alt;
            b.KeyDown += KeyDown_Alt;
            l.KeyDown += KeyDown_Alt;
        }

        private void _tabHeaderUpdate()
        {
            _tabHeaderText[_tabDirBoxInd].Text = _tabDirBox[_tabDirBoxInd][_tabHistoryInd].Name;
        }
    }
}
