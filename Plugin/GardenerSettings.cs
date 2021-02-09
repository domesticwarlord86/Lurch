using System;
using System.ComponentModel;
using System.IO;
using Clio.Utilities;
using ff14bot.Enums;
using ff14bot.Helpers;

namespace TheGardener
{
    public class GardenerSettings : JsonSettings
    {
        private static GardenerSettings _settings;
        public static GardenerSettings Instance => _settings ?? (_settings = new GardenerSettings());
        
        private DateTime _resetTime = new DateTime(1970, 1, 1);
        private DateTime _lastChecked = new DateTime(1970, 1, 1);

        private Vector3 _gardenLocation;

        private HouseAetheryte _houseaetheryte;
        public enum HouseAetheryte
        {
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
    }
}