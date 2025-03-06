using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp92
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            Increase(ref a);
            Console.WriteLine(a);

            int x, y;
            int b = 20;
            OutFunc(a, b, out x, out y);
            Console.WriteLine(x + " " + y);
        }

        static void Increase(ref int x)
        {
            x++;
        }

        static void OutFunc(int a, int b, out int x, out int y)
        {
            x = a;
            y = b;
        }
    }
}
