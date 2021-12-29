using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ff14bot;
using ff14bot.Helpers;

namespace TheGardener
{
    public partial class GardenerSettingsForm : Form
    {
        private readonly Dictionary<uint,string> _seeds = new Dictionary<uint, string>
        {
            {7715, "Paprika Seeds"},
            {7716, "Wild Onion Set"},
            {7717, "Coerthan Carrot Seeds"},
            {7718, "La Noscean Lettuce Seeds"},
            {7719, "Olive Seeds"},
            {7720, "Popoto Set"},
            {7721, "Millioncorn Seeds"},
            {7722, "Wizard Eggplant Seeds"},
            {7723, "Midland Cabbage Seeds"},
            {7724, "Dzemael Tomato Seeds"},
            {7725, "La Noscean Orange Seeds"},
            {7726, "Lowland Grape Seeds"},
            {7727, "Faerie Apple Seeds"},
            {7728, "Sun Lemon Seeds"},
            {7729, "Pixie Plum Seeds"},
            {7730, "Blood Currant Seeds"},
            {7731, "Mirror Apple Seeds"},
            {7732, "Rolanberry Seeds"},
            {7733, "Honey Lemon Seeds"},
            {7734, "Prickly Pineapple Seeds"},
            {7735, "Garlic Cloves"},
            {7736, "Lavender Seeds"},
            {7737, "Black Pepper Seeds"},
            {7738, "Ala Mhigan Mustard Seeds"},
            {7739, "Pearl Ginger Root"},
            {7740, "Chamomile Seeds"},
            {7741, "Linseed"},
            {7742, "Midland Basil Seeds"},
            {7743, "Mandrake Seeds"},
            {7744, "Almond Seeds"},
            {7745, "Halone Gerbera Seeds"},
            {7746, "Azeyma Rose Seeds"},
            {7747, "Nymeia Lily Seeds"},
            {7748, "Star Anise Seeds"},
            {7749, "Dalamud Popoto Set"},
            {7750, "Royal Kukuru Seeds"},
            {7751, "Apricot Kernels"},
            {7752, "La Noscean Leek Seeds"},
            {7753, "Shroud Tea Seeds"},
            {7754, "Umbrella Fig Seeds"},
            {7755, "Jute Seeds"},
            {7756, "Glazenut Seeds"},
            {7757, "Broombush Seeds"},
            {8167, "Pearl Roselle Seeds"},
            {8169, "Curiel Root Seeds"},
            {8170, "Sylkis Bud Seeds"},
            {8171, "Mimett Gourd Seeds"},
            {8172, "Tantalplant Seeds"},
            {8173, "Pahsana Fruit Seeds"},
            {8174, "Xelphatol Apple Seeds"},
            {8175, "Doman Plum Pits"},
            {8176, "Mamook Pear Seeds"},
            {8177, "Valfruit Seeds"},
            {8178, "O'Ghomoro Berry Seeds"},
            {8179, "Cieldalaes Pineapple Seeds"},
            {8180, "Han Lemon Seeds"},
            {8182, "Krakka Root Seeds"},
            {8183, "Thavnairian Onion Seeds"},
            {8184, "Onion Prince Seeds"},
            {8185, "Eggplant Knight Seeds"},
            {8186, "Garlic Jester Seeds"},
            {8187, "Tomato King Seeds"},
            {8188, "Mandragora Queen Seeds"},
            {8572, "Gysahl Greens Seeds"},
            {13755, "Blood Pepper Seeds"},
            {13765, "Old World Fig Seeds"},
            {13766, "Chive Seeds"},
            {13767, "Pearl Sprout Seeds"},
            {13768, "Coerthan Tea Seeds"},
            {14007, "Oldrose Seeds"},
            {15855, "Althyk Lavender Seeds"},
            {15856, "Voidrake Seeds"},
            {15865, "Firelight Seeds"},
            {15866, "Icelight Seeds"},
            {15867, "Windlight Seeds"},
            {15868, "Earthlight Seeds"},
            {15869, "Levinlight Seeds"},
            {15870, "Waterlight Seeds"},
            {16016, "Viola Seeds"},
            {17546, "Shroud Cherry Sapling"},
            {17547, "Cloud Acorn Sapling"},
            {17996, "Daisy Seeds"},
            {20792, "Cloudsbreath Seeds"},
            {20794, "Royal Fern Sori"},
            {20795, "Brightlily Seeds"},
            {21875, "Tulip Bulbs"},
            {22589, "Dahlia Bulbs"},
            {24165, "Arum Bulbs"},
            {24541, "Lily of the Valley Pips"},
            {27320, "Hydrangea Seeds"},
            {28175, "Campanula Seeds"},
            {28947, "Hyacinth Bulbs"},
            {30364, "Allagan Melon Seeds"},
            {30365, "Cosmos Seeds"},
            {32812, "Carnation Seeds"},
        };

