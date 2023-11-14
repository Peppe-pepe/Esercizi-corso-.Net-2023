using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class City
    {
        public County province;
        public Citizien inhabitant;//placeholder for array
        string _name;
        double _population;
        double _pil;
        public City(County c, string Name, double Population, double Pil)
        {
            province = c;
            _name = Name;
            _population = Population;
            _pil = Pil;
        }
        public string Name { get { return _name; } }
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
    }
}
