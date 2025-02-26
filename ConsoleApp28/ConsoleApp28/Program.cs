using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {

            string horse1 = "                   *@*=";
            string horse2 = "                   ;@@@@=";
            string horse3 = "                 -#@@@@@@~";
            string horse4 = "                 -*@@@=~*@";
            string horse5 = "       ,,,,;#-,,,!@@@@   ;";
            string horse6 = "      =@!:@@@@@@@@@@@@";
            string horse7 = "    -@@* @@@@@@@@@@@@@";
            string horse8 = "    @:~  @@@@@@@@@@@@@";
            string horse9 = "         @@@@@#@@@@@@*";
            string horse10 = "        @@ @@=....@*. @*";
            string horse11 = "      :=! ,@*     @;  ~*~";
            string horse12 = "      @:  -#      @:   .@";
            string horse13 = "     -@    ;!    !:     !:";
            string horse14 = "     ;      .#.~#;       $.";

            string horse10_2 = "        @@@@=  ...@*.@*";
            string horse11_2 = "       :=!,@*     @; ~*~";
            string horse12_2 = "       @:-#         @: @";
            string horse13_2 = "       -@ ;!        !: !:";
            string horse14_2 = "       ; .#.         ~# $.";


            int windowWidth = 120;
            int windowHeight = 25;

            Console.SetWindowSize(windowWidth, windowHeight);
            Console.SetBufferSize(windowWidth, windowHeight);            

            string input = default;
            int result = 0;

            while(true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 18);
                Console.WriteLine("경마장에 온 당신 무엇을 할까?");
                Console.Write("번호를 입력해 주세요(1. 경마를 즐긴다 / 2. 나간다.):");
                input = Console.ReadLine();
                if (int.TryParse(input, out result))
                {
                    if (result == 1 || result == 2)
                    {
                        if(result == 1)
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.SetCursorPosition(0, 18);
                                Console.WriteLine("몇번말의 우승에 걸까?");
                                Console.Write("번호를 입력해 주세요(1 ~ 9) (나가시려면 x를 입력해 주세요): ");
                                input = Console.ReadLine();
                                if(input == "x")
                                {
                                    break;
                                }
                                if (int.TryParse(input, out result))
                                {
                                    if (result > 0 && result < 10)
                                    {
                                        for (int i = 0; i < 85; i += 1)
                                        {
                                            Console.Clear();
                                            Console.SetCursorPosition(i, 4);
                                            Console.Write(horse1);
                                            Console.SetCursorPosition(i, 5);
                                            Console.Write(horse2);
                                            Console.SetCursorPosition(i, 6);
                                            Console.Write(horse3);
                                            Console.SetCursorPosition(i, 7);
                                            Console.Write(horse4);
                                            Console.SetCursorPosition(i, 8);
                                            Console.Write(horse5);
                                            Console.SetCursorPosition(i, 9);
                                            Console.Write(horse6);
                                            Console.SetCursorPosition(i, 10);
                                            Console.Write(horse7);
                                            Console.SetCursorPosition(i, 11);
                                            Console.Write(horse8);
                                            Console.SetCursorPosition(i, 12);
                                            Console.Write(horse9);
                                            if (i % 3 != 0)
                                            {
                                                Console.SetCursorPosition(i, 13);
                                                Console.Write(horse10);
                                                Console.SetCursorPosition(i, 14);
                                                Console.Write(horse11);
                                                Console.SetCursorPosition(i, 15);
                                                Console.Write(horse12);
                                                Console.SetCursorPosition(i, 16);
                                                Console.Write(horse13);
                                                Console.SetCursorPosition(i, 17);
                                                Console.Write(horse14);
                                                Console.SetCursorPosition(0, 18);
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(i, 13);
                                                Console.Write(horse10_2);
                                                Console.SetCursorPosition(i, 14);
                                                Console.Write(horse11_2);
                                                Console.SetCursorPosition(i, 15);
                                                Console.Write(horse12_2);
                                                Console.SetCursorPosition(i, 16);
                                                Console.Write(horse13_2);
                                                Console.SetCursorPosition(i, 17);
                                                Console.Write(horse14_2);
                                                Console.SetCursorPosition(0, 18);
                                            }
                                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                                            Console.WriteLine($"말들이 말들이 달리는중! 당신이 고른 말은 {result}번 말입니다!");
                                            Thread.Sleep(90);
                                        }
                                        Console.Clear();
                                        Random rand = new Random();
                                        int winNum = rand.Next(1, 10);
                                        if(winNum == result)
                                        {
                                            Console.SetCursorPosition(0, 18);
                                            Console.WriteLine("당신이 고른 말이 우승했습니다!!!");                                               
                                            Console.WriteLine("당신은 건 돈의 20배를 땄습니다 와우ㅡ! 한턱 쏘셔야 겠는걸요?");
                                            Console.WriteLine("한번 더 도전해 봅시다!");
                                            Console.ReadLine();

                                        }
                                        else
                                        {
                                            int loseNum = rand.Next(2, 10);
                                            Console.SetCursorPosition(0, 18);
                                            Console.WriteLine("당신이 고른 말은 우승하지 못했습니다..");
                                            Console.WriteLine($"당신이 고른 말의 최종 성적은 {loseNum}착 입니다.");
                                            Console.WriteLine("당신의 마권은 휴지조각이 되어버렸습니다.");
                                            Console.WriteLine("한번 더 도전해 봅시다!");
                                            Console.ReadLine();
                                        }                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("잘못된 번호입력!");
                                        Thread.Sleep(500);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("잘못된 문자 입력!");
                                    Console.WriteLine("숫자를 입력해 주세요!");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("안녕히 가세요!");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 번호입력!");
                    }
                }                
                //Console.CursorVisible = false; // 커서 숨기기
            }


         
        }
    }
            
}
