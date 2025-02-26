using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"숫자 : {i}");
            }

            /*
            for (; ; )
            {
                Console.WriteLine("무한 반복");
            }
            */

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            int sum = default;
            for (int i = 1; i < 11; i++)
            {
                sum += i;
            }
            Console.WriteLine(sum);

            int count = 1;

            while(count <= 5)
            {
                Console.WriteLine($"count: {count}");
                count++;

                if(count == 3)
                {
                    Console.WriteLine("check point!");
                }
            }
        }
    }
}
