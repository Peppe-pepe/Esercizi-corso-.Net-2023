

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
            EUCountry Italy = new EUCountry(Union,"Italy",false,
                true,60000000,150000000000,2000000000,true,true);
            bool result =Union.IsEuroZone(Italy);
            if(result)
                Console.WriteLine(Italy.Name+$" is part of the EuroZone");
            else
                Console.WriteLine(Italy.Name + $" is not part of the EuroZone");
           
            result=Italy.RespectsRights(Italy);
            if (result)
                Console.WriteLine(Italy.Name + $" respects human rights");
            else
                Console.WriteLine(Italy.Name + $" does not respect human rights");
        }
    }
    //adding EU class,Nato,Region,Province and city
  



 


}
