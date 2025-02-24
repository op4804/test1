using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 3;
            int sum = a + b;
            bool isEqual = a == b;
            int cha = a - b;
            int times = a * b;
            int devide = a / b;
            int namugee = a % b;

            Console.WriteLine($"a: {a} b: {b}");
            Console.WriteLine($"a와 b의 합: {sum}");
            Console.WriteLine($"a와 b가 같다: {isEqual}");
            Console.WriteLine($"a와 b의 차: {cha}");
            Console.WriteLine($"a와 b의 곱: {times}");
            Console.WriteLine($"a와 b의 나눔: {devide}");
            Console.WriteLine($"a와 b의 나머지: {namugee}");

        }
    }
}
