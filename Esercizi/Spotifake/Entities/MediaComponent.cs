using Spotifake.Classes;
using Spotifake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    public class MediaComponent : IMedia
    {
        List<Song> _queue;
        public MediaComponent()
        {
         _queue = new List<Song>();
        }

        public void AddToQueue(Song song) => _queue.Add(song);
        public void RemoveFromQueue(Song song) => _queue.Remove(song);
        public void Play(Song s)
        {
            throw new NotImplementedException();
        }

        public void Play(Album a)
        {
            throw new NotImplementedException();
        }

        public void Play(Playlist p)
        {
            throw new NotImplementedException();
        }

        public void Play(Radio r)
        {
            throw new NotImplementedException();
        }
        public void Pause(Song s)
        {
            throw new NotImplementedException();
        }

        public void Stop(Song s)
        {
            throw new NotImplementedException();
        }

        public void Forward(Song s)
        {
            throw new NotImplementedException();
        }

        public void Previous(Song s)
        {
            throw new NotImplementedException();
        }
    }
}
