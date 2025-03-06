using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp57
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterations = 100000;
            string text = "";

            Stopwatch sw = Stopwatch.StartNew();            

            for(int i = 0; i < iterations; i++)
            {
                text += "a";
            }

            sw.Stop();
            Console.WriteLine($"String: {sw.ElapsedMilliseconds}ms");

            StringBuilder sb = new StringBuilder();

            sw.Restart();
            for (int i = 0; i < iterations; i++)
            {
                sb.Append("a");
            }

            sw.Stop();
            Console.WriteLine($"String: {sw.ElapsedMilliseconds}ms");
        }
    }
}
