using System.ComponentModel;

namespace MeteorInstaller.ui.installer
{
    partial class InstallPanel
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
            this.textbox = new System.Windows.Forms.RichTextBox();
            this.progress_bar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // textbox
            // 
            this.textbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.textbox.Location = new System.Drawing.Point(0, 0);
            this.textbox.Name = "textbox";
            this.textbox.ReadOnly = true;
            this.textbox.Size = new System.Drawing.Size(533, 312);
            this.textbox.TabIndex = 0;
            this.textbox.Text = "";
            // 
            // progress_bar
            // 
            this.progress_bar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progress_bar.Location = new System.Drawing.Point(0, 158);
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Size = new System.Drawing.Size(533, 23);
            this.progress_bar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress_bar.TabIndex = 1;
            // 
            // InstallPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(533, 181);
            this.Controls.Add(this.progress_bar);
            this.Controls.Add(this.textbox);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "InstallPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.InstallPanel_Shown);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ProgressBar progress_bar;

        private System.Windows.Forms.RichTextBox textbox;

        #endregion
    }
}