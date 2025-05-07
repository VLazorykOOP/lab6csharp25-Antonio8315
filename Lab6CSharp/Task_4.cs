using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_4
{
    public class Task_4
    {
        class Person
        {
            public string name, surname;
            public uint age;

            public Person(string name1, string surname1, uint age1)
            {
                name = name1;
                surname = surname1;
                age = age1;
            }

            public virtual string Show()
            {
                return $"Ім'я: {name} Прізвище: {surname} Вік: {age}";
            }
        }

        class Employee : Person
        {
            public float salary;

            public Employee(string name1, string surname1, uint age1, float salary1)
                : base(name1, surname1, age1)
            {
                salary = salary1;
            }

            public override string Show()
            {
                return base.Show() + $" Зарплата: {salary}";
            }
        }

        class Worker : Person
        {
            public string typeOfWork;

            public Worker(string name1, string surname1, uint age1, string typeOfWork1)
                : base(name1, surname1, age1)
            {
                typeOfWork = typeOfWork1;
            }

            public override string Show()
            {
                return base.Show() + $" Професія: {typeOfWork}";
            }
        }

        class Engineer : Person
        {
            public float experience;

            public Engineer(string name1, string surname1, uint age1, uint experience1)
                : base(name1, surname1, age1)
            {
                experience = experience1;
            }

            public override string Show()
            {
                return base.Show() + $" Досвід: {experience}";
            }
        }

        // Клас Team підтримує foreach
        class Team : IEnumerable<Person>
        {
            private List<Person> members = new List<Person>();

            public void AddMember(Person p) => members.Add(p);

            public IEnumerator<Person> GetEnumerator() => members.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public void main4()
        {
            Team team = new Team();
            team.AddMember(new Person("Антон", "Берегій", 19));
            team.AddMember(new Employee("Богдан", "Богданенко", 19, 10000));
            team.AddMember(new Worker("Василь", "Василенко", 30, "Сантехнік"));
            team.AddMember(new Engineer("хз хто", "хз хто", 30, 10));

            Console.WriteLine("Список учасників команди:");
            foreach (var member in team)
            {
                Console.WriteLine(member.Show());
            }
        }
    }
}
