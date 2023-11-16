

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
                true,60000000,150000000000,2000000000,true,true);
            EUCountry Germany = new EUCountry(parliament,Union, "Germany", 501.340,
               true, 60000000, 150000000000, 2000000000, true, true);
            EURegion Lombardia = new EURegion(parliament, Italy, "lombardia", 0);
            Lombardia.ChangeCountry(Germany);

        }

    }
    //adding EU class,Nato,Region,Province and city
  



 


}
