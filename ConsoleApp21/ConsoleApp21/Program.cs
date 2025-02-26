using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    class Program
    {
        static void Main(string[] args)
        {
            int character = default;

            Console.Write("캐릭터를 선택해 주세요(1. 검사 2. 마법사 3. 도적): ");
            string input = Console.ReadLine();
            character = int.Parse(input);

            switch (character)
            {
                case 1:
                    Console.WriteLine("공격력 100 방어력 90");
                    break;
                case 2:
                    Console.WriteLine("마법사 110 방어력 80");
                    break;
                case 3:
                    Console.WriteLine("도적 공격력 115 방어력 70");
                    break;
                default:
                    Console.WriteLine("유효한 캐릭터가 아닙니다. ");
                    break;
            }
        }
    }
}
