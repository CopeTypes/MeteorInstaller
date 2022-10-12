using System.ComponentModel;

namespace MeteorInstaller.ui.installer
{
    partial class JavaInstallPanel
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
            this.progressBar.Location = new System.Drawing.Point(0, 295);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(406, 27);
            this.progressBar.TabIndex = 0;
            // 
            // logBox
            // 
            this.logBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.logBox.Location = new System.Drawing.Point(0, 0);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(406, 289);
            this.logBox.TabIndex = 1;
            this.logBox.Text = "";
            // 
            // JavaInstallPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 322);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.progressBar);
            this.Name = "JavaInstallPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JavaInstallPanel";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.JavaInstallPanel_Shown);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.RichTextBox logBox;

        private System.Windows.Forms.ProgressBar progressBar;

        #endregion
    }
}