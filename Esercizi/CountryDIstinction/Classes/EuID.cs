using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class EuID
    {
        string _idNumber;
        string _name;
        string _surname;
        string _dateOfBirth;
        string _gender;
        string _countryOfResidence;
        public EuID(string idNumber, string name, string surname, string dateOfBirth, string gender, string countryOfResidence)
        {
            _idNumber = idNumber;
            _name = name;
            _surname = surname;
            _dateOfBirth = dateOfBirth;
            _gender = gender;
            _countryOfResidence = countryOfResidence;
        }

        public string IdNumber { get { return _idNumber; }}
        public string Name { get { return _name; } }
        public string Surname {get {return _surname; } }
        public string DateOfBirth {  get { return _dateOfBirth; }  }
        public string Gender { get { return _gender; } }
        public string CountryOfResidence { get { return _countryOfResidence; } }
    }
}
