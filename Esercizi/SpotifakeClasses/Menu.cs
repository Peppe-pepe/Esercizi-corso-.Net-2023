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
        public static void Menu1(User user,MediaComponent media,Database datas) {
            while (true)
            {
                Console.WriteLine("Premi A per vedere le canzoni");
                Console.WriteLine("Premi B per vedere le playist");
                Console.WriteLine("Premi C per vedere le radio");
                Console.WriteLine("Premi E per uscire");
                string check = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                switch (check)
                {
                    case "A": datas.ShowSongs(); Menu2(user, media, datas); break;
                    case "B": datas.ShowPlaylists(); Menu3(user, media, datas); break;
                    case "C": datas.ShowRadios(); Menu4(user, media, datas); break;
                    case "E": Environment.Exit(0); break;
                }
            }
        }
        public static void Menu2(User user,MediaComponent media, Database datas) {
            while (true)
            {
                Console.WriteLine("Inserisci il numero della canzone da riprodurre o -1 per tornare indietro");
                int check = int.Parse(Console.ReadKey().KeyChar.ToString());
                if (check == -1) { Menu1(user, media, datas); }
                Song s = datas.SelectSong(check);
                media.Play(s);
                Menu5(user, media, datas);
            } 
        }

        public static void Menu3(User user,MediaComponent media, Database datas)
        {
            while (true)
            {
                Console.WriteLine("Inserisci il numero della Playlist da riprodurre o -1 per tornare indietro");
                int check = int.Parse(Console.ReadKey().KeyChar.ToString());
                if (check == -1) { Menu1(user, media, datas); }
                Playlist s = datas.SelectPlaylist(check);
                media.Play(s);
                Menu5(user, media, datas);
            }
        }

        public static void Menu4(User user,MediaComponent media, Database datas)
        {
            while (true)
            {
                Console.WriteLine("Inserisci il numero della Radio da riprodurre o  -1 per tornare indietro");
                int check = int.Parse(Console.ReadKey().KeyChar.ToString());
                if (check == -1) { Menu1(user, media, datas); }
                Radio r = datas.SelectRadio(check);
                media.Play(r);
                Menu5(user, media, datas);
            }
        }

        public static void Menu5(User user, MediaComponent media, Database datas)
        {
            while (true)
            {
                Console.WriteLine("Inserisci F per passare alla prossima canzone");
                Console.WriteLine("Inserisci P per mettere in pausa");
                Console.WriteLine("Inserisci B per tornare alla canzone precedente");
                Console.WriteLine("Inserisci S per fermare la riproduzione");
                Console.WriteLine("Inserisci E per tornare al menu precedente");
                string check = Console.ReadKey().KeyChar.ToString();
                switch (check)
                {
                    case "F": media.Forward(); break;
                    case "P": media.Pause(); break;
                    case "B": media.Previous(); break;
                    case "S": media.Stop(); Menu1(user, media, datas); break;
                    case "E": media.Stop(); return;
                }
            }
        }
    }
}
