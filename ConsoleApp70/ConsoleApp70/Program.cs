using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp70
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Chalie", "Bob", "Alice" };

            var sortedNames = names.OrderBy(n => n);

            foreach (var name in sortedNames)
            {
                Console.WriteLine(name);
            }

            var firstLetter = names.First(n => n.StartsWith("A"));

            Console.WriteLine(firstLetter);
        }
    }
}
