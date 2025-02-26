using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp34
{
    class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }
        static void Main(string[] args)
        {

            int result = Add(10, 20);
            Console.WriteLine($"10 + 20 = {result}");
        }
    }
}
