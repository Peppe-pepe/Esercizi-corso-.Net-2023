using CountryDIstinction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class EUCountry : Country,
      IEuropeanCourtHumanRights
    {

        bool _isONU;
        bool _isNATO;
        public EU union;

        public EUCountry(EU Union, String Name, double Area, bool FreedomofSpeech, double Population,
            double Pil, double PublicDebt, bool IsONU, bool IsNato) : base(Name,Area, FreedomofSpeech, Population, Pil, PublicDebt)
        {

            _isONU = IsONU;
            _isNATO = IsNato;
            union = Union;

        }
        public bool RespectsRights(Country c)
        {
            if ((!(c is CapitalPunishmentState)) && c.FreedomSpeech)
                return true;
            return false;
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