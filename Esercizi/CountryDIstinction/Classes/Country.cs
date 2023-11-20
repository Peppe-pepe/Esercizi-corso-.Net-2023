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
        protected int _population;
        protected double _pil;
        protected double _publicDebt;
        protected int _numberOfRegions;
        protected int _maxRegions = 10;
        public Country(String Name, double Area, bool FreedomofSpeech, int Population,
            double Pil, double PublicDebt):base(Name,Area)
        {
            _freedomOfSpeech = FreedomofSpeech;
            _population = Population;
            _pil = Pil;
            _publicDebt = PublicDebt;
            _regions = new Region[_maxRegions];
        }
        public bool FreedomSpeech { get { return _freedomOfSpeech; } }
        public int Population { get { return _population; } }
        public double Pil { get { return _pil; } }
        public double PublicDebt { get { return _publicDebt; } }
        public int MaxRegions { get { return _maxRegions; } set { _maxRegions = value; } }

        public virtual void AddRegion()
        {
            _regions[_numberOfRegions] = new Region(this, "placeholder",0);
            _numberOfRegions++;
        }
        public void AddRegion(Region r)
        {
            _regions[_numberOfRegions++] = r;
            _numberOfRegions++;
        }
        public void RemoveRegion(Region region)
        {
            int index = Array.IndexOf(_regions, region);
            _regions[index] = null;
            for(;index<_numberOfRegions;index++)
            {
                _regions[index] = _regions[index + 1];
            }
            _numberOfRegions--;
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

        protected virtual int CountCounties()
        {
            int count = 0;
            foreach (var item in _regions)
            {
                if(item!=null)
                    count+=item.NumberOfCounties;
            }
            return count;
        }
        public virtual void DistributePopulation()
        {
            int totalCounties=CountCounties();
            Console.WriteLine($"{totalCounties}");
            foreach(var item in _regions)
            {
                if (item != null) {
                    item.Population = item.NumberOfCounties * (_population / totalCounties);
                }
              //  item.DistributePopulation();
            }
   

        }
    }
}
