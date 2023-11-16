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
        public EUParliament parliament;
        public new EURegion region;

        public EUCountry(EUParliament Parliament,EU Union, String Name, double Area, bool FreedomofSpeech, double Population,
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

        public override void AddRegion()
        {
            region = new EURegion(parliament,this, "placeholder", 0);
        }
        public void AddRegion(EURegion r)
        {
            region = r;
        }
        public void RemoveRegion(EURegion region)
        {
            //to do
            region = null;
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