        private readonly Dictionary<uint, string> _soils = new Dictionary<uint, string>
        {
            {7758, "Grade 1 La Noscean Topsoil"},
            {7759, "Grade 2 La Noscean Topsoil"},
            {7760, "Grade 3 La Noscean Topsoil"},
            {7761, "Grade 1 Shroud Topsoil"},
            {7762, "Grade 2 Shroud Topsoil"},
            {7763, "Grade 3 Shroud Topsoil"},
            {7764, "Grade 1 Thanalan Topsoil"},
            {7765, "Grade 2 Thanalan Topsoil"},
            {7766, "Grade 3 Thanalan Topsoil"},
            {16026, "Potting Soil"},
        };

        public GardenerSettingsForm() 
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = TheGardener.GardenSettings;
            propertyGrid1.Update();
            propertyGrid2.SelectedObject = TheGardener.ChocoboSettings;
            propertyGrid2.Update();            
            initialize_form();
        }

        private void initialize_form()
        {
            /*
            // Set all Seed ComboBoxes to the SeedList
            for (int i = 0; i < 8; i++) {
                var b = new BindingSource {DataSource = _seeds};
                var ctl = Controls.Find($"comboSeed{i}", true);
                if (ctl.Length == 0) continue;
                foreach (var control in ctl)
                {
                    var cb = (ComboBox) control;
                    SetDoubleBuffer(cb, true);
                    cb.DataSource = b;
                    cb.DisplayMember = "Value";
                    cb.ValueMember = "Key";
                }
            }
            // Set all Soil ComboBoxes to the SoilList
            for (int i = 0; i < 8; i++) {
                var b = new BindingSource {DataSource = _soils};
                var ctl = Controls.Find($"comboSoil{i}", true);
                if (ctl.Length == 0) continue;
                foreach (var control in ctl)
                {
                    var cb = (ComboBox) control;                    
                    SetDoubleBuffer(cb, true);
                    cb.DataSource = b;
                    cb.DisplayMember = "Value";
                    cb.ValueMember = "Key";
                }
            }
            // Initialize ComboBoxes to what was found in Settings.
            if (_seeds.ContainsKey(GardenerSettings.Instance.Seed0)) comboSeed0.SelectedValue = GardenerSettings.Instance.Seed0;
            if (_soils.ContainsKey(GardenerSettings.Instance.Soil0)) comboSoil0.SelectedValue = GardenerSettings.Instance.Soil0;

            if (_seeds.ContainsKey(GardenerSettings.Instance.Seed1)) comboSeed1.SelectedValue = GardenerSettings.Instance.Seed1;
            if (_soils.ContainsKey(GardenerSettings.Instance.Soil1)) comboSoil1.SelectedValue = GardenerSettings.Instance.Soil1;

            if (_seeds.ContainsKey(GardenerSettings.Instance.Seed2)) comboSeed2.SelectedValue = GardenerSettings.Instance.Seed2;
            if (_soils.ContainsKey(GardenerSettings.Instance.Soil2)) comboSoil2.SelectedValue = GardenerSettings.Instance.Soil2;

            if (_seeds.ContainsKey(GardenerSettings.Instance.Seed3)) comboSeed3.SelectedValue = GardenerSettings.Instance.Seed3;
            if (_soils.ContainsKey(GardenerSettings.Instance.Soil3)) comboSoil3.SelectedValue = GardenerSettings.Instance.Soil3;

            if (_seeds.ContainsKey(GardenerSettings.Instance.Seed4)) comboSeed4.SelectedValue = GardenerSettings.Instance.Seed4;
            if (_soils.ContainsKey(GardenerSettings.Instance.Soil4)) comboSoil4.SelectedValue = GardenerSettings.Instance.Soil4;

            if (_seeds.ContainsKey(GardenerSettings.Instance.Seed5)) comboSeed5.SelectedValue = GardenerSettings.Instance.Seed5;
            if (_soils.ContainsKey(GardenerSettings.Instance.Soil5)) comboSoil5.SelectedValue = GardenerSettings.Instance.Soil5;

            if (_seeds.ContainsKey(GardenerSettings.Instance.Seed6)) comboSeed6.SelectedValue = GardenerSettings.Instance.Seed6;
            if (_soils.ContainsKey(GardenerSettings.Instance.Soil6)) comboSoil6.SelectedValue = GardenerSettings.Instance.Soil6;

            if (_seeds.ContainsKey(GardenerSettings.Instance.Seed7)) comboSeed7.SelectedValue = GardenerSettings.Instance.Seed7;
            if (_soils.ContainsKey(GardenerSettings.Instance.Soil7)) comboSoil7.SelectedValue = GardenerSettings.Instance.Soil7;
            */       
        }

