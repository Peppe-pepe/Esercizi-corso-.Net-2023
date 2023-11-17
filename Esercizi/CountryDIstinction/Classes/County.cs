using CountryDIstinction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class County : GeographicArea
    {
        protected City[] _cities;
        protected Region _region;
        protected int numberOfCities;
        public County(Region R, string Name,double Area) : base(Name,Area)
        {
            _region = R;
            _cities = new City[10];
        }
        public virtual void AddCity()
        {
            _cities[numberOfCities] = new City(this, "placeholder", 0,0, 0);
            numberOfCities++;
        }
        public void AddCity(City c)
        {
            _cities[numberOfCities] = c;
            numberOfCities++;
        }
        public void RemoveCity(City c)
        {
            int index = Array.IndexOf(_cities, c);
            _cities[index] = null;
            for (; index < numberOfCities; index++)
            {
                _cities[index] = _cities[index + 1];
            }
            numberOfCities--;
        }
        public Region region { get { return _region; } }
        public void ChangeRegion(Region newRegion)
        {
            if (newRegion.country != region.country)
                return;
            region.RemoveCounty(this);
            newRegion.AddCounty(this);
            _region = newRegion;
        }

    }
}
