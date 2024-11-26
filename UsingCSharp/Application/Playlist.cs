using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    internal class Playlist
    {
        private List<Song> songs;
        private int currentIndex;

        public Playlist()
        {
            songs = new List<Song>();
            currentIndex = -1;
        }

        public void AddSong(Song song)
        {
            songs.Add(song);
            Console.WriteLine($"Song '{song.Title}' added to the playlist.");
        }

        public void RemoveSong(string title)
        {
            Song song = songs.Find(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (song != null)
            {
                songs.Remove(song);
                Console.WriteLine($"Song '{title}' removed from the playlist.");
            }
            else
            {
                Console.WriteLine($"Song '{title}' not found in the playlist.");
            }
        }

        public void DisplayPlaylist()
        {
            if (songs.Count == 0)
            {
                Console.WriteLine("The playlist is empty.");
                return;
            }

            Console.WriteLine("\nPlaylist:");
            foreach (var song in songs)
            {
                Console.WriteLine($"Title: {song.Title}, Artist: {song.Artist}, Duration: {song.Duration} seconds");
            }
        }

        public void PlayNext()
        {
            if (songs.Count == 0)
            {
                Console.WriteLine("The playlist is empty.");
                return;
            }

            currentIndex = (currentIndex + 1) % songs.Count;
            Song currentSong = songs[currentIndex];
            Console.WriteLine($"\nNow playing: {currentSong.Title} by {currentSong.Artist} ({currentSong.Duration} seconds)");
        }

        public void ClearPlaylist()
        {
            songs.Clear();
            Console.WriteLine("All songs have been removed from the playlist.");
        }

        public void SearchSongByTitle(string title)
        {
            Song song = songs.Find(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (song != null)
            {
                Console.WriteLine($"\nSong Found: Title: {song.Title}, Artist: {song.Artist}, Duration: {song.Duration} seconds");
            }
            else
            {
                Console.WriteLine($"Song '{title}' not found in the playlist.");
            }
        }

        public void SearchSongsByArtist(string artist)
        {
            var foundSongs = songs.FindAll(s => s.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase));

            if (foundSongs.Count > 0)
            {
                Console.WriteLine($"\nSongs by Artist '{artist}':");
                foreach (var song in foundSongs)
                {
                    Console.WriteLine($"Title: {song.Title}, Duration: {song.Duration} seconds");
                }
            }
            else
            {
                Console.WriteLine($"No songs by '{artist}' found in the playlist.");
            }
        }

        public void DisplayTotalDuration()
        {
            int totalDuration = 0;

            foreach (var song in songs)
            {
                totalDuration += song.Duration;
            }

            Console.WriteLine($"\nTotal Playlist Duration: {totalDuration} seconds ({totalDuration / 60} minutes and {totalDuration % 60} seconds)");
        }

        public void AddSampleSongs()
        {
            AddSong(new Song("Bohemian Rhapsody", "Queen", 354));
            AddSong(new Song("Imagine", "John Lennon", 183));
            AddSong(new Song("Hotel California", "Eagles", 390));
            AddSong(new Song("Shape of You", "Ed Sheeran", 233));

            Console.WriteLine("\nSample songs added to the playlist:");
            DisplayPlaylist();
        }
    }
}
