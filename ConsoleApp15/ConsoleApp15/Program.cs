using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10; 
            int b = 20;

            int max;

            max = (a > b) ? a : b;

            Console.WriteLine(max);

            int result = default;
            result = 10 + 2 * 5;
            Console.WriteLine(result);
            result = (10 + 2) * 5;
            Console.WriteLine(result);
        }
    }
}
