using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            int? nullableInt = null;

            Console.WriteLine(nullableInt.HasValue ? nullableInt.Value.ToString() : "No value");

            nullableInt = 10;

            Console.WriteLine(nullableInt.HasValue ? nullableInt.Value.ToString() : "No value");


            // null 값을 다루는 연산자

            string str = null;

            Console.WriteLine(str ?? "DefaultValue");

            str = "Hello";

            Console.WriteLine(str?.Length); // str이 null이 아니면 길이 출력
        }
    }
}
