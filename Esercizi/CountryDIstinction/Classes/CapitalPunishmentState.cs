using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountryDIstinction.Interfaces;

namespace CountryDIstinction.Classes
{
    public class CapitalPunishmentState : Country, ICapitalPunishment
    {
        string _punishment;
        public CapitalPunishmentState(string Name, double Area, bool FreedomofSpeech,
            int Population, double Pil, double PublicDebt,string punishment) : base(Name, Area, FreedomofSpeech, Population, Pil, PublicDebt)
        {
            _punishment = punishment;
        }

        public string Punishment { get { return _punishment; } }

        public void CapitalPunishment()
        {
            Console.WriteLine($"un cittadino è stato ucciso attraverso {this.Punishment}");
        }
    }
}
