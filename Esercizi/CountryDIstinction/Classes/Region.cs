using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class Region
    {
        public Country country;
        public County province;//placeholder for array
        string _name;
        public Region(Country c, string Name)
        {
            country = c;
            _name = Name;
        }
        public void AddCounty()
        {
            province = new County(this, "placeholder");
        }
        public void AddCounty(County c)
        {
            province = c;
        }
        public void RemoveCounty(County c)
        {
            //to do
            province = null;
        }
        public void ChangeCountry(Country newCountry)
        {
            country.RemoveRegion(this);
            newCountry.AddRegion(this);
            country = newCountry;
        }
        public string Name { get { return _name; } }
    }
}
