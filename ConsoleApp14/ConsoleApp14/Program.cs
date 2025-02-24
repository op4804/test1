using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 5;
            int y = 10;

            Console.WriteLine($"x: {x}, y: {y}");
            Console.WriteLine($"x == y : {x == y}");
            Console.WriteLine($"x != y : {x != y}");
            Console.WriteLine($"x < y : {x < y}");
            Console.WriteLine($"x > y : {x > y}");
            Console.WriteLine($"x <= y : {x <= y}");
            Console.WriteLine($"x >= y : {x >= y}");
            Console.WriteLine();

            bool a = true;
            bool b = false;

            Console.WriteLine($"a: {a}, b: {b}");
            Console.WriteLine($"a && b : {a && b}");
            Console.WriteLine($"a || b : {a || b}");
            Console.WriteLine($"!a : {!a}");
            Console.WriteLine();

            int c = 5; // 0101
            int d = 3; // 0011

            Console.WriteLine($"c: {c}, d: {d} 이진 c: {Convert.ToString(c,2)}, d: {Convert.ToString(d,2)}" );
            Console.WriteLine($"c & d: {c & d} 이진 c & d: {Convert.ToString(c & d, 2)}");
            Console.WriteLine($"c | d: {c | d} 이진 c | d: {Convert.ToString(c | d, 2)}");
            Console.WriteLine($"c & d: {c ^ d} 이진 c ^ d: {Convert.ToString(c ^ d, 2)}");
            Console.WriteLine($"~c: {~c} 이진 ~c: {Convert.ToString(~c, 2)}");
            Console.WriteLine();

            int value = 4;
            Console.WriteLine($"value: {value} 이진 c: {Convert.ToString(value, 2)}");
            Console.WriteLine($"value << 1: {value << 1} 이진 c: {Convert.ToString(value << 1, 2)}");
            Console.WriteLine($"value >> 1: {value >> 1} 이진 c: {Convert.ToString(value >> 1, 2)}");





        }
    }
}
