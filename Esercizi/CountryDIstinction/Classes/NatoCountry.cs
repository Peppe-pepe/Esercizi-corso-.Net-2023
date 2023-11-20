using CountryDIstinction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class NatoCountry : Country, INato
    {
        public NATO nato;
        double _militaryExpense;
        int _bases;
        public NatoCountry(NATO Nato, String Name,double Area, bool FreedomofSpeech, int Population,
            double Pil, double PublicDebt, int Bases) : base(Name,Area, FreedomofSpeech,
                Population, Pil, PublicDebt)
        {
            nato = Nato;
            _bases = Bases;
        }
        public double MilitaryBudget { get { return _militaryExpense; } private set { _militaryExpense = value; } }
        public double MilitaryExpense(NatoCountry c)
        {
            c.MilitaryBudget = c.Pil * 0.02;
            return c.MilitaryBudget;
        }

        public void ExitAlliance()
        {
            nato.RemoveMember(this);
            //should destruct the object
        }
    }
}
