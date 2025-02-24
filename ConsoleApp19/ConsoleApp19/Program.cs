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
            int skullTouched = 0;
            while(true)
            {
                if(x == 0 && y == 3)
                {
                    Console.WriteLine("해골더미가 있다. ");
                    Console.WriteLine($"현재 위치: x{x}, y{y}");
                    Console.WriteLine("어떡게 할까?(1. 전진한다, 2.왼쪽으로 간다. 3. 오른쪽으로 간다. 4. 후진한다. 5.해골을 만진다.");
                }
                else
                {
                    Console.WriteLine($"현재 위치: x{x}, y{y}");
                    Console.WriteLine("어떡게 할까?(1. 전진한다, 2.왼쪽으로 간다. 3. 오른쪽으로 간다. 4. 후진한다.");
                }                
                Console.Write("명령어를 입력해 주세요: ");
                input = Console.ReadLine();
                if(input == "1")
                {
                    if(y >= 3)
                    {
                        Console.WriteLine("앞이 막혀있어서 더이상 진행할 수 없습니다.");
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine("앞으로 나아갑니다.");
                        Console.WriteLine();

                        y++;
                    }
                }
                if (input == "2")
                {
                    if (y >= 3)
                    {
                        Console.WriteLine("앞이 막혀있어서 더이상 진행할 수 없습니다.");
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine("앞으로 나아갑니다.");
                        Console.WriteLine();
                        y++;
                    }
                }
                if (input == "3")
                {
                    if (y >= 3)
                    {
                        Console.WriteLine("앞이 막혀있어서 더이상 진행할 수 없습니다.");
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine("앞으로 나아갑니다.");
                        Console.WriteLine();

                        y++;
                    }
                }
                if (input == "4")
                {
                    if (y <= 0)
                    {
                        Console.WriteLine("뒤가 막혀있어서 더이상 진행할 수 없습니다.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("뒤로 돌아갑니다. 나아갑니다.");
                        Console.WriteLine();
                        y++;
                    }
                }
                if (input == "5")
                {
                    if (x == 0 && y == 3)
                    {
                        Console.WriteLine("해골을 만집니다.");
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine("잘못된 명령어 입니다.");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 명령어 입니다.");
                    Console.WriteLine();

                }
            }

        }
    }
}
