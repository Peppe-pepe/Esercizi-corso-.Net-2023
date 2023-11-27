using SpotifakeClasses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifakeClasses
{
    public class Menu
    {
        public Menu() { }
        public static void Menu1() {
            Console.WriteLine("Premi A per vedere le canzoni");
            Console.WriteLine("Premi B per vedere le playist");
            Console.WriteLine("Premi C per vedere le radio");
            string check = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();
            Database datas = new Database();
            User user = new User(); 
            switch (check)
            {
                case "A":datas.ShowSongs();Menu2(); break;
                case "B":datas.ShowPlaylists();Menu3(); break;
                case "C":datas.ShowRadios();Menu4(); break;  
            }
        }
        public static Song Menu2() {
            Console.WriteLine("Inserisci il numero della canzone da riprodurre");
            int check = int.Parse(Console.ReadKey().KeyChar.ToString());
            Database datas = new Database();
            Song s = datas.SelectSong(check);
            return s;
        }

        public static Playlist Menu3()
        {
            Console.WriteLine("Inserisci il numero della Playlist da riprodurre");
            int check = int.Parse(Console.ReadKey().KeyChar.ToString());
            Database datas = new Database();
            Song s = datas.SelectSong(check);
            return s;
        }

        public static Radio Menu4()
        {
            Console.WriteLine("Inserisci il numero della Radio da riprodurre");
            int check = int.Parse(Console.ReadKey().KeyChar.ToString());
            Database datas = new Database();
            Song s = datas.SelectSong(check);
            return s;
        }
    }
}
