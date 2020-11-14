namespace DirT
{
    partial class TabHeader
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        private void InitializeComponent()
        {
            this.btnTabClose = new System.Windows.Forms.Button();
            this.dirName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTabClose
            // 
            this.btnTabClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTabClose.FlatAppearance.BorderSize = 0;
            this.btnTabClose.ForeColor = System.Drawing.Color.Silver;
            this.btnTabClose.Location = new System.Drawing.Point(101, 4);
            this.btnTabClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnTabClose.Name = "btnTabClose";
            this.btnTabClose.Size = new System.Drawing.Size(22, 22);
            this.btnTabClose.TabStop = false;
            this.btnTabClose.Text = "X";
            this.btnTabClose.UseVisualStyleBackColor = false;
            this.btnTabClose.Click += new System.EventHandler(this.btnTabClose_Click);
            this.btnTabClose.MouseLeave += new System.EventHandler(this.btnTabClose_MouseLeave);
            this.btnTabClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnTabClose_MouseMove);
            // 
            // dirName
            // 
            this.dirName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dirName.AutoSize = true;
            this.dirName.Location = new System.Drawing.Point(3, 8);
            this.dirName.Name = "dirName";
            this.dirName.Text = "dirName";
            this.dirName.Size = new System.Drawing.Size(0, 13);
            this.dirName.TabIndex = 1;
            this.dirName.Click += new System.EventHandler(this.TabHeader_Click);
            // 
            // TabHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.dirName);
            this.Controls.Add(this.btnTabClose);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.MaximumSize = new System.Drawing.Size(128, 32);
            this.MinimumSize = new System.Drawing.Size(64, 32);
            this.Name = "TabHeader";
            this.Size = new System.Drawing.Size(126, 30);
            this.Click += new System.EventHandler(this.TabHeader_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTabClose;
        private System.Windows.Forms.Label dirName;
    }
}
