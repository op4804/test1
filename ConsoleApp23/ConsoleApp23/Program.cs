using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int randomnumber;

            while (true)
            {
                randomnumber = rand.Next(1,101);

                if (randomnumber > 90)
                {
                    Console.WriteLine("SSS등급 도끼 획득!!!");
                }
                else if(randomnumber > 50)
                {
                    Console.WriteLine("SS등급 도끼 획득!!");
                }
                else
                {
                    Console.WriteLine("S등급 도끼 획득!");
                }
                Console.ReadLine();
            }


        }
    }
}
