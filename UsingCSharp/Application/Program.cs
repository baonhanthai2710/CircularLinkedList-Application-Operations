using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Playlist playlist = new Playlist();
            playlist.AddSampleSongs();

            while (true)
            {
                Console.WriteLine("\n--- Music Playlist Manager ---");
                Console.WriteLine("1. Add a Song");
                Console.WriteLine("2. Remove a Song");
                Console.WriteLine("3. Display Playlist");
                Console.WriteLine("4. Play Next Song");
                Console.WriteLine("5. Search Song by Title");
                Console.WriteLine("6. Search Songs by Artist");
                Console.WriteLine("7. Display Total Playlist Duration");
                Console.WriteLine("8. Clear Playlist");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 9)
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                if (choice == 9) break;

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter song title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter artist name: ");
                        string artist = Console.ReadLine();
                        Console.Write("Enter song duration (seconds): ");
                        if (int.TryParse(Console.ReadLine(), out int duration))
                        {
                            playlist.AddSong(new Song(title, artist, duration));
                        }
                        else
                        {
                            Console.WriteLine("Invalid duration entered. Song not added.");
                        }
                        break;

                    case 2:
                        Console.Write("Enter the title of the song to remove: ");
                        string removeTitle = Console.ReadLine();
                        playlist.RemoveSong(removeTitle);
                        break;

                    case 3:
                        playlist.DisplayPlaylist();
                        break;

                    case 4:
                        playlist.PlayNext();
                        break;

                    case 5:
                        Console.Write("Enter the song title to search: ");
                        string searchTitle = Console.ReadLine();
                        playlist.SearchSongByTitle(searchTitle);
                        break;

                    case 6:
                        Console.Write("Enter the artist name to search: ");
                        string searchArtist = Console.ReadLine();
                        playlist.SearchSongsByArtist(searchArtist);
                        break;

                    case 7:
                        playlist.DisplayTotalDuration();
                        break;

                    case 8:
                        playlist.ClearPlaylist();
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }

            Console.WriteLine("Exiting the Music Playlist Manager. Goodbye!");
        }
    }
}
