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
        public Country country;
        public County province;//placeholder for array
        public Region(Country c, string Name,double Area):base(Name, Area)  
        {
            country = c;
        }
        public virtual void  AddCounty()
        {
            province = new County(this, "placeholder",0);
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


    }
}
