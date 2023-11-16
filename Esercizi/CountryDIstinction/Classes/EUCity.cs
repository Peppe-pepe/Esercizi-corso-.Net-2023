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
        public EUCitizien _citiziens; //placeholder for ID
        EuID _ids;//placeholder for ID array
        public EUCity(EUParliament Parliament,EUCounty c, string Name, double Area, double Population, double Pil) : base(c, Name, Area, Population, Pil)
        {
            parliament = Parliament;
            province = c;
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

        void AssignID(Citizien c) {
            _ids = new EuID("0",c.Name,c.Surname,c.DateOfBirth,c.Gender,this.province.region.country.Name);
            _citiziens = new EUCitizien(_ids, this, c.Name,c.Surname, c.Age, c.nSons, c.IsinDebt);
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
