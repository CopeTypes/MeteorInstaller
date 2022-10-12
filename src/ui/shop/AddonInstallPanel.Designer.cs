using System.ComponentModel;

namespace MeteorInstaller.ui.shop
{
    partial class AddonInstallPanel
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 299);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(406, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            // 
            // logBox
            // 
            this.logBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.logBox.Location = new System.Drawing.Point(0, 0);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(406, 293);
            this.logBox.TabIndex = 1;
            this.logBox.Text = "";
            // 
            // AddonInstallPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 322);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.progressBar);
            this.Name = "AddonInstallPanel";
            this.Text = "AddonInstallPanel";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.AddonInstallPanel_Shown);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.RichTextBox logBox;

        private System.Windows.Forms.ProgressBar progressBar;

        #endregion
    }
}