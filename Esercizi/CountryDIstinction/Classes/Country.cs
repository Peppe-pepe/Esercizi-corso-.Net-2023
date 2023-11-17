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
        protected Region[] _regions;//placeholder for array
        protected bool _freedomOfSpeech;
        protected double _population;
        protected double _pil;
        protected double _publicDebt;
        protected int numberOfRegions;
        public Country(String Name, double Area, bool FreedomofSpeech, double Population,
            double Pil, double PublicDebt):base(Name,Area)
        {
            _freedomOfSpeech = FreedomofSpeech;
            _population = Population;
            _pil = Pil;
            _publicDebt = PublicDebt;
            _regions = new Region[10];
        }
        public bool FreedomSpeech { get { return _freedomOfSpeech; } }
        public double Population { get { return _population; } }
        public double Pil { get { return _pil; } }
        public double PublicDebt { get { return _publicDebt; } }
        public  virtual void AddRegion()
        {
            _regions[numberOfRegions] = new Region(this, "placeholder",0);
            numberOfRegions++;
        }
        public void AddRegion(Region r)
        {
            _regions[numberOfRegions++] = r;
            numberOfRegions++;
        }
        public void RemoveRegion(Region region)
        {
            int index = Array.IndexOf(_regions, region);
            _regions[index] = null;
            for(;index<numberOfRegions;index++)
            {
                _regions[index] = _regions[index + 1];
            }
            numberOfRegions--;
        }

        public void Represent(){ Console.WriteLine($"Rappresento l'opinione pubblica del {this.Name}"); }

        public void Administrate() { Console.WriteLine($"Amministro il/la {this.Name}"); }

        public void HNSRequest()
        {
            throw new NotImplementedException();
        }

        public void LawSystem()
        {
            throw new NotImplementedException();
        }

        public void EducationalSystem()
        {
            throw new NotImplementedException();
        }
    }
}
