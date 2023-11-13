using System;
using System.ComponentModel.Design;

namespace RDCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UniversityStudent _person = new UniversityStudent(
                "Giuseppe",
                "Pepe",
                63,
                3,
                4000000,
                true,
                100,
                28
                );
            Comune city = new Comune("nocera");
            city.isEligible(_person);
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
        public bool WasSoldier { get { return _wasSoldier; } }
        public int nSons { get { return _nSons; } }
        protected override bool isSenior()
        {
            if (_age > 60)
                return true;
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
                int HighschoolGrade) : base(Name,
                Surname,
                 Age,
                 nSons,
                 cityPil,
                isInDebt)
        {
            _highSchoolGrade = HighschoolGrade;
        }
        public int HighSchoolGrade{get{ return _highSchoolGrade; } }
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
        public decimal CollegeGrade { get { return _collegeGrade; } }
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

    }

    public abstract class EntePubblico
    {
        string _name;
        public EntePubblico(string name)
        {
                  _name = name;
        }
        public abstract void isEligible(Citizien c);
    }

    public class Comune : EntePubblico
    {
        public Comune(string Nome):base(Nome) {
        }
        public override void isEligible(Citizien c)
        {
            decimal _points = 0; // Inizializza _points a zero

            if ((18 <= c.Age && c.Age <= 25 && c is Student) || c.IsAdult)
                _points += 15;
            if (c is Soldier || c.WasSoldier)
                _points += 5;
            if (c is Student)
                _points+=calcStudent((Student)c);
                    
            if (c is UniversityStudent)
                _points += calcUniversityStudent((UniversityStudent)c);
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
             int calcStudent(Student s){
                if (s.HighSchoolGrade>90)
                    return 10;
                return 0;
            }
            int calcUniversityStudent(UniversityStudent u)
            {
                if(u.CollegeGrade>28)
                    return 10;
                return 0;
            }
        }
    }
}