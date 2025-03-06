using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp71
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] nums = { 5, 8, 6, 3, 1 };

            var sortedMethod = nums.OrderBy(n => n);

            var sortedQuery = from n in nums
                              orderby n
                              select n;

            Console.WriteLine("Method syntax");

            foreach(var n in sortedMethod)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("Query syntax");

            foreach(var n in sortedQuery)
            {
                Console.WriteLine(n);

            }


        }
    }
}
