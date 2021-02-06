
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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.BtnSetLocation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(477, 350);
            this.propertyGrid1.TabIndex = 0;
            // 
            // BtnSetLocation
            // 
            this.BtnSetLocation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnSetLocation.Location = new System.Drawing.Point(0, 357);
            this.BtnSetLocation.Name = "BtnSetLocation";
            this.BtnSetLocation.Size = new System.Drawing.Size(477, 24);
            this.BtnSetLocation.TabIndex = 1;
            this.BtnSetLocation.Text = "Set Garden Location";
            this.BtnSetLocation.UseVisualStyleBackColor = true;
            this.BtnSetLocation.Click += new System.EventHandler(this.BtnSetLocation_Click);
            // 
            // GardenerSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 381);
            this.Controls.Add(this.BtnSetLocation);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "GardenerSettingsForm";
            this.Text = "GardenerSettings";
            this.Load += new System.EventHandler(this.GardenerSettings_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button BtnSetLocation;

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}