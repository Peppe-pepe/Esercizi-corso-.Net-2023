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
        public new EUCounty _province;
        private new EUCitizien[] _inhabitants; 
        EuID[] _ids;
        public EUCity(EUParliament Parliament,EUCounty c, string Name, double Area, int Population, double Pil) : base(c, Name, Area, Population, Pil)
        {
            parliament = Parliament;
            _province = c;
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
            if (_population < _maxPopulation)
            {
                _ids[_population] = new EuID("0", c.Name, c.Surname, c.DateOfBirth, c.Gender, this._province.region.country.Name);
                _inhabitants[_population] = new EUCitizien(_ids[_population], this, c.Name, c.Surname, c.Age, c.nSons, c.IsinDebt);
                _population++;
            }
            else
                Console.WriteLine("massimo cittadini raggiunto");
         
        }
        public void AddCitizien(EUCitizien c,EuID e)
        {
            e.ChangeCountry(this._province.region.country);
            _ids[_population] = e;
            _inhabitants[_population] = c;
            _population++;
        }
        public override void AllocateCitiensArray()
        {
            _inhabitants=new EUCitizien[_maxPopulation];
            _ids=new EuID[_maxPopulation];
        }
        public void RemoveCitizien(EUCitizien c,EuID e)
        {
            int index = Array.IndexOf(_inhabitants, c);
            for (; index < _population; index++)
            {
                _inhabitants[index] = _inhabitants[index + 1];
            }
            index=Array.IndexOf(_ids, e);
            for (; index < _population; index++)
            {
                _ids[index] = _ids[index + 1];
            }
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
            if (newCounty.region.country != _province.region.country)
                parliament.BorderRedefinition(this, newCounty);
            else
            {
                _province.RemoveCity(this);
                newCounty.AddCity(this);
                _province = newCounty;
            }
                
        }
    }

}
