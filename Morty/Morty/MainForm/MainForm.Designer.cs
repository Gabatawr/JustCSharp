using System;
using System.Drawing;
using System.Windows.Forms;

namespace Morty
{
    partial class MainForm : Form
    {
        #region _sys

        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #endregion
        private void InitializeComponent()
        {
            // Form
            Text = "Morty";
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            MinimumSize = new Size(320, 240);
            BackColor = Color.White;

            // Event
            this.KeyDown += KeyDown_Alt;
        }

    }
}

