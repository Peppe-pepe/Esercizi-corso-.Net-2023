using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class EUCounty:County
    {
        public EUParliament parliament;
        public new EUCity city;
        public new EURegion region;
        public EUCounty(EUParliament Parliament,EURegion R, string Name, double Area) : base(R, Name, Area)
        {
            region = R;
            parliament = Parliament;
        }
        public override void AddCity()
        {
            city = new EUCity(parliament, this, "placeholder", 0, 0, 0);
        }
        public void AddCity(EUCity c)
        {
            city = c;
        }
        public void RemoveCity(EUCity c)
        {
            //to do
            city = null;
        }
        public void ChangeRegion(EURegion newRegion)
        {
            if (newRegion.country != region.country)
                parliament.BorderRedefinition(this,newRegion);
            else
            {
                region.RemoveCounty(this);
                newRegion.AddCounty(this);
                region = newRegion;
            }
     
        }

    }
}
