using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp76
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fruits = { "apple", "banana", "blueberry", "cherry", "apricot" };

            var groups = fruits.GroupBy(f => f[0]);

            foreach(var group in groups)
            {
                Console.WriteLine($"Key : {group.Key}");

                foreach(var item in group)
                {
                    Console.WriteLine($"{item}");
                }
            }
        }
    }
}
