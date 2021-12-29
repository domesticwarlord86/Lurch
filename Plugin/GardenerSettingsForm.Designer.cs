
namespace TheGardener
{
    partial class GardenerSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GardenerSettingsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BtnSetLocation3 = new System.Windows.Forms.Button();
            this.BtnSetLocation2 = new System.Windows.Forms.Button();
            this.BtnSetLocation = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.ChocoboSettings = new System.Windows.Forms.TabPage();
            this.StableLoc = new System.Windows.Forms.Button();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.ChocoboSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.ChocoboSettings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(643, 381);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BtnSetLocation3);
            this.tabPage1.Controls.Add(this.BtnSetLocation2);
            this.tabPage1.Controls.Add(this.BtnSetLocation);
            this.tabPage1.Controls.Add(this.propertyGrid1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(635, 355);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "GardenSettings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BtnSetLocation3
            // 
            this.BtnSetLocation3.Location = new System.Drawing.Point(429, 308);
            this.BtnSetLocation3.Name = "BtnSetLocation3";
            this.BtnSetLocation3.Size = new System.Drawing.Size(186, 28);
            this.BtnSetLocation3.TabIndex = 4;
            this.BtnSetLocation3.Text = "Set Garden3 Location";
            this.BtnSetLocation3.UseVisualStyleBackColor = true;
            this.BtnSetLocation3.Click += new System.EventHandler(this.BtnSetLocation3_Click_1);
            // 
            // BtnSetLocation2
            // 
            this.BtnSetLocation2.Location = new System.Drawing.Point(220, 308);
            this.BtnSetLocation2.Name = "BtnSetLocation2";
            this.BtnSetLocation2.Size = new System.Drawing.Size(186, 28);
            this.BtnSetLocation2.TabIndex = 3;
            this.BtnSetLocation2.Text = "Set Garden2 Location";
            this.BtnSetLocation2.UseVisualStyleBackColor = true;
            this.BtnSetLocation2.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnSetLocation
            // 
            this.BtnSetLocation.Location = new System.Drawing.Point(8, 308);
            this.BtnSetLocation.Name = "BtnSetLocation";
            this.BtnSetLocation.Size = new System.Drawing.Size(186, 28);
            this.BtnSetLocation.TabIndex = 2;
            this.BtnSetLocation.Text = "Set Garden1 Location";
            this.BtnSetLocation.UseVisualStyleBackColor = true;
            this.BtnSetLocation.Click += new System.EventHandler(this.BtnSetLocation_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(629, 344);
            this.propertyGrid1.TabIndex = 1;
            this.propertyGrid1.Click += new System.EventHandler(this.propertyGrid1_Click);
            // 
            // ChocoboSettings
            // 
            this.ChocoboSettings.Controls.Add(this.StableLoc);
            this.ChocoboSettings.Controls.Add(this.propertyGrid2);
            this.ChocoboSettings.Location = new System.Drawing.Point(4, 22);
            this.ChocoboSettings.Name = "ChocoboSettings";
            this.ChocoboSettings.Padding = new System.Windows.Forms.Padding(3);
            this.ChocoboSettings.Size = new System.Drawing.Size(635, 355);
            this.ChocoboSettings.TabIndex = 1;
            this.ChocoboSettings.Text = "ChocoboSettings";
            this.ChocoboSettings.UseVisualStyleBackColor = true;
            // 
            // StableLoc
            // 
            this.StableLoc.Location = new System.Drawing.Point(479, 324);
            this.StableLoc.Name = "StableLoc";
            this.StableLoc.Size = new System.Drawing.Size(148, 23);
            this.StableLoc.TabIndex = 1;
            this.StableLoc.Text = "Set Stable Location";
            this.StableLoc.UseVisualStyleBackColor = true;
            this.StableLoc.Click += new System.EventHandler(this.StableLoc_Click);
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(635, 355);
            this.propertyGrid2.TabIndex = 0;
            // 
            // GardenerSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 381);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "GardenerSettingsForm";
            this.Text = "GardenerSettings";
            this.Load += new System.EventHandler(this.GardenerSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ChocoboSettings.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button StableLoc;

        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.TabPage ChocoboSettings;

        private System.Windows.Forms.Button BtnSetLocation3;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Button BtnSetLocation2;

        private System.Windows.Forms.Button BtnSet2Location;

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button BtnSetLocation;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}