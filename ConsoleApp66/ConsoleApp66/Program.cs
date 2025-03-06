using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp66
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("숫자를 입력해 주세요: ");
                string input = Console.ReadLine();
                try
                {
                    Console.WriteLine(int.Parse(input));
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"올바른 숫자를 입력하세요!");
                }
            }


        }
    }
}
