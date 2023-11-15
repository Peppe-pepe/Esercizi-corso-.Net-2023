using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    internal class EUCity : City
    {
        EUCitizien _citiziens; //placeholder for ID
        EuID _ids;//placeholder for ID array
        public EUCity(County c, string Name, double Area, double Population, double Pil) : base(c, Name, Area, Population, Pil)
        {
        }
        void AssignID(Citizien c) {
            _ids = new EuID("0",c.Name,c.Surname,c.DateOfBirth,c.Gender);
            _citiziens = new EUCitizien(_ids, c.city, c.Name,c.Surname, c.Age, c.nSons, c.IsinDebt);
        }
    }
}
