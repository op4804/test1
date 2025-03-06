using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp69
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var evens = numbers.Where(n => n % 2 == 0);

            int sum = numbers.Sum();

            foreach (int even in evens)
            {
                Console.WriteLine(even);
            }
            Console.WriteLine($"sum : {sum}");
        }
    }
}
