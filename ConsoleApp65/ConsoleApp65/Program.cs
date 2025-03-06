using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp65
{
    class Warrior
    {
        public string name { get; set; }
        public int score { get; set; }
        public int strength { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior();
            warrior.name = "babarian";
            warrior.score = 79;
            warrior.strength = 12;

            Console.WriteLine($"Warrior's name : {warrior.name}");
            Console.WriteLine($"Warrior's score : {warrior.score}");
            Console.WriteLine($"Warrior's strength : {warrior.strength}");
        }
    }
}
