using CountryDIstinction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class Region : GeographicArea,IAdministrativeEntity
    {
        public Country country;
        public County province;//placeholder for array
        public Region(Country c, string Name,double Area):base(Name, Area)  
        {
            country = c;
        }
        public void AddCounty()
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
        public void ChangeCountry(Country newCountry)
        {
            country.RemoveRegion(this);
            newCountry.AddRegion(this);
            country = newCountry;
        }

        public void Administrate() { Console.WriteLine($"Amministro il/la {this.Name}"); }
    }
}
