using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp47
{
    class Person
    {
        public string name;
        public int age;

        public Person()
        {
            name = "이름 없음";
            age = 20;
        }

        public Person(string _name, int _age)
        {
            this.name = _name;
            this.age = _age;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름: {name}");
            Console.WriteLine($"나이: {age}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.name = "이사야";

            p1.ShowInfo();

            Person p2 = new Person("박민수", 32);
            p2.ShowInfo();
        }
    }
}
