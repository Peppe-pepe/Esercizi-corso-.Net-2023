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
            _cities = new EUCity[10];
        }
        public override void AddCity()
        {
            _cities[numberOfCities] = new EUCity(parliament, this, "placeholder", 0, 0, 0);
            numberOfCities++;
        }
        public void AddCity(EUCity c)
        {
            _cities[numberOfCities] = c;
            numberOfCities++;
        }
        public void RemoveCity(EUCity c)
        {
            int index = Array.IndexOf(_cities, c);
            _cities[index] = null;
            for (; index < numberOfCities; index++)
            {
                _cities[index] = _cities[index + 1];
            }
            numberOfCities--;
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

    }
}
