using CountryDIstinction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class City : GeographicArea
    {
        protected County _province;
        protected Citizien[] _inhabitants;//placeholder for array
        protected string _name;
        protected int _population;
        protected double _pil;
        public City(County c, string Name,double Area,int Population, double Pil):base(Name,Area)
        {
            _province = c;
            _population = Population;
            _pil = Pil;
        }
        public virtual void AddCitizien()
        {
            _inhabitants[_population] = new Citizien(this, "place", "holder", 0, 0, false);
            _population++;
        }
        public void AddCitizien(Citizien c)
        {
            _inhabitants[_population] = c;
            _population++;
        }
        public void RemoveCitizien(Citizien c)
        {
            int index = Array.IndexOf(_inhabitants, c);
            _inhabitants[index] = null;
            for (; index < _population; index++)
            {
                _inhabitants[index] = _inhabitants[index + 1];
            }
            _population--;
        }
        public void ChangeCounty(County newCounty)
        {
            if (newCounty.region.country != _province.region.country)
                return;
            _province.RemoveCity(this);
            newCounty.AddCity(this);
            _province = newCounty;

        }

    }
}
