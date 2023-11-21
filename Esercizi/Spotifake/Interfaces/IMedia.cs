using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Interfaces
{
    public interface IMedia
    {
        public void Play();
        public void Pause();
        public void Stop();
        public void Forward();
        public void Previous();
    }
}
