using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0, y = 0;
            string input = default;
            bool isSkullCrashed = false;
            bool isKeyGet = false;
            int skullTouched = 0;

            Console.WriteLine();
            Console.WriteLine("영문도 모른 채 어딘가에서 깨어난 당신.");
            Console.WriteLine("눈앞에 펼처진건 게임에서나 보던 던전인 것 같다.");
            Console.WriteLine("말도 안 되는 억지지만 당신은 여기서 탈출할 수 있을까?");
            Console.WriteLine();

            while (true)
            {
                if(x == 0 && y == 2)
                {
                    if (isSkullCrashed)
                    {
                        Console.WriteLine();
                        Console.WriteLine("부서진 해골이 있습니다.");
                        Console.WriteLine("반쯤 부서진 두개골 안으로 당신을 저주하는 눈빛이 느껴집니다.");
                        Console.WriteLine();
                        Console.WriteLine($"현재 위치: x{x}, y{y}");
                        Console.WriteLine("어떻게 할까?(1.북쪽으로 간다, 2.서쪽으로 간다, 3.동쪽으로 간다, 4.남쪽으로 간다.");
                    }
                    else if(isKeyGet)
                    {
                        Console.WriteLine();
                        Console.WriteLine("해골이 있습니다. 당신에게 열쇠를 준 고마운 녀석입니다.");
                        Console.WriteLine();
                        Console.WriteLine($"현재 위치: x{x}, y{y}");
                        Console.WriteLine("어떻게 할까?(1.북쪽으로 간다, 2.서쪽으로 간다, 3.동쪽으로 간다, 4.남쪽으로 간다, 5.해골을 만진다.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("해골이 있습니다.");
                        Console.WriteLine();
                        Console.WriteLine($"현재 위치: x{x}, y{y}");
                        Console.WriteLine("어떻게 할까?(1.북쪽으로 간다, 2.서쪽으로 간다, 3.동쪽으로 간다. 4.남쪽으로 간다, 5.해골을 만진다.");
                    }
                }
                else if(x == 2 && y == 2)
                {
                    if (isKeyGet)
                    {
                        Console.WriteLine();
                        Console.WriteLine("굳게 잠겨진 문이 있습니다. 이게 탈출구인걸까요?");
                        Console.WriteLine();
                        Console.WriteLine($"현재 위치: x{x}, y{y}");
                        Console.WriteLine("어떻게 할까?(1.북쪽으로 간다, 2.서쪽으로 간다, 3.동쪽으로 간다, 4.남쪽으로 간다, 5.문을 연다.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("굳게 잠겨진 문이 있습니다. 이게 탈출구인걸까요?");
                        Console.WriteLine();
                        Console.WriteLine($"현재 위치: x{x}, y{y}");
                        Console.WriteLine("어떻게 할까?(1.북쪽으로 간다, 2.서쪽으로 간다, 3.동쪽으로 간다, 4.남쪽으로 간다, 5.문을 두드린다.");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"현재 위치: x{x}, y{y}");
                    Console.WriteLine("어떻게 할까?(1.북쪽으로 간다, 2.서쪽으로 간다. 3. 동쪽으로 간다. 4. 남쪽으로 간다.");
                }
                // 입력 부
                Console.Write("명령어를 입력해 주세요: ");
                input = Console.ReadLine();
                if(input == "1")
                {
                    if(y >= 2 || (x == 1 && y == 1))
                    {
                        Console.WriteLine();
                        Console.WriteLine("길이 막혀있어서 더이상 진행할 수 없습니다.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("북쪽으로 나아갑니다.");
                        Console.WriteLine();
                        y++;
                    }
                }
                else if (input == "2")
                {
                    if (x <= 0 ||(x == 0 && y == 0))
                    {
                        Console.WriteLine();
                        Console.WriteLine("길이 막혀있어서 더이상 진행할 수 없습니다.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("서쪽으로 나아갑니다.");
                        Console.WriteLine();
                        x--;
                    }
                }
                else if (input == "3")
                {
                    if (x >= 2 || (x == 0 && y == 0) || (x == 0 && y == 2))
                    {
                        Console.WriteLine();
                        Console.WriteLine("길이 막혀있어서 더이상 진행할 수 없습니다.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("동쪽으로 나아갑니다.");
                        Console.WriteLine();
                        x++;
                    }
                }
                else if (input == "4")
                {
                    if (y <= 0 || (x == 1 && y == 1) || (x == 2 && y == 1))
                    {
                        Console.WriteLine();
                        Console.WriteLine("길이 막혀있어서 더이상 진행할 수 없습니다.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("남쪽으로 나아갑니다.");
                        Console.WriteLine();
                        y--;
                    }
                }
                else if (input == "5")
                {
                    if (x == 0 && y == 2)
                    {
                        if(isKeyGet && skullTouched == 3)
                        {
                            Console.WriteLine();
                            Console.WriteLine("해골을 만집니다. 순간 해골이 전부 뿌서졌습니다. 왜그러셨나요?");
                            Console.WriteLine();
                            isSkullCrashed = true;
                        }
                        else if (isKeyGet)
                        {
                            Console.WriteLine();
                            Console.WriteLine("해골을 만집니다. 아무일도 일어나지 않습니다.");
                            Console.WriteLine();
                            skullTouched++;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("해골을 만집니다. 순간 해골의 손이 펴집니다. 안에 열쇠가 들어있습니다.");
                            Console.WriteLine("열쇠를 얻었습니다.");
                            Console.WriteLine();
                            isKeyGet = true;
                            skullTouched++;
                        }                     
                    }
                    else if (x == 2 && y == 2)
                    {
                        if (isKeyGet)
                        {
                            Console.Clear();
                            Console.WriteLine();                            
                            Console.WriteLine("문에 열쇠를 넣어봅니다.");
                            System.Threading.Thread.Sleep(800);
                            Console.WriteLine("딱 알맞게 들어갑니다.");
                            System.Threading.Thread.Sleep(800);
                            Console.WriteLine("열쇠를 돌리자 문이 열리고 틈사이로 빛이 쏟아집니다.");
                            System.Threading.Thread.Sleep(800);
                            Console.WriteLine("이게 끝인걸까요? 애석하게도 이번 이야기는 여기서 끝입니다.");
                            System.Threading.Thread.Sleep(800);
                            Console.WriteLine();
                            Console.WriteLine("플레이 해주셔서 감사합니다.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("똑똑. \"거기 누구 계세요? \"");
                            Console.WriteLine("당신은 문에 노크를 해봤습니다.");
                            Console.WriteLine("바보도 아니고 탈출구에 노크하는사람이 다 있네요.");
                            Console.WriteLine("당연하게도 아무일도 일어나지 않았습니다.");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("잘못된 명령어 입니다.");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("잘못된 명령어 입니다.");
                    Console.WriteLine();
                }
            }

        }
    }
}
