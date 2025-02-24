using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("이진수 입력: ");
            string binaryInput = Console.ReadLine();
            int decimalValue = Convert.ToInt32(binaryInput, 2);

            Console.WriteLine($"이진수: {binaryInput}");
            Console.WriteLine($"10진수 :{decimalValue}");
        }
    }
}
