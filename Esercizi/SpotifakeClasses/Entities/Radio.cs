using SpotifakeClasses.Entities;
using SpotifakeClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeClasses.Entities
{
    public class Radio : IRating
    {
        private string _name;
        private List<Song> _songs;
        private int _id;
        private decimal _rating;
        public Radio(string name, List<Song> songs)
        {
            _name = name;
            _songs = songs;
        }

        public void ShowSongs()
        {
            foreach (Song song in _songs)
            {
                if (song != null)
                    Console.WriteLine($"{song.Title}");
            }
        }

        public void CalcRating()
        {
            foreach (Song song in _songs)
                _rating += song.Rating;
            _rating /= _songs.Count();
        }
        public string Name { get => _name; }
        public List<Song> Songs { get => _songs; }
        public int Id { get => _id; set => _id = value; }

        public decimal Rating { get => _rating;}
    }
}
