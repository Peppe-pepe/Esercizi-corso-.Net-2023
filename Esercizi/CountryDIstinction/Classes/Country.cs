using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
      public class Country
    {
        public Region region;//placeholder for array
        string _name;
        bool _hasDeathPenalty;
        bool _freedomOfSpeech;
        double _population;
        double _pil;
        double _publicDebt;
        public Country(String Name, bool DeathP, bool FreedomofSpeech, double Population,
            double Pil, double PublicDebt)
        {
            _name = Name;
            _hasDeathPenalty = DeathP;
            _freedomOfSpeech = FreedomofSpeech;
            _population = Population;
            _pil = Pil;
            _publicDebt = PublicDebt;
        }
        public string Name { get { return _name; } }
        public bool DeathPenalty { get { return _hasDeathPenalty; } }
        public bool FreedomSpeech { get { return _freedomOfSpeech; } }
        public double Population { get { return _population; } }
        public double Pil { get { return _pil; } }
        public double PublicDebt { get { return _publicDebt; } }
        public void AddRegion()
        {
            region = new Region(this, "placeholder");
        }
        public void AddRegion(Region r)
        {
            region = r;
        }
        public void RemoveRegion(Region region)
        {
            //to do
            region = null;
        }
    }
}
