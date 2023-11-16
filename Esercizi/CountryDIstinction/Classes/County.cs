using CountryDIstinction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class County : GeographicArea
    {
        public City city;//placeholder for array
        public Region region;
        public County(Region R, string Name,double Area) : base(Name,Area)
        {
            region = R;
        }
        public virtual void AddCity()
        {
            city = new City(this, "placeholder", 0,0, 0);
        }
        public void AddCity(City c)
        {
            city = c;
        }
        public void RemoveCity(City c)
        {
            //to do
            city = null;
        }
        public void ChangeRegion(Region newRegion)
        {
            if (newRegion.country != region.country)
                return;
            region.RemoveCounty(this);
            newRegion.AddCounty(this);
            region = newRegion;
        }

    }
}
