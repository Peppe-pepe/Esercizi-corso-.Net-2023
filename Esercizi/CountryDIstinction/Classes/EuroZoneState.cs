using CountryDIstinction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    internal class EuroZoneState : EUCountry,IEuroCentralBank
    {
        //to do
        public EuroZoneState(EU Union, string Name, double Area, bool FreedomofSpeech, double Population, double Pil, double PublicDebt, bool IsONU, bool IsNato) :
            base(Union, Name, Area, FreedomofSpeech, Population, Pil, PublicDebt, IsONU, IsNato)
        {
        }

        public decimal CalcSPread(EUCountry c)
        {
            return ((decimal)(c.PublicDebt * (c.Pil * 0.01)));
        }

        public void MonetaUnica()
        {
            Console.WriteLine("Uso la moneta unica");
        }

    }
}
