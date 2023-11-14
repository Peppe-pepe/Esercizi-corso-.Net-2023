

using CountryDIstinction;
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
    public abstract class Country {
        public Region region;//placeholder for array
        string _name;
        bool _hasDeathPenalty;
        bool _freedomOfSpeech;
        double _population;
        double _pil;
        double _publicDebt;
        public Country(String Name, bool DeathP, bool FreedomofSpeech, double Population,
            double Pil,double PublicDebt)
        {
            _name = Name;
            _hasDeathPenalty = DeathP;
            _freedomOfSpeech = FreedomofSpeech;
            _population = Population;
            _pil = Pil;
            _publicDebt = PublicDebt;
        }
        public string Name { get { return _name; } }
        public bool DeathPenalty { get { return _hasDeathPenalty; } }
        public bool FreedomSpeech { get { return _freedomOfSpeech; } }
        public double Population { get { return _population; } }
        public double Pil { get { return _pil; } }
        public double PublicDebt { get { return _publicDebt; } }
        public void AddRegion()
        {
            region = new Region(this,"placeholder");
        }
        public void AddRegion(Region r)
        {
            region = r;
        }
        public void RemoveRegion(Region region)
        {
            //to do
            region = null;
        }
    }
    public interface IEuroCentralBank
    {
        public decimal CalcSPread(EUCountry c);
    }
    public interface IEuropeanCourtHumanRights {
    public bool RespectsRights(Country c); 
    }
    public interface INato
    {
        public double MilitaryExpense(NatoCountry c);
    }
    public class EUCountry : Country, 
        IEuropeanCourtHumanRights, IEuroCentralBank
{
        
        bool _isONU;
        bool _isNATO;
        public EU union;
      
        public EUCountry(EU Union,String Name, bool DeathP, bool FreedomofSpeech, double Population,
            double Pil, double PublicDebt,bool IsONU,bool IsNato) : base(Name,DeathP,FreedomofSpeech,Population,Pil,PublicDebt)
        {
         
            _isONU = IsONU;
            _isNATO = IsNato;
            union = Union;   
            
        }
    public bool RespectsRights(Country c) {
            if ((!c.DeathPenalty) && c.FreedomSpeech)
                    return true;
            return false;
        }
    public decimal CalcSPread(EUCountry c)
        {
            return ((decimal)(c.PublicDebt* (c.Pil* 0.01)));
        }

    public bool IsOnu { get { return _isONU; } }
        public bool IsNato { get { return _isNATO; } }

    public void ExitUnion()
        {
            union.RemoveMember(this);
            //should destruct the object
        }
        
    }
    public class NatoCountry : Country, INato
    {
        public NATO nato;
        double _militaryExpense;
        int _bases;
        public NatoCountry(NATO Nato,String Name, bool DeathP, bool FreedomofSpeech, double Population,
            double Pil, double PublicDebt,int Bases) :base(Name,DeathP,FreedomofSpeech,
                Population,Pil,PublicDebt)
        {
                nato = Nato;
                _militaryExpense = Pil * 0.02;
                _bases = Bases;
        }
        public double MilitaryBudget { get { return _militaryExpense; } private set { _militaryExpense = value; } }   
        public double MilitaryExpense(NatoCountry c) {
            c.MilitaryBudget = c.Pil * 0.02;
            return c.MilitaryBudget;
        }
       
        public void ExitAlliance() {
            nato.RemoveMember(this);
            //should destruct the object
        }
    }
    public class NATO {
        public NatoCountry country;
        int _bases;//placeholder attributes until we study arrays and collection
        public NATO(int Bases)
        {
                _bases=Bases;
        }
        public void addMember(Country c)
        {
           country= new NatoCountry(this, c.Name, c.DeathPenalty, c.FreedomSpeech, c.Population,
                c.Pil,c.PublicDebt,0);
        }
        public void RemoveMember(NatoCountry c) {
            c = null;
        }
    }
    public class EU
    {
        string _president;//placeholder attributes until we study arrays and collection
        public EUCountry country;
        public EU(String President)
        {
                _president= President;
        }
        public void addCountry(Country c)
        {
            country = new EUCountry(this, c.Name, c.DeathPenalty, c.FreedomSpeech,c.Population,
                c.Pil,c.PublicDebt,true,true);
        }

        public void RemoveMember(EUCountry c) {  c = null; }
        
        public bool IsEuroZone(EUCountry c)
        {
            if (c.PublicDebt < (c.Pil * 0.03))
                return true;
            else
                return false;
        }
    }
    public class Region {
        public Country country; 
        public County province;//placeholder for array
        string _name;
        public Region(Country c,string Name)
        {
            country = c;   
            _name= Name;
        }
        public void AddCounty()
        {
            province = new County(this, "placeholder");
        }
        public void AddCounty(County c)
        {
            province = c;
        }
        public void RemoveCounty(County c)
        {
            //to do
            province = null;
        }
        public void ChangeCountry(Country newCountry)
        {
            country.RemoveRegion(this);
            newCountry.AddRegion(this);
            country= newCountry;
        }
        public string Name { get { return _name; } }
    }
    public class County {
        public City city;//placeholder for array
        public Region region;
        string _name;
        public County(Region r, string name)
        {
            region = r;
            _name = name;
        }
        public void AddCity()
        {
            city = new City(this, "placeholder", 0, 0);
        }
        public void AddCity(City c)
        {
            city = c;
        }
        public void RemoveCity(City c)
        {
            //to do
            city = null;
        }
        public string Name{ get { return _name; } }
        public void ChangeRegion(Region newRegion)
        {
            region.RemoveCounty(this);
            newRegion.AddCounty(this);
            region = newRegion;
        }
    }
    public class City {
        public County province;
        public Citizien inhabitant;//placeholder for array
        string _name;
        double _population;
        double _pil;
        public City(County c,string Name,double Population,double Pil)
        {
            province = c;
            _name = Name;
            _population = Population; 
            _pil=Pil;
        }
        public string Name { get { return _name; } }
        public void AddCitizien() {
            inhabitant = new Citizien(this,"place", "holder", 0, 0, false);
        }
        public void AddCitizien(Citizien c) {
            inhabitant = c;
        }
        public void RemoveCitizien(Citizien c) {
         //to do
         c=null;    
        }
        public void ChangeCounty(County newCounty)
        {
            province.RemoveCity(this);
            newCounty.AddCity(this);
            province = newCounty;
            
        }
    }
    public abstract class Person
    {
        protected string _name;
        protected string _surname;
        protected int _age;
        protected Person(string Name, string Surname, int Age)
        {
            _name = Name;
            _surname = Surname;
            _age = Age;
        }
        protected abstract bool isSenior();
    }

    public class Citizien : Person
    {
        public City city;
        private int _nSons;
        private bool _isInDebt;
        public Citizien(
                City c,
                string Name,
                string Surname,
                int Age,
                int nSons,
                bool isInDebt
            ) : base(Name, Surname, Age)
        {
            _nSons = nSons;
            _isInDebt = isInDebt;
        }
        public string Name { get { return _name; } }
        public string Surname { get { return _surname; } }
        public bool IsAdult { get { return isSenior(); } }
        public int Age { get { return _age; } }
        public bool IsinDebt { get { return _isInDebt; } }
        public int nSons { get { return _nSons; } }
        protected override bool isSenior()
        {
            if (_age > 60)
                return true;
            return false;
        }
        public void ChangeCity(City newCity)
        {
            city.RemoveCitizien(this);
            newCity.AddCitizien(this);
            city = newCity;
        }


    }
}
