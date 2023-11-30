using SpotifakeClasses.Entities;
using SpotifakeClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpotifakeClasses.Entities
{
    public class Album : IRating
    {
        private string _title;
        private string _releaseDate;
        private int _nOfTracks;
        private bool _isLive;
        private string _genre;
        private Artist _artist;
        private List<Song> _songs;
        private decimal _rating;
        public Album()
        {
            _artist=new Artist(); 
            _songs=new List<Song>();    
        }


        public Album(string title, string releaseDate, int nOfTracks, bool isLive, Artist artist, List<Song> songs, string genre, decimal rating)
        {
            _title = title;
            _releaseDate = releaseDate;
            _nOfTracks = nOfTracks;
            _isLive = isLive;
            _artist = artist;
            _songs = songs;
            _genre = genre;
            _rating = rating;
        }


        public Album(string title, string releaseDate, int nOfTracks, bool isLive,Artist artist, List<Song> songs)
        {
            _title = title;
            _releaseDate = releaseDate;
            _nOfTracks = nOfTracks;
            _isLive = isLive;
            _artist=artist;
            _songs = songs;
        }

        public Album(string title, string releaseDate, int nOfTracks, bool isLive, Artist artist,Song song)
        {
            _title = title;
            _releaseDate = releaseDate;
            _nOfTracks = nOfTracks;
            _isLive = isLive;
            _artist = artist;
            _songs = new List<Song>();
            _songs.Add(song);
            CalcRating();
        }

        public void CalcRating()
        {
            decimal rating = 0;
            foreach (Song song in _songs)
                rating+= song.Rating;
            _rating = rating / _nOfTracks;
        }

        public void ShowSongs()
        {

            foreach (Song song in _songs)
                {
                    if (song != null)
                        Console.WriteLine(song.ToString());
                }
        }

        public override string ToString()
        {
            return _title + " " + _genre+ " " + _nOfTracks+ " " +_artist;
        }
        public string Title { get => _title; set => _title = value; }
        public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public int NOfTracks { get => _nOfTracks; set => _nOfTracks = value; }
        public bool IsLive { get => _isLive; set => _isLive = value; }
        public Artist Artist { get => _artist; set => _artist = value; }
        public List<Song> Songs { get => _songs; set => _songs = value; }
        public decimal Rating { get { return _rating; } set => _rating = value; }

        public string Genre { get => _genre; set => _genre = value; }
    }
}
