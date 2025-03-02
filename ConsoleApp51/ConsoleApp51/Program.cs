using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ConsoleApp51.MainGame;

namespace ConsoleApp51
{
    public class MainGame
    {
        // 아스키 키 코드
        enum KeyCode
        {
            UPKEY = 72,
            DOWNKEY = 80,
            LEFTKEY = 75,
            RIGHTKEY = 77,
            SPACEBAR = 32,
            X = 88,
            x = 120,
        }

        public const int MAX_WINDOW_HEIGHT = 60;
        public const int MAX_WINDOW_WIDTH = 80;

        const int MAX_ENEMY_LIMIT = 10;
        const int MAX_ITEM_LIMIT = 3;

        public string scene = "main";

        Striker striker;

        Enemy[] enemies = new Enemy[MAX_ENEMY_LIMIT];
        int currentEnemyCount = 1;

        Item[] items = new Item[MAX_ITEM_LIMIT];

        int life = 3;
        int score;
        int difficulty = 1;
        // 난이도 

        public int tick = 0;

        [DllImport("msvcrt.dll")]
        static extern int _getch();

        public MainGame()
        {
            // 콘솔 초기화            
            Console.SetWindowSize(MAX_WINDOW_WIDTH, MAX_WINDOW_HEIGHT);
            Console.SetBufferSize(MAX_WINDOW_WIDTH, MAX_WINDOW_HEIGHT);

            Console.CursorVisible = false;

            striker = new Striker();

            enemies[0] = new Enemy();

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Item();
            }
        }
        public void Game()
        {
            // 키 입력
            KeyControl();
            // 플레이어 그리기
            striker.DrawStriker();
            CrashStriker();
            // 미사일 그리기
            striker.DrawBullet();
            // 적
            for (int i = 0; i < currentEnemyCount; i++)
            {
                enemies[i].MoveEnemy();
                enemies[i].DrawEnemy();
                CrashEnemy();
            }
            // 아이템
            for (int i = 0; i < items.Length; i++)
            {
                items[i].MoveItem();
                items[i].DrawItem();
                GetItem();
            }
            striker.upgradeFlag = true;
            // UI 그리기
            DrawUI();
            // DrawTest();
            HardMode();

        }
        private void DrawTest()
        {
            int scoreUIPosition = MAX_WINDOW_WIDTH - 16;
            // 2까지는 스코어 보드
            // Console.SetCursorPosition(scoreUIPosition, 3);
            // Console.WriteLine($"striker rc:{striker.recreateCount}");
            Console.SetCursorPosition(scoreUIPosition, 4);
            Console.WriteLine($"striker upgrd:{striker.upgrade}");
            // Console.SetCursorPosition(scoreUIPosition, 5);
            // Console.WriteLine($"item x:{items[0].itemX}");
            Console.SetCursorPosition(scoreUIPosition, 6);
            Console.WriteLine($"striker X:{striker.strikerX}");
            Console.SetCursorPosition(scoreUIPosition, 7);
            Console.WriteLine($"striker Y:{striker.strikerY}");
            Console.SetCursorPosition(scoreUIPosition, 8);
            Console.WriteLine($"enem X:{enemies[0].enemyX}");
            Console.SetCursorPosition(scoreUIPosition, 9);
            Console.WriteLine($"enem Y:{enemies[0].enemyY}");
            Console.SetCursorPosition(scoreUIPosition, 10);
            Console.WriteLine($"bulet X:{striker.bullets[0].x}");
            Console.SetCursorPosition(scoreUIPosition, 11);
            Console.WriteLine($"bulet Y:{striker.bullets[0].y}");
        }
        public void HardMode()
        {
            if (difficulty == 1 && (score > 500))
            {
                difficulty = 2;
                enemies[1] = new Enemy();
                currentEnemyCount = 2;
            }
            if (difficulty == 2 && (score > 1000))
            {
                difficulty = 3;
                enemies[2] = new Enemy();
                currentEnemyCount = 3;
            }
            if (difficulty == 3 && (score > 2000))
            {
                difficulty = 4;
                enemies[3] = new Enemy();
                enemies[4] = new Enemy();
                currentEnemyCount = 5;
            }
        }
        public void CrashEnemy()
        {
            // 미사일과 적 체크
            for (int i = 0; i < striker.bullets.Length; i++)
            {
                if (striker.bullets[i].fire == true)
                {
                    for (int j = 0; j < currentEnemyCount; j++)
                    {
                        if (striker.bullets[i].y == enemies[j].enemyY)
                        {
                            if ((striker.bullets[i].x > enemies[j].enemyX - 2) && (striker.bullets[i].x < enemies[j].enemyX + 2))
                            {
                                // 충돌
                                // 아이템 생성
                                for (int it = 0; it < items.Length; it++)
                                {
                                    if (!items[it].itemAvailavle)
                                    {
                                        items[it].itemAvailavle = true;
                                        items[it].itemX = enemies[j].enemyX;
                                        items[it].itemY = enemies[j].enemyY;
                                    }
                                }
                                enemies[j].Recreate();
                                striker.bullets[i].fire = false;
                                score += 100;
                            }
                        }
                    }
                }
            }
        }
        private void GetItem()
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].itemAvailavle)
                {
                    if (((items[i].itemY <= striker.strikerY && items[i].itemY >= striker.strikerY - 1)) &&
                            (items[i].itemX <= striker.strikerX + 2 && items[i].itemX >= striker.strikerX - 2))
                    {
                        // 아이템 획득
                        items[i].itemAvailavle = false;
                        striker.Upgrade();
                        items[i].itemAvailavle = false;
                        return;
                    }
                }
            }
        }
        private void CrashStriker()
        {
            for (int i = 0; i < currentEnemyCount; i++)
            {
                if ((striker.strikerY > enemies[i].enemyY - 3) && ((striker.strikerY < enemies[i].enemyY + 3)))
                {
                    if ((striker.strikerX > enemies[i].enemyX - 3) && (striker.strikerX < enemies[i].enemyX + 3))
                    {
                        // 충돌
                        enemies[i].Recreate();
                        life--;
                        striker.Recreate();
                        if (life == 0)
                        {
                            scene = "gameOver";
                        }
                    }
                }
            }
        }
        private void DrawUI()
        {
            int lifeUIPosition = 2;
            Console.SetCursorPosition(lifeUIPosition, 1);
            Console.Write($"LIFE: ");
            for (int i = 0; i < life; i++)
            {
                Console.Write($"{"▲"}");
            }
            Console.SetCursorPosition(lifeUIPosition, 2);
            Console.WriteLine($"DIFFICULTY: {difficulty}");


            int scoreUIPosition = MAX_WINDOW_WIDTH - 16;
            Console.SetCursorPosition(scoreUIPosition, 0);
            Console.Write("┏━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(scoreUIPosition, 1);
            Console.Write("┃              ┃");
            Console.SetCursorPosition(scoreUIPosition + 2, 1);
            Console.Write($"Score : {score,2}");
            Console.SetCursorPosition(scoreUIPosition, 2);
            Console.Write("┗━━━━━━━━━━━━━━┛");
        }
        public void DrawMain()
        {

            // ┏━┃┓┛┗
            Console.SetCursorPosition(1, 1);
            Console.Write("┏");
            Console.SetCursorPosition(MAX_WINDOW_WIDTH - 2, 1);
            Console.Write("┓");

            for (int i = 2; i < MAX_WINDOW_WIDTH - 3; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("━");
            }
            for (int i = 2; i < MAX_WINDOW_HEIGHT - 2; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("┃");
                Console.SetCursorPosition(MAX_WINDOW_WIDTH - 2, i);
                Console.Write("┃");
            }

            Console.SetCursorPosition(1, MAX_WINDOW_HEIGHT - 2);
            Console.Write("┗");
            Console.SetCursorPosition(MAX_WINDOW_WIDTH - 2, MAX_WINDOW_HEIGHT - 2);
            Console.Write("┛");
            for (int i = 2; i < MAX_WINDOW_WIDTH - 2; i++)
            {
                Console.SetCursorPosition(i, MAX_WINDOW_HEIGHT - 2);
                Console.Write("━");
            }

            string[] mainLogo1 = new string[]
            {
                "□□□ □  □  □□   □□  □□□ □ □    □   □□  ",
                "□     □  □ □  □ □  □   □   □ □□  □  □     ",
                "□□□ □□□ □  □ □  □   □   □ □ □ □ □  □□",
                "    □ □  □ □  □ □  □   □   □ □  □□  □  □ ",
                "□□□ □  □  □□   □□    □   □ □    □   □□  ",
                "                                                       ",
                "            ■■     ■    ■    ■  ■■■            ",
                "           ■      ■  ■ ■■  ■■ ■                ",
                "          ■  ■■ ■■■ ■ ■■ ■ ■■■            ",
                "           ■  ■  ■  ■ ■  ■  ■ ■                ",
                "            ■■   ■  ■ ■  ■  ■ ■■■            "

            };

            string[] mainLogo2 = new string[]
            {
                "■■■ ■  ■  ■■   ■■  ■■■ ■ ■    ■   ■■  ",
                "■     ■  ■ ■  ■ ■  ■   ■   ■ ■■  ■  ■     ",
                "■■■ ■■■ ■  ■ ■  ■   ■   ■ ■ ■ ■ ■  ■■",
                "    ■ ■  ■ ■  ■ ■  ■   ■   ■ ■  ■■  ■  ■ ",
                "■■■ ■  ■  ■■   ■■    ■   ■ ■    ■   ■■  ",
                "                                                       ",
                "            □□     □    □    □  □□□            ",
                "           □      □  □ □□  □□ □                ",
                "          □  □□ □□□ □ □□ □ □□□            ",
                "           □  □  □  □ □  □  □ □                ",
                "            □□   □  □ □  □  □ □□□            "

            };


            for (int i = 0; i < mainLogo1.Length; i++)
            {
                Console.SetCursorPosition(14, 15 + i);
                Console.WriteLine(mainLogo1[i]);
            }

            if (tick % 3 == 0)
            {

            }
            else
            {
                Console.SetCursorPosition(29, 40);
                Console.WriteLine("PRESS ANY KEY TO START!");
            }


            if (tick > 10)
            {
                tick = 0;
            }
            else
            {
                tick++;
            }
        }
        public void DrawGameOver()
        {
            Console.SetCursorPosition(1, 1);
            Console.Write("┏");
            Console.SetCursorPosition(MAX_WINDOW_WIDTH - 2, 1);
            Console.Write("┓");

            for (int i = 2; i < MAX_WINDOW_WIDTH - 3; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("━");
            }
            for (int i = 2; i < MAX_WINDOW_HEIGHT - 2; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("┃");
                Console.SetCursorPosition(MAX_WINDOW_WIDTH - 2, i);
                Console.Write("┃");
            }

            Console.SetCursorPosition(1, MAX_WINDOW_HEIGHT - 2);
            Console.Write("┗");
            Console.SetCursorPosition(MAX_WINDOW_WIDTH - 2, MAX_WINDOW_HEIGHT - 2);
            Console.Write("┛");
            for (int i = 2; i < MAX_WINDOW_WIDTH - 2; i++)
            {
                Console.SetCursorPosition(i, MAX_WINDOW_HEIGHT - 2);
                Console.Write("━");
            }

            string[] gameOverLogo = new string[]
            {
                "                                                       ",
                "            ■■     ■    ■    ■  ■■■            ",
                "           ■      ■  ■ ■■  ■■ ■                ",
                "          ■  ■■ ■■■ ■ ■■ ■ ■■■            ",
                "           ■  ■  ■  ■ ■  ■  ■ ■                ",
                "            ■■   ■  ■ ■  ■  ■ ■■■            ",
                "                                                       ",
                "              ■■   ■  ■ ■■■ ■■■              ",
                "             ■  ■  ■  ■ ■     ■   ■             ",
                "            ■    ■ ■  ■ ■■■ ■■■              ",
                "             ■  ■   ■■  ■     ■ ■               ",
                "              ■■     ■   ■■■ ■   ■             ",

            };

            for (int i = 0; i < gameOverLogo.Length; i++)
            {
                Console.SetCursorPosition(14, 15 + i);
                Console.WriteLine(gameOverLogo[i]);


            }
            Console.SetCursorPosition(35, 35);
            Console.WriteLine($"SCORE : {score}");


            if (tick > 20)
            {
                if (tick % 3 == 0)
                {

                }
                else
                {
                    Console.SetCursorPosition(29, 40);
                    Console.WriteLine("PRESS ANY KEY TO RESTART!");
                    // Console.WriteLine($"{tick}");
                }
            }
            else
            {

            }
            tick++;

        }
        public void KeyControl()
        {
            int pressedKey; // 정수형 변수 선언

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
                        striker.strikerY--;
                        if (striker.strikerY < 4)
                            striker.strikerY = 4;
                        break;
                    case (int)KeyCode.LEFTKEY:
                        striker.strikerX--;
                        if (striker.strikerX < 2)
                            striker.strikerX = 2;
                        break;
                    case (int)KeyCode.RIGHTKEY:
                        striker.strikerX++;
                        if (striker.strikerX > MAX_WINDOW_WIDTH - 5)
                            striker.strikerX = MAX_WINDOW_WIDTH - 5;
                        break;
                    case (int)KeyCode.DOWNKEY:
                        striker.strikerY++;
                        if (striker.strikerY > MAX_WINDOW_HEIGHT - 4)
                            striker.strikerY = MAX_WINDOW_HEIGHT - 4;
                        break;
                    case (int)KeyCode.SPACEBAR:  // 총알 발사
                        striker.FireBullet();
                        break;
                    case (int)KeyCode.X:  // 총알 발사
                        striker.FireBullet();
                        break;
                    case (int)KeyCode.x:  // 총알 발사
                        striker.FireBullet();
                        break;
                }
            }
            return;
        }
        internal void StartGame()
        {
            if (Console.KeyAvailable) // 키입력이 들어올 경우 true
            {
                this.score = 0;
                this.life = 3;
                this.tick = 0;
                this.difficulty = 1;
                this.currentEnemyCount = 1;
                this.scene = "inGame";
            }
        }
    }
    public class Striker
    {
        private const int BULLET_MAX = 30;

        // 배열 문자열로 그리기
        static String[] strikerSprite = new string[]
        {
                    "  ▲  ",
                    "  ※  ",
                    "▲■▲"
        };
        public int strikerX;
        public int strikerY;

        public int upgrade = 1;
        public bool upgradeFlag = true;
        public int recreateCount = 10;
        public Bullet[] bullets = new Bullet[BULLET_MAX];

        public Striker()
        {
            for (int i = 0; i < BULLET_MAX; i++)
            {
                bullets[i] = new Bullet();
            }
            this.strikerX = MAX_WINDOW_WIDTH / 2;
            this.strikerY = MAX_WINDOW_HEIGHT * 3 / 4;
        }

        public void DrawStriker()
        {
            if (recreateCount > 0)
            {
                if (recreateCount % 2 == 0)
                {
                    for (int i = 0; i < strikerSprite.Length; i++)
                    {
                        // 콘솔좌표 설정 플레이어X 플레이어Y
                        Console.SetCursorPosition(strikerX - 1, strikerY + i);
                        // 문자열배열 출력
                        Console.WriteLine(strikerSprite[i]);
                    }
                }
                recreateCount--;
            }
            else
            {
                for (int i = 0; i < strikerSprite.Length; i++)
                {
                    // 콘솔좌표 설정 플레이어X 플레이어Y
                    Console.SetCursorPosition(strikerX - 1, strikerY - 1 + i);
                    // 문자열배열 출력
                    Console.WriteLine(strikerSprite[i]);
                }
            }
        }
        public void Upgrade()
        {
            if (upgradeFlag)
            {
                if(upgrade < 3)
                {
                    upgrade += 1;
                    upgradeFlag = false;
                }
            }
            return;
        }

        public void DrawBullet()
        {
            string bullet = "↑"; // 미사일 모습

            for (int i = 0; i < BULLET_MAX; i++)
            {
                //미사일이 살아있는 상태
                if (bullets[i].fire == true)
                {
                    // 좌표설정 -> 앞에서 나가도록 y - 1
                    Console.SetCursorPosition(bullets[i].x + 1, bullets[i].y);
                    // 총알 출력
                    Console.Write(bullet);

                    bullets[i].y--; //미사일 위쪽으로 날라가기

                    if (bullets[i].y < 5) // 화면 천장에 닿으면 초기화
                    {
                        bullets[i].fire = false;  //미사일 false 다시 준비상태
                    }
                }
            }
        }
        internal void FireBullet()
        {

            for (int i = 0; i < 10; i++)
            {
                if (upgrade == 1)
                {
                    if (bullets[i].fire == false)
                    {
                        bullets[i].fire = true;
                        // 플레이어 위로 발사 Y좌표 - 2
                        bullets[i].x = strikerX;
                        bullets[i].y = strikerY - 2;
                        // 한발씩 사격
                        break;
                    }
                }
                else if (upgrade == 2)
                {
                    if (bullets[i * 2].fire == false && bullets[i * 2 + 1].fire == false)
                    {
                        bullets[i * 2].fire = true;
                        bullets[i * 2 + 1].fire = true;
                        // 플레이어 위로 발사
                        bullets[i * 2].x = strikerX - 1;
                        bullets[i * 2].y = strikerY - 2;
                        bullets[i * 2 + 1].x = strikerX + 1;
                        bullets[i * 2 + 1].y = strikerY - 2;
                        break;
                        // 두발씩 사격                     
                    }                  
                }
                else if (upgrade == 3)
                {
                    if (bullets[i * 3].fire == false && bullets[i * 3 + 1].fire == false && bullets[i * 3 + 2].fire == false)
                    {
                        bullets[i * 3].fire = true;
                        bullets[i * 3 + 1].fire = true;
                        bullets[i * 3 + 2].fire = true;
                        // 플레이어 위로 발사 
                        bullets[i * 3].x = strikerX - 1;
                        bullets[i * 3].y = strikerY - 2;
                        bullets[i * 3 + 1].x = strikerX;
                        bullets[i * 3 + 1].y = strikerY - 3;
                        bullets[i * 3 + 2].x = strikerX + 1;
                        bullets[i * 3 + 2].y = strikerY - 2;
                        // 세발씩 사격
                        break;
                    }
                }
            }
        }
        internal void Recreate()
        {
            upgrade = 1;
            this.strikerX = MAX_WINDOW_WIDTH / 2;
            this.strikerY = MAX_WINDOW_HEIGHT * 3 / 4;
            recreateCount = 10;
        }
    }
    public class Enemy
    {
        // 배열 문자열로 그리기
        static String[] enemySprite = { "<-※->" };

        public int enemyX;
        public int enemyY;

        public Enemy()
        {
            Random rand = new Random();
            enemyX = rand.Next(5, 20);
            enemyY = rand.Next(5, 35);
        }
        internal void MoveEnemy()
        {
            Random rand = new Random();
            // 랜덤
            enemyX++; // 오른쪽으로 움직임                
            if (enemyX > MAX_WINDOW_WIDTH - 4) //화면 왼쪽넘어가면 새로 좌표잡아라
            {
                enemyX = 5;
                enemyY += rand.Next(1, 4);
            }
            if (enemyY > MAX_WINDOW_HEIGHT - 10)
            {
                enemyY = 5;
            }
        }
        internal void DrawEnemy()
        {

            Console.SetCursorPosition(enemyX - 2, enemyY); // 좌표설정
            Console.Write(enemySprite[0]); // 출력
        }

        internal void Recreate()
        {
            Random rand = new Random();
            enemyX = 5 + 2;
            enemyY = rand.Next(5, 20);
        }
    }
    public class Bullet
    {
        public int x;
        public int y;
        public bool fire;

        public Bullet()
        {
            this.x = 0;
            this.y = 0;
            this.fire = false;
        }
    }
    public class Item
    {
        public string ItemName;
        public string ItemSprite = "◎";
        public int itemX = 0;
        public int itemY = 0;
        // public int leftRight = 0; // 0일때 왼쪽 1일때 오른쪽(팅기는 아이템을 위한)
        public bool itemAvailavle = false;

        public void DrawItem()
        {
            if (itemAvailavle)
            {
                Console.SetCursorPosition(itemX + 1, itemY);
                Console.Write(ItemSprite);
            }
        }

        public void MoveItem()
        {
            if (itemAvailavle)
            {
                itemY++;
            }
            if (itemY > MAX_WINDOW_HEIGHT - 5) // 충분히 바닥에 갔을때 
            {
                itemAvailavle = false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MainGame mainGame = new MainGame();
            Console.CursorVisible = false;

            // 유니티처럼 프레임 단위 갱신
            int dwTiime;
            dwTiime = Environment.TickCount; // 1/1000 초 계산
            int tickTime = 100; // 0.03초마다 재생
            while (true)
            {
                // 0.03초마다 재생
                if (dwTiime + tickTime < Environment.TickCount)
                {

                    dwTiime = Environment.TickCount;

                    if (mainGame.scene == "main")
                    {
                        Console.Clear();
                        mainGame.DrawMain();
                        mainGame.StartGame();
                    }
                    else if (mainGame.scene == "inGame")
                    {
                        // Console.WriteLine(dwTiime);
                        Console.Clear();
                        mainGame.Game();
                    }
                    else if (mainGame.scene == "gameOver")
                    {
                        Console.Clear();
                        mainGame.DrawGameOver();
                        if (mainGame.tick > 20)
                        {
                            mainGame.StartGame();
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
