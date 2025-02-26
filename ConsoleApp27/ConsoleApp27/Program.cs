using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp27
{
    class Program
    {
        static void Main(string[] args)
        {
            // 좌표
            // 화면 크기 설정
            int windowWidth = 80;
            int windowHeight = 25;

            Console.SetWindowSize(windowWidth, windowHeight);
            Console.SetBufferSize(windowWidth, windowHeight);

            Console.WriteLine("콘솔 창 크기가 80x25로 설정되었습니다.");

            Console.CursorVisible = false; // 커서 숨기기

            Console.Clear();
            Console.SetCursorPosition(40, 12);
            Console.WriteLine("-!-");

            Console.Clear();
            Console.SetCursorPosition(0, 0);
            //━━
            Console.Write("┏");
            Console.SetCursorPosition(1, 0);
            for(int i = 0; i < windowWidth - 2; i++)
            {
                Console.Write("━");
            }
            Console.Write("┓");
            for(int i = 1; i< windowHeight-15; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("┃");
                for (int j = 0; j < windowWidth - 2; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("┃");
            }

            Thread.Sleep(3000);

            Console.Clear();
            for(int x = 0; x < 30; x++)
            {
                Console.Clear();
                Console.SetCursorPosition(x, 10);
                Console.Write("◎");
                Thread.Sleep(100);
            }
            


        }
    }
}
