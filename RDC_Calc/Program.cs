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

    public abstract class Person {
        protected string _name;
        protected string _surname;
        protected int _age;
        protected Person(string Name,string Surname,int Age) { 
         _name = Name;   
        _surname = Surname; 
        _age = Age; 
        }
        protected bool isSenior();
    }

    public class Citizien : Person
    {

        private int _nSons = 3;
        private decimal _cityPil = 50000000;
        private bool _isStudent = false;
        private bool _isInDebt = false;
        private bool _wasSoldier = true;
        public Citizien(
                string Name,
                string Surname,
                int Age,
                int nSons,
                decimal cityPil,
                bool isInDebt
            ) : base(Name,Surname,Age)
        {
            _nSons = nSons;
            _cityPil = cityPil;
            _isInDebt = isInDebt;
        }
        public string Name { get { return _name; } }
        public string Surname { get { return _surname; } }
        public bool IsAdult { get { return isSenior(); } }
        protected override bool isSenior() { 
            if (_age > 60) 
                return true;
            return false;   
        }
        public virtual decimal collegeGrade()
        {
            return 0;
        }
        public virtual int HighSchoolGrade()
        {
            return 0;
        }

        public virtual int wasSoldier() {
            return 0;
        }
    }

    public class Student : Citizien
    {
        private int _highSchoolGrade;
        public Student(string Name,
                string Surname,
                int Age,
                int nSons,
                decimal cityPil,
                bool isInDebt,
                int HighschoolGrade):base(string Name,
                string Surname,
                int Age,
                int nSons,
                decimal cityPil,
                bool isInDebt)
        {
            _highSchoolGrade = HighschoolGrade;
        }
    }

    public class UniversityStudent : Student
    {
        private decimal _collegeGrade;
        public UniversityStudent(string Name,
                string Surname,
                int Age,
                int nSons,
                decimal cityPil,
                bool isInDebt,
                int HighschoolGrade,
                decimal CollegeGrade) : base(string Name,
                string Surname,
                int Age,
                int nSons,
                decimal cityPil,
                bool isInDebt,
                int HighschoolGrade)
        {
            _collegeGrade = CollegeGrade;
        }
    }

    public class Soldier : Citizien
    {
        private int _yearsOfService;
    }

    public abstract class EntePubblico
    {

    }

    public class Comune : EntePubblico
    {
        public decimal calcPoints(Citizien c)
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
