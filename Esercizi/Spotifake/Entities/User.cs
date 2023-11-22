﻿using Spotifake.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    public class User : Person
    {
       private Setting _settings;
       private List<Playlist> _playlists;
       private List<Song> _favouriteSongs;
       private List<Radio> _favouriteRadios;
       private string _username;
       private string _password;

        public User(string name, string surname, string dateOfBirth,
            string username, string password):base(name,surname,dateOfBirth)
        {
            _settings = new Setting(this);
            _username = username;
            _password = password;
            _favouriteRadios = new List<Radio>();
            _favouriteSongs = new List<Song>(); 
            _playlists = new List<Playlist>();
        }

        public void CreatePlaylist(String name) {
            _playlists.Add(new Playlist(name, this));
        }
        public void RemovePlaylist(Playlist p) {
            
            if(_playlists.Count==0)
                Console.WriteLine("l'utente non ha playlist");
            _playlists.Remove(p);
         }
        public void ShowPlaylists()
        {
            foreach (Playlist item in _playlists)
            {
                if (item == null)
                    break;
                Console.WriteLine($"{item.Name}");
                item.ShowSongs();
            }
        }

        public void ShowRadios()
        {
            foreach(Radio radio in _favouriteRadios)
            {
                if (radio == null)
                    break;
                Console.WriteLine($"{radio.Name}");
                radio.ShowSongs();
            }
        }

        public List<Playlist> Playlists { get => _playlists; set => _playlists = value; }
        public List<Song> FavouriteSongs { get => _favouriteSongs; set => _favouriteSongs = value; }
        public List<Radio> FavouriteRadios { get => _favouriteRadios; set => _favouriteRadios = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        internal Setting Settings { get => _settings; set => _settings = value; }
    }
}

