using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace ConsoleApp53
{
    enum KeyCode
    {
        UPKEY = 72,
        DOWNKEY = 80,
        LEFTKEY = 75,
        RIGHTKEY = 77,
    }
    class Game
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch();

        Stages stage = new Stages();

        public const int MAX_WINDOW_WIDTH = 60;
        public const int MAX_WINDOW_HEIGHT = 20;

        int gameStartX = 8;
        int gameStartY = 4;
        int wallSize = 12;

        int currentStage = 1;
        int steps = 0;

        int[,] stageMap = new int[12, 12]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        };

        int playerX;
        int playerY;

        public string scene = "main";
        bool input = false;

        public Game()
        {
            Console.SetWindowSize(MAX_WINDOW_WIDTH, MAX_WINDOW_HEIGHT);
            Console.SetBufferSize(MAX_WINDOW_WIDTH, MAX_WINDOW_HEIGHT);
            Console.CursorVisible = false;

            stageMap = stage.stage1;
            playerX = stage.stage1PlayerPos[0];
            playerY = stage.stage1PlayerPos[1];
        }

        public void Play()
        {

            while (true)
            {
                // DrawWall();
                DrawStage();
                DrawTest();
                KeyControl();
                if (input)
                {
                    Console.Clear();
                }
            }
        }

        private void DrawTest()
        {
            Console.SetCursorPosition(MAX_WINDOW_WIDTH - 8, 1);
            Console.WriteLine($"pX: {playerX}");
            Console.SetCursorPosition(MAX_WINDOW_WIDTH - 8, 2);
            Console.WriteLine($"pY: {playerY}");
        }

        /*
        private void DrawWall()
        {
           Console.SetCursorPosition(gameStartX, gameStartY);
           for (int i = 0; i < wallSize; i++)
           {
               Console.Write("■");
           }
           for (int i = 1; i < wallSize - 1; i++)
           {
               Console.SetCursorPosition(gameStartX, gameStartY + i);
               Console.Write("■");
               Console.SetCursorPosition(gameStartX + (wallSize - 1) * 2, gameStartY + i);
               Console.Write("■");
           }
           Console.SetCursorPosition(gameStartX, gameStartY + wallSize - 2);
           for (int i = 0; i < wallSize; i++)
           {
               Console.Write("■");
           }
        }
        */
        public void DrawStage()
        {
            Console.SetCursorPosition(gameStartX + 1, gameStartY - 2);
            Console.WriteLine($"STAGE: {currentStage}");
            Console.SetCursorPosition(gameStartX + 15, gameStartY - 2);
            Console.WriteLine($"STEPS: {steps}");

            Console.SetCursorPosition(gameStartX, gameStartY);
            for (int i = 0; i < stageMap.GetLength(0); i++)
            {
                for (int j = 0; j < stageMap.GetLength(1); j++)
                {
                    Console.SetCursorPosition(gameStartX + 2 * j, gameStartY + i);
                    switch (stageMap[i, j])
                    {
                        case 0:
                            Console.Write("");
                            break;
                        case 1:
                            Console.Write("■");
                            break;
                        case 2:
                            Console.Write("웃");
                            break;
                        case 3:
                            Console.Write("●");
                            break;
                        case 4:
                            Console.Write("○");
                            break;
                        case 5:
                            Console.Write("●");// ○위에 올라간 ●
                            break;
                        case 6:
                            Console.Write("웃"); // ○위에 올라간 웃
                            break;
                        case 9:
                            Console.Write("▒");
                            break;
                        default:
                            Console.Write("?");
                            break;
                    }
                }
            }
        }
        public void KeyControl()
        {
            int pressedKey; // 정수형 변수 선언
            input = false;
            if (Console.KeyAvailable) // 키입력이 들어올 경우 true
            {
                pressedKey = _getch(); // 아스키 값으로 받음.

                if (pressedKey == 0 || pressedKey == 224) // 화살표 키 또는 특수 키 감지
                {
                    pressedKey = _getch(); // 실제 키 값 읽기
                }

                switch (pressedKey)
                {
                    case (int)KeyCode.UPKEY:
                        Move("up");
                        input = true;
                        break;
                    case (int)KeyCode.LEFTKEY:
                        Move("left");
                        input = true;
                        break;
                    case (int)KeyCode.RIGHTKEY:
                        Move("right");
                        input = true;
                        break;
                    case (int)KeyCode.DOWNKEY:
                        Move("down");
                        input = true;
                        break;
                }
            }
        }
        void Move(string dir)
        {
            switch (dir)
            {
                case "up":
                    if (stageMap[playerY - 1, playerX] == 0) // 빈 칸일 경우 -> 그냥 움직인다.
                    {
                        stageMap[playerY - 1, playerX] = 2;
                        stageMap[playerY, playerX] = 0;
                        playerY = playerY - 1;
                    }
                    else if (stageMap[playerY - 1, playerX] == 1) // 벽일 경우 -> 아무 변화 없음.
                    {
                        // 사실 없어도 되는 코드
                    }
                    else if (stageMap[playerY - 1, playerX] == 3) // 공일 경우 -> 1칸 더 체크
                    {
                        if (stageMap[playerY - 2, playerX] == 0) // 공 너머가 빈칸일 경우 -> 공과 함께 움직인다.
                        {
                            stageMap[playerY - 2, playerX] = 3;
                            stageMap[playerY - 1, playerX] = 2;
                            stageMap[playerY, playerX] = 0;
                            playerY = playerY - 1;
                        }
                        else if (stageMap[playerY - 2, playerX] == 4) // 공 너머가 집일 경우
                        {
                            stageMap[playerY - 2, playerX] = 5;
                            stageMap[playerY - 1, playerX] = 2;
                            stageMap[playerY, playerX] = 0;
                            playerY = playerY - 1;
                        }
                        // 이외에 경우에는 움직이지 않는다.
                    }
                    else if (stageMap[playerY - 1, playerX] == 5) // ○위에 올라간 공일 경우 -> 1칸 더 체크 
                    {
                        if (stageMap[playerY - 2, playerX] == 0) // 공 너머가 빈칸일 경우 -> 공과 함께 움직인다.
                        {
                            stageMap[playerY - 2, playerX] = 3;
                            stageMap[playerY - 1, playerX] = 6;
                            stageMap[playerY, playerX] = 0;
                            playerY = playerY - 1;
                        }
                        else if (stageMap[playerY - 2, playerX] == 4) // 공 너머가 집일 경우
                        {
                            stageMap[playerY - 2, playerX] = 5;
                            stageMap[playerY - 1, playerX] = 6;
                            stageMap[playerY, playerX] = 0;
                            playerY = playerY - 1;
                        }
                    }
                    else if (stageMap[playerY - 1, playerX] == 4) // ○일 경우 -> ○위에 올라간 웃
                    {
                        stageMap[playerY - 1, playerX] = 6;
                        stageMap[playerY, playerX] = 0;
                        playerY = playerY - 1;
                    }

                    if (stageMap[playerY, playerX] == 6) // 현재 위치가 ○라면
                    {
                        stageMap[playerY, playerX] = 4;
                    }
                    break;
                case "left":
                    if (stageMap[playerY , playerX - 1] == 0) // 빈 칸일 경우 -> 그냥 움직인다.
                    {
                        stageMap[playerY, playerX - 1] = 2;
                        stageMap[playerY, playerX] = 0;
                        playerX = playerX - 1;
                    }
                    else if (stageMap[playerY, playerX - 1] == 1) // 벽일 경우 -> 아무 변화 없음.
                    {
                        // 사실 없어도 되는 코드
                    }
                    else if (stageMap[playerY, playerX - 1] == 3) // 공일 경우 -> 1칸 더 체크
                    {
                        if (stageMap[playerY, playerX - 2] == 0) // 공 너머가 빈칸일 경우 -> 공과 함께 움직인다.
                        {
                            stageMap[playerY, playerX - 2] = 3;
                            stageMap[playerY, playerX - 1] = 2;
                            stageMap[playerY, playerX] = 0;
                            playerX = playerX - 1;
                        }
                        else if (stageMap[playerY, playerX - 2] == 4) // 공 너머가 집일 경우
                        {
                            Console.WriteLine("!");
                            stageMap[playerY, playerX - 2] = 5;
                            stageMap[playerY, playerX - 1] = 2;
                            stageMap[playerY, playerX] = 0;
                            playerX = playerX - 1;
                        }
                        // 이외에 경우에는 움직이지 않는다.
                    }
                    else if (stageMap[playerY, playerX - 1] == 5) // ○위에 올라간 공일 경우 -> 1칸 더 체크 
                    {
                        if (stageMap[playerY, playerX - 2] == 0) // 공 너머가 빈칸일 경우 -> 공과 함께 움직인다.
                        {
                            stageMap[playerY, playerX - 2] = 3;
                            stageMap[playerY, playerX - 1] = 6;
                            stageMap[playerY, playerX] = 0;
                            playerX = playerX - 1;
                        }
                        else if (stageMap[playerY, playerX - 1] == 4) // 공 너머가 집일 경우
                        {
                            stageMap[playerY, playerX - 2] = 5;
                            stageMap[playerY, playerX - 1] = 6;
                            stageMap[playerY, playerX] = 0;
                            playerX = playerX - 1;
                        }
                    }
                    else if (stageMap[playerY, playerX - 1] == 4) // ○일 경우 -> ○위에 올라간 웃
                    {
                        stageMap[playerY, playerX - 1] = 6;
                        stageMap[playerY, playerX] = 0;
                        playerX = playerX - 1;
                    }

                    if (stageMap[playerY, playerX] == 6) // 현재 위치가 ○라면
                    {
                        stageMap[playerY, playerX] = 4;
                    }
                    break;
                case "right":
                    if (stageMap[playerY, playerX + 1] == 0) // 빈 칸일 경우 -> 그냥 움직인다.
                    {
                        stageMap[playerY, playerX + 1] = 2;
                        stageMap[playerY, playerX] = 0;
                        playerX = playerX + 1;
                    }
                    else if (stageMap[playerY, playerX + 1] == 1) // 벽일 경우 -> 아무 변화 없음.
                    {
                        // 사실 없어도 되는 코드
                    }
                    else if (stageMap[playerY, playerX + 1] == 3) // 공일 경우 -> 1칸 더 체크
                    {
                        if (stageMap[playerY, playerX + 2] == 0) // 공 너머가 빈칸일 경우 -> 공과 함께 움직인다.
                        {
                            stageMap[playerY, playerX + 2] = 3;
                            stageMap[playerY, playerX + 1] = 2;
                            stageMap[playerY, playerX] = 0;
                            playerX = playerX + 1;
                        }
                        else if (stageMap[playerY, playerX + 2] == 4) // 공 너머가 집일 경우
                        {
                            stageMap[playerY, playerX + 2] = 5;
                            stageMap[playerY, playerX + 1] = 2;
                            stageMap[playerY, playerX] = 0;
                            playerX = playerX + 1;
                        }
                        // 이외에 경우에는 움직이지 않는다.
                    }
                    else if (stageMap[playerY, playerX + 1] == 5) // ○위에 올라간 공일 경우 -> 1칸 더 체크 
                    {
                        if (stageMap[playerY, playerX + 2] == 0) // 공 너머가 빈칸일 경우 -> 공과 함께 움직인다.
                        {
                            stageMap[playerY, playerX + 2] = 3;
                            stageMap[playerY, playerX + 1] = 6;
                            stageMap[playerY, playerX] = 0;
                            playerX = playerX + 1;
                        }
                        else if (stageMap[playerY, playerX + 2] == 4) // 공 너머가 집일 경우
                        {
                            stageMap[playerY, playerX + 2] = 5;
                            stageMap[playerY, playerX + 1] = 6;
                            stageMap[playerY, playerX] = 0;
                            playerX = playerX + 1;
                        }
                    }
                    else if (stageMap[playerY, playerX + 1] == 4) // ○일 경우 -> ○위에 올라간 웃
                    {
                        stageMap[playerY, playerX + 1] = 6;
                        stageMap[playerY, playerX] = 0;
                        playerX = playerX + 1;
                    }

                    if (stageMap[playerY, playerX] == 6) // 현재 위치가 ○라면
                    {
                        stageMap[playerY, playerX] = 4;
                    }
                    break;
                case "down":
                    if (stageMap[playerY + 1, playerX] == 0) // 빈 칸일 경우 -> 그냥 움직인다.
                    {
                        stageMap[playerY + 1, playerX] = 2;
                        stageMap[playerY, playerX] = 0;
                        playerY = playerY + 1;
                    }
                    else if (stageMap[playerY + 1, playerX] == 1) // 벽일 경우 -> 아무 변화 없음.
                    {
                        // 사실 없어도 되는 코드
                    }
                    else if (stageMap[playerY + 1, playerX] == 3) // 공일 경우 -> 1칸 더 체크
                    {
                        if (stageMap[playerY + 2, playerX] == 0) // 공 너머가 빈칸일 경우 -> 공과 함께 움직인다.
                        {
                            stageMap[playerY + 2, playerX] = 3;
                            stageMap[playerY + 1, playerX] = 2;
                            stageMap[playerY, playerX] = 0;
                            playerY = playerY + 1;
                        }
                        else if (stageMap[playerY + 2, playerX] == 4) // 공 너머가 집일 경우
                        {
                            stageMap[playerY + 2, playerX] = 5;
                            stageMap[playerY + 1, playerX] = 2;
                            stageMap[playerY, playerX] = 0;
                            playerY = playerY + 1;
                        }
                        // 이외에 경우에는 움직이지 않는다.
                    }
                    else if (stageMap[playerY + 1, playerX] == 5) // ○위에 올라간 공일 경우 -> 1칸 더 체크 
                    {
                        if (stageMap[playerY + 2, playerX] == 0) // 공 너머가 빈칸일 경우 -> 공과 함께 움직인다.
                        {
                            stageMap[playerY + 2, playerX] = 3;
                            stageMap[playerY + 1, playerX] = 6;
                            stageMap[playerY, playerX] = 0;
                            playerY = playerY + 1;
                        }
                        else if (stageMap[playerY + 2, playerX] == 4) // 공 너머가 집일 경우
                        {
                            stageMap[playerY + 2, playerX] = 5;
                            stageMap[playerY + 1, playerX] = 6;
                            stageMap[playerY, playerX] = 0;
                            playerY = playerY + 1;
                        }
                    }
                    else if (stageMap[playerY + 1, playerX] == 4) // ○일 경우 -> ○위에 올라간 웃
                    {
                        stageMap[playerY + 1, playerX] = 6;
                        stageMap[playerY, playerX] = 0;
                        playerY = playerY + 1;
                    }

                    if (stageMap[playerY, playerX] == 6) // 현재 위치가 ○라면
                    {
                        stageMap[playerY, playerX] = 4;
                    }
                    break;
            }
        }
    }
    class Stages
    {
        public int[,] stage1 = new int[12, 12]
        {
            { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
            { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
            { 9, 9, 9, 9, 1, 1, 1, 9, 9, 9, 9, 9},
            { 9, 9, 9, 9, 1, 4, 1, 9, 9, 9, 9, 9},
            { 9, 9, 9, 9, 1, 0, 1, 1, 1, 1, 9, 9},
            { 9, 9, 1, 1, 1, 3, 3, 0, 4, 1, 9, 9},
            { 9, 9, 1, 4, 0, 3, 2, 1, 1, 1, 9, 9},
            { 9, 9, 1, 1, 1, 1, 3, 1, 9, 9, 9, 9},
            { 9, 9, 9, 9, 9, 1, 4, 1, 9, 9, 9, 9},
            { 9, 9, 9, 9, 9, 1, 1, 1, 9, 9, 9, 9},
            { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
            { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
        };
        public int[] stage1PlayerPos = { 6, 6 };
        public int clearCount = 4;
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Play();
        }
    }
}
