

using CountryDIstinction;
using System;
using System.Reflection.Metadata.Ecma335;

namespace CountryDIstinction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public abstract class Country {
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
    }
    public interface IEuroCentralBank{
        public decimal CalcSPread(Country c);
    }
    public interface IEuropeanCourtHumanRights {
    public bool RespectsRights(Country c); 
    }
    public class EuropeanCountry : Country, IEuropeanCourtHumanRights, IEuroCentralBank
{
        
        bool _isONU;
        bool _isNATO;
        bool _isEU;
      
        public EuropeanCountry(String Name, bool DeathP, bool FreedomofSpeech, double Population,
            double Pil, double PublicDebt,bool IsONU,bool IsNato,bool IsEU) : base(Name,DeathP,FreedomofSpeech,Population,Pil,PublicDebt)
        {
         
            _isONU = IsONU;
            _isNATO = IsNato;
            _isEU = IsEU;   
            
        }
    public bool RespectsRights(Country c) {
            if ((!c.DeathPenalty) && c.FreedomSpeech)
                    return true;
            return false;
        }
    public decimal CalcSPread(Country c)
        {
            return ((decimal)(c.PublicDebt* (c.Pil* 0.01)));
        }
    public bool IsOnu { get { return _isONU; } }
        public bool IsNato { get { return _isNATO; } }
        public bool IsEU {  get { return _isEU; } }
        
    }
}
