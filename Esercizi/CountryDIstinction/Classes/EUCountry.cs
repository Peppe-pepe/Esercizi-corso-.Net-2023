using CountryDIstinction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class EUCountry : Country,
      IEuropeanCourtHumanRights, IEuroCentralBank
    {

        bool _isONU;
        bool _isNATO;
        public EU union;

        public EUCountry(EU Union, String Name, bool DeathP, bool FreedomofSpeech, double Population,
            double Pil, double PublicDebt, bool IsONU, bool IsNato) : base(Name, DeathP, FreedomofSpeech, Population, Pil, PublicDebt)
        {

            _isONU = IsONU;
            _isNATO = IsNato;
            union = Union;

        }
        public bool RespectsRights(Country c)
        {
            if ((!c.DeathPenalty) && c.FreedomSpeech)
                return true;
            return false;
        }
        public decimal CalcSPread(EUCountry c)
        {
            return ((decimal)(c.PublicDebt * (c.Pil * 0.01)));
        }

        public bool IsOnu { get { return _isONU; } }
        public bool IsNato { get { return _isNATO; } }

        public void ExitUnion()
        {
            union.RemoveMember(this);
            //should destruct the object
        }

    }
}
