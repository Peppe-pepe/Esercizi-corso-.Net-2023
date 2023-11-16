using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class EURegion : Region
    {
        public EUParliament parliament;
        public new EUCounty province;
        public new EUCountry country;
        public EURegion(EUParliament Parliament,EUCountry c, string Name, double Area) : base(c, Name, Area)
        {
            country = c;
            parliament = Parliament;
        }
        public override void AddCounty()
        {
            province= new EUCounty(this.parliament,this, "placeholder", 0);
        }
        public void AddCounty(EUCounty c)
        {
            province = c;
        }
        public void RemoveCounty(EUCounty c)
        {
            //to do
            c = null;
        }

        public void ChangeCountry(EUCountry newCountry)
        {
            parliament.BorderRedefinition(this, newCountry);
        }

    }
}
