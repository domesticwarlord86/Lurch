using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using ff14bot;
using ff14bot.AClasses;
using ff14bot.Helpers;
using ff14bot.Managers;
using Clio.Utilities;
using LlamaLibrary;
using LlamaLibrary.Logging;

namespace TheGardener
{
    public class TheGardener : BotPlugin
    {
        public static string _name = "Lurch";
        
        private static readonly string NameValue = "Lurch";

        private static readonly LLogger LogLurch = new LLogger(NameValue, Colors.SaddleBrown);
        private static readonly LLogger LogGarden = new LLogger(NameValue, Colors.LawnGreen);
        private static readonly LLogger LogChocobo = new LLogger(NameValue, Colors.Yellow);
        private static readonly string HookName = "Lurch";
        private static readonly string HookName1 = "TheGardener";
        private static readonly string HookName2 = "ChocoboTrainer";

        //private static Func<uint, Task> _activate; Before adding gardenLoc
		private static Func<uint, Vector3, Task> _activate;

        private static List<Tuple<uint, uint>> plantPlan = new List<Tuple<uint, uint>>();
        private GardenerSettingsForm _form;
        public override string Author => "DomesticWarlord";
        public override Version Version => new Version(2, 0, 1);
        public override string Name => "Lurch Settings";
        public override string ButtonText => "Settings";
        public override bool WantButton => true;

        public static GardenerSettings GardenSettings => GardenerSettings.Instance;
        public static ChocoboSettings ChocoboSettings => ChocoboSettings.Instance;

