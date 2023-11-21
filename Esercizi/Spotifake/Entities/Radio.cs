using Spotifake.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    public class Radio
    {
        private string _name;
        private List<Song> _songs;

        public Radio(string name, List<Song> songs)
        {
            _name = name;
            _songs = songs;
        }

        public string Name { get => _name; }
        public List<Song> Songs { get => _songs; }
    }
}
