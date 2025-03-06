using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp90
{
    class Person
    {
        public string name { get; set; }

        public int age { get; set; }

        public Person()
        {
            this.name = "Unknown";
            this.age = -1;
        }
        public Person(string name)
        {
            this.name = name;
            this.age = -1;

        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void Print()
        {
            Console.WriteLine(this.name + ", " + this.age);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Person p1 = new Person();
            Person p2 = new Person("Katarina");
            Person p3 = new Person("Bob", 32);

            p1.Print();
            p2.Print();
            p3.Print();

            

        }
    }
}
