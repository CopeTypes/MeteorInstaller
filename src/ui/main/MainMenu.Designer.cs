namespace MeteorInstaller.ui.main
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.install_dev = new System.Windows.Forms.Button();
            this.install_release = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.customDir = new System.Windows.Forms.CheckBox();
            this.customFolder = new System.Windows.Forms.TextBox();
            this.skipLauncherCheck = new System.Windows.Forms.CheckBox();
            this.addonShop = new System.Windows.Forms.Button();
            this.launcherPick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // install_dev
            // 
            this.install_dev.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.install_dev.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.install_dev.Location = new System.Drawing.Point(0, 302);
            this.install_dev.Name = "install_dev";
            this.install_dev.Size = new System.Drawing.Size(408, 59);
            this.install_dev.TabIndex = 0;
            this.install_dev.Text = "Install Dev Build";
            this.install_dev.UseVisualStyleBackColor = true;
            this.install_dev.Click += new System.EventHandler(this.install_dev_Click);
            // 
            // install_release
            // 
            this.install_release.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.install_release.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.install_release.Location = new System.Drawing.Point(0, 243);
            this.install_release.Name = "install_release";
            this.install_release.Size = new System.Drawing.Size(408, 59);
            this.install_release.TabIndex = 1;
            this.install_release.Text = "Install Release";
            this.install_release.UseVisualStyleBackColor = true;
            this.install_release.Click += new System.EventHandler(this.install_release_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 65);
            this.label1.TabIndex = 2;
            this.label1.Text = "Meteor on Crack!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customDir
            // 
            this.customDir.Location = new System.Drawing.Point(12, 68);
            this.customDir.Name = "customDir";
            this.customDir.Size = new System.Drawing.Size(138, 18);
            this.customDir.TabIndex = 3;
            this.customDir.Text = "Custom Install Folder";
            this.customDir.UseVisualStyleBackColor = true;
            this.customDir.CheckedChanged += new System.EventHandler(this.customDir_CheckedChanged);
            // 
            // customFolder
            // 
            this.customFolder.Location = new System.Drawing.Point(156, 65);
            this.customFolder.Name = "customFolder";
            this.customFolder.Size = new System.Drawing.Size(240, 21);
            this.customFolder.TabIndex = 4;
            this.customFolder.Text = "install folder";
            this.customFolder.Visible = false;
            // 
            // skipLauncherCheck
            // 
            this.skipLauncherCheck.Location = new System.Drawing.Point(12, 92);
            this.skipLauncherCheck.Name = "skipLauncherCheck";
            this.skipLauncherCheck.Size = new System.Drawing.Size(138, 18);
            this.skipLauncherCheck.TabIndex = 5;
            this.skipLauncherCheck.Text = "Custom Launcher";
            this.skipLauncherCheck.UseVisualStyleBackColor = true;
            // 
            // addonShop
            // 
            this.addonShop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.addonShop.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addonShop.Location = new System.Drawing.Point(0, 184);
            this.addonShop.Name = "addonShop";
            this.addonShop.Size = new System.Drawing.Size(408, 59);
            this.addonShop.TabIndex = 6;
            this.addonShop.Text = "Addon Shop";
            this.addonShop.UseVisualStyleBackColor = true;
            this.addonShop.Click += new System.EventHandler(this.addonShop_Click);
            // 
            // launcherPick
            // 
            this.launcherPick.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.launcherPick.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launcherPick.Location = new System.Drawing.Point(0, 125);
            this.launcherPick.Name = "launcherPick";
            this.launcherPick.Size = new System.Drawing.Size(408, 59);
            this.launcherPick.TabIndex = 7;
            this.launcherPick.Text = "I need a launcher";
            this.launcherPick.UseVisualStyleBackColor = true;
            this.launcherPick.Click += new System.EventHandler(this.launcherPick_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(408, 361);
            this.Controls.Add(this.launcherPick);
            this.Controls.Add(this.addonShop);
            this.Controls.Add(this.skipLauncherCheck);
            this.Controls.Add(this.customFolder);
            this.Controls.Add(this.customDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.install_release);
            this.Controls.Add(this.install_dev);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button launcherPick;

        private System.Windows.Forms.Button addonShop;

        private System.Windows.Forms.CheckBox skipLauncherCheck;

        private System.Windows.Forms.CheckBox customDir;
        private System.Windows.Forms.TextBox customFolder;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button install_release;

        private System.Windows.Forms.Button install_dev;

        #endregion
    }
}