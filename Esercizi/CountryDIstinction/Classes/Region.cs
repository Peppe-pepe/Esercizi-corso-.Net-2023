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
        protected int numberOfCounties;
        public Region(Country c, string Name,double Area):base(Name, Area)  
        {
            _country = c;
            _counties = new County[10];
        }

        public Country country { get{ return _country; } }
        public virtual void  AddCounty()
        {
            _counties[numberOfCounties] = new County(this, "placeholder",0);
            numberOfCounties++;
        }
        public void AddCounty(County c)
        {
            _counties[numberOfCounties] = c;
            numberOfCounties++;
        }
        public void RemoveCounty(County c)
        {
            int index = Array.IndexOf(_counties, c);
            _counties[index] = null;
            for (; index < numberOfCounties; index++)
            {
                _counties[index] = _counties[index + 1];
            }
            numberOfCounties--;
        }


    }
}
