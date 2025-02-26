using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int x = 5;
            do
            {
                Console.WriteLine("최소 한번은 실행됩니다.");
                x--;
            } while (x > 0);

            // break;

            for(int i = 1; i < 10; i++)
            {
                if(i == 5)
                {
                    break;
                }
                Console.WriteLine(i);
            }

            for(int i = 0; i < 10; i++)
            {
                if(i % 2 == 0)
                {
                    continue;
                }

                Console.WriteLine(i);
            }

            int n = 1;

            start:
            if(n <= 5)
            {
                Console.WriteLine(n);
                n++;

                goto start;
            }
        

        }
    }
}
