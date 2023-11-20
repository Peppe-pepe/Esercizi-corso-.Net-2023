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
        protected int _numberOfCities;
        protected int _maxCities=10;
        protected int _population;
        public County(Region R, string Name,double Area) : base(Name,Area)
        {
            _region = R;
            _cities = new City[_maxCities];
        }
        public virtual void AddCity()
        {
            if (_numberOfCities < _maxCities)
            {
                _cities[_numberOfCities] = new City(this, "placeholder", 0, 0, 0);
                _numberOfCities++;
            }
            else
                Console.WriteLine("raggiunto il numero massimo di città");
        }
        public void AddCity(City c)
        {
            _cities[_numberOfCities] = c;
            _numberOfCities++;
        }
        public void RemoveCity(City c)
        {
            int index = Array.IndexOf(_cities, c);
            _cities[index] = null;
            for (; index < _numberOfCities; index++)
            {
                _cities[index] = _cities[index + 1];
            }
            _numberOfCities--;
        }
       
        public void ChangeRegion(Region newRegion)
        {
            if (newRegion.country != region.country)
                return;
            region.RemoveCounty(this);
            newRegion.AddCounty(this);
            _region = newRegion;
        }
        public  virtual void DistributePopulation()
        {
            
            foreach (var item in _cities)
            {
                if (item == null)
                    continue;
                item.MaxPopulation = _population/_numberOfCities;
                item.AllocateCitiensArray();
            }


        }
        public Region region { get { return _region; } }
        public int MaxCities { get { return _maxCities; } set { _maxCities = value; } }
        public int NumberOfCities { get { return _numberOfCities; } }

        public int Population { get => _population; set => _population = value; }
    }
}
