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
        private new EUCounty[] _counties;
        public new EUCountry country;
        public EURegion(EUParliament Parliament,EUCountry c, string Name, double Area) : base(c, Name, Area)
        {
            country = c;
            parliament = Parliament;
            _counties = new EUCounty[10];
        }
        public override void AddCounty()
        {
            _counties[numberOfCounties]= new EUCounty(this.parliament,this, "placeholder", 0);
            numberOfCounties++;
        }
        public void AddCounty(EUCounty c)
        {
            _counties[numberOfCounties] = c;
            numberOfCounties++;
        }
        public void RemoveCounty(EUCounty c)
        {
            int index = Array.IndexOf(_counties, c);
            _counties[index] = null;
            for (; index < numberOfCounties; index++)
            {
                _counties[index] = _counties[index + 1];
            }
            numberOfCounties--;
        }

        public void ChangeCountry(EUCountry newCountry)
        {
            parliament.BorderRedefinition(this, newCountry);
        }

    }
}
