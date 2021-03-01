﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using ff14bot;
using ff14bot.AClasses;
using ff14bot.Helpers;
using ff14bot.Managers;
using Clio.Utilities;

namespace TheGardener
{
    public class TheGardener : BotPlugin
    {
        public static string _name = "TheGardener";
        //private static Func<uint, Task> _activate; Before adding gardenLoc
		private static Func<uint, Vector3, Dictionary<uint, uint>, Task> _activate;
        private static readonly string HookName = _name;
        private static Action<string, Func<Task>> _addHook;
        private static Action<string> _removeHook;
        private static Func<List<string>> _getHookList;
        private static Action<string, Func<Task>> _addHook1;
        private static Action<string> _removeHook1;
        private static bool FoundLisbeth = false;
        private static bool FoundLL = false;
        private static Dictionary<uint, uint> plantPlan = new Dictionary<uint, uint>();
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
            FindLL();
        }

        public override void OnEnabled()
        {
            TreeRoot.OnStart += OnBotStart;
            TreeRoot.OnStop += OnBotStop;
            Log($"{_name} Enabled");
        }

        public override void OnDisabled()
        {
            TreeRoot.OnStart -= OnBotStart;
            TreeRoot.OnStop -= OnBotStop;
            Log($"{_name} Disabled");
        }

        private void OnBotStop(BotBase bot)
        {
                if (!FoundLisbeth) FindLisbeth();
                if (FoundLisbeth && FoundLL)
                    RemoveHooks();
        }

        private void OnBotStart(BotBase bot)
        {
                if (!FoundLisbeth) FindLisbeth();
                if (FoundLisbeth && FoundLL)
                    AddHooks();
        }

        private void AddHooks()
        {
            var hooks = _getHookList.Invoke();
            Log($"Adding {HookName} Hook");
            if (!hooks.Contains(HookName))
            {
                _addHook.Invoke(HookName, GardenTask);
                _addHook1.Invoke(HookName, GardenTask);
            }
        }

        private void RemoveHooks()
        {
            var hooks = _getHookList.Invoke();
            Log($"Removing {HookName} Hook");
            if (hooks.Contains(HookName))
            {
                _removeHook.Invoke(HookName);
                _removeHook1.Invoke(HookName);
            }
        }

        public static async Task GardenTask()
        {
            Log($"Last Run Time: {Settings.LastChecked}, Reset Time: {Settings.ResetTime}, Current Time: {DateTime.Now}");
            Log($"Time Difference: {DateTime.Now - Settings.LastChecked} ");
            plantPlan.Clear();
            if ((DateTime.Now - Settings.LastChecked).TotalHours > 1)
            {
                Log($"Past reset time of {Settings.ResetTime}");
                Log($"Calling GoGarden");
                if (Settings.GardenLocation != default(Vector3) && Settings.Aetheryte != GardenerSettings.HouseAetheryte.Not_Selected)
                {
                    if (Settings.ShouldPlant)
                    {
                        GeneratePlantPlan();
                    }
                    await _activate((uint)Settings.Aetheryte, Settings.GardenLocation, plantPlan); // need to change this to accept a dict...
                    Settings.LastChecked = DateTime.Now;
                    Settings.ResetTime = DateTime.Now + new TimeSpan(0, 1, 1, 0);
                }
                else
                {
                    Log("No Garden Location or Aetheryte Set. Please check settings... Exiting task.");
                }
            }
            else
            {
                Log($"Not past Reset time of {Settings.ResetTime}, will check again later.");
            }
        }

        private static void GeneratePlantPlan()
        {
            // bed, seed, soil... bed can be the index into the dict
            plantPlan.Add(Settings.Seed0, Settings.Soil0);
            plantPlan.Add(Settings.Seed1, Settings.Soil1);
            plantPlan.Add(Settings.Seed2, Settings.Soil2);
            plantPlan.Add(Settings.Seed3, Settings.Soil3);
            plantPlan.Add(Settings.Seed4, Settings.Soil4);
            plantPlan.Add(Settings.Seed5, Settings.Soil5);
            plantPlan.Add(Settings.Seed6, Settings.Soil6);
            plantPlan.Add(Settings.Seed7, Settings.Soil7);
        }

        private static void FindLL()
        {
            var loader = BotManager.Bots.FirstOrDefault(c => c.EnglishName == "Retainers");

            if (loader == null) return;

            var q = from t in loader.GetType().Assembly.GetTypes()
                    where t.Namespace == "LlamaLibrary.Helpers" && t.Name.Equals("GardenHelper")
                    select t;

            if (q.Any())
            {
                var helper = q.First();
                var fcAction = helper.GetMethod("GoGarden");
				_activate = (Func<uint, Vector3, Dictionary<uint, uint>, Task >) fcAction?.CreateDelegate(typeof(Func<uint, Vector3, Dictionary<uint, uint>, Task>));
                //_activate = (Func<uint, Task>) fcAction?.CreateDelegate(typeof(Func<uint, Task>)); Before adding gardenLoc setting.
                Log($"Found {helper.GetMethod("GoGarden")?.Name}");
            }

            FoundLL = true;
        }

        private static void FindLisbeth()
        {
            var loader = BotManager.Bots
                .FirstOrDefault(c => c.Name == "Lisbeth");

            if (loader == null) return;

            var lisbethObjectProperty = loader.GetType().GetProperty("Lisbeth");
            var lisbeth = lisbethObjectProperty?.GetValue(loader);
            if (lisbeth == null) return;
            var apiObject = lisbeth.GetType().GetProperty("Api")?.GetValue(lisbeth);
            if (apiObject != null)
            {
                var m = apiObject.GetType().GetMethod("GetCurrentAreaName");
                if (m != null)
                {
                    _addHook = (Action<string, Func<Task>>) Delegate.CreateDelegate(typeof(Action<string, Func<Task>>), apiObject, "AddCraftCycleHook");
                    _removeHook = (Action<string>) Delegate.CreateDelegate(typeof(Action<string>), apiObject, "RemoveCraftCycleHook");
                    _getHookList = (Func<List<string>>) Delegate.CreateDelegate(typeof(Func<List<string>>), apiObject, "GetHookList");
                    _addHook1 = (Action<string, Func<Task>>) Delegate.CreateDelegate(typeof(Action<string, Func<Task>>), apiObject, "AddHook");
                    _removeHook1 = (Action<string>) Delegate.CreateDelegate(typeof(Action<string>), apiObject, "RemoveHook");
                    FoundLisbeth = true;
                }
            }

            Logging.Write("Lisbeth found.");
        }

        private static void Log(string text)
        {
            var msg = string.Format($"[{_name}] " + text);
            Logging.Write(Colors.LimeGreen, msg);
        }
    }
}