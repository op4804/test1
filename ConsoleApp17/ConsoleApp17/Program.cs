using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("돈을 주면 금액에 맞는 검을 드립니다.");
            Console.Write("소지금을 입력해 주세요: ");
            string input = Console.ReadLine();

            string characterName = "멋사 검존";
            int swordDamage = default;
            string yourSword = default;

            if (Int32.Parse(input) > 600)
            {
                yourSword = "전설의 검";
                swordDamage = 7;
            }
            else if (Int32.Parse(input) > 500)
            {
                yourSword = "유령검";
                swordDamage = 6;
            }
            else if (Int32.Parse(input) > 400)
            {
                yourSword = "엑스칼리버";
                swordDamage = 5;
            }
            else if (Int32.Parse(input) > 300)
            {
                yourSword = "집판검";
                swordDamage = 4;
            }
            else if (Int32.Parse(input) > 200)
            {
                yourSword = "집행검";
                swordDamage = 3;
            }
            else if (Int32.Parse(input) > 100)
            {
                yourSword = "카타나";
                swordDamage = 2;
            }
            else
            {
                yourSword = "무한의 대검";
                swordDamage = 1;
            }
            Console.WriteLine($"{yourSword} (을)를 획득하셨습니다!");

            

            Console.WriteLine();
            Console.WriteLine("현재 스테이터스");
            Console.WriteLine($"이름 : {characterName}");
            Console.WriteLine($"공격력 : 100 + {swordDamage}");



        }
    }
}
