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
        R = 82,
        r = 114,
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

        int currentClearCount = 0;
        int currentStageClearCount = 0;

        int playerX;
        int playerY;

        public string scene = "main";
        bool input = false;

        public Game()
        {
            Console.SetWindowSize(MAX_WINDOW_WIDTH, MAX_WINDOW_HEIGHT);
            Console.SetBufferSize(MAX_WINDOW_WIDTH, MAX_WINDOW_HEIGHT);
            Console.CursorVisible = false;

            stageMap = (int[,])stage.stage1.Clone();
            playerX = stage.stage1PlayerPos[0];
            playerY = stage.stage1PlayerPos[1];
            currentStageClearCount = stage.stage1ClearCount;
        }

        public void Play()
        {

            while (true)
            {
                // DrawWall();
                switch (scene)
                {
                    case "main":
                        DrawMain();
                        StartGame();

                        break;
                    case "game":
                        DrawStage();
                        // DrawTest();
                        KeyControl();
                        CheckGameClear();
                        if (input)
                        {
                            Console.Clear();
                        }
                        break;
                }
            }
        }

        private void StartGame()
        {
            if (Console.KeyAvailable) // 키입력이 들어올 경우 true
            {
                currentStage = 1;
                stageMap = (int[,])stage.stage1.Clone();
                playerX = stage.stage1PlayerPos[0];
                playerY = stage.stage1PlayerPos[1];
                currentClearCount = 0;
                currentStageClearCount = stage.stage1ClearCount;
                steps = 0;
                this.scene = "game";
            }
        }

        private void DrawMain()
        {
            Console.SetCursorPosition(gameStartX + 2, gameStartY - 1);
            Console.Write("■■■■■■■■■■■■■■■■■■■■"); // 44

            for(int i = 0; i < 14; i++)
            {
                Console.SetCursorPosition(gameStartX + 2, gameStartY - 1 + i);
                Console.Write("■");
                Console.SetCursorPosition(gameStartX + 2 + 40, gameStartY - 1 + i);
                Console.Write("■");
            }
            Console.SetCursorPosition(gameStartX + 2, gameStartY - 1 + 13);
            Console.Write("■■■■■■■■■■■■■■■■■■■■");

            Console.SetCursorPosition(gameStartX + 4 + 14, gameStartY - 1 + 4);
            Console.Write("PUSH! PUSH!");
            Console.SetCursorPosition(gameStartX + 4 + 10, gameStartY - 1 + 8);
            Console.Write("○            ●웃");
            Console.SetCursorPosition(gameStartX + 4 + 8, gameStartY - 1 + 9);
            Console.Write("■■■■■■■■■■■");
            Console.SetCursorPosition(gameStartX + 4 + 8, gameStartY - 1 + 15);
            Console.Write("PRESS ANY KEY TO START!");
        }

        private void CheckGameClear()
        {
            if (currentStageClearCount == currentClearCount)
            {
                // 게임 클리어
                NextStage();
            }
        }

        private void NextStage()
        {
            if (currentStage == 1)
            {
                currentStage = 2;
                stageMap = (int[,])stage.stage2.Clone();
                playerX = stage.stage2PlayerPos[0];
                playerY = stage.stage2PlayerPos[1];
                currentClearCount = 0;
                currentStageClearCount = stage.stage2ClearCount;
                steps = 0;
            }
            else if (currentStage == 2)
            {
                currentStage = 3;
                stageMap = (int[,])stage.stage3.Clone();
                playerX = stage.stage3PlayerPos[0];
                playerY = stage.stage3PlayerPos[1];
                currentClearCount = 0;
                currentStageClearCount = stage.stage3ClearCount;
                steps = 0;
            }
            else if (currentStage == 3)
            {
                scene = "main";
                // 메인 화면으로 돌아가기
            }
        }

        private void DrawTest()
        {
            Console.SetCursorPosition(MAX_WINDOW_WIDTH - 8, 1);
            Console.WriteLine($"pX: {playerX}");
            Console.SetCursorPosition(MAX_WINDOW_WIDTH - 8, 2);
            Console.WriteLine($"pY: {playerY}");
            Console.SetCursorPosition(MAX_WINDOW_WIDTH - 8, 3);
            Console.WriteLine($"Cc: {currentClearCount}");            
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
            Console.SetCursorPosition(gameStartX + 28, gameStartY + 4);
            Console.WriteLine($"MOVE KEY : ←↑↓→");
            Console.SetCursorPosition(gameStartX + 28, gameStartY + 6);
            Console.WriteLine($"PRESS 'R' TO RESTART");

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
                    case (int)KeyCode.r:
                        Restart();
                        input = true;
                        break;
                    case (int)KeyCode.R:
                        Restart();
                        input = true;
                        break;
                }
            }
        }

        private void Restart()
        {
            if (currentStage == 1)
            {
                stageMap = (int[,])stage.stage1.Clone();
                playerX = stage.stage1PlayerPos[0];
                playerY = stage.stage1PlayerPos[1];
                currentClearCount = 0;
                steps = 0;
            }
            else if (currentStage == 2)
            {
                stageMap = (int[,])stage.stage2.Clone();
                playerX = stage.stage2PlayerPos[0];
                playerY = stage.stage2PlayerPos[1];
                currentClearCount = 0;
                steps = 0;
            }
            else if (currentStage == 3)
            {
                stageMap = (int[,])stage.stage3.Clone();
                playerX = stage.stage3PlayerPos[0];
                playerY = stage.stage3PlayerPos[1];
                currentClearCount = 0;
                steps = 0;
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
                        if (stageMap[playerY, playerX] == 6)
                        {
                            stageMap[playerY, playerX] = 4;
                        }
                        else
                        {
                            stageMap[playerY, playerX] = 0;
                        }
                        playerY = playerY - 1;
                        steps++;
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
                            if (stageMap[playerY, playerX] == 6)
                            {
                                stageMap[playerY, playerX] = 4;
                            }
                            else
                            {
                                stageMap[playerY, playerX] = 0;
                            }
                            playerY = playerY - 1;
                            steps++;
                        }
                        else if (stageMap[playerY - 2, playerX] == 4) // 공 너머가 집일 경우
                        {
                            stageMap[playerY - 2, playerX] = 5;
                            currentClearCount++;
                            stageMap[playerY - 1, playerX] = 2;
                            if (stageMap[playerY, playerX] == 6)
                            {
                                stageMap[playerY, playerX] = 4;
                            }
                            else
                            {
                                stageMap[playerY, playerX] = 0;
                            }
                            playerY = playerY - 1;
                            steps++;
                        }
                        // 이외에 경우에는 움직이지 않는다.
                    }
                    else if (stageMap[playerY - 1, playerX] == 5) // ○위에 올라간 공일 경우 -> 1칸 더 체크 
                    {
                        if (stageMap[playerY - 2, playerX] == 0) // 공 너머가 빈칸일 경우 -> 공과 함께 움직인다.
                        {
                            stageMap[playerY - 2, playerX] = 3;
                            stageMap[playerY - 1, playerX] = 6;
                            if (stageMap[playerY, playerX] == 6)
                            {
                                stageMap[playerY, playerX] = 4;
                            }
                            else
                            {
                                stageMap[playerY, playerX] = 0;
                            }
                            currentClearCount--;
                            playerY = playerY - 1;
                            steps++;
                        }
                        else if (stageMap[playerY - 2, playerX] == 4) // 공 너머가 집일 경우
                        {
                            stageMap[playerY - 2, playerX] = 5;
                            currentClearCount++;
                            stageMap[playerY - 1, playerX] = 6;
                            if (stageMap[playerY, playerX] == 6)
                            {
                                stageMap[playerY, playerX] = 4;
                            }
                            else
                            {
                                stageMap[playerY, playerX] = 0;
                            }
                            currentClearCount--;
                            playerY = playerY - 1;
                            steps++;
                        }
                    }
                    else if (stageMap[playerY - 1, playerX] == 4) // ○일 경우 -> ○위에 올라간 웃
                    {
                        stageMap[playerY - 1, playerX] = 6;
                        if (stageMap[playerY, playerX] == 6)
                        {
                            stageMap[playerY, playerX] = 4;
                        }
                        else
                        {
                            stageMap[playerY, playerX] = 0;
                        }
                        playerY = playerY - 1;
                        steps++;
                    }
                    break;
                case "left":
                    if (stageMap[playerY, playerX - 1] == 0) // 빈 칸일 경우 -> 그냥 움직인다.
                    {
                        stageMap[playerY, playerX - 1] = 2;
                        if (stageMap[playerY, playerX] == 6)
                        {
                            stageMap[playerY, playerX] = 4;
                        }
                        else
                        {
                            stageMap[playerY, playerX] = 0;
                        }
                        playerX = playerX - 1;
                        steps++;
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
                            if (stageMap[playerY, playerX] == 6)
                            {
                                stageMap[playerY, playerX] = 4;
                            }
                            else
                            {
                                stageMap[playerY, playerX] = 0;
                            }
                            playerX = playerX - 1;
                            steps++;
                        }
                        else if (stageMap[playerY, playerX - 2] == 4) // 공 너머가 집일 경우
                        {
                            Console.WriteLine("!");
                            stageMap[playerY, playerX - 2] = 5;
                            currentClearCount++;
                            stageMap[playerY, playerX - 1] = 2;
                            if (stageMap[playerY, playerX] == 6)
                            {
                                stageMap[playerY, playerX] = 4;
                            }
                            else
                            {
                                stageMap[playerY, playerX] = 0;
                            }
                            playerX = playerX - 1;
                            steps++;
                        }
                        // 이외에 경우에는 움직이지 않는다.
                    }
                    else if (stageMap[playerY, playerX - 1] == 5) // ○위에 올라간 공일 경우 -> 1칸 더 체크 
                    {
                        if (stageMap[playerY, playerX - 2] == 0) // 공 너머가 빈칸일 경우 -> 공과 함께 움직인다.
                        {
                            stageMap[playerY, playerX - 2] = 3;
                            stageMap[playerY, playerX - 1] = 6;
                            if (stageMap[playerY, playerX] == 6)
                            {
                                stageMap[playerY, playerX] = 4;
                            }
                            else
                            {
                                stageMap[playerY, playerX] = 0;
                            }
                            currentClearCount--;
                            playerX = playerX - 1;
                            steps++;
                        }
                        else if (stageMap[playerY, playerX - 1] == 4) // 공 너머가 집일 경우
                        {
                            stageMap[playerY, playerX - 2] = 5;
                            currentClearCount++;
                            stageMap[playerY, playerX - 1] = 6;
                            if (stageMap[playerY, playerX] == 6)
                            {
                                stageMap[playerY, playerX] = 4;
                            }
                            else
                            {
                                stageMap[playerY, playerX] = 0;
                            }
                            currentClearCount--;
                            playerX = playerX - 1;
                            steps++;
                        }
                    }
                    else if (stageMap[playerY, playerX - 1] == 4) // ○일 경우 -> ○위에 올라간 웃
                    {
                        stageMap[playerY, playerX - 1] = 6;
                        if (stageMap[playerY, playerX] == 6)
                        {
                            stageMap[playerY, playerX] = 4;
                        }
                        else
                        {
                            stageMap[playerY, playerX] = 0;
                        }
                        playerX = playerX - 1;
                        steps++;
                    }
                    break;
                case "right":
                    if (stageMap[playerY, playerX + 1] == 0) // 빈 칸일 경우 -> 그냥 움직인다.
                    {
                        stageMap[playerY, playerX + 1] = 2;
                        if (stageMap[playerY, playerX] == 6)
                        {
                            stageMap[playerY, playerX] = 4;
                        }
                        else
                        {
                            stageMap[playerY, playerX] = 0;
                        }
                        playerX = playerX + 1;
                        steps++;
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
                            if (stageMap[playerY, playerX] == 6)
                            {
                                stageMap[playerY, playerX] = 4;
                            }
                            else
                            {
                                stageMap[playerY, playerX] = 0;
                            }
                            playerX = playerX + 1;
                            steps++;
                        }
                        else if (stageMap[playerY, playerX + 2] == 4) // 공 너머가 집일 경우
                        {
                            stageMap[playerY, playerX + 2] = 5;
                            currentClearCount++;
                            stageMap[playerY, playerX + 1] = 2;
                            if (stageMap[playerY, playerX] == 6)
                            {
                                stageMap[playerY, playerX] = 4;
                            }
                            else
                            {
                                stageMap[playerY, playerX] = 0;
                            }
                            playerX = playerX + 1;
                            steps++;
                        }
                        // 이외에 경우에는 움직이지 않는다.
                    }
                    else if (stageMap[playerY, playerX + 1] == 5) // ○위에 올라간 공일 경우 -> 1칸 더 체크 
                    {
                        if (stageMap[playerY, playerX + 2] == 0) // 공 너머가 빈칸일 경우 -> 공과 함께 움직인다.
                        {
                            stageMap[playerY, playerX + 2] = 3;
                            stageMap[playerY, playerX + 1] = 6;
                            if (stageMap[playerY, playerX] == 6)
                            {
                                stageMap[playerY, playerX] = 4;
                            }
                            else
                            {
                                stageMap[playerY, playerX] = 0;
                            }
                            currentClearCount--;
                            playerX = playerX + 1;
                            steps++;
                        }
                        else if (stageMap[playerY, playerX + 2] == 4) // 공 너머가 집일 경우
                        {
                            stageMap[playerY, playerX + 2] = 5;
                            currentClearCount++;
                            stageMap[playerY, playerX + 1] = 6;
                            if (stageMap[playerY, playerX] == 6)
                            {
                                stageMap[playerY, playerX] = 4;
                            }
                            else
                            {
                                stageMap[playerY, playerX] = 0;
                            }
                            currentClearCount--;
                            playerX = playerX + 1;
                            steps++;
                        }
                    }
                    else if (stageMap[playerY, playerX + 1] == 4) // ○일 경우 -> ○위에 올라간 웃
                    {
                        stageMap[playerY, playerX + 1] = 6;
                        if (stageMap[playerY, playerX] == 6)
                        {
                            stageMap[playerY, playerX] = 4;
                        }
                        else
                        {
                            stageMap[playerY, playerX] = 0;
                        }
                        playerX = playerX + 1;
                        steps++;
                    }
                    break;
                case "down":
                    if (stageMap[playerY + 1, playerX] == 0) // 빈 칸일 경우 -> 그냥 움직인다.
                    {
                        stageMap[playerY + 1, playerX] = 2;
                        if (stageMap[playerY, playerX] == 6)
                        {
                            stageMap[playerY, playerX] = 4;
                        }
                        else
                        {
                            stageMap[playerY, playerX] = 0;
                        }
                        playerY = playerY + 1;
                        steps++;
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
                            if (stageMap[playerY, playerX] == 6)
                            {
                                stageMap[playerY, playerX] = 4;
                            }
                            else
                            {
                                stageMap[playerY, playerX] = 0;
                            }
                            playerY = playerY + 1;
                            steps++;
                        }
                        else if (stageMap[playerY + 2, playerX] == 4) // 공 너머가 집일 경우
                        {
                            stageMap[playerY + 2, playerX] = 5;
                            currentClearCount++;
                            stageMap[playerY + 1, playerX] = 2;
                            if (stageMap[playerY, playerX] == 6)
                            {
                                stageMap[playerY, playerX] = 4;
                            }
                            else
                            {
                                stageMap[playerY, playerX] = 0;
                            }
                            playerY = playerY + 1;
                            steps++;
                        }
                        // 이외에 경우에는 움직이지 않는다.
                    }
                    else if (stageMap[playerY + 1, playerX] == 5) // ○위에 올라간 공일 경우 -> 1칸 더 체크 
                    {
                        if (stageMap[playerY + 2, playerX] == 0) // 공 너머가 빈칸일 경우 -> 공과 함께 움직인다.
                        {
                            stageMap[playerY + 2, playerX] = 3;
                            stageMap[playerY + 1, playerX] = 6;
                            if (stageMap[playerY, playerX] == 6)
                            {
                                stageMap[playerY, playerX] = 4;
                            }
                            else
                            {
                                stageMap[playerY, playerX] = 0;
                            }
                            currentClearCount--;
                            playerY = playerY + 1;
                            steps++;
                        }
                        else if (stageMap[playerY + 2, playerX] == 4) // 공 너머가 집일 경우
                        {
                            stageMap[playerY + 2, playerX] = 5;
                            currentClearCount++;
                            stageMap[playerY + 1, playerX] = 6;
                            if (stageMap[playerY, playerX] == 6)
                            {
                                stageMap[playerY, playerX] = 4;
                            }
                            else
                            {
                                stageMap[playerY, playerX] = 0;
                            }
                            currentClearCount--;
                            playerY = playerY + 1;
                            steps++;
                        }
                    }
                    else if (stageMap[playerY + 1, playerX] == 4) // ○일 경우 -> ○위에 올라간 웃
                    {
                        stageMap[playerY + 1, playerX] = 6;
                        if (stageMap[playerY, playerX] == 6)
                        {
                            stageMap[playerY, playerX] = 4;
                        }
                        else
                        {
                            stageMap[playerY, playerX] = 0;
                        }
                        playerY = playerY + 1;
                        steps++;
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
        public int stage1ClearCount = 4;

        public int[,] stage2 = new int[12, 12]
        {
            { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
            { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
            { 9, 9, 1, 1, 1, 1, 1, 9, 9, 9, 9, 9},
            { 9, 9, 1, 2, 0, 0, 1, 9, 1, 1, 1, 9},
            { 9, 9, 1, 0, 3, 3, 1, 9, 1, 4, 1, 9},
            { 9, 9, 1, 0, 3, 0, 1, 9, 1, 4, 1, 9},
            { 9, 9, 1, 1, 1, 0, 1, 1, 1, 4, 1, 9},
            { 9, 9, 9, 1, 1, 0, 0, 0, 0, 0, 1, 9},
            { 9, 9, 9, 1, 0, 0, 0, 1, 0, 0, 1, 9},
            { 9, 9, 9, 1, 0, 0, 0, 1, 1, 1, 1, 9},
            { 9, 9, 9, 1, 1, 1, 1, 1, 9, 9, 9, 9},
            { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
        };
        public int[] stage2PlayerPos = { 3, 3 };
        public int stage2ClearCount = 3;

        public int[,] stage3 = new int[12, 12]
        {
            { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
            { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
            { 9, 9, 1, 1, 1, 1, 1, 1, 1, 9, 9, 9},
            { 9, 9, 1, 0, 0, 0, 0, 0, 1, 1, 1, 9},
            { 9, 1, 1, 3, 1, 1, 1, 0, 0, 0, 1, 9},
            { 9, 1, 0, 0, 0, 0, 0, 3, 3, 0, 1, 9},
            { 9, 1, 0, 4, 4, 1, 2, 3, 0, 1, 1, 9},
            { 9, 1, 1, 4, 4, 1, 0, 0, 0, 1, 9, 9},
            { 9, 9, 1, 1, 1, 1, 1, 1, 1, 1, 9, 9},
            { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
            { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
            { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
        };
        public int[] stage3PlayerPos = { 6, 6 };
        public int stage3ClearCount = 4;
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
