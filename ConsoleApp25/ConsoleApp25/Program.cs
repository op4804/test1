using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp25
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int pMoney = default;
            string input = default;
            int num = default;
            int randNum = default;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("-------대장장이 키우기-------");
                Console.WriteLine($"현재 소지금 : {pMoney}");
                Console.WriteLine("1. 나무 캐기");
                Console.WriteLine("2. 장비 뽑기");
                Console.WriteLine("3. 나가기");
                Console.Write("입력: ");

                input = Console.ReadLine();
                num = int.Parse(input);

                switch (num)
                {
                    case 1:
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("나가시려면 x를 입력해주세요");
                            Console.WriteLine($"현재 소지금 : {pMoney}");
                            input = Console.ReadLine();
                            if (input == "x")
                            {
                                break;
                            }
                            pMoney += 100;
                        }
                        break;
                    case 2:
                        Console.WriteLine("나가시려면 x를 입력해주세요");
                        
                        while (true)
                        {                            
                            input = Console.ReadLine();
                            Console.WriteLine($"현재 소지금 : {pMoney}");
                            if (input == "x")
                            {
                                break;
                            }
                            if (pMoney < 100)
                            {
                                Console.WriteLine("돈이 부족합니다.");
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                randNum = rand.Next(1, 101);
                                if (randNum > 95)
                                {
                                    Console.WriteLine("SSS등급 도끼 획득!!!");
                                }
                                else if (randNum > 85)
                                {
                                    Console.WriteLine("SS등급 도끼 획득!!");
                                }
                                else if (randNum > 70)
                                {
                                    Console.WriteLine("S등급 도끼 획득!");
                                }
                                else if (randNum > 45)
                                {
                                    Console.WriteLine("A등급 도끼 획득");
                                }
                                else
                                {
                                    Console.WriteLine("F등급 도끼 획득...");
                                }
                                pMoney -= 100;
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("시스템 종료");
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. ");
                        Console.ReadLine();
                        break;
                }

            }

        }
    }
}
