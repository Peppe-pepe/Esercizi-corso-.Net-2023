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

        public EuID(string idNumber, string name, string surname, string dateOfBirth, string gender)
        {
            _idNumber = idNumber;
            _name = name;
            _surname = surname;
            _dateOfBirth = dateOfBirth;
            _gender = gender;
        }
    }
}
