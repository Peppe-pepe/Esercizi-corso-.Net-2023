
using SpotifakeClasses;
using SpotifakeClasses.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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
            string check;
            User user = new User("Giuseppe", "Pepe", "20-12-1999", "Peppe-Pepe", "1234");
            Artist artist1 = new Artist("Vincenzo ", "Sarnelli", "07-01-1961", "Tony Tammaro");
            Group group1 = new Group("Eiffel 65", new List<Artist>(), new List<Album>(), new List<Song>(), "placeholder");
            group1.AddMember(new Artist("Maurizio", "Lobina", "30-10-1973", "Maury"));
            group1.AddMember(new Artist("Gianfranco", "Randone", "05-01-1970", "Jeffrey Jey"));
            group1.AddSong(new Song(group1, 288, "Eurodance", "I'm Blue (Da Ba Dee)", "10-10-1998"));
            Song song;//used as a temp for SelectSong
            Song song1 = new Song(artist1, 140, "pop", "'O trerrote", "21-02-1997");
            Album album1 = new Album("Monnezzarium", "21-02-1997", 10, false, artist1, song1);
            artist1.AddSong(song1);
            artist1.AddAlbum(album1);
            database.AddArtist(artist1);
            database.AddGroup(group1);
            MediaComponent media = new MediaComponent();
            Menus.StartMenu(user,database);
        }
    }
}


