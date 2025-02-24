using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            a += 5;
            Console.WriteLine(a); // a = 15
            a -= 5;
            Console.WriteLine(a); // a = 10
            a *= 5;
            Console.WriteLine(a); // a = 50
            a /= 5;
            Console.WriteLine(a); // a = 10
            a %= 5;
            Console.WriteLine(a); // a = 0


        }
    }
}
