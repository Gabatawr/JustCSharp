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
        private TableLayoutPanel _navPanel;

        private Button _navPanelBtnPrev;
        private Button _navPanelBtnNext;

        private TextBox _navPanelPath;

        private void _navPanelInit()
        {
            // Panel
            _navPanel = new TableLayoutPanel
            {
                Size = new Size(Width - 32, 24),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(8, 0),
                TabIndex = 1,
                RowCount = 1,
                ColumnCount = 3
            };

            _navPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 48F));
            _navPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 48F));
            _navPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            // Prev
            _navPanelBtnPrev = new Button
            {
                Size = new Size(0, 20),
                Margin = new Padding(1),
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TabIndex = 0,
                Image = Image.FromFile("prev.png"),
                FlatStyle = FlatStyle.Flat
            };
            _navPanelBtnPrev.FlatAppearance.BorderSize = 1;
            _navPanelBtnPrev.FlatAppearance.BorderColor = Color.Gray;
            _navPanelBtnPrev.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            _navPanelBtnPrev.FlatAppearance.MouseDownBackColor = Color.Silver;
            
            _navPanel.Controls.Add(_navPanelBtnPrev, 0, 0);

            // Next
            _navPanelBtnNext = new Button
            {
                Size = new Size(0, 20),
                Margin = new Padding(1),
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TabIndex = 1,
                Image = Image.FromFile("next.png"),
                FlatStyle = FlatStyle.Flat
            };

            _navPanelBtnNext.FlatAppearance.BorderSize = 1;
            _navPanelBtnNext.FlatAppearance.BorderColor = Color.Gray;
            _navPanelBtnNext.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            _navPanelBtnNext.FlatAppearance.MouseDownBackColor = Color.Silver;

            _navPanel.Controls.Add(_navPanelBtnNext, 1, 0);

            // Path
            _navPanelPath = new TextBox
            {
                Margin = new Padding(1),
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                TabIndex = 2
            };

            _navPanel.Controls.Add(_navPanelPath, 2, 0);

            // Form
            Controls.Add(_navPanel);

            // Event
            _navPanel.KeyDown += KeyDown_Alt;
            _navPanelBtnPrev.KeyDown += KeyDown_Alt;
            _navPanelBtnNext.KeyDown += KeyDown_Alt;
            _navPanelPath.KeyDown += KeyDown_Alt;
            _navPanelPath.KeyDown += KeyDown_Enter;
        }
    }
}
