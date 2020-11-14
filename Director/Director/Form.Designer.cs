using System.Drawing;

namespace Director
{
    partial class Form
    {
        #region sys

        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #endregion
        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this._menuUp = new System.Windows.Forms.MenuStrip();
            this._menuUpFile = new System.Windows.Forms.ToolStripMenuItem();
            this._menuUpFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this._menuUpFileFile = new System.Windows.Forms.ToolStripMenuItem();
            this._menuUpFileDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this._menuUpEdit = new System.Windows.Forms.ToolStripMenuItem();
            this._menuUpEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this._menuUpEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this._menuUpEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this._nav = new Director.Nav();
            this.headers = new Director.Headers();
            this._menuUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuUp
            // 
            this._menuUp.BackColor = System.Drawing.Color.White;
            this._menuUp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuUpFile,
            this._menuUpEdit});
            this._menuUp.Location = new System.Drawing.Point(0, 0);
            this._menuUp.Name = "_menuUp";
            this._menuUp.Size = new System.Drawing.Size(1280, 24);
            this._menuUp.TabIndex = 0;
            this._menuUp.Text = "_menuUp";
            this._menuUp.Visible = false;
            // 
            // _menuUpFile
            // 
            this._menuUpFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuUpFileNew});
            this._menuUpFile.Name = "_menuUpFile";
            this._menuUpFile.Size = new System.Drawing.Size(37, 20);
            this._menuUpFile.Text = "File";
            // 
            // _menuUpFileNew
            // 
            this._menuUpFileNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuUpFileFile,
            this._menuUpFileDirectory});
            this._menuUpFileNew.Name = "_menuUpFileNew";
            this._menuUpFileNew.Size = new System.Drawing.Size(98, 22);
            this._menuUpFileNew.Text = "New";
            // 
            // _menuUpFileFile
            // 
            this._menuUpFileFile.Name = "_menuUpFileFile";
            this._menuUpFileFile.Size = new System.Drawing.Size(122, 22);
            this._menuUpFileFile.Text = "File";
            // 
            // _menuUpFileDirectory
            // 
            this._menuUpFileDirectory.Name = "_menuUpFileDirectory";
            this._menuUpFileDirectory.Size = new System.Drawing.Size(122, 22);
            this._menuUpFileDirectory.Text = "Directory";
            // 
            // _menuUpEdit
            // 
            this._menuUpEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuUpEditCut,
            this._menuUpEditCopy,
            this._menuUpEditPaste});
            this._menuUpEdit.Name = "_menuUpEdit";
            this._menuUpEdit.Size = new System.Drawing.Size(39, 20);
            this._menuUpEdit.Text = "Edit";
            // 
            // _menuUpEditCut
            // 
            this._menuUpEditCut.Name = "_menuUpEditCut";
            this._menuUpEditCut.ShortcutKeyDisplayString = "Ctrl + X";
            this._menuUpEditCut.Size = new System.Drawing.Size(150, 22);
            this._menuUpEditCut.Text = "Cut";
            // 
            // _menuUpEditCopy
            // 
            this._menuUpEditCopy.Name = "_menuUpEditCopy";
            this._menuUpEditCopy.ShortcutKeyDisplayString = "Ctrl + C";
            this._menuUpEditCopy.Size = new System.Drawing.Size(150, 22);
            this._menuUpEditCopy.Text = "Copy";
            // 
            // _menuUpEditPaste
            // 
            this._menuUpEditPaste.Name = "_menuUpEditPaste";
            this._menuUpEditPaste.ShortcutKeyDisplayString = "Ctrl + V";
            this._menuUpEditPaste.Size = new System.Drawing.Size(150, 22);
            this._menuUpEditPaste.Text = "Paste";
            // 
            // _nav
            // 
            this._nav.Location = new System.Drawing.Point(9, 9);
            this._nav.Margin = new System.Windows.Forms.Padding(0);
            this._nav.Name = "_nav";
            this._nav.Size = new System.Drawing.Size(1262, 24);
            this._nav.TabIndex = 1;
            // 
            // headers
            // 
            this.headers.Location = new System.Drawing.Point(9, 33);
            this.headers.Margin = new System.Windows.Forms.Padding(0);
            this.headers.Name = "headers";
            this.headers.Size = new System.Drawing.Size(1262, 46);
            this.headers.TabIndex = 2;
            // 
            // Form
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.headers);
            this.Controls.Add(this._nav);
            this.Controls.Add(this._menuUp);
            this.MainMenuStrip = this._menuUp;
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "Form";
            this.Text = "Director";
            this._menuUp.ResumeLayout(false);
            this._menuUp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuUp;
        private System.Windows.Forms.ToolStripMenuItem _menuUpFile;
        private System.Windows.Forms.ToolStripMenuItem _menuUpFileNew;
        private System.Windows.Forms.ToolStripMenuItem _menuUpFileFile;
        private System.Windows.Forms.ToolStripMenuItem _menuUpFileDirectory;
        private System.Windows.Forms.ToolStripMenuItem _menuUpEdit;
        private System.Windows.Forms.ToolStripMenuItem _menuUpEditCut;
        private System.Windows.Forms.ToolStripMenuItem _menuUpEditCopy;
        private System.Windows.Forms.ToolStripMenuItem _menuUpEditPaste;
        private Nav _nav;
        private Headers headers;
    }
}

