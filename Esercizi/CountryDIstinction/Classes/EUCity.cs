using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountryDIstinction.Interfaces;

namespace CountryDIstinction.Classes
{
    public class EUCity : City,IEUCitizienServices
    {
        public  EUParliament parliament;
        public new EUCounty province;
        private new EUCitizien[] _inhabitants; 
        EuID[] _ids;
        public EUCity(EUParliament Parliament,EUCounty c, string Name, double Area, int Population, double Pil) : base(c, Name, Area, Population, Pil)
        {
            parliament = Parliament;
            province = c;
            _inhabitants = new EUCitizien[10];
            _ids = new EuID[10];
        }

        public void EducationalSystem(EuID id)
        {
            Console.WriteLine($"Apro richiesta per d'iscrizione al sistema educativo per {id.Name} {id.Surname}");
        }

        public void HNSRequest(EuID id)
        {
            Console.WriteLine($"dò assistenza sanitaria a {id.Name} {id.Surname}");
        }

        public void Wellfare()
        {
            Console.WriteLine("apro richiesta per i sussidi");
        }

        public void AssignID(Citizien c) {
            _ids[_population] = new EuID("0",c.Name,c.Surname,c.DateOfBirth,c.Gender,this.province.region.country.Name);
            _inhabitants[_population] = new EUCitizien(_ids[_population], this, c.Name,c.Surname, c.Age, c.nSons, c.IsinDebt);
            _population++;
        }
        public void AddCitizien(EUCitizien c,EuID e)
        {
            e.ChangeCountry(this.province.region.country);
            _ids[_population] = e;
            _inhabitants[_population] = c;
            _population++;
        }
        public void RemoveCitizien(EUCitizien c,EuID e)
        {

        }
        public void LawSystem()
        {
           //to do
        }

        public void HNSRequest()
        {
           //to do
        }

        public void EducationalSystem()
        {
            //to do
        }

        public void ChangeCounty(EUCounty newCounty)
        {
            if (newCounty.region.country != province.region.country)
                parliament.BorderRedefinition(this, newCounty);
            else
            {
                province.RemoveCity(this);
                newCounty.AddCity(this);
                province = newCounty;
            }
                
        }
    }

}
