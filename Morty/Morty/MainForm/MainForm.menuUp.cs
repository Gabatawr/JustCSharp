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
        private MenuStrip _menuUp;

        private ToolStripMenuItem _menuUpFile;
        private ToolStripMenuItem _menuUpFileNew;
        private ToolStripMenuItem _menuUpFileNewFile;
        private ToolStripMenuItem _menuUpFileNewDirectory;

        private ToolStripMenuItem _menuUpEdit;
        private ToolStripMenuItem _menuUpEditCut;
        private ToolStripMenuItem _menuUpEditCopy;
        private ToolStripMenuItem _menuUpEditPaste;

        private void _menuUpInit()
        {
            // Menu
            _menuUp = new MenuStrip();
            _menuUp.BackColor = Color.White;
            _menuUp.Visible = false;

            // File
            _menuUpFile = new ToolStripMenuItem("File");
            _menuUp.Items.Add(_menuUpFile);

            _menuUpFileNew = new ToolStripMenuItem("New");
            _menuUpFile.DropDownItems.Add(_menuUpFileNew);

            _menuUpFileNewFile = new ToolStripMenuItem("File");
            _menuUpFileNewDirectory = new ToolStripMenuItem("Directory");
            _menuUpFileNew.DropDownItems.AddRange(new ToolStripItem[] { _menuUpFileNewFile, _menuUpFileNewDirectory });

            // Edit
            _menuUpEdit = new ToolStripMenuItem("Edit");
            _menuUp.Items.Add(_menuUpEdit);

            _menuUpEditCut = new ToolStripMenuItem("Cut");
            _menuUpEditCopy = new ToolStripMenuItem("Copy");
            _menuUpEditPaste = new ToolStripMenuItem("Paste");
            _menuUpEdit.DropDownItems.AddRange(new ToolStripItem[] { _menuUpEditCut, _menuUpEditCopy, _menuUpEditPaste });

            // Form
            Controls.Add(_menuUp);
            MainMenuStrip = _menuUp;

            // Event
            _menuUp.KeyDown += KeyDown_Alt;
        }
    }
}
