using System.Text.RegularExpressions;
using System.Collections;

namespace Lab6CSharp
{
    internal class Program
    {
        static void task1()
        {
            string inputFilePath = "D:\\input.txt";
            string outputFilePath = "D:\\output.txt";
            Stack<int> numbersStack = new Stack<int>();
            string[] lines = File.ReadAllLines(inputFilePath);
            foreach (string line in lines)
            {
                if (int.TryParse(line, out int number))
                {
                    numbersStack.Push(number);
                }
                else
                {
                    Console.WriteLine($"Non-numeric string found in the file: {line}");
                }
            }
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("Numbers in reverse order:");
                while (numbersStack.Count > 0)
                {
                    int number = numbersStack.Pop();
                    writer.WriteLine(number);
                    Console.WriteLine(number);
                }
            }
            Console.WriteLine("Numbers in reverse order have been written to the file: " + outputFilePath);
        }
        static void task2()
        {
            string inputFilePath = "D:\\input.txt";
            Queue<char> nonDigitQueue = new Queue<char>();
            Queue<char> digitQueue = new Queue<char>();
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    char c = (char)reader.Read();
                    if (char.IsDigit(c))
                    {
                        digitQueue.Enqueue(c);
                    }
                    else
                    {
                        nonDigitQueue.Enqueue(c);
                    }
                }
            }
            while (nonDigitQueue.Count > 0)
            {
                Console.Write(nonDigitQueue.Dequeue());
            }
            while (digitQueue.Count > 0)
            {
                Console.Write(digitQueue.Dequeue());
            }
            Console.WriteLine();
        }
        static void task3()
        {
            string inputFilePath = "D:\\input.txt";
            Queue nonDigitQueue = new Queue();
            Queue digitQueue = new Queue();
            string text = System.IO.File.ReadAllText(inputFilePath);
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    digitQueue.Enqueue(c);
                }
                else
                {
                    nonDigitQueue.Enqueue(c);
                }
            }
            foreach (char c in nonDigitQueue)
            {
                Console.Write(c);
            }
            foreach (char c in digitQueue)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }
        class Song
        {
            public string Title { get; }
            public string Artist { get; }
            public Song(string title, string artist)
            {
                Title = title;
                Artist = artist;
            }
        }
        class MusicAlbum
        {
            public string Title { get; }
            public ArrayList songs = new ArrayList();
            public MusicAlbum(string title)
            {
                Title = title;
            }
            public void AddSong(Song song)
            {
                songs.Add(song);
            }
            public void RemoveSong(Song song)
            {
                songs.Remove(song);
            }
            public void ShowAlbumContent()
            {
                Console.WriteLine($"Album: {Title}");
                foreach (Song song in songs)
                {
                    Console.WriteLine($"- {song.Title} by {song.Artist}");
                }
            }
        }
        class MusicCatalog
        {
            private Hashtable albums = new Hashtable();

            public void AddAlbum(string title)
            {
                if (!albums.Contains(title))
                {
                    albums.Add(title, new MusicAlbum(title));
                }
            }
            public void RemoveAlbum(string title)
            {
                if (albums.Contains(title))
                {
                    albums.Remove(title);
                }
            }
            public void AddSongToAlbum(string albumTitle, Song song)
            {
                if (albums.Contains(albumTitle))
                {
                    ((MusicAlbum)albums[albumTitle]).AddSong(song);
                }
            }
            public void RemoveSongFromAlbum(string albumTitle, Song song)
            {
                if (albums.Contains(albumTitle))
                {
                    ((MusicAlbum)albums[albumTitle]).RemoveSong(song);
                }
            }
            public void ShowCatalogContent()
            {
                foreach (DictionaryEntry entry in albums)
                {
                    ((MusicAlbum)entry.Value).ShowAlbumContent();
                }
            }
            public void SearchByArtist(string artist)
            {
                Console.WriteLine($"Search results for artist '{artist}':");
                foreach (DictionaryEntry entry in albums)
                {
                    MusicAlbum album = (MusicAlbum)entry.Value;
                    foreach (Song song in album.songs)
                    {
                        if (song.Artist == artist)
                        {
                            Console.WriteLine($"- {song.Title} from album '{album.Title}'");
                        }
                    }
                }
            }
        }
        static void task4()
        {
            MusicCatalog catalog = new MusicCatalog();
            catalog.AddAlbum("Album 1");
            catalog.AddAlbum("Album 2");
            catalog.AddSongToAlbum("Album 1", new Song("Song 1", "Artist 1"));
            catalog.AddSongToAlbum("Album 1", new Song("Song 2", "Artist 2"));
            catalog.AddSongToAlbum("Album 2", new Song("Song 3", "Artist 1"));
            catalog.AddSongToAlbum("Album 2", new Song("Song 4", "Artist 3"));
            catalog.ShowCatalogContent();
            catalog.SearchByArtist("Artist 1");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 9 ");
            Console.Write("Enter task number: ");
            int task_id = int.Parse(Console.ReadLine());
            switch (task_id)
            {
                case 1:
                    task1();
                    break;
                case 2:
                    task2();
                    break;
                case 3:
                    task3();
                    break;
                case 4:
                    task4();
                    break;
                default:
                    Console.WriteLine("No task under such number!");
                    break;
            }
        }
    }
}
