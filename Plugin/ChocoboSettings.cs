using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using Clio.Utilities;
using ff14bot.Enums;
using ff14bot.Helpers;
using Newtonsoft.Json;

namespace TheGardener
{
    public class ChocoboSettings : JsonSettings
    {
        private static ChocoboSettings _ChocoboSettingssettings;
        public static ChocoboSettings Instance => _ChocoboSettingssettings ?? (_ChocoboSettingssettings = new ChocoboSettings());
        
        public ChocoboSettings() : base(Path.Combine(CharacterSettingsDirectory, "Lurch.json")) {

        }
        
        private bool _fetchAfter = false;
        [Description("Remove chocobo from stables when done.")]
        [DefaultValue(true)]  
        public bool FetchAfter
        
        {
            get => _fetchAfter;
            set
            {
                if (_fetchAfter != value)
                {
                    _fetchAfter = value;
                    Save();
                }
            }
        }
        
        private bool _cleanBefore = false;
        [Description("Clean out the stable before training.")]
        [DefaultValue(true)]       
        public bool CleanBefore
        {
            get => _cleanBefore;
            set
            {
                if (_cleanBefore != value)
                {
                    _cleanBefore = value;
                    Save();
                }
            }
        }
        
        private bool _thavnairianOnion = false;
        [Description("Use Thavnairian Onion when Chocobos level is maxed..")]
        [DefaultValue(true)]  
        public bool ThavnairianOnion
        
        {
            get => _thavnairianOnion;
            set
            {
                if (_thavnairianOnion != value)
                {
                    _thavnairianOnion = value;
                    Save();
                }
            }
        }
        
        public enum ChocoFoodId
        {
            Not_Selected = -1,
            Curiel_Root = 7894,
            Sylkis_Bud = 7895,
            Mimett_Gourd = 7897,
            Tantalplant = 7898,
            Pahsana_Fruit = 7900,
            Krakka_Root = 8165,
            Thavnairian_Onion = 8166,
        } 
        
        private ChocoFoodId _chocoFoodId;
        [Description("What food should we give our chocobo during training?")]
        [DefaultValue(ChocoFoodId.Not_Selected)]
        public ChocoFoodId ChocoboFood
        {
            get => _chocoFoodId;
            set
            {
                if (_chocoFoodId != value)
                {
                    _chocoFoodId = value;
                    Save();
                }
            }
        }       

        public enum StableAE
        {
            Not_Selected = -1,
            Mist_Free_Company = 56,
            Lavender_Beds_Free_Company = 57,
            The_Goblet_Free_Company = 58,
            Shirogane_Free_Company = 96,
            Mist_Private = 59,
            Lavender_Beds_Private = 60,
            The_Goblet_Private = 61,
            Shirogane_Private = 97,
        }
        
        private StableAE _stableaetheryte;
        [DefaultValue(StableAE.Not_Selected)]
        [Description("What housing zone is our stable located in?")]
        public StableAE StableAetheryte
        {
            get => _stableaetheryte;
            set
            {
                if (_stableaetheryte != value)
                {
                    _stableaetheryte = value;
                    Save();
                }
            }
        }
        
        private Vector3 _stablelocation;
        [Description("XYZ Location for our stable.")]
        public Vector3 StableLocation
        {
            get => _stablelocation;
            set
            {
                if (_stablelocation != value)
                {
                    _stablelocation = value;
                    Save();
                }
            }
        }
        
        
        private DateTime _resetTime = new DateTime(1970, 1, 1);  
        [Description("Time to visit the stables next.")]
        [Browsable(true)]
        public DateTime ResetTime
        {
            get => _resetTime;
            set
            {
                if (_resetTime != value)
                {
                    _resetTime = value;
                    Save();
                }
            }
        }
        
        private DateTime _lastChecked = new DateTime(1970, 1, 1);
        [Description("Last time we visited the stables.")]
        [Browsable(true)]
        public DateTime LastChecked
        {
            get => _lastChecked;
            set
            {
                if (_lastChecked != value)
                {
                    _lastChecked = value;
                    Save();
                }
            }
        }

    }
}