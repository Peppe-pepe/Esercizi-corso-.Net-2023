using System;
using System.ComponentModel.Design;

namespace RDCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student _person = new Student(
                "Giuseppe",
                "Pepe",
                63,
                3,
                4000000,
                true,
                100
                );
            Comune city = new Comune();
            city.calcPoints(_person);
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
            ) : base(Name, Surname, Age)
        {
            _nSons = nSons;
            _cityPil = cityPil;
            _isInDebt = isInDebt;
        }
        public string Name { get { return _name; } }
        public string Surname { get { return _surname; } }
        public bool IsAdult { get { return isSenior(); } }
        public decimal CityPil { get { return _cityPil; } }
        public int Age { get { return _age; } }
        public bool IsinDebt { get { return _isInDebt; } }  
        public int nSons {  get { return _nSons; } }    
        protected override bool isSenior()
        {
            if (_age > 60)
                return true;
            return false;
        }

        public virtual bool isStudent() {  return false; }
        public virtual decimal CollegeGrade()
        {
            return 0;
        }
        public virtual decimal HighSchoolGrade()
        {
            return 0;
        }

        public virtual bool wasSoldier()
        {
            return false;
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
                int HighschoolGrade) : base( Name,
                Surname,
                 Age,
                 nSons,
                 cityPil,
                isInDebt)
        {
            _highSchoolGrade = HighschoolGrade;
        }
        public override bool isStudent()
        {
            if (_highSchoolGrade != 0)
                return true;
            return false;
        }

        public override decimal HighSchoolGrade()
        {
            return _highSchoolGrade;
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
                decimal CollegeGrade) : base( Name,
                Surname,
                Age,
                nSons,
                cityPil,
                isInDebt,
                HighschoolGrade)
        {
            _collegeGrade = CollegeGrade;
        }
        public override decimal CollegeGrade() { return _collegeGrade;}
    }

    public class Soldier : Citizien
    {
        private int _yearsOfService;
        public Soldier(string Name,
                string Surname,
                int Age,
                int nSons,
                decimal cityPil,
                bool isInDebt,int yearsOfService) :base(Name,
                Surname,
                Age,
                nSons,
                cityPil,
                isInDebt)
        {
            _yearsOfService = yearsOfService;
        }
        public override bool wasSoldier()
        {
            if(_yearsOfService>=1)
                return true;
            return false;
        }
    }

    public abstract class EntePubblico
    {

    }

    public class Comune : EntePubblico
    {
        public void calcPoints(Citizien c)
        {
            decimal _points = 0; // Inizializza _points a zero

            if ((18 <= c.Age && c.Age <= 25 && c.isStudent()) || c.IsAdult)
                _points += 15;
            if (c.wasSoldier())
                _points += 5;
            if (c.HighSchoolGrade() > 90)
                _points += 1;
            if (c.CollegeGrade() > 28)
                _points += 1;
            if (c.nSons > 1)
                _points += 3;
            if (c.CityPil < 100000000)
                _points += 3;
            if (c.IsinDebt)
                _points += 2;
            if (_points >= 25)
                Console.WriteLine($"il cittadino ha diritto al RDC");
            else
                Console.WriteLine($"il cittadino non ha diritto al RDC");
        }
    }
}