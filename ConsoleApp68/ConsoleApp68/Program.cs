using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp68
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine($"Upper: {input.ToUpper()}");
            Console.WriteLine($"Replace: {input.Replace("C#", "CSharp")}");
            Console.WriteLine($"string length: {input.Length}");

        }
    }
}
