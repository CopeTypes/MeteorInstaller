using System.ComponentModel;

namespace MeteorInstaller.ui.shop.addon
{
    partial class AddonSummaryUI
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
            this.addonName = new System.Windows.Forms.Label();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.verifyButton = new System.Windows.Forms.Button();
            this.viewModulesButton = new System.Windows.Forms.Button();
            this.addonModules = new System.Windows.Forms.Label();
            this.discordButton = new System.Windows.Forms.Button();
            this.githubButton = new System.Windows.Forms.Button();
            this.addonDownloads = new System.Windows.Forms.Label();
            this.addonDesc = new System.Windows.Forms.Label();
            this.installButton = new System.Windows.Forms.Button();
            this.addonAuthors = new System.Windows.Forms.Label();
            this.addonMeteorVer = new System.Windows.Forms.Label();
            this.addonMcVer = new System.Windows.Forms.Label();
            this.addonIcon = new System.Windows.Forms.PictureBox();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addonIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // addonName
            // 
            this.addonName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addonName.Location = new System.Drawing.Point(13, 38);
            this.addonName.Name = "addonName";
            this.addonName.Size = new System.Drawing.Size(290, 51);
            this.addonName.TabIndex = 0;
            this.addonName.Text = "Addon Name";
            this.addonName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // controlPanel
            // 
            this.controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPanel.Controls.Add(this.verifyButton);
            this.controlPanel.Controls.Add(this.viewModulesButton);
            this.controlPanel.Controls.Add(this.addonModules);
            this.controlPanel.Controls.Add(this.discordButton);
            this.controlPanel.Controls.Add(this.githubButton);
            this.controlPanel.Controls.Add(this.addonDownloads);
            this.controlPanel.Controls.Add(this.addonDesc);
            this.controlPanel.Controls.Add(this.installButton);
            this.controlPanel.Controls.Add(this.addonAuthors);
            this.controlPanel.Controls.Add(this.addonMeteorVer);
            this.controlPanel.Controls.Add(this.addonMcVer);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlPanel.Location = new System.Drawing.Point(0, 115);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(485, 162);
            this.controlPanel.TabIndex = 1;
            // 
            // verifyButton
            // 
            this.verifyButton.Location = new System.Drawing.Point(231, 125);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(90, 24);
            this.verifyButton.TabIndex = 10;
            this.verifyButton.Text = "Verify";
            this.verifyButton.UseVisualStyleBackColor = true;
            this.verifyButton.Click += new System.EventHandler(this.verifyButton_Click);
            // 
            // viewModulesButton
            // 
            this.viewModulesButton.Location = new System.Drawing.Point(120, 125);
            this.viewModulesButton.Name = "viewModulesButton";
            this.viewModulesButton.Size = new System.Drawing.Size(90, 24);
            this.viewModulesButton.TabIndex = 9;
            this.viewModulesButton.Text = "View Modules";
            this.viewModulesButton.UseVisualStyleBackColor = true;
            this.viewModulesButton.Click += new System.EventHandler(this.viewModulesButton_Click);
            // 
            // addonModules
            // 
            this.addonModules.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addonModules.Location = new System.Drawing.Point(12, 125);
            this.addonModules.Name = "addonModules";
            this.addonModules.Size = new System.Drawing.Size(102, 18);
            this.addonModules.TabIndex = 8;
            this.addonModules.Text = "Modules:";
            // 
            // discordButton
            // 
            this.discordButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discordButton.Location = new System.Drawing.Point(338, 104);
            this.discordButton.Name = "discordButton";
            this.discordButton.Size = new System.Drawing.Size(107, 39);
            this.discordButton.TabIndex = 7;
            this.discordButton.Text = "Discord";
            this.discordButton.UseVisualStyleBackColor = true;
            this.discordButton.Click += new System.EventHandler(this.discordButton_Click);
            // 
            // githubButton
            // 
            this.githubButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.githubButton.Location = new System.Drawing.Point(338, 59);
            this.githubButton.Name = "githubButton";
            this.githubButton.Size = new System.Drawing.Size(107, 39);
            this.githubButton.TabIndex = 6;
            this.githubButton.Text = "GitHub";
            this.githubButton.UseVisualStyleBackColor = true;
            this.githubButton.Click += new System.EventHandler(this.githubButton_Click);
            // 
            // addonDownloads
            // 
            this.addonDownloads.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addonDownloads.Location = new System.Drawing.Point(11, 86);
            this.addonDownloads.Name = "addonDownloads";
            this.addonDownloads.Size = new System.Drawing.Size(291, 18);
            this.addonDownloads.TabIndex = 5;
            this.addonDownloads.Text = "Downloads: ";
            // 
            // addonDesc
            // 
            this.addonDesc.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addonDesc.Location = new System.Drawing.Point(11, 14);
            this.addonDesc.Name = "addonDesc";
            this.addonDesc.Size = new System.Drawing.Size(310, 31);
            this.addonDesc.TabIndex = 0;
            // 
            // installButton
            // 
            this.installButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installButton.Location = new System.Drawing.Point(338, 14);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(107, 39);
            this.installButton.TabIndex = 4;
            this.installButton.Text = "Install";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // addonAuthors
            // 
            this.addonAuthors.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addonAuthors.Location = new System.Drawing.Point(11, 104);
            this.addonAuthors.Name = "addonAuthors";
            this.addonAuthors.Size = new System.Drawing.Size(291, 18);
            this.addonAuthors.TabIndex = 3;
            this.addonAuthors.Text = "Authors: ";
            // 
            // addonMeteorVer
            // 
            this.addonMeteorVer.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addonMeteorVer.Location = new System.Drawing.Point(11, 68);
            this.addonMeteorVer.Name = "addonMeteorVer";
            this.addonMeteorVer.Size = new System.Drawing.Size(291, 18);
            this.addonMeteorVer.TabIndex = 2;
            this.addonMeteorVer.Text = "Meteor Version: ";
            // 
            // addonMcVer
            // 
            this.addonMcVer.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addonMcVer.Location = new System.Drawing.Point(11, 50);
            this.addonMcVer.Name = "addonMcVer";
            this.addonMcVer.Size = new System.Drawing.Size(291, 18);
            this.addonMcVer.TabIndex = 1;
            this.addonMcVer.Text = "MC Version: ";
            // 
            // addonIcon
            // 
            this.addonIcon.Location = new System.Drawing.Point(339, 25);
            this.addonIcon.Name = "addonIcon";
            this.addonIcon.Size = new System.Drawing.Size(64, 64);
            this.addonIcon.TabIndex = 2;
            this.addonIcon.TabStop = false;
            this.addonIcon.Visible = false;
            // 
            // AddonSummaryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 277);
            this.Controls.Add(this.addonIcon);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.addonName);
            this.Name = "AddonSummaryUI";
            this.Text = "AddonSummaryUI";
            this.TopMost = true;
            this.controlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addonIcon)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button viewModulesButton;

        private System.Windows.Forms.Label addonModules;
        private System.Windows.Forms.Button verifyButton;

        private System.Windows.Forms.PictureBox addonIcon;

        private System.Windows.Forms.Button discordButton;

        private System.Windows.Forms.Button githubButton;

        private System.Windows.Forms.Label addonDownloads;

        private System.Windows.Forms.Label addonMeteorVer;
        private System.Windows.Forms.Label addonAuthors;
        private System.Windows.Forms.Button installButton;

        private System.Windows.Forms.Label addonMcVer;

        private System.Windows.Forms.Label addonDesc;

        private System.Windows.Forms.Panel controlPanel;

        private System.Windows.Forms.Label addonName;

        #endregion
    }
}