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
        public static string _name = "TheGardener";
        
        private static readonly string NameValue = "TheGardener";

        private static readonly LLogger Log = new LLogger(NameValue, Colors.LawnGreen);
        private static readonly string HookName = "TheGardener";

        //private static Func<uint, Task> _activate; Before adding gardenLoc
		private static Func<uint, Vector3, Task> _activate;

        private static List<Tuple<uint, uint>> plantPlan = new List<Tuple<uint, uint>>();
        private GardenerSettingsForm _form;
        public override string Author => "Domestic";
        public override Version Version => new Version(0, 2, 1);
        public override string Name => "Gardener Settings";
        public override string ButtonText => "Settings";
        public override bool WantButton => true;

        public static GardenerSettings Settings => GardenerSettings.Instance;

        public override void OnButtonPress()
        {
            if (_form == null)
            {
                _form = new GardenerSettingsForm()
                {
                    Text = "Gardener Settings v" + Version,
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
            Log.Information($"{_name} Enabled");
        }

        public override void OnDisabled()
        {
            TreeRoot.OnStart -= OnBotStart;
            TreeRoot.OnStop -= OnBotStop;
            Log.Information($"{_name} Disabled");
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
            Log.Information($"Adding {HookName} Hook");
            if (!hooks.Contains(HookName))
            {
                LlamaLibrary.Helpers.Lisbeth.AddHook(HookName, GardenTask);
            }
     
        }

        private void RemoveHooks()
        {
            var hooks = LlamaLibrary.Helpers.Lisbeth.GetHookList();
            Log.Information($"Removing {HookName} Hook");
            if (hooks.Contains(HookName))
            {
                LlamaLibrary.Helpers.Lisbeth.RemoveHook(HookName);
            }

        }

        public static async Task GardenTask()
        {
            Log.Information($"Last Run Time: {Settings.LastChecked}, Reset Time: {Settings.ResetTime}, Current Time: {DateTime.Now}");
            Log.Information($"Time Difference: {DateTime.Now - Settings.LastChecked} ");
            //plantPlan.Clear();
            if ((DateTime.Now - Settings.LastChecked).TotalHours > 1)
            {
                Log.Information($"Past reset time of {Settings.ResetTime}");
                Log.Information($"Calling GoGarden");
                if (Settings.GardenLocation != default(Vector3) && Settings.Aetheryte != GardenerSettings.HouseAetheryte.Not_Selected)
                {
                   // if (Settings.ShouldPlant)
                   // {
                   //     GeneratePlantPlan();
                   // }
                   //await _activate((uint)Settings.Aetheryte, Settings.GardenLocation, plantPlan); // need to change this to accept a dict...
                   await LlamaLibrary.Helpers.GardenHelper.GoGarden((uint)Settings.Aetheryte, Settings.GardenLocation, plantPlan); // need to change this to accept a dict...                    Settings.LastChecked = DateTime.Now;
                   Settings.ResetTime = DateTime.Now + new TimeSpan(0, 1, 1, 0);
                }
                else
                {
                    Log.Information("No Garden Location or Aetheryte Set. Please check settings... Exiting task.");
                }
            }
            else
            {
                Log.Information($"Not past Reset time of {Settings.ResetTime}, will check again later.");
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