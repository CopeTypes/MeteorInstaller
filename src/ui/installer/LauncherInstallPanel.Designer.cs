using System.ComponentModel;

namespace MeteorInstaller.ui.installer
{
    partial class LauncherInstallPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.logBox.Location = new System.Drawing.Point(0, 0);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(390, 222);
            this.logBox.TabIndex = 0;
            this.logBox.Text = "";
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 228);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(390, 26);
            this.progressBar.TabIndex = 1;
            // 
            // LauncherInstallPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 254);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.logBox);
            this.Name = "LauncherInstallPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LauncherInstallPanel";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.LauncherInstallPanel_Shown);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ProgressBar progressBar;

        private System.Windows.Forms.RichTextBox logBox;

        #endregion
    }
}