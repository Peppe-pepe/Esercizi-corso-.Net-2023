using CountryDIstinction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDIstinction.Classes
{
    public class EUCountry : Country,
      IEuropeanCourtHumanRights
    {

        bool _isONU;
        bool _isNATO;
        public EU union;
        public EUParliament parliament;
        protected new EURegion[] _regions;
        public EUCountry(EUParliament Parliament,EU Union, String Name, double Area, bool FreedomofSpeech, int Population,
            double Pil, double PublicDebt, bool IsONU, bool IsNato) : base(Name,Area, FreedomofSpeech, Population, Pil, PublicDebt)
        {

            _isONU = IsONU;
            _isNATO = IsNato;
            union = Union;
            _regions = new EURegion[10];
        }
        public bool RespectsRights(Country c)
        {
            if ((!(c is CapitalPunishmentState)) && c.FreedomSpeech)
                return true;
            return false;
        }

        public override void AddRegion()
        {
            if (_numberOfRegions < _maxRegions)
            {
                _regions[_numberOfRegions] = new EURegion(parliament, this, "placeholder", 0);
                _numberOfRegions++;
            }
            else
                Console.WriteLine("massimo regioni raggiunto");
           
        }
        public void AddRegion(EURegion r)
        {
            _regions[_numberOfRegions] = r;
            _numberOfRegions++;
        }
        public void RemoveRegion(EURegion region)
        {
            int index = Array.IndexOf(_regions, region);
            _regions[index] = null;
            for (; index < _numberOfRegions; index++)
            {
                _regions[index] = _regions[index + 1];
            }
        }
       protected override int CountCounties()
        {
            int count = 0;
            foreach (var item in _regions)
            {
                if (item != null)
                    count += item.NumberOfCounties;
            }
            return count;
        }
        public override void DistributePopulation()
        {
            int totalCounties = CountCounties();
            Console.WriteLine($"{totalCounties}");
            foreach (var item in _regions)
            {
                if (item == null)
                    continue;
                 item.Population = item.NumberOfCounties * (_population / totalCounties);
                 item.DistributePopulation();
            }

        
        }
    
        public bool IsOnu { get { return _isONU; } }
        public bool IsNato { get { return _isNATO; } }

        public void ExitUnion()
        {
            union.RemoveMember(this);
            //should destruct the object
        }

}
}