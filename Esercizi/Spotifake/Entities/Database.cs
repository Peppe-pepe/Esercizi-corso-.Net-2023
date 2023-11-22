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
                artist.ShowSongs();
            }
            foreach (Group group in _groups)
            {
                group.ShowSongs();
            }
        }
        public void ShowAlbums()
        {
            foreach (Artist artist in _artists)
            {
                artist.ShowAlbums();
            }
            foreach (Group group in _groups)
            {
                group.ShowAlbums();
            }
        }
        public void SearchSong(String s) {
            List<Song> songs;
            List<Song> foundSong=new List<Song>();
            foreach (Artist artist in _artists)
            {
                songs=artist.Songs;
                foundSong=foundSong.Concat(songs.Where(song=>song.Title.Equals(s)).ToList()).ToList();
                
            }
            foreach (Group group in _groups)
            {
                songs=group.Songs;
                foundSong = foundSong.Concat(songs.Where(song => song.Title.Equals(s)).ToList()).ToList();
            }
            foreach(Song song in foundSong)
            {

                Console.WriteLine($"{song.Title}");
                Console.WriteLine($"{song.Genre}");
                Console.WriteLine($"{song.Duration}");
                Console.WriteLine($"{song.ReleaseDate}");

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
        }

        private void ShowGroup(Group g)
        {

            if (g == null)
                return;
            Console.WriteLine(g.Name);
        }

       
    }
}