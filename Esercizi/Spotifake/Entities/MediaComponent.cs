using Spotifake.Classes;
using Spotifake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    public class MediaComponent : IMedia
    {
        private List<Song> _queue;
        private int _index;
        public MediaComponent()
        {
         _queue = new List<Song>();
        _index = 0;
        }

        public void AddToQueue(Song song) => _queue.Add(song);
        public void RemoveFromQueue(Song song) => _queue.Remove(song);
        public void Play(Song s)
        {
            AddToQueue(s);
        }

        public void Play(Album a)
        {
            foreach(Song item in a.Songs){
                AddToQueue(item);
            }
            PlayQueue();
        }

        public void Play(Playlist p)
        {
            foreach (Song item in p.Songs)
            {
                AddToQueue(item);
            }
            PlayQueue();    
        }

        public void Play(Radio r)
        {
            foreach (Song item in r.Songs)
            {
                Play(item);//radios in spotify overwrite your current Queue,this is reflected here
            }
        }
        public void Pause(  )
        {
            Console.WriteLine($"Paused :{_queue[_index].Title}");
        }

        public void Stop(   )
        {
            Console.WriteLine($"Stopped reproduction of :{_queue[_index].Title}");
        }

        public void Forward()
        {
            if (_queue.Count == 0)
                return;
            _index++;

        }

        public void Previous()
        {
            if (_queue.Count == 0)
                return;
           _index--;
        }

        public void PlayQueue()
        {
            try
            {
                
                while( _index<_queue.Count )
                {

                    Console.WriteLine($"Now Playing : {_queue[_index].Title}");
                    System.Threading.Thread.Sleep(_queue[_index].Duration * 1000);//here we fake actually playing the song
                    Forward();
                }

            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("non esiste nessuna coda");
            }

        }
    }
}
