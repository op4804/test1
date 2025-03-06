using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp55
{
    class Program
    {
        static void Main(string[] args)
        {
            // 값 형식과 참조 형식
            // 값 형식은 스택에 저장되고 참조형식은 힙에 저장된다. 

            int valueType = 10;
            object referenceType = valueType; // (얕은 복사)

            valueType = 20;

            Console.WriteLine($"valueType: {valueType}");
            Console.WriteLine($"referenceType: {referenceType}");

            // 박싱 언박싱
            // 값 형식을 참조 형식으로 변환(박싱), 다시 값 형식으로 변환(언박싱)

            int value = 42;
            object boxed = value; // 박싱
            int unboxed = (int)boxed; // 언박싱

            Console.WriteLine($"Boxed : {boxed}, Unboxed : {unboxed}");

            // is 연산자

            object obj = "Hello";

            Console.WriteLine(obj is string);
            Console.WriteLine(obj is int);

            object obj2 = "Hello";
            string str = obj2 as string;

            Console.WriteLine(obj2 is string);
            Console.WriteLine(obj2 is int);

            Console.WriteLine(str);

            object obj3 = "3123";

            if(obj3 is int number)
            {
                Console.WriteLine($"Number : {number}");

            }
            else
            {
                Console.WriteLine("not a number");
            }




        }
    }
}
