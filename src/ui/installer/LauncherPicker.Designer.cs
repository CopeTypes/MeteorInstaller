using System.ComponentModel;

namespace MeteorInstaller.ui.installer
{
    partial class LauncherPicker
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
            this.launcherChoices = new System.Windows.Forms.ListView();
            this.noLauncherMain = new System.Windows.Forms.Label();
            this.noLauncherSub = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // launcherChoices
            // 
            this.launcherChoices.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.launcherChoices.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launcherChoices.Location = new System.Drawing.Point(0, 159);
            this.launcherChoices.Name = "launcherChoices";
            this.launcherChoices.Size = new System.Drawing.Size(363, 212);
            this.launcherChoices.TabIndex = 0;
            this.launcherChoices.UseCompatibleStateImageBehavior = false;
            this.launcherChoices.View = System.Windows.Forms.View.List;
            this.launcherChoices.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.launcherChoices_ItemSelectionChanged);
            // 
            // noLauncherMain
            // 
            this.noLauncherMain.Font = new System.Drawing.Font("Microsoft YaHei Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noLauncherMain.Location = new System.Drawing.Point(12, 9);
            this.noLauncherMain.Name = "noLauncherMain";
            this.noLauncherMain.Size = new System.Drawing.Size(338, 71);
            this.noLauncherMain.TabIndex = 1;
            this.noLauncherMain.Text = "You don\'t have a Minecraft launcher installed!";
            this.noLauncherMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // noLauncherSub
            // 
            this.noLauncherSub.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noLauncherSub.Location = new System.Drawing.Point(12, 114);
            this.noLauncherSub.Name = "noLauncherSub";
            this.noLauncherSub.Size = new System.Drawing.Size(338, 42);
            this.noLauncherSub.TabIndex = 2;
            this.noLauncherSub.Text = "Pick one of these trusted launchers to install";
            this.noLauncherSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LauncherPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 371);
            this.Controls.Add(this.noLauncherSub);
            this.Controls.Add(this.noLauncherMain);
            this.Controls.Add(this.launcherChoices);
            this.Name = "LauncherPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LauncherPicker";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label noLauncherSub;

        private System.Windows.Forms.Label noLauncherMain;

        private System.Windows.Forms.ListView launcherChoices;

        #endregion
    }
}