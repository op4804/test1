using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp72
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "thada", "baboou", "eleleh" };

            var upperWords = words.Select(w => w.ToUpper());

            foreach (string word in upperWords)
            {
                Console.WriteLine(word);
            }

            int[] data = { 1, 2, 3, 4, 5 };
            int sum = 0;

            foreach (var d in data)
            {
                sum += d;

            }

            Console.WriteLine($"Sum : {sum}");

            int count = data.Length;  //개수

            Console.WriteLine($"Cout : {count}");

            float[] data2 = { 80, 76, 65 };
            double avg = data2.Average();
            Console.WriteLine($"Average: {avg:F2}");

            int[] data3 = { 55, 76, 65 };
            int max = data3.Max();

            Console.WriteLine($"Max :  {max}");

            int min = data3.Min();

            Console.WriteLine($"Min : {min}");

        }
    }
}
