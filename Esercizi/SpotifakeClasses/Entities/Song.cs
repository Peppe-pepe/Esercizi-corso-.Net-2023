using SpotifakeClasses.Entities;
using SpotifakeClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeClasses.Entities
{
    public class Song : IRating
    {
        private Artist _artist;
        private Album _album;

        private int _duration;
        private string _genre;
        private string _title;
        private string _releaseDate;
        private Playlist _playlist;
        private int _id;
        private int _rating;
        public Song()
        {
            _artist = new Artist();
            _album = new Album();
        }
        public Song(Artist artist, Album album, int duration, string genre, string title, string releaseDate)
        {
            _artist = artist;
            _album = album;
            _duration = duration;
            _genre = genre;
            _title = title;
            _releaseDate = releaseDate;
        }

        public Song(Artist artist, int duration, string genre, string title, string releaseDate)
        {
            _artist = artist;
            _duration = duration;
            _genre = genre;
            _title = title;
            _releaseDate = releaseDate;
        }

        public Song(Artist artist, Album album, int duration, string genre, string title, string releaseDate, Playlist playlist)
        {
            _artist = artist;
            _album = album;
            _duration = duration;
            _genre = genre;
            _title = title;
            _releaseDate = releaseDate;
            _playlist = playlist;
        }

        public void AddtoPlaylist(Playlist p)
        {
            _playlist = p;
        }
        public void AddArtist(Artist a)
        {
            _artist=a;
        }
        public void AddAlbum(Album a)
        {
            _album=a;
        }

        public void CalcRating()
        {
            _rating++;
        }

        public override string ToString()
        {
            return Id+" "+Title+" "+Genre+" "+_artist.ArtName+" "+Duration+" "+ReleaseDate;
        }
        public Artist Artist { get => _artist; }
        public Album Album { get => _album; }
        public int Duration { get => _duration; set => _duration = value; }
        public string Genre { get => _genre; set => _genre = value; }
        public string Title { get => _title; set => _title = value; }
        public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public int Id { get => _id; set => _id = value; }
        public decimal Rating { get => _rating; set => _rating = (int)value; }
        public Playlist Playlist { get => _playlist; set => _playlist = value; }
    }
}
