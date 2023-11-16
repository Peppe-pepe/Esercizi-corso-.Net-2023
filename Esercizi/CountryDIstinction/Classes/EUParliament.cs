using CountryDIstinction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class EUParliament : IEUAdministrativeEntity
    {
        int _members;
        public EUParliament(int members)
        {
            _members = members;
        }

        public void BorderRedefinition(EUCity a, EUCounty b)
        {
            Console.WriteLine("valori della città prima del cambiamento");
            Console.WriteLine($"Regione : {a.province.region.country.Name}");
            Console.WriteLine($"Regione : {a.province.region.Name}");
            Console.WriteLine($"Provincia : {a.province.Name}");
            Console.WriteLine($"Nome : {a.Name}");
            Console.WriteLine($"Area : {a.Area}");
            a.province.RemoveCity(a);
            b.AddCity(a);
            a.province = b;
            Console.WriteLine("valori della regione dopo il cambiamento");
            Console.WriteLine($"Nazione : {a.province.region.country.Name}");
            Console.WriteLine($"Regione : {a.province.region.Name}");
            Console.WriteLine($"Provincia : {a.province.Name}");
            Console.WriteLine($"Nome : {a.Name}");
            Console.WriteLine($"Area : {a.Area}");

        }

        public void BorderRedefinition(EUCounty a, EURegion b)
        {
            Console.WriteLine("valori della provincia prima del cambiamento");
            Console.WriteLine($"Nazione : {a.region.country.Name}");
            Console.WriteLine($"Regione : {a.region.Name}");
            Console.WriteLine($"Nome : {a.Name}");
            Console.WriteLine($"Area : {a.Area}");
            a.region.RemoveCounty(a);
            b.AddCounty(a);
            a.region = b;
            Console.WriteLine("valori della regione dopo il cambiamento");
            Console.WriteLine($"Nazione : {a.region.country.Name}");
            Console.WriteLine($"Regione : {a.region.Name}");
            Console.WriteLine($"Nome : {a.Name}");
            Console.WriteLine($"Area : {a.Area}");
 
        }

        public void BorderRedefinition(EURegion a, EUCountry b)
        {
            Console.WriteLine("valori della regione prima del cambiamento");
            Console.WriteLine($"Nazione : {a.country.Name}");
            Console.WriteLine($"Nome : {a.Name}");
            Console.WriteLine($"Area : {a.Area}");
            a.country.RemoveRegion(a);
            b.AddRegion(a);
            a.country = b;
            Console.WriteLine("valori della regione dopo il cambiamento");
            Console.WriteLine($"Nazione : {a.country.Name}");
            Console.WriteLine($"Nome : {a.Name}");
            Console.WriteLine($"Area : {a.Area}");

        }
    }
}
