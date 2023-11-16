using CountryDIstinction.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Interfaces
{
    public interface IEUAdministrativeEntity
    {
        public void BorderRedefinition(EUCity a, EUCounty b);
        public void BorderRedefinition(EUCounty a, EURegion b);
        public void BorderRedefinition(EURegion a, EUCountry b);
    }
}
