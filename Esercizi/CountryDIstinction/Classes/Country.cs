using CountryDIstinction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
      public class Country : GeographicArea,IPoliticalOrg,IAdministrativeEntity
    {
        public Region region;//placeholder for array
        bool _freedomOfSpeech;
        double _population;
        double _pil;
        double _publicDebt;
        public Country(String Name, double Area, bool FreedomofSpeech, double Population,
            double Pil, double PublicDebt):base(Name,Area)
        {
            _freedomOfSpeech = FreedomofSpeech;
            _population = Population;
            _pil = Pil;
            _publicDebt = PublicDebt;
        }
        public bool FreedomSpeech { get { return _freedomOfSpeech; } }
        public double Population { get { return _population; } }
        public double Pil { get { return _pil; } }
        public double PublicDebt { get { return _publicDebt; } }
        public void AddRegion()
        {
            region = new Region(this, "placeholder",0);
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

        public void Represent(){ Console.WriteLine($"Rappresento l'opinione pubblica del {this.Name}"); }

        public void Administrate() { Console.WriteLine($"Amministro il/la {this.Name}"); }
    }
}
