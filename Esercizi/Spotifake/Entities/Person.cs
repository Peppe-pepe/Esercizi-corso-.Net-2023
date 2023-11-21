using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifake.Entities
{
    public class Person
    {
        private string _name;
        private string _email;
        private string _dateOfBirth;

        public Person(string name, string email, string dateOfBirth)
        {
            _name = name;
            _email = email;
            _dateOfBirth = dateOfBirth;
        }

        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }
        public string DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
    }
}
