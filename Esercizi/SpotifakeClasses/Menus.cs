using SpotifakeClasses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SpotifakeClasses
{
    public class Menus
    {
        public Menus() { }
        public static void StartMenu(User user,Database datas) {
            Console.Clear();
            string menu = "╔═════════════════════════════════════════════╗" +
                        "\n║          Please select a language           ║" +
                        "\n║                  1.English                  ║" +
                        "\n║                  2.Italian                  ║" +
                        "\n╚═════════════════════════════════════════════╝";
            Console.WriteLine(menu);
            char check = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch(check){
                case '1':
                    user.Culture = CultureInfo.CreateSpecificCulture("en-US"); Menu1(user, new MediaComponent(),datas);
                    break;
                case '2':
                    user.Culture = CultureInfo.CreateSpecificCulture("it-IT");Menu1(user, new MediaComponent(),datas);
                    break;
            }            

        }
        public static void Menu1(User user,MediaComponent media,Database datas) {
            string check;
            string menu;
            while (true)
            {
                if (user.RemainingTime == 0)
                {
                           menu = "╔═════════════════════════════════════════════╗" +
                                "\n║  Premi A per riprodurre una canzone casuale ║" +
                                "\n║  Premi E per uscire dal programma           ║" +
                                "\n╚═════════════════════════════════════════════╝";
                    Console.WriteLine(menu);
                   check = Console.ReadKey().KeyChar.ToString();
                    Console.WriteLine();
                    switch (check) {
                        case "A":
                            Random random=new Random(); 
                            int n = random.Next(0,datas.TotalSongs()); 
                            media.Play(datas.SelectSong(n),user);
                            break;
                        case "E": Environment.Exit(0); break;
                    }

                }
                Console.WriteLine("Premi A per vedere le canzoni");
                Console.WriteLine("Premi B per vedere le playist");
                Console.WriteLine("Premi C per vedere le radio");
                Console.WriteLine("Premi D per vedere gli artisti");
                Console.WriteLine("Premi E per uscire");
                check = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                switch (check)
                {
                    case "A": datas.ShowTop5<Song, decimal>(song => song.Rating); ; Menu2(user, media, datas); break;
                    case "B": datas.ShowTop5<Playlist, decimal>(playlist => playlist.Rating); ; Menu3(user, media, datas); break;
                    case "C": datas.ShowTop5<Radio, decimal>(radio => radio.Rating); Menu4(user, media, datas); break;
                    case "D":datas.ShowTop5<Artist,decimal>(artist => artist.Rating); break;
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
                media.Play(s,user);
                Menu5(user, media, datas);
            } 
        }

        public static void Menu3(User user,MediaComponent media, Database datas)
        {
            while (true)
            {
                Console.WriteLine("Inserisci il numero della Playlist da riprodurre o -1 per tornare indietro");
                int check = int.Parse(Console.ReadKey().KeyChar.ToString());
                Console.WriteLine();
                if (check == -1) { Menu1(user, media, datas); }
                Playlist s = datas.SelectPlaylist(check);
                media.Play(s,user);
                Menu5(user, media, datas);
            }
        }

        public static void Menu4(User user,MediaComponent media, Database datas)
        {
            while (true)
            {
                Console.WriteLine("Inserisci il numero della Radio da riprodurre o  -1 per tornare indietro");
                int check = int.Parse(Console.ReadKey().KeyChar.ToString());
                Console.WriteLine();
                if (check == -1) { Menu1(user, media, datas); }
                Radio r = datas.SelectRadio(check);
                media.Play(r,user);
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
                Console.WriteLine();
                switch (check)
                {
                    case "F": media.Forward(); break;
                    case "P": media.Pause(); break;
                    case "B": media.Previous(); break;
                    case "S": media.Stop(); Menu1(user, media, datas); break;
                    case "E": return;
                }
            }
        }
    }
}