        public override void OnButtonPress()
        {
            if (_form == null)
            {
                _form = new GardenerSettingsForm()
                {
                    Text = "Lurch Settings v" + Version,
                };
                _form.Closed += (o, e) => { _form = null; };
            }

            try
            {
                _form.Show();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public override void OnInitialize()
        {
        }

        public override void OnEnabled()
        {
            TreeRoot.OnStart += OnBotStart;
            TreeRoot.OnStop += OnBotStop;
            LogLurch.Information($"{_name} Enabled");
        }

        public override void OnDisabled()
        {
            TreeRoot.OnStart -= OnBotStart;
            TreeRoot.OnStop -= OnBotStop;
            LogLurch.Information($"{_name} Disabled");
        }

        private void OnBotStop(BotBase bot)
        {
            RemoveHooks();
        }

        private void OnBotStart(BotBase bot)
        {
            AddHooks();
        }

        private void AddHooks()
        {
            var hooks = LlamaLibrary.Helpers.Lisbeth.GetHookList();
            LogLurch.Information($"Adding {HookName} Hook");
            if (!hooks.Contains(HookName1))
            {
                LlamaLibrary.Helpers.Lisbeth.AddHook(HookName1, GardenTask);
            }
            if (!hooks.Contains(HookName2))
            {
                LlamaLibrary.Helpers.Lisbeth.AddHook(HookName2, ChocoboTask);
            }
        }

        private void RemoveHooks()
        {
            var hooks = LlamaLibrary.Helpers.Lisbeth.GetHookList();
            LogLurch.Information($"Removing {HookName} Hook");
            if (hooks.Contains(HookName))
            {
                LlamaLibrary.Helpers.Lisbeth.RemoveHook(HookName);
            }

        }

        public static async Task GardenTask()
        {
            LogLurch.Information($"Gardener Last Run Time: {GardenSettings.LastChecked}, Reset Time: {GardenSettings.ResetTime}, Current Time: {DateTime.Now}");
            LogLurch.Information($"Time Difference: {DateTime.Now - GardenSettings.LastChecked} ");
            //plantPlan.Clear();
            if ((DateTime.Now - GardenSettings.LastChecked).TotalHours > 1)
            {
                LogLurch.Information($"Past reset time of {GardenSettings.ResetTime}");
                LogLurch.Information($"Calling GoGarden");
                
                // Garden 1
                if (GardenSettings.GardenLocation != default(Vector3) && GardenSettings.Aetheryte != GardenerSettings.HouseAetheryte.Not_Selected)
                {
                   // if (Settings.ShouldPlant)
                   // {
                   //     GeneratePlantPlan();
                   // }
                   //await _activate((uint)Settings.Aetheryte, Settings.GardenLocation, plantPlan); // need to change this to accept a dict...
                   LogGarden.Information($"Go to Garden at Location 1: " +GardenSettings.Aetheryte);
                   await LlamaLibrary.Helpers.GardenHelper.GoGarden((uint)GardenSettings.Aetheryte, GardenSettings.GardenLocation, plantPlan); // need to change this to accept a dict...
                   GardenSettings.LastChecked = DateTime.Now;
                   GardenSettings.ResetTime = DateTime.Now + new TimeSpan(0, 1, 1, 0);
                }
                
                //Garden 2
                if (GardenSettings.GardenLocation2 != default(Vector3) && GardenSettings.Aetheryte2 != GardenerSettings.HouseAetheryte2.Not_Selected)
                {
                    // if (Settings.ShouldPlant)
                    // {
                    //     GeneratePlantPlan();
                    // }
                    //await _activate((uint)Settings.Aetheryte, Settings.GardenLocation, plantPlan); // need to change this to accept a dict...
                    LogGarden.Information($"Go to Garden at Location 2: " +GardenSettings.Aetheryte2);
                    await LlamaLibrary.Helpers.GardenHelper.GoGarden((uint)GardenSettings.Aetheryte2, GardenSettings.GardenLocation2, plantPlan); // need to change this to accept a dict...
                    GardenSettings.LastChecked = DateTime.Now;
                    GardenSettings.ResetTime = DateTime.Now + new TimeSpan(0, 1, 1, 0);
                }
                
                //Garden 3
                if (GardenSettings.GardenLocation3 != default(Vector3) && GardenSettings.Aetheryte3 != GardenerSettings.HouseAetheryte3.Not_Selected)
                {
                    // if (Settings.ShouldPlant)
                    // {
                    //     GeneratePlantPlan();
                    // }
                    //await _activate((uint)Settings.Aetheryte, Settings.GardenLocation, plantPlan); // need to change this to accept a dict...
                    LogGarden.Information($"Go to Garden at Location 3: " +GardenSettings.Aetheryte3);
                    await LlamaLibrary.Helpers.GardenHelper.GoGarden((uint)GardenSettings.Aetheryte3, GardenSettings.GardenLocation3, plantPlan); // need to change this to accept a dict...
                    GardenSettings.LastChecked = DateTime.Now;
                    GardenSettings.ResetTime = DateTime.Now + new TimeSpan(0, 1, 1, 0);
                }                
                
                else
                {
                    LogLurch.Information("No Garden Location or Aetheryte Set. Please check settings... Exiting task.");
                }
            }
            else
            {
                LogLurch.Information($"Not past Reset time of {GardenSettings.ResetTime}, will check again later.");
            }
        }

        public static async Task ChocoboTask()
        {
            LogLurch.Information($"Chocobo Trainer Last Run Time: {ChocoboSettings.LastChecked}, Reset Time: {ChocoboSettings.ResetTime}, Current Time: {DateTime.Now}");
            LogLurch.Information($"Time Difference: {DateTime.Now - ChocoboSettings.LastChecked} ");
            if ((DateTime.Now - ChocoboSettings.LastChecked).TotalHours > 1)
            {
                LogLurch.Information($"Past reset time of {GardenSettings.ResetTime}");
                LogLurch.Information($"Calling GoGoChocobo"); 
                if (ChocoboSettings.StableLocation != default(Vector3) && ChocoboSettings.StableAetheryte != ChocoboSettings.StableAE.Not_Selected)
                {
                    LogChocobo.Information($"Go to stable at Location: " +ChocoboSettings.StableAetheryte );
                    await LlamaLibrary.Helpers.ChocoboHelper.GoGoChocobo((uint)ChocoboSettings.StableAetheryte, (Vector3) ChocoboSettings.StableLocation, (bool) ChocoboSettings.CleanBefore, (uint) ChocoboSettings.ChocoboFood, (bool) ChocoboSettings.FetchAfter, (bool) ChocoboSettings.ThavnairianOnion);
                    ChocoboSettings.LastChecked = DateTime.Now;
                    ChocoboSettings.ResetTime = DateTime.Now + new TimeSpan(0, 1, 1, 0);
                }
                else
                {
                    LogLurch.Information("No stable Location or Aetheryte Set. Please check settings... Exiting task.");
                }
            }
            else
            {
                LogLurch.Information($"Not past Reset time of {ChocoboSettings.ResetTime}, will check again later.");
            }
        }

        /*
        private static void GeneratePlantPlan()
        {
            // bed, seed, soil... bed can be the index into the list
            plantPlan.Clear();
            plantPlan.Add(new Tuple<uint, uint>(Settings.Seed0, Settings.Soil0));
            plantPlan.Add(new Tuple<uint, uint>(Settings.Seed1, Settings.Soil1));
            plantPlan.Add(new Tuple<uint, uint>(Settings.Seed2, Settings.Soil2));
            plantPlan.Add(new Tuple<uint, uint>(Settings.Seed3, Settings.Soil3));
            plantPlan.Add(new Tuple<uint, uint>(Settings.Seed4, Settings.Soil4));
            plantPlan.Add(new Tuple<uint, uint>(Settings.Seed5, Settings.Soil5));
            plantPlan.Add(new Tuple<uint, uint>(Settings.Seed6, Settings.Soil6));
            plantPlan.Add(new Tuple<uint, uint>(Settings.Seed7, Settings.Soil7));
        }
  */      
    }
}