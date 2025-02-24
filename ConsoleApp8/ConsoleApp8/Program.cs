using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            int defaultInt = default;
            string defaultString = default;
            bool defaultBool = default;

            Console.WriteLine($"정수 기본값{defaultInt}");
            Console.WriteLine($"문자열 기본값{defaultString}");
            Console.WriteLine($"논리 기본값{defaultBool}");


        }
    }
}
