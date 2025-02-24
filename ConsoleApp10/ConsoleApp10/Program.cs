using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 5;
            bool flag = true;

            Console.WriteLine(+num);
            Console.WriteLine(-num);

            Console.WriteLine(!flag);

            int num2 = 10; // 4바이트 0000 0101 8비트가 1바이트
            // 0000 0000 0000 0000 0000 0000 0000 0000
            // 0000 0000 0000 0000 0000 0000 0000 0101 을 반전해서
            // 1111 ... 1111 1010 으로 전환.
            int result = ~num2;

            Console.WriteLine("원래 값: " + num2);
            Console.WriteLine("~연산자 적용 후: " + result);


        }
    }
}
