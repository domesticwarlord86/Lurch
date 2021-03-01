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
    public class GardenerSettings : JsonSettings
    {
        private static GardenerSettings _settings;
        public static GardenerSettings Instance => _settings ?? (_settings = new GardenerSettings());
        
        private DateTime _resetTime = new DateTime(1970, 1, 1);
        private DateTime _lastChecked = new DateTime(1970, 1, 1);
        private bool _shouldPlant = false;

        private uint _seed0, _seed1, _seed2, _seed3, _seed4, _seed5, _seed6, _seed7;
        private uint _soil0, _soil1, _soil2, _soil3, _soil4, _soil5, _soil6, _soil7;

        private Vector3 _gardenLocation;

        private HouseAetheryte _houseaetheryte;
        public enum HouseAetheryte
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

        public GardenerSettings() : base(Path.Combine(CharacterSettingsDirectory, "GardenerSettings.json")) {

        }
        [DefaultValue(HouseAetheryte.Not_Selected)]
        public HouseAetheryte Aetheryte
        {
            get => _houseaetheryte;
            set
            {
                if (_houseaetheryte != value)
                {
                    _houseaetheryte = value;
                    Save();
                }
            }
        }
        public Vector3 GardenLocation
        {
            get => _gardenLocation;
            set
            {
                if (_gardenLocation != value)
                {
                    _gardenLocation = value;
                    Save();
                }
            }
        }
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
        public bool ShouldPlant
        {
            get => _shouldPlant;
            set
            {
                if (_shouldPlant != value)
                {
                    _shouldPlant = value;
                    Save();
                }
            }
        }
        [Browsable(false)]
        [DefaultValue(typeof(uint),"13765")]
        public uint Seed0
        {
            get => _seed0;
            set
            {
                if (_seed0 == value) return;
                _seed0 = value;
                Save();
            }
        }
        [Browsable(false)]
        [DefaultValue(typeof(uint),"13765")]
        public uint Seed1 {
            get => _seed1;
            set {
                if (_seed1 != value) {
                    _seed1 = value;
                    Save();
                }
            }
        }
        [Browsable(false)]
        [DefaultValue(typeof(uint),"8172")]
        public uint Seed2 {
            get => _seed2;
            set {
                if (_seed2 != value) {
                    _seed2 = value;
                    Save();
                }
            }
        }
        [Browsable(false)]
        [DefaultValue(typeof(uint),"13765")]
        public uint Seed3 {
            get => _seed3;
            set {
                if (_seed3 != value) {
                    _seed3 = value;
                    Save();
                }
            }
        }
        [Browsable(false)]
        [DefaultValue(typeof(uint),"8172")]
        public uint Seed4 {
            get => _seed4;
            set {
                if (_seed4 != value) {
                    _seed4 = value;
                    Save();
                }
            }
        }
        [Browsable(false)]
        [DefaultValue(typeof(uint),"13765")]
        public uint Seed5 {
            get => _seed5;
            set {
                if (_seed5 != value) {
                    _seed5 = value;
                    Save();
                }
            }
        }
        [Browsable(false)]
        [DefaultValue(typeof(uint), "13765")]
        public uint Seed6 {
            get => _seed6;
            set {
                if (_seed6 != value) {
                    _seed6 = value;
                    Save();
                }
            }
        }
        [Browsable(false)]
        [DefaultValue(typeof(uint),"8172")]
        public uint Seed7 {
            get => _seed7;
            set {
                if (_seed7 != value) {
                    _seed7 = value;
                    Save();
                }
            }
        }
        [Browsable(false)]
        [DefaultValue(typeof(uint),"7766")]
        public uint Soil0
        {
            get => _soil0;
            set
            {
                if (_soil0 != value)
                {
                    _soil0 = value;
                    Save();
                }
            }
        }
        [Browsable(false)]
        [DefaultValue(typeof(uint),"7766")]
        public uint Soil1 {
            get => _soil1;
            set {
                if (_soil1 != value) {
                    _soil1 = value;
                    Save();
                }
            }
        }
        [Browsable(false)]
        [DefaultValue(typeof(uint),"7766")]
        public uint Soil2 {
            get => _soil2;
            set {
                if (_soil2 != value) {
                    _soil2 = value;
                    Save();
                }
            }
        }
        [Browsable(false)]
        [DefaultValue(typeof(uint),"7766")]
        public uint Soil3 {
            get => _soil3;
            set {
                if (_soil3 != value) {
                    _soil3 = value;
                    Save();
                }
            }
        }
        [Browsable(false)]
        [DefaultValue(typeof(uint),"7766")]
        public uint Soil4 {
            get => _soil4;
            set {
                if (_soil4 != value) {
                    _soil4 = value;
                    Save();
                }
            }
        }
        [Browsable(false)]
        [DefaultValue(typeof(uint),"7766")]
        public uint Soil5 {
            get => _soil5;
            set {
                if (_soil5 != value) {
                    _soil5 = value;
                    Save();
                }
            }
        }
        [Browsable(false)]
        [DefaultValue(typeof(uint),"7766")]
        public uint Soil6 {
            get => _soil6;
            set {
                if (_soil6 != value) {
                    _soil6 = value;
                    Save();
                }
            }
        }
        [Browsable(false)]
        [DefaultValue(typeof(uint),"7766")]
        public uint Soil7 {
            get => _soil7;
            set {
                if (_soil7 != value) {
                    _soil7 = value;
                    Save();
                }
            }
        }
    }
}