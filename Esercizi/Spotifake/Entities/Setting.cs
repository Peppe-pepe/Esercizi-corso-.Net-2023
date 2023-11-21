﻿using System;

namespace Spotifake.Entities
{
    public class Setting
    {
        private User _user;
        private bool _darkTheme;
        private string _equalizer;
        private bool _isPremium;
        private int _nOfDevices;

        public Setting(User user, bool darkTheme, string equalizer, bool isPremium, int nOfDevices)
        {
            _user = user;
            _darkTheme = darkTheme;
            _equalizer = equalizer;
            _isPremium = isPremium;
            _nOfDevices = nOfDevices;
        }

        public bool DarkTheme { get => _darkTheme; set => _darkTheme = value; }
        public string Equalizer { get => _equalizer; private set => _equalizer = value; }
        public bool IsPremium { get => _isPremium; private set => _isPremium = value; }
        public int NOfDevices { get => _nOfDevices; private set => _nOfDevices = value; }

        public void AddDevice() {
            _nOfDevices++;
        }
        public void RemoveDevice() { 
            _nOfDevices--;
        }
        public void BuyPremium()
        {
            Console.WriteLine("Paga");
            _isPremium = true;
        }
    }
}