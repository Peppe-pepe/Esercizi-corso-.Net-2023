using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleSystemExercise.Classes
{
    internal class Customer
    {

        private string _fullname;
        private int _age;

        public Customer(string name, int age)
            {
                _fullname = name;
                _age = age;
            }

        public string Name { get => _fullname; }
        public int Age { get => _age; }

        public override string ToString()
            {
                return $"Customer Name: {Name}, Age: {Age}";

            }
        }
}
