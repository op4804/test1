using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 85;

            if(score >= 90)
            {
                Console.WriteLine("A 학점");
            }
            else
            {
                Console.WriteLine("B 학점");
            }

            Console.WriteLine("조건문 종료");

            string gameId = "아냐";
            if(gameId == "아냐")
            {
                Console.WriteLine("아이디 일치");
            }
            else
            {
                Console.WriteLine("아이디 불일치");
            }

            int newScore = 60;

            if (newScore >= 90)
            {
                Console.WriteLine("A 학점");
            }
            else if (newScore >= 80)
            {
                Console.WriteLine("B 학점");
            }
            else if (newScore >= 70)
            {
                Console.WriteLine("C 학점");
            }
            else
            {
                Console.WriteLine("F 학점");
            }
        }
    }
}
