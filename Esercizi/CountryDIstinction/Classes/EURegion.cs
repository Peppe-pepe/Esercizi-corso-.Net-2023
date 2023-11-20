using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class EURegion : Region
    {
        public EUParliament parliament;
        private new EUCounty[] _counties;
        public new EUCountry country;
        public EURegion(EUParliament Parliament,EUCountry c, string Name, double Area) : base(c, Name, Area)
        {
            country = c;
            parliament = Parliament;
            _counties = new EUCounty[_maxCounties];
        }
        public override void AddCounty()
        {
            if (_numberOfCounties < _maxCounties)
            {
                _counties[_numberOfCounties] = new EUCounty(this.parliament, this, "placeholder", 0);
                _numberOfCounties++;
            }
            else
                Console.WriteLine("massimo province raggiunto");
            
        }
        public void AddCounty(EUCounty c)
        {
            _counties[_numberOfCounties] = c;
            _numberOfCounties++;
        }
        public void RemoveCounty(EUCounty c)
        {
            int index = Array.IndexOf(_counties, c);
            _counties[index] = null;
            for (; index < _numberOfCounties; index++)
            {
                _counties[index] = _counties[index + 1];
            }
            _numberOfCounties--;
        }
        protected override int CountCities()
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
        public override void DistributePopulation()
        {
            int totalCounties = CountCities();
            foreach (var item in _counties)
            {
                if (item == null)
                    continue;
                item.Population = item.NumberOfCities * (_population / totalCounties);
                item.DistributePopulation();
            }


        }
        public void ChangeCountry(EUCountry newCountry)
        {
            parliament.BorderRedefinition(this, newCountry);
        }

    }
}
