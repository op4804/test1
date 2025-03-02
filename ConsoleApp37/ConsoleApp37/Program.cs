using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmptySpace
{
    class MyClass
    {
        public static void SayHello()
        {
            Console.WriteLine("안녕하세요 !MyNamespace의 MyClass입니다.");
        }    
    }
}

namespace ConsoleApp37
{
    class Program
    {
        static void SayHello()
        {
            Console.WriteLine("hi");
        }

        // 화살표 함수 중괄호와 리턴 생략

        static int AddArrow(int a, int b) => a + b;

        static void PrintMessageArrow() => Console.WriteLine("Hello");

        static void Main(string[] args)
        {
            SayHello();
            EmptySpace.MyClass.SayHello();

            Console.WriteLine(AddArrow(3, 5));

            PrintMessageArrow();
        }
    }
}
