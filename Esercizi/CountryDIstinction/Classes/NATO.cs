using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class NATO
    {
        public NatoCountry country;
        int _bases;//placeholder attributes until we study arrays and collection
        public NATO(int Bases)
        {
            _bases = Bases;
        }
        public void addMember(Country c)
        {
            country = new NatoCountry(this, c.Name,c.Area, c.FreedomSpeech, c.Population,
                 c.Pil, c.PublicDebt, 0);
        }
        public void RemoveMember(NatoCountry c)
        {
            c = null;
        }
    }
}
