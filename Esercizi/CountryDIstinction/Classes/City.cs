using CountryDIstinction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class City : GeographicArea,IAdministrativeEntity
    {
        public County province;
        public Citizien inhabitant;//placeholder for array
        string _name;
        double _population;
        double _pil;
        public City(County c, string Name,double Area,double Population, double Pil):base(Name,Area)
        {
            province = c;
            _population = Population;
            _pil = Pil;
        }
        public void AddCitizien()
        {
            inhabitant = new Citizien(this, "place", "holder", 0, 0, false);
        }
        public void AddCitizien(Citizien c)
        {
            inhabitant = c;
        }
        public void RemoveCitizien(Citizien c)
        {
            //to do
            c = null;
        }
        public void ChangeCounty(County newCounty)
        {
            province.RemoveCity(this);
            newCounty.AddCity(this);
            province = newCounty;

        }
        public void Administrate() { Console.WriteLine($"Amministro {this.Name}"); }
    }
}
