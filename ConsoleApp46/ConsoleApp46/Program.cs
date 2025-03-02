using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;

            Console.WriteLine($"current time: {now}");

            TimeSpan duration = new TimeSpan(1, 30, 0);
            Console.WriteLine($"duration : {duration}");
        }
    }
}
