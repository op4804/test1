using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp89
{
    class Person
    {
        public string name;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.name = "Alice";
            Console.WriteLine(p.name);
        }
    }
}
