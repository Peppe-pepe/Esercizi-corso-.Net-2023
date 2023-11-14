using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public abstract class Person
    {
        protected string _name;
        protected string _surname;
        protected int _age;
        protected Person(string Name, string Surname, int Age)
        {
            _name = Name;
            _surname = Surname;
            _age = Age;
        }
        protected abstract bool isSenior();
    }
}
