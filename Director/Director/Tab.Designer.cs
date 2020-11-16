
using System.Windows.Forms;

namespace Director
{
    partial class Tab
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.content = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // content
            // 
            this.content.BackColor = System.Drawing.Color.White;
            this.content.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.FullRowSelect = true;
            this.content.HideSelection = false;
            this.content.Location = new System.Drawing.Point(0, 0);
            this.content.Margin = new System.Windows.Forms.Padding(0);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(12, 12);
            this.content.TabIndex = 0;
            this.content.UseCompatibleStateImageBehavior = false;
            this.content.View = System.Windows.Forms.View.Details;
            // 
            // Tab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.content);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Tab";
            this.Size = new System.Drawing.Size(12, 12);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView content;
    }
}
