using CountryDIstinction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class Region : GeographicArea
    {
        protected Country _country;
        protected County[] _counties;//placeholder for array
        protected int _numberOfCounties;
        protected int _maxCounties=10;
        protected int _population;
        public Region(Country c, string Name,double Area):base(Name, Area)  
        {
            _country = c;
            _counties = new County[_maxCounties];
        }

        public Country country { get{ return _country; } }
        public virtual void  AddCounty()
        {
            _counties[_numberOfCounties] = new County(this, "placeholder",0);
            _numberOfCounties++;
        }
        public void AddCounty(County c)
        {
            _counties[_numberOfCounties] = c;
            _numberOfCounties++;
        }
        public void RemoveCounty(County c)
        {
            int index = Array.IndexOf(_counties, c);
            _counties[index] = null;
            for (; index < _numberOfCounties; index++)
            {
                _counties[index] = _counties[index + 1];
            }
            _numberOfCounties--;
        }
        protected virtual int CountCities()
        {
            int count = 0;
            foreach (var item in _counties)
            {
                if (item == null)
                    continue;
                count = +item.NumberOfCities;
            }
            return count;
        }
        public virtual void DistributePopulation()
        {
            int totalCounties = CountCities();
            foreach (var item in _counties)
            {
                if(item==null)
                    continue;
                item.Population = item.NumberOfCities * (_population / totalCounties);
                item.DistributePopulation();
            }


        }
        public int MaxCounties { get { return _maxCounties; } set { _maxCounties = value; } }
        public int NumberOfCounties { get => _numberOfCounties; set => _numberOfCounties=value; }//set was added for testing reasons

        public int Population { get => _population; set => _population = value; }
    }
}
