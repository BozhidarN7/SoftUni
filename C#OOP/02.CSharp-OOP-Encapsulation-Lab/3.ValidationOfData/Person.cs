using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name must be at least 3 symbols");
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name must be at least 3 symbols");
                }
                lastName = value;
            }
        }
        public int Age
        {
            get => age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Zero or negative age is not allowed");
                }
                age = value;
            }
        }

        public decimal Salary
        {
            get => salary;
            set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }
                salary = value;
            }
        }

        public void IncreaseSalary(decimal persentage)
        {
            if (Age > 30)
            {
                Salary += Salary * persentage / 100;
            }
            else
            {
                Salary += Salary * persentage / 200;
            }
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
    }
}