        private void SetDoubleBuffer(Control ctl, bool doublebuffered)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                ctl,
                new object[] { doublebuffered });
        }

        private void GardenerSettings_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = TheGardener.GardenSettings;
        }

        private void BtnSetLocation_Click(object sender, EventArgs e)
        {
            GardenerSettings.Instance.GardenLocation = Core.Me.Location;
            propertyGrid1.SelectedObject = TheGardener.GardenSettings;
            propertyGrid1.Update();
        }
        
        private void BtnSetLocation3_Click_1(object sender, EventArgs e)
        {
            GardenerSettings.Instance.GardenLocation3 = Core.Me.Location;
            propertyGrid1.SelectedObject = TheGardener.GardenSettings;
            propertyGrid1.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GardenerSettings.Instance.GardenLocation2 = Core.Me.Location;
            propertyGrid1.SelectedObject = TheGardener.GardenSettings;
            propertyGrid1.Update();
        }
        
        /*

        private void comboSeed0_SelectedIndexChanged(object sender, EventArgs e)
        {
            GardenerSettings.Instance.Seed0 = (uint) comboSeed0.SelectedValue;
        }

        private void comboSoil0_SelectedIndexChanged(object sender, EventArgs e)
        {
            GardenerSettings.Instance.Soil0 = (uint) comboSoil0.SelectedValue;
        }

        private void comboSeed1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GardenerSettings.Instance.Seed1 = (uint) comboSeed1.SelectedValue;
        }

        private void comboSoil1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GardenerSettings.Instance.Soil1 = (uint) comboSoil1.SelectedValue;
        }

        private void comboSeed2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GardenerSettings.Instance.Seed2 = (uint) comboSeed2.SelectedValue;
        }

        private void comboSoil2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GardenerSettings.Instance.Soil2 = (uint) comboSoil2.SelectedValue;
        }

        private void comboSeed3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GardenerSettings.Instance.Seed3 = (uint) comboSeed3.SelectedValue;
        }

        private void comboSoil3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GardenerSettings.Instance.Soil3 = (uint) comboSoil3.SelectedValue;
        }

        private void comboSeed4_SelectedIndexChanged(object sender, EventArgs e)
        {
            GardenerSettings.Instance.Seed4 = (uint) comboSeed4.SelectedValue;
        }

        private void comboSoil4_SelectedIndexChanged(object sender, EventArgs e)
        {
            GardenerSettings.Instance.Soil4 = (uint) comboSoil4.SelectedValue;
        }

        private void comboSeed5_SelectedIndexChanged(object sender, EventArgs e)
        {
            GardenerSettings.Instance.Seed5 = (uint) comboSeed5.SelectedValue;
        }

        private void comboSoil5_SelectedIndexChanged(object sender, EventArgs e)
        {
            GardenerSettings.Instance.Soil5 = (uint) comboSoil5.SelectedValue;
        }

        private void comboSeed6_SelectedIndexChanged(object sender, EventArgs e)
        {
            GardenerSettings.Instance.Seed6 = (uint) comboSeed6.SelectedValue;
        }

        private void comboSoil6_SelectedIndexChanged(object sender, EventArgs e)
        {
            GardenerSettings.Instance.Soil6 = (uint) comboSoil6.SelectedValue;
        }

        private void comboSeed7_SelectedIndexChanged(object sender, EventArgs e)
        {
            GardenerSettings.Instance.Seed7 = (uint) comboSeed7.SelectedValue;
        }

        private void comboSoil7_SelectedIndexChanged(object sender, EventArgs e)
        {
            GardenerSettings.Instance.Soil7 = (uint) comboSoil7.SelectedValue;
        }

        */


        private void propertyGrid1_Click(object sender, EventArgs e)
        {
            propertyGrid2.SelectedObject = TheGardener.ChocoboSettings;
        }

        private void StableLoc_Click(object sender, EventArgs e)
        {
            TheGardener.ChocoboSettings.StableLocation = Core.Me.Location;
            propertyGrid2.SelectedObject = TheGardener.ChocoboSettings;
            propertyGrid2.Update();
        }
    }
}
