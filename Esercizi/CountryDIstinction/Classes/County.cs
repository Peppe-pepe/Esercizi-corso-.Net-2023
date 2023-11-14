using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class County
    {
        public City city;//placeholder for array
        public Region region;
        string _name;
        public County(Region r, string name)
        {
            region = r;
            _name = name;
        }
        public void AddCity()
        {
            city = new City(this, "placeholder", 0, 0);
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
        public string Name { get { return _name; } }
        public void ChangeRegion(Region newRegion)
        {
            region.RemoveCounty(this);
            newRegion.AddCounty(this);
            region = newRegion;
        }
    }
}
