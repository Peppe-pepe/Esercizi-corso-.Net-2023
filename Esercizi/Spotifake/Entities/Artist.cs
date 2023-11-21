using Spotifake.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
       public class Artist : Person
    {
        private string _artName;
        private List<Album> _albums;
        private List<Song> _songs;
        private Group _group;
        private string _bio;

        public Artist(string name,string surname,string dateOfBirth,string artName, List<Album> albums, List<Song> songs, string bio):
            base(name,surname,dateOfBirth)
        {
            _artName = artName;
            _albums = albums;
            _songs = songs;
            _bio=bio;

        }
        public void PublishSong()
        {

        }
        public void JoinGroup()
        {

        }
        public void LeaveGroup() { }
    }
}
