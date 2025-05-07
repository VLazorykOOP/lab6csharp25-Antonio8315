using System;
using System.Security.Cryptography;
namespace Task_1
{
    public class Task_1
    {
        public interface IPerson
        {
            string Name { get; set; }
            string Surname { get; set; }
            uint Age { get; set; }

            string Show();
        }

        public class Person : IPerson, ICloneable
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public uint Age { get; set; }

            public Person(string name, string surname, uint age)
            {
                Name = name;
                Surname = surname;
                Age = age;
            }

            public virtual string Show()
            {
                return $"Ім'я: {Name} Прізвище: {Surname} Вік: {Age}";
            }

            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        public class Employee : Person, IComparable<Employee>
        {
            public float Salary { get; set; }

            public Employee(string name, string surname, uint age, float salary)
                : base(name, surname, age)
            {
                Salary = salary;
            }

            public override string Show()
            {
                return base.Show() + $" Зарплата: {Salary}";
            }

            public int CompareTo(Employee? other)
            {
                if (other == null) return 1;
                return Salary.CompareTo(other.Salary);
            }
        }

        public class Worker : Person
        {
            public string TypeOfWork { get; set; }

            public Worker(string name, string surname, uint age, string typeOfWork)
                : base(name, surname, age)
            {
                TypeOfWork = typeOfWork;
            }

            public override string Show()
            {
                return base.Show() + $" Професія: {TypeOfWork}";
            }
        }

        public class Engineer : Person, IDisposable
        {
            public float Experience { get; set; }

            public Engineer(string name, string surname, uint age, float experience)
                : base(name, surname, age)
            {
                Experience = experience;
            }

            public override string Show()
            {
                return base.Show() + $" Досвід: {Experience} років";
            }

            public void Dispose()
            {
                Console.WriteLine("Ресурси інженера звільнено.");
            }
        }



        public void main1()
        {
            IPerson person1 = new Person("Антон", "Берегій", 19);
            Console.WriteLine(person1.Show());

            Employee employee1 = new Employee("Богдан", "Богданенко", 19, 10000);
            Console.WriteLine(employee1.Show());

            Worker worker1 = new Worker("Василь", "Василенко", 30, "Сантехнік");
            Console.WriteLine(worker1.Show());

            using (Engineer engineer1 = new Engineer("Іван", "Іваненко", 30, 10))
            {
                Console.WriteLine(engineer1.Show());
            }
        }
    }
}