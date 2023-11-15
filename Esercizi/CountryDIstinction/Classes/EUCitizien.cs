using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class EUCitizien : Citizien
    {
        public EuID id;

        public EUCitizien(EuID ID, City c, string Name, string Surname, int Age, int nSons, bool isInDebt) :
            base(c, Name, Surname, Age, nSons, isInDebt)
        {
            id = ID;
        }
    }
}
