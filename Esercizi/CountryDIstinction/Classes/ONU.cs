using CountryDIstinction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class ONU : IPoliticalOrg
    {
        int _members;
        public ONUCountry country;//placeholder for array
        public ONU(int Nmembers) {
            _members = Nmembers;    
        }
        public int Members { get{ return _members; } }
        public void AddMember(Country c) {
            country = new ONUCountry(this,c.Name,c.Area, false, 0, 0, 0, false);
            _members++;}
        public void RemoveMember(ONUCountry ocountry)
        {
            //to do
            country=null;
        }

        public void Represent() {
            Console.WriteLine("Rappresento l'opinione pubblica dell'ONU");
        }
    }
}
