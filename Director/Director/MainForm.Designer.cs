using System.Drawing;

namespace Director
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._menuUp = new System.Windows.Forms.MenuStrip();
            this._menuUpFile = new System.Windows.Forms.ToolStripMenuItem();
            this._menuUpFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this._menuUpFileFile = new System.Windows.Forms.ToolStripMenuItem();
            this._menuUpFileDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this._menuUpEdit = new System.Windows.Forms.ToolStripMenuItem();
            this._menuUpEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this._menuUpEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this._menuUpEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this._navPanel = new System.Windows.Forms.Panel();
            this._nav = new Director.Nav();
            this._headersPanel = new System.Windows.Forms.Panel();
            this._headers = new Director.Headers();
            this._tabPanel = new System.Windows.Forms.Panel();
            this._folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this._infoPanel = new System.Windows.Forms.StatusStrip();
            this._infoDirectoryLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._infoDirectoryCount = new System.Windows.Forms.ToolStripStatusLabel();
            this._infoViewMode = new System.Windows.Forms.ToolStripSplitButton();
            this._infoViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this._infoViewTitle = new System.Windows.Forms.ToolStripMenuItem();
            this._infoViewList = new System.Windows.Forms.ToolStripMenuItem();
            this._infoViewSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this._infoViewLangeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this._infoFileLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._infoFileCount = new System.Windows.Forms.ToolStripStatusLabel();
            this._menuUp.SuspendLayout();
            this._navPanel.SuspendLayout();
            this._headersPanel.SuspendLayout();
            this._infoPanel.SuspendLayout();
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
            // _navPanel
            // 
            this._navPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._navPanel.Controls.Add(this._nav);
            this._navPanel.Location = new System.Drawing.Point(8, 12);
            this._navPanel.Margin = new System.Windows.Forms.Padding(0);
            this._navPanel.Name = "_navPanel";
            this._navPanel.Size = new System.Drawing.Size(1264, 24);
            this._navPanel.TabIndex = 4;
            // 
            // _nav
            // 
            this._nav.BackColor = System.Drawing.Color.White;
            this._nav.Dock = System.Windows.Forms.DockStyle.Fill;
            this._nav.Location = new System.Drawing.Point(0, 0);
            this._nav.Margin = new System.Windows.Forms.Padding(0);
            this._nav.Name = "_nav";
            this._nav.Size = new System.Drawing.Size(1264, 24);
            this._nav.TabIndex = 0;
            // 
            // _headersPanel
            // 
            this._headersPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._headersPanel.AutoSize = true;
            this._headersPanel.BackColor = System.Drawing.Color.White;
            this._headersPanel.Controls.Add(this._headers);
            this._headersPanel.Location = new System.Drawing.Point(8, 40);
            this._headersPanel.Margin = new System.Windows.Forms.Padding(0);
            this._headersPanel.Name = "_headersPanel";
            this._headersPanel.Size = new System.Drawing.Size(1264, 36);
            this._headersPanel.TabIndex = 5;
            // 
            // _headers
            // 
            this._headers.AutoSize = true;
            this._headers.Dock = System.Windows.Forms.DockStyle.Fill;
            this._headers.Location = new System.Drawing.Point(0, 0);
            this._headers.Margin = new System.Windows.Forms.Padding(0);
            this._headers.Name = "_headers";
            this._headers.Size = new System.Drawing.Size(1264, 36);
            this._headers.TabIndex = 0;
            // 
            // _tabPanel
            // 
            this._tabPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tabPanel.BackColor = System.Drawing.Color.White;
            this._tabPanel.Location = new System.Drawing.Point(8, 80);
            this._tabPanel.Margin = new System.Windows.Forms.Padding(0);
            this._tabPanel.Name = "_tabPanel";
            this._tabPanel.Size = new System.Drawing.Size(1264, 618);
            this._tabPanel.TabIndex = 3;
            // 
            // _infoPanel
            // 
            this._infoPanel.BackColor = System.Drawing.Color.Transparent;
            this._infoPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._infoDirectoryLabel,
            this._infoDirectoryCount,
            this._infoFileLabel,
            this._infoFileCount,
            this._infoViewMode});
            this._infoPanel.Location = new System.Drawing.Point(0, 698);
            this._infoPanel.Name = "_infoPanel";
            this._infoPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this._infoPanel.Size = new System.Drawing.Size(1280, 22);
            this._infoPanel.TabIndex = 6;
            // 
            // _infoDirectoryLabel
            // 
            this._infoDirectoryLabel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 2);
            this._infoDirectoryLabel.Name = "_infoDirectoryLabel";
            this._infoDirectoryLabel.Size = new System.Drawing.Size(66, 17);
            this._infoDirectoryLabel.Text = "Directories:";
            // 
            // _infoDirectoryCount
            // 
            this._infoDirectoryCount.Name = "_infoDirectoryCount";
            this._infoDirectoryCount.Size = new System.Drawing.Size(13, 17);
            this._infoDirectoryCount.Text = "0";
            // 
            // _infoViewMode
            // 
            this._infoViewMode.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._infoViewMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._infoViewMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._infoViewDetails,
            this._infoViewTitle,
            this._infoViewList,
            this._infoViewSmallIcons,
            this._infoViewLangeIcons});
            this._infoViewMode.Image = ((System.Drawing.Image)(resources.GetObject("_infoViewMode.Image")));
            this._infoViewMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._infoViewMode.Name = "_infoViewMode";
            this._infoViewMode.Size = new System.Drawing.Size(32, 20);
            this._infoViewMode.ToolTipText = "ViewMode";
            // 
            // _infoViewDetails
            // 
            this._infoViewDetails.Checked = true;
            this._infoViewDetails.CheckState = System.Windows.Forms.CheckState.Checked;
            this._infoViewDetails.Name = "_infoViewDetails";
            this._infoViewDetails.Size = new System.Drawing.Size(180, 22);
            this._infoViewDetails.Text = "Details";
            // 
            // _infoViewTitle
            // 
            this._infoViewTitle.Name = "_infoViewTitle";
            this._infoViewTitle.Size = new System.Drawing.Size(180, 22);
            this._infoViewTitle.Text = "Title";
            // 
            // _infoViewList
            // 
            this._infoViewList.Name = "_infoViewList";
            this._infoViewList.Size = new System.Drawing.Size(180, 22);
            this._infoViewList.Text = "List";
            // 
            // _infoViewSmallIcons
            // 
            this._infoViewSmallIcons.Name = "_infoViewSmallIcons";
            this._infoViewSmallIcons.Size = new System.Drawing.Size(180, 22);
            this._infoViewSmallIcons.Text = "SmallIcons";
            // 
            // _infoViewLangeIcons
            // 
            this._infoViewLangeIcons.Name = "_infoViewLangeIcons";
            this._infoViewLangeIcons.Size = new System.Drawing.Size(180, 22);
            this._infoViewLangeIcons.Text = "LargeIcons";
            // 
            // _infoFileLabel
            // 
            this._infoFileLabel.Name = "_infoFileLabel";
            this._infoFileLabel.Size = new System.Drawing.Size(33, 17);
            this._infoFileLabel.Text = "Files:";
            // 
            // _infoFileCount
            // 
            this._infoFileCount.Name = "_infoFileCount";
            this._infoFileCount.Size = new System.Drawing.Size(13, 17);
            this._infoFileCount.Text = "0";
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this._infoPanel);
            this.Controls.Add(this._headersPanel);
            this.Controls.Add(this._navPanel);
            this.Controls.Add(this._tabPanel);
            this.Controls.Add(this._menuUp);
            this.MainMenuStrip = this._menuUp;
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "MainForm";
            this.Text = "Director";
            this._menuUp.ResumeLayout(false);
            this._menuUp.PerformLayout();
            this._navPanel.ResumeLayout(false);
            this._headersPanel.ResumeLayout(false);
            this._headersPanel.PerformLayout();
            this._infoPanel.ResumeLayout(false);
            this._infoPanel.PerformLayout();
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
        private System.Windows.Forms.Panel _navPanel;
        private System.Windows.Forms.Panel _headersPanel;
        private Nav _nav;
        private Headers _headers;
        private System.Windows.Forms.Panel _tabPanel;
        private System.Windows.Forms.FolderBrowserDialog _folderDialog;
        private System.Windows.Forms.StatusStrip _infoPanel;
        private System.Windows.Forms.ToolStripStatusLabel _infoDirectoryLabel;
        private System.Windows.Forms.ToolStripStatusLabel _infoDirectoryCount;
        private System.Windows.Forms.ToolStripSplitButton _infoViewMode;
        private System.Windows.Forms.ToolStripMenuItem _infoViewSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem _infoViewLangeIcons;
        private System.Windows.Forms.ToolStripMenuItem _infoViewList;
        private System.Windows.Forms.ToolStripMenuItem _infoViewDetails;
        private System.Windows.Forms.ToolStripMenuItem _infoViewTitle;
        private System.Windows.Forms.ToolStripStatusLabel _infoFileLabel;
        private System.Windows.Forms.ToolStripStatusLabel _infoFileCount;
    }
}

