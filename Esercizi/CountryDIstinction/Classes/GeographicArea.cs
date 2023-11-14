using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class GeographicArea 
    {
        string _name;
        double _area;
        public GeographicArea(string Name,double Area)
        {
                _area = Area;   
                _name = Name;
        }

        public double Area { get { return _area; } }    
        public string Name { get { return _name;} }
    }
}
