using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp77
{

    class Animal
    {
        public string name { get; set; }

        public void Eat()
        {
            Console.WriteLine($"{name}이(가) 음식을 먹고 있습니다. ");
        }
    }

    class Dog : Animal
    {

        public void Bark()
        {
            Console.WriteLine($"{name}이(가) 짖습니다. ");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dog mydog = new Dog();
            mydog.name = "바둑이";
            mydog.Eat();
            mydog.Bark();
        }
    }
}
