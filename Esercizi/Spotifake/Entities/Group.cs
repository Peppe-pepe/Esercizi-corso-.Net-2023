using Spotifake.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    public class Group
    {
        private List<Artist> _members;
        private List<Album> _albums;
        private List<Song> _songs;
        private string _bio;
       
        public Group(List<Artist> members, List<Album> albums, List<Song> songs, string bio)
        {
            _members = members;
            _albums = albums;
            _songs = songs;
            _bio = bio;
        }

        public void AddMember(Artist a)
        {
            _members.Add(a);
        }
        public void RemoveMember(Artist a)
        {
            _members.Remove(a);
        }

        public void PublishSong(Album a,int duration,string genre,string title,string release)
        {
            _songs.Add(new Song(this,a,duration,genre,title,release));
        }
        public void PublishSong(int duration,string genre,string title,string release)
        {
            _songs.Add(new Song(this, duration, genre, title, release));
        }
        public void PublishAlbum(string Title,string release,int nTracks,bool live,List<Song> songs) {
            _albums.Add(new Album(Title,release,nTracks,live,this,songs));
        }
        public void AddSong(Song s) => _songs.Add(s);  //used for feat songs

        public void AddAlbum(Album a) => _albums.Add(a); //used for feat albums

        public List<Artist> Members { get => _members; }
        public List<Album> Albums { get => _albums; }
        public List<Song> Songs { get => _songs; }
        public string Bio { get => _bio; }
    }
}
