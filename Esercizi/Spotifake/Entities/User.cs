using Spotifake.Classes;
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
        }

        public void CreatePlaylist(String name) {
            _playlists.Add(new Playlist(name, this));
        }
        public void RemovePlaylist(Playlist p) {
            try
            {
                _playlists.Remove(p);
            }
            catch (System.NullReferenceException) {
                Console.WriteLine("l'utente non ha playlist");
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

