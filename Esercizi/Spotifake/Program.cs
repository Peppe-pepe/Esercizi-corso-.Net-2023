using Spotifake.Classes;
using Spotifake.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Spotifake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Media Source");
            Console.WriteLine("selection succesfull");//just a simulation for now
            Database database = new Database(); 
            User user = new User("Giuseppe", "Pepe", "20-12-1999", "Peppe-Pepe", "1234");
            Artist artist1 = new Artist("Vincenzo ", "Sarnelli", "7-1-1961", "Tony Tammaro");
            Song song1 = null;//new Song(artist1, 140, "pop", "'O trerrote", "21-02-1997");
            Album album1 = new Album("Monnezzarium", "21-02-1997", 10, false, artist1, song1);
            artist1.AddSong(song1);
            artist1.AddAlbum(album1);
            database.AddArtist(artist1);
            MediaComponent media = new MediaComponent();
            Console.WriteLine("Premi A per mostrare tutti gli artisti");
            Console.WriteLine("Premi D per mostrare tutti gli album");
            Console.WriteLine("Premi P per mostrare le playlist");
            Console.WriteLine("Premi R per mostrare le radio");
            Console.WriteLine("Premi C per cercare una canzone");
            Console.WriteLine("Premi L per riprodurre una canzone");
            Console.WriteLine("Premi F per passare alla prossima canzone");
            Console.WriteLine("Premi B per riprodurre la canzone precedente");
            Console.WriteLine("Premi S per fermare la riproduzione");
            Console.WriteLine("Premi Z per mettere in pausa la riproduzione");
            string check;
            while (true){
                check=Console.ReadLine();
                switch (check)
                {
                    case "A":database.ShowArtists();break;//to do
                    case "D": database.ShowAlbums();break;//to do
                    case "P": user.ShowPlaylists();break;//to do
                    case "R": user.ShowRadios();break;//to do
                    case "C":check = Console.ReadLine(); Console.WriteLine(check); database.SearchSong(check);break;//to do
                    case "L":media.AddToQueue(song1);media.PlayQueue();break;
                    case "F": media.Forward();break;
                    case "B": media.Previous();break;
                    case "S": media.Stop();break;
                    case "Z": media.Pause();break;
                }
            }
        }
    }
}