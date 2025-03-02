using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    class Program
    {
        static void PrintHelloWorld()
        {
            Console.WriteLine("Hello World!");
        }

        static void PrintWord(string str)
        {
            Console.WriteLine(str);
        }

        static int GetNumber()
        {
            return 42;
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        static void Greet(string name = "손")
        {
            Console.WriteLine($"안녕하세요 {name}님");
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }
        
        static double Multiply(double a, double b)
        {
            return a * b;
        }

        // out 키워드
        static void Devide(int a, int b, out int quotient, out int remainder)
        {
            quotient = a / b;
            remainder = a % b;
        }

        static void Increase(ref int num)
        {
            num += 10;
        }

        static int Sum(params int[] numbers)
        {
            int total = 0;

            foreach(int num in numbers)
            {
                total += num;
            }
            return total;
        }
        static int Factorial(int n)
        {
            if(n <= 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        static void Main(string[] args)
        {
            PrintHelloWorld();
            PrintWord("hi");
            Console.WriteLine($"{42 + GetNumber()}");
            Console.WriteLine($"{Add(32, 64)}");
            Greet();
            Greet("철수");

            Console.WriteLine(Multiply(3, 4));
            Console.WriteLine(Multiply(3.32, 4.23));

            int q;
            int r;
            Devide(5, 3, out q, out r);

            Console.WriteLine($"몫: {q}, 나머지: {r}");

            int bns = 10;

            Console.WriteLine($"{bns}");
            Increase(ref bns);
            Console.WriteLine($"{bns}");

            Console.WriteLine(Sum(1, 2, 3));   
            Console.WriteLine(Sum(1, 2, 3, 4, 5, 6, 7, 8, 9));

            Console.WriteLine(Factorial(4));

        }
    }
}
