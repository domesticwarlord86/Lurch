using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using ff14bot;
using ff14bot.AClasses;
using ff14bot.Helpers;
using ff14bot.Managers;

namespace TheGardener
{
    public class TheGardener : BotPlugin
    {
        public static string _name = "TheGardener";
        private static Func<uint, Task> _activate;
        private static readonly string HookName = _name;
        private static Action<string, Func<Task>> _addHook;
        private static Action<string> _removeHook;
        private static Func<List<string>> _getHookList;
        private static Action<string, Func<Task>> _addHook1;
        private static Action<string> _removeHook1;
        private static bool FoundLisbeth = false;
        private static bool FoundLL = false;
        private GardenerSettingsForm _form;
        public override string Author => "Domestic";
        public override Version Version => new Version(0, 0, 1);
        public override string Name => "Gardener Settings";
        public override string ButtonText => "Gardener Settings";
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
            catch (Exception e)
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
            if (bot.Name == "Lisbeth")
            {
                if (!FoundLisbeth) FindLisbeth();
                if (FoundLisbeth && FoundLL)
                    RemoveHooks();
            }
        }

        private void OnBotStart(BotBase bot)
        {
            if (bot.Name == "Lisbeth")
            {
                if (!FoundLisbeth) FindLisbeth();
                if (FoundLisbeth && FoundLL)
                    AddHooks();
            }
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
            if ((DateTime.Now - Settings.ResetTime).TotalHours > 1)
            {
                Log($"Past reset time of {Settings.ResetTime}");
                Log($"Calling GoGarden");
                await _activate((uint) Settings.Aetheryte);
                Settings.ResetTime = DateTime.Now + new TimeSpan(0, 1, 1, 0);
            }
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
                _activate = (Func<uint, Task>) fcAction?.CreateDelegate(typeof(Func<uint, Task>));
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