using System;

namespace Calcolo_RDC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Citizien _person = new Citizien();
            decimal _points = _person.calcPoints();

            if (_points >= 25)
                Console.WriteLine($"Il cittadino ha diritto al RDC");
            else
                Console.WriteLine($"Il cittadino non ha diritto al RDC");
        }
    }

    public class Citizien
    {
        private string _name = "Giuseppe";
        private string _surname = "Pepe";
        private decimal _age = 63;
        private decimal _nSons = 3;
        private decimal _highSchoolGrade = 70;
        private decimal _collegeGrade = 23;
        private decimal _cityPil = 50000000;
        private bool _isStudent = false;
        private bool _isInDebt = false;
        private bool _wasSoldier = true;
        public decimal calcPoints()
        {
            decimal _points = 0; // Inizializza _points a zero

            if ((18 <= _age && _age <= 25 && _isStudent) || _age > 60)
                _points += 15;
            if (_wasSoldier)
                _points += 5;
            if (_highSchoolGrade > 90)
                _points += 1;
            if (_collegeGrade > 28)
                _points += 1;
            if (_nSons > 1)
                _points += 3;
            if (_cityPil < 100000000)
                _points += 3;
            if (_isInDebt)
                _points += 2;

            return _points;
        }
    }
}
