

using CountryDIstinction;
using CountryDIstinction.Classes;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace CountryDIstinction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EU Union= new EU("Mario Draghi");
            EUParliament parliament = new EUParliament(5);
            EUCountry Italy = new EUCountry(parliament,Union,"Italy",301.340,
                true,200,150000000000,2000000000,true,true);
            EURegion Piemonte= new EURegion(parliament, Italy, "piemonte", 0);
            EURegion Lombardia = new EURegion(parliament, Italy, "lombardia", 0);
            Piemonte.NumberOfCounties = 5;
            Lombardia.NumberOfCounties = 3;
            Italy.AddRegion(Lombardia);
            Italy.AddRegion(Piemonte);
            Italy.DistributePopulation();
            Console.WriteLine($"Popolazione del Piemonte {Piemonte.Population}");
            Console.WriteLine($"Popolazione della Lombardia {Lombardia.Population}");
        }

    }
    //adding EU class,Nato,Region,Province and _city
  



 


}
