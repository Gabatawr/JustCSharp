namespace DirT
{
    partial class TabBox
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
            this.panelHeaders = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTabCreate = new System.Windows.Forms.Button();
            this.panelContents = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeaders
            // 
            this.panelHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHeaders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelHeaders.Location = new System.Drawing.Point(0, 0);
            this.panelHeaders.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeaders.Name = "panelHeaders";
            this.panelHeaders.Size = new System.Drawing.Size(1, 30);
            this.panelHeaders.TabIndex = 0;
            // 
            // btnTabCreate
            // 
            this.btnTabCreate.Location = new System.Drawing.Point(1, 0);
            this.btnTabCreate.Margin = new System.Windows.Forms.Padding(0);
            this.btnTabCreate.Name = "btnTabCreate";
            this.btnTabCreate.Size = new System.Drawing.Size(32, 30);
            this.btnTabCreate.TabIndex = 0;
            this.btnTabCreate.Text = "+";
            this.btnTabCreate.UseVisualStyleBackColor = true;
            this.btnTabCreate.Click += new System.EventHandler(this.btnTabCreate_Click);
            // 
            // panelContents
            // 
            this.panelContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContents.Location = new System.Drawing.Point(3, 33);
            this.panelContents.Margin = new System.Windows.Forms.Padding(0);
            this.panelContents.Name = "panelContents";
            this.panelContents.Size = new System.Drawing.Size(885, 392);
            this.panelContents.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Controls.Add(this.btnTabCreate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelHeaders, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(885, 30);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // TabBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelContents);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TabBox";
            this.Size = new System.Drawing.Size(891, 428);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelHeaders;
        private System.Windows.Forms.Panel panelContents;
        private System.Windows.Forms.Button btnTabCreate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
