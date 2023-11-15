using CountryDIstinction.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Interfaces
{
    public interface IEuroCentralBank
    {
        public void MonetaUnica();
        public decimal CalcSPread(EUCountry c);
    }
}
