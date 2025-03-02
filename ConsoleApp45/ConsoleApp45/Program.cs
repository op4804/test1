using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp45
{
    class Program
    {

        static void DrawStriker(int x, int y)
        {
            string[] striker = new string[]
{
                "  ▲  ",
                "↑※↑",
                "▲■▲",};

            for (int i = 0; i < striker.Length; i++)
            {
                Console.SetCursorPosition(x - 2, y + i);
                Console.Write(striker[i]);
            }
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo keyInfo;

            const int WINDOW_WIDTH = 60;
            const int WINDOW_HEIGHT = 40;
            Console.SetWindowSize(WINDOW_WIDTH + 1, WINDOW_HEIGHT);
            Console.SetBufferSize(WINDOW_WIDTH + 1, WINDOW_HEIGHT);
            Console.CursorVisible = false;

            int x = WINDOW_WIDTH / 2;
            int y = 30;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long prevSecond = stopwatch.ElapsedMilliseconds; // 1/1000초 (1000일때 1초)

            while (true)
            {
                long currentSecond = stopwatch.ElapsedMilliseconds; //현재시간 가져오기
                if (currentSecond - prevSecond >= 10)
                {
                    keyInfo = Console.ReadKey(true);
                    Console.Clear();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow: if (y > 0) y--; break;
                        case ConsoleKey.DownArrow: if (y < Console.WindowHeight - 1 - 2) y++; break;
                        case ConsoleKey.LeftArrow: if (x > 2) x--; break;
                        case ConsoleKey.RightArrow: if (x < Console.WindowWidth - 1 - 3) x++; break;
                        case ConsoleKey.Spacebar: Console.Write("미사일키"); break;
                        case ConsoleKey.Escape: return; //ESC키로 종료 
                    }

                    DrawStriker(x, y);
                    prevSecond = currentSecond; // 시간 업데이트
                }
            }
        }
    }
}