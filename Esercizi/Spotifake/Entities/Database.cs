using Spotifake.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spotifake.Entities
{
    public class Database //we'll fake a database with this class
    {
        private List<Artist> _artists;
        private List<Group> _groups;
        public Database() { 
            _artists = new List<Artist>();  
            _groups = new List<Group>();    
        }
        public void ShowArtists()
        {
           foreach(Artist artist in _artists) { 
                ShowArtist(artist);
            }
        }
        public void ShowGroups() {
            foreach (Group group in _groups)
            {
                ShowGroup(group);
            }
        }
        public void ShowSongs()
        {
            foreach(Artist artist in _artists)
            {
                if(artist != null)
                    artist.ShowSongs();
            }
            foreach (Group group in _groups)
            {
                if (group != null)
                    group.ShowSongs();
            }
        }
        public void ShowAlbums()
        {
            foreach (Artist artist in _artists)
            {
                if(artist!=null)
                    artist.ShowAlbums();
            }
            foreach (Group group in _groups)
            {
                if(group!=null)
                    group.ShowAlbums();
            }
        }
        public void SearchSong(String s) {
            List<Song> songs;
            List<Song> foundSong=new List<Song>();

            try
            {
                foreach (Artist artist in _artists)
                {
                    foundSong = foundSong.Concat(artist.Songs.Where(song => song.Title.Equals(s)).ToList()).ToList();

                }
                foreach (Group group in _groups)
                {
                    songs = group.Songs;
                    foundSong = foundSong.Concat(songs.Where(song => song.Title.Equals(s)).ToList()).ToList();
                }
                foreach (Song song in foundSong)
                {

                    Console.WriteLine($"{song.Title}");
                    Console.WriteLine($"{song.Genre}");
                    Console.WriteLine($"{song.Duration}");
                    Console.WriteLine($"{song.ReleaseDate}");

                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Non ci sono Artisti o/e gruppi {ex.Message}");
            }
        }
        public Song SelectSong(string s) //returns the first song with the desired title
        {
            List<Song> songs;
            Song song=null;
            try {
                foreach (Artist artist in _artists)
                {
                    song = artist.Songs.FirstOrDefault(song => song.Title.Equals(s));
                    if (song != null)
                        return song;
                }
            } catch (NullReferenceException ex) {
                Console.WriteLine($"Non ci sono Artisti {ex.Message}");
                return null;
            }
            try
            {
                foreach (Group group in _groups)
                {
                    song = group.Songs.FirstOrDefault(song => song.Title.Equals(s));
                    if (song != null)
                        return song;
                }
                Console.WriteLine("Nessuna canzone con quel titolo");
                return null;
            }
            catch(NullReferenceException ex) {
                Console.WriteLine($"Non ci sono Gruppi {ex.Message}");
                return null;
            }
               
        }
        public void AddArtist(Artist a)
        {
            _artists.Add(a);    
        }

        public void AddGroup(Group g)
        {
            _groups.Add(g); 
        }
        private void ShowArtist(Artist a) {

            if (a == null)
                return;
            Console.WriteLine(a.ArtName);
            a.ShowAlbums();
            a.ShowSongs();
        }

        private void ShowGroup(Group g)
        {

            if (g == null)
                return;
            Console.WriteLine(g.Name);
            g.ShowAlbums();
            g.ShowSongs();
        }

       
    }
}