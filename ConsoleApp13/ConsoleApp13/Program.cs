using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            int b = 3;
            b++;
            Console.WriteLine(b); // 4
            --b; // 3
            Console.WriteLine(b); // 3
            Console.WriteLine(++b); // 4되고 출력,
            Console.WriteLine(b++); // 출력되고 5
            Console.WriteLine(b); // 5
        }
    }
}
