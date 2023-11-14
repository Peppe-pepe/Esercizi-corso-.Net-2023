using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class EU
    {
        string _president;//placeholder attributes until we study arrays and collection
        public EUCountry country;
        public EU(String President)
        {
            _president = President;
        }
        public void addCountry(Country c)
        {
            country = new EUCountry(this, c.Name, c.DeathPenalty, c.FreedomSpeech, c.Population,
                c.Pil, c.PublicDebt, true, true);
        }

        public void RemoveMember(EUCountry c) { c = null; }

        public bool IsEuroZone(EUCountry c)
        {
            if (c.PublicDebt < (c.Pil * 0.03))
                return true;
            else
                return false;
        }
    }
}
