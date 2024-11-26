using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    internal class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; } // Duration in seconds

        public Song(string title, string artist, int duration)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
        }
    }
}
