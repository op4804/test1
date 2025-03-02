using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp43
{
    class Program
    {
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

            string[] striker = new string[]
            {
                "  ▲  ",
                "↑※↑",
                "▲■▲",
            };

            while (true)
            {
                Console.Clear();
                
                for(int i = 0; i < striker.Length; i++)
                {
                    Console.SetCursorPosition(x - 2, y + i);
                    Console.Write(striker[i]);
                }        

                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: if (y > 0) y--; break;
                    case ConsoleKey.DownArrow: if (y < Console.WindowHeight - 1 - 2) y++; break;
                    case ConsoleKey.LeftArrow: if (x > 2) x--; break;
                    case ConsoleKey.RightArrow: if (x < Console.WindowWidth - 1 - 3) x++; break;
                    case ConsoleKey.Spacebar: Console.Write("미사일키"); break;
                    case ConsoleKey.Escape: return; //ESC키로 종료 
                }
            }
        }
    }
}
