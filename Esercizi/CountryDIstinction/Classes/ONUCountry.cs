using CountryDIstinction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class ONUCountry : Country,IONU
    {
        public ONU Organization;
        bool _hasVeto;
        public ONUCountry(ONU Org,String Name,double Area, bool FreedomofSpeech, int Population,
            double Pil, double PublicDebt,bool veto):base(Name,Area, FreedomofSpeech,Population,Pil,PublicDebt)
        {
            _hasVeto = veto;
        }
        public bool Veto { get {return _hasVeto; } }

        public void Leave() {
            Organization.RemoveMember(this);    
        }
        public void TerritoryDefense()
        {
            Console.WriteLine("il territorio è difeso");
        }
        public void PopulationControl()
        {
            Console.WriteLine("la popolazione è controllata");  
        }
    }
}
