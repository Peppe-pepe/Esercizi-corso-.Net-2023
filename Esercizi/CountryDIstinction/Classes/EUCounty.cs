using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class EUCounty:County
    {
        public EUParliament parliament;
        public new EUCity[] _cities;
        public new EURegion region;
        public EUCounty(EUParliament Parliament,EURegion R, string Name, double Area) : base(R, Name, Area)
        {
            region = R;
            parliament = Parliament;
            _cities = new EUCity[_maxCities];
        }
        public override void AddCity()
        {
            if (_numberOfCities < _maxCities)
            {
                _cities[_numberOfCities] = new EUCity(parliament, this, "placeholder", 0, 0, 0);
                _numberOfCities++;
            }
            else
                Console.WriteLine("massimo città raggiunto");
        }
        public void AddCity(EUCity c)
        {
            if (_numberOfCities < _maxCities)
            {
                _cities[_numberOfCities] = c;
                _numberOfCities++;
            }
            else
                Console.WriteLine("massimo città raggiunto");
        }
        public void RemoveCity(EUCity c)
        {
            int index = Array.IndexOf(_cities, c);
            _cities[index] = null;
            for (; index < _numberOfCities; index++)
            {
                _cities[index] = _cities[index + 1];
            }
            _numberOfCities--;
        }
        public void ChangeRegion(EURegion newRegion)
        {
            if (newRegion.country != region.country)
                parliament.BorderRedefinition(this,newRegion);
            else
            {
                region.RemoveCounty(this);
                newRegion.AddCounty(this);
                region = newRegion;
            }
     
        }
        public override void DistributePopulation()
        {

            foreach (var item in _cities)
            {
                if (item == null)
                    continue;
                item.MaxPopulation = _population / _numberOfCities;
                item.AllocateCitiensArray();
            }


        }
    }
}
