using SpotifakeClasses.Entities;
using SpotifakeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using SpotifakeClasses.Interfaces;

namespace SpotifakeClasses.Entities
{
    public class Database  //we'll fake a database with this class
    {
        private List<Artist> _artists;
        private List<Album> _albums;
        private List<Song> _songs;
        User _user;
        public Database()
        {
            _artists = new List<Artist>();
            _albums = new List<Album>();
            _songs = new List<Song>();
        }
        public Database(List<String> artistFile, List<String> albumFile)
        {
            _artists = FileHandler<Artist>.CreateObject(artistFile);
            _albums = FileHandler<Album>.CreateObject(albumFile);
        }
        public void ShowArtists()
        {
            foreach (Artist artist in _artists)
                ShowArtist(artist);
        }
        public void ShowAlbums()
        {
            foreach (Album album in _albums)
                ShowAlbum(album);

        }
        public void ShowSongs()
        {
            foreach (Artist artist in _artists)
                if (artist != null)
                    artist.ShowSongs();

            foreach (Album album in _albums)
                if (album != null)
                    album.ShowSongs();

        }

        public void SearchSong(String s)
        {
            List<Song> foundSong = new List<Song>();
            try
            {
                foundSong = foundSong.Concat(_songs.Where(song => song.Title.Equals(s)).ToList()).ToList();
                foreach (Song song in foundSong)
                    song.ToString();
            }
            catch (NullReferenceException ex)
            {
                List<Exception> list = new List<Exception> { ex };
                FileHandler<Exception>.WriteOnFile("Errors.txt", list);
            }
        }
        public Song SelectSong(int id) //returns the first song with the desired id
        {
            Song song = null;
            try
            {

                song = _songs[id - 1];
                return song;
            }
            catch (Exception ex)
            {
                List<Exception> list = new List<Exception> { ex };
                FileHandler<Exception>.WriteOnFile("Errors.txt", list);
                return null;
            }

        }

        public Playlist SelectPlaylist(int id)
        {
            foreach (Playlist list in _user.Playlists)
            {
                if (list.Id.Equals(id))
                    return list;
            }
            return null;
        }

        public Radio SelectRadio(int id)
        {
            foreach (Radio radio in _user.FavouriteRadios)
            {
                if (radio.Id.Equals(id))
                    return radio;
            }
            return null;
        }

        public void AddArtist(Artist a)
        {
            _artists.Add(a);
            foreach (Song song in a.Songs)
            {
                _songs.Add(song);
                song.Id = _songs.Count();
            }
        }
        public void User(User u)
        {
            _user = u;
        }
        public void AddAlbum(Album g)
        {
            _albums.Add(g);
            foreach (Song song in g.Songs)
            {
                _songs.Add(song);
                song.Id = _songs.Count();
            }
        }
        private void ShowArtist(Artist a)
        {

            if (a == null)
                return;
            Console.WriteLine(a.ArtName);
            a.ShowAlbums();
            a.ShowSongs();
        }

        private void ShowAlbum(Album a)
        {
            if (a == null)
                return;
            Console.WriteLine(a.Title);
            a.ShowSongs();
        }
        public void ShowRadios()
        {
            try { _user.ShowRadios(); }
            catch (NullReferenceException ex)
            {
                List<Exception> list = new List<Exception> { ex };
                FileHandler<Exception>.WriteOnFile("Errors.txt", list); ;
            }

        }
        public void ShowPlaylists()
        {
            try { _user.ShowPlaylists(); }
            catch (NullReferenceException ex)
            {
                List<Exception> list = new List<Exception> { ex };
                FileHandler<Exception>.WriteOnFile("Errors.txt", list); ;
            }

        }

        public int TotalSongs()
        {
            int count = 0;
            try
            {
                foreach (Artist artist in _artists)
                {
                    count += artist.Songs.Count;
                }
            }
            catch (NullReferenceException ex)
            {
                List<Exception> list = new List<Exception> { ex };
                FileHandler<Exception>.WriteOnFile("Errors.txt", list);
            }
            try
            {
                foreach (Album album in _albums)
                {
                    count += album.Songs.Count;
                }
            }
            catch (NullReferenceException ex)
            {
                List<Exception> list = new List<Exception> { ex };
                FileHandler<Exception>.WriteOnFile("Errors.txt", list); ;
            }
            return count;
        }
        public void ShowTop5<T, TKey>(Func<T, TKey> selector) where T : IRating
        {
            List<T> top5 = _GetList<T>().GroupBy(item=> selector(item)).OrderByDescending(group=> group.Key)
                .SelectMany(group=>group.Take(5)).ToList();
            foreach (var item in top5)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private List<T> _GetList<T>()
        {
            if (typeof(T)==typeof( Artist))
            {
                return _artists.Cast<T>().ToList();
            }
            if (typeof(T)==typeof( Album))
            {
                return _albums.Cast<T>().ToList();
            }
            if (typeof(T)==typeof(Song))
            {
                return _songs.Cast<T>().ToList();
            }
            if (typeof(T) == typeof(Playlist))
            {
                return  _user.Playlists.Cast<T>().ToList();
            }
            if (typeof(T) == typeof(Radio))
            {
                return _user.FavouriteRadios.Cast<T>().ToList();
            }
            else
            {
                throw new ArgumentException("Unsupported type");
            }
        }
    }
}