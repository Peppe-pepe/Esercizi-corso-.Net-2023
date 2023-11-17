using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class Citizien : Person
    {
        protected City city;
        protected int _nSons;
        protected bool _isInDebt;
        protected string _dateOfBirth;
        protected string _gender;

        public Citizien(
                City c,
                string Name,
                string Surname,
                int Age,
                int nSons,
                bool isInDebt
            ) : base(Name, Surname, Age)
        {
            _nSons = nSons;
            _isInDebt = isInDebt;
        }
        public string Name { get { return _name; } }
        public string Surname { get { return _surname; } }
        public bool IsAdult { get { return isSenior(); } }
        public int Age { get { return _age; } }
        public bool IsinDebt { get { return _isInDebt; } }
        public int nSons { get { return _nSons; } }

        public string DateOfBirth { get { return _dateOfBirth; } }

        public string Gender { get {return _gender; }  }

        protected override bool isSenior()
        {
            if (_age > 60)
                return true;
            return false;
        }
        public void ChangeCity(City newCity)
        {
            city.RemoveCitizien(this);
            newCity.AddCitizien(this);
            city = newCity;
        }


    }
}
