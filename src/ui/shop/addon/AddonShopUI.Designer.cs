using System.ComponentModel;

namespace MeteorInstaller.ui.shop.addon
{
    partial class AddonShopUI
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
            this.addonList = new System.Windows.Forms.ListView();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.scrapeGithub = new System.Windows.Forms.CheckBox();
            this.scrapeAntiCope = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // addonList
            // 
            this.addonList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.addonList.AutoArrange = false;
            this.addonList.Dock = System.Windows.Forms.DockStyle.Top;
            this.addonList.Location = new System.Drawing.Point(0, 0);
            this.addonList.Name = "addonList";
            this.addonList.Size = new System.Drawing.Size(512, 402);
            this.addonList.TabIndex = 0;
            this.addonList.UseCompatibleStateImageBehavior = false;
            this.addonList.View = System.Windows.Forms.View.List;
            this.addonList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.addonList_ItemSelectionChanged);
            //this.addonList.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.addonList_ControlAdded);
            // 
            // logBox
            // 
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logBox.Location = new System.Drawing.Point(0, 470);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(512, 205);
            this.logBox.TabIndex = 1;
            this.logBox.Text = "";
            // 
            // updateButton
            // 
            this.updateButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.updateButton.Location = new System.Drawing.Point(0, 437);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(512, 33);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // scrapeGithub
            // 
            this.scrapeGithub.Location = new System.Drawing.Point(12, 408);
            this.scrapeGithub.Name = "scrapeGithub";
            this.scrapeGithub.Size = new System.Drawing.Size(144, 23);
            this.scrapeGithub.TabIndex = 3;
            this.scrapeGithub.Text = "Scrape Github";
            this.scrapeGithub.UseVisualStyleBackColor = true;
            // 
            // scrapeAntiCope
            // 
            this.scrapeAntiCope.Location = new System.Drawing.Point(162, 408);
            this.scrapeAntiCope.Name = "scrapeAntiCope";
            this.scrapeAntiCope.Size = new System.Drawing.Size(186, 23);
            this.scrapeAntiCope.TabIndex = 4;
            this.scrapeAntiCope.Text = "Scrape AntiCope.ml\r\n";
            this.scrapeAntiCope.UseVisualStyleBackColor = true;
            // 
            // AddonShopUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 675);
            this.Controls.Add(this.scrapeAntiCope);
            this.Controls.Add(this.scrapeGithub);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.addonList);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AddonShopUI";
            this.Text = "AddonShopUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddonShopUI_FormClosing);
            this.Shown += new System.EventHandler(this.AddonShopUI_Shown);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.CheckBox scrapeGithub;
        private System.Windows.Forms.CheckBox scrapeAntiCope;

        private System.Windows.Forms.Button updateButton;

        private System.Windows.Forms.RichTextBox logBox;

        private System.Windows.Forms.ListView addonList;

        #endregion
    }
}