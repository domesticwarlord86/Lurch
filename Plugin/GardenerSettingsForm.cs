using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ff14bot;

namespace TheGardener
{
    public partial class GardenerSettingsForm : Form
    {
        public GardenerSettingsForm() {
            InitializeComponent();
        }

        private void GardenerSettings_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = TheGardener.Settings;
        }

        private void BtnSetLocation_Click(object sender, EventArgs e)
        {
            GardenerSettings.Instance.GardenLocation = Core.Me.Location;
            propertyGrid1.SelectedObject = TheGardener.Settings;
            propertyGrid1.Update();
        }
    }
}
