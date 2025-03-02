using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShootingGame
{
    //미사일 클래스
    public class BULLET
    {
        public int x;
        public int y;
        public bool fire;
        public int prevX;
        public int prevY;
    }
    //플레이어 클래스
    public class Player
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch();  //c언어 함수 가져옴

        public int prevPlayerX, prevPlayerY;
        public int playerX, playerY;
        public BULLET[] playerBullet = new BULLET[20];
        public BULLET[] playerBullet2 = new BULLET[20];
        public BULLET[] playerBullet3 = new BULLET[20];
        public int Score = 100;
        public Item item = new Item();
        public int itemCount = 0;
        public int maxHP = 100;
        public int currentHP = 100;
        private int prevHP = -1;     // 이전 HP 값 (변경 감지용)


        public Player() //생성자
        {
            //플레이어 좌표위치 초기화
            playerX = 0;
            playerY = 12;

            for (int i = 0; i < 20; i++) //총알 초기화
            {
                playerBullet[i] = new BULLET();
                playerBullet[i].x = 0;
                playerBullet[i].y = 0;
                playerBullet[i].fire = false;

                playerBullet2[i] = new BULLET();
                playerBullet2[i].x = 0;
                playerBullet2[i].y = 0;
                playerBullet2[i].fire = false;


                playerBullet3[i] = new BULLET();
                playerBullet3[i].x = 0;
                playerBullet3[i].y = 0;
                playerBullet3[i].fire = false;
            }


        }

        public void TakeDamage(int damage)
        {
            currentHP -= damage;
            if (currentHP < 0) currentHP = 0;
        }

        public void Heal(int amount)
        {
            currentHP += amount;
            if (currentHP > maxHP) currentHP = maxHP;
        }

        public void GameMain()
        {
            //키를 입력하는 부분
            KeyControl();
            //플레이얼를 그려준다.
            PlayerDraw();

            //UI점수
            UIscore();
            UIhp();

            if (item.ItemLife)
            {
                item.ItemMove();
                item.ItemDraw();
                CrashItem();
            }
        }

        public void KeyControl()
        {
            int pressKey;  //정수형 변수선언 키값 받을거임 

            if (Console.KeyAvailable) //키가 눌렸을때 true
            {
                pressKey = _getch(); //아스키값 왼쪽 오른쪽


                switch (pressKey)
                {
                    case 72:  //위쪽방향 아스키코드                    
                        playerY--;
                        if (playerY < 1)
                            playerY = 1;
                        break;
                    case 75:
                        //왼쪽 화살표키
                        playerX--;
                        if (playerX < 0)
                            playerX = 0;
                        break;
                    case 77:
                        //오른쪽
                        playerX++;
                        if (playerX > 75)
                            playerX = 75;
                        break;
                    case 80: //아래
                        playerY++;
                        if (playerY > 21)
                            playerY = 21;
                        break;
                    case 32: // 스페이스바
                        for (int i = 0; i < 20; i++)
                        {
                            if (playerBullet[i].fire == false)
                            {
                                playerBullet[i].fire = true;
                                playerBullet[i].x = playerX + 5;
                                playerBullet[i].y = playerY + 1;
                                playerBullet[i].prevX = playerBullet[i].x; // 초기화
                                playerBullet[i].prevY = playerBullet[i].y; // 초기화
                                break;
                            }
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            if (playerBullet2[i].fire == false)
                            {
                                playerBullet2[i].fire = true;
                                playerBullet2[i].x = playerX + 5;
                                playerBullet2[i].y = playerY;
                                playerBullet2[i].prevX = playerBullet2[i].x; // 초기화
                                playerBullet2[i].prevY = playerBullet2[i].y; // 초기화
                                break;
                            }
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            if (playerBullet3[i].fire == false)
                            {
                                playerBullet3[i].fire = true;
                                playerBullet3[i].x = playerX + 5;
                                playerBullet3[i].y = playerY + 2;
                                playerBullet3[i].prevX = playerBullet3[i].x; // 초기화
                                playerBullet3[i].prevY = playerBullet3[i].y; // 초기화
                                break;
                            }
                        }
                        break;
                }


            }





        }

        //미사일 그리기
        public void BulletDraw()
        {
            string bullet = "->";
            for (int i = 0; i < 20; i++)
            {
                if (playerBullet[i].fire)
                {
                    // 이전 위치 지우기 (유효성 검사 강화)
                    if (playerBullet[i].prevX >= 0 && playerBullet[i].prevX < 80 &&
                        playerBullet[i].prevY >= 0 && playerBullet[i].prevY < 25)
                    {
                        Console.SetCursorPosition(playerBullet[i].prevX, playerBullet[i].prevY);
                        Console.Write("  ");
                    }

                    // 새로운 위치에 그리기 (화면 범위 내에서만)
                    if (playerBullet[i].x >= 0 && playerBullet[i].x < 80 &&
                        playerBullet[i].y >= 0 && playerBullet[i].y < 25)
                    {
                        Console.SetCursorPosition(playerBullet[i].x, playerBullet[i].y);
                        Console.Write(bullet);
                    }

                    // 이전 위치 업데이트
                    playerBullet[i].prevX = playerBullet[i].x;
                    playerBullet[i].prevY = playerBullet[i].y;

                    // 미사일 이동
                    playerBullet[i].x++;

                    // 화면 밖으로 나가면 제거 및 지우기
                    if (playerBullet[i].x > 78)
                    {
                        playerBullet[i].fire = false;
                        if (playerBullet[i].prevX >= 0 && playerBullet[i].prevX < 80 &&
                            playerBullet[i].prevY >= 0 && playerBullet[i].prevY < 25)
                        {
                            Console.SetCursorPosition(playerBullet[i].prevX, playerBullet[i].prevY);
                            Console.Write("  ");
                        }
                    }
                }
            }
        }


        //미사일 그리기2
        public void BulletDraw2()
        {
            string bullet = "->";
            for (int i = 0; i < 20; i++)
            {
                if (playerBullet2[i].fire) // playerBullet2로 수정
                {
                    if (playerBullet2[i].prevX + 1 >= 0 && playerBullet2[i].prevX + 1 < 80 &&
                        playerBullet2[i].prevY >= 0 && playerBullet2[i].prevY < 25)
                    {
                        Console.SetCursorPosition(playerBullet2[i].prevX + 1, playerBullet2[i].prevY);
                        Console.Write("  ");
                    }
                    Console.SetCursorPosition(playerBullet2[i].x + 1, playerBullet2[i].y);
                    Console.Write(bullet);
                    playerBullet2[i].prevX = playerBullet2[i].x;
                    playerBullet2[i].prevY = playerBullet2[i].y;
                    playerBullet2[i].x++;
                    if (playerBullet2[i].x > 78)
                    {
                        playerBullet2[i].fire = false;
                        if (playerBullet2[i].prevX + 1 >= 0 && playerBullet2[i].prevX + 1 < 80 &&
                            playerBullet2[i].prevY >= 0 && playerBullet2[i].prevY < 25)
                        {
                            Console.SetCursorPosition(playerBullet2[i].prevX + 1, playerBullet2[i].prevY);
                            Console.Write("  ");
                        }
                    }
                }
            }
        }

        public void BulletDraw3()
        {
            string bullet = "->";
            for (int i = 0; i < 20; i++)
            {
                if (playerBullet3[i].fire) // playerBullet3로 수정
                {
                    if (playerBullet3[i].prevX + 1 >= 0 && playerBullet3[i].prevX + 1 < 80 &&
                        playerBullet3[i].prevY >= 0 && playerBullet3[i].prevY < 25)
                    {
                        Console.SetCursorPosition(playerBullet3[i].prevX + 1, playerBullet3[i].prevY);
                        Console.Write("  ");
                    }
                    Console.SetCursorPosition(playerBullet3[i].x + 1, playerBullet3[i].y);
                    Console.Write(bullet);
                    playerBullet3[i].prevX = playerBullet3[i].x;
                    playerBullet3[i].prevY = playerBullet3[i].y;
                    playerBullet3[i].x++;
                    if (playerBullet3[i].x > 78)
                    {
                        playerBullet3[i].fire = false;
                        if (playerBullet3[i].prevX + 1 >= 0 && playerBullet3[i].prevX + 1 < 80 &&
                            playerBullet3[i].prevY >= 0 && playerBullet3[i].prevY < 25)
                        {
                            Console.SetCursorPosition(playerBullet3[i].prevX + 1, playerBullet3[i].prevY);
                            Console.Write("  ");
                        }
                    }
                }
            }
        }
        public void PlayerDraw()
        {
            // 이전 위치 지우기
            Console.SetCursorPosition(prevPlayerX, prevPlayerY);
            Console.Write("  "); // 플레이어 크기에 맞게 공백
            Console.SetCursorPosition(prevPlayerX, prevPlayerY + 1);
            Console.Write("   ");
            Console.SetCursorPosition(prevPlayerX, prevPlayerY + 2);
            Console.Write("  ");

            // 새로운 위치에 그리기
            String[] player = new string[] { "->", ">>>", "->" };
            for (int i = 0; i < player.Length; i++)
            {
                Console.SetCursorPosition(playerX, playerY + i);
                Console.Write(player[i]);
            }

            // 이전 위치 업데이트
            prevPlayerX = playerX;
            prevPlayerY = playerY;
        }

        //충돌처리
        public void ClashEnemyAndBullet(Enemy enemy)
        {
            for (int i = 0; i < 20; i++)
            {
                if (playerBullet[i].fire)
                {
                    if (playerBullet[i].y == enemy.enemyY &&
                        playerBullet[i].x >= (enemy.enemyX - 1) &&
                        playerBullet[i].x <= (enemy.enemyX + 1))
                    {
                        item.ItemLife = true;
                        item.itemX = enemy.enemyX;
                        item.itemY = enemy.enemyY;

                        Random rand = new Random();
                        enemy.enemyX = 75;
                        enemy.enemyY = rand.Next(2, 22);

                        playerBullet[i].fire = false;

                        if (playerBullet[i].prevX >= 0 && playerBullet[i].prevX < 80 &&
                            playerBullet[i].prevY >= 0 && playerBullet[i].prevY < 25)
                        {
                            Console.SetCursorPosition(playerBullet[i].prevX, playerBullet[i].prevY);
                            Console.Write("  ");
                        }

                        Score += 100;
                    }
                }
            }
            for (int i = 0; i < 20; i++)
            {
                if (playerBullet2[i].fire)
                {
                    if (playerBullet2[i].y == enemy.enemyY &&
                        playerBullet2[i].x >= (enemy.enemyX - 1) &&
                        playerBullet2[i].x <= (enemy.enemyX + 1))
                    {
                        Random rand = new Random();
                        enemy.enemyX = 75;
                        enemy.enemyY = rand.Next(2, 22);

                        playerBullet2[i].fire = false;

                        if (playerBullet2[i].prevX >= 0 && playerBullet2[i].prevX < 80 &&
                            playerBullet2[i].prevY >= 0 && playerBullet2[i].prevY < 25)
                        {
                            Console.SetCursorPosition(playerBullet2[i].prevX, playerBullet2[i].prevY);
                            Console.Write("  ");
                        }

                        Score += 100;
                    }
                }
            }
            for (int i = 0; i < 20; i++)
            {
                if (playerBullet3[i].fire)
                {
                    if (playerBullet3[i].y == enemy.enemyY &&
                        playerBullet3[i].x >= (enemy.enemyX - 1) &&
                        playerBullet3[i].x <= (enemy.enemyX + 1))
                    {
                        Random rand = new Random();
                        enemy.enemyX = 75;
                        enemy.enemyY = rand.Next(2, 22);

                        playerBullet3[i].fire = false;

                        if (playerBullet3[i].prevX >= 0 && playerBullet3[i].prevX < 80 &&
                            playerBullet3[i].prevY >= 0 && playerBullet3[i].prevY < 25)
                        {
                            Console.SetCursorPosition(playerBullet3[i].prevX, playerBullet3[i].prevY);
                            Console.Write("  ");
                        }

                        Score += 100;
                    }
                }
            }
        }

        public int prevScore = -1;
        public void UIscore()
        {
            Console.SetCursorPosition(63, 0);
            Console.Write("┏━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(63, 1);
            Console.Write("┃              ┃");
            Console.SetCursorPosition(65, 1);
            Console.Write("Score : " + Score);
            Console.SetCursorPosition(63, 2);
            Console.Write("┗━━━━━━━━━━━━━━┛");
            prevScore = Score;
        }

        public void UIhp()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("┏━━━━┓┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(0, 1);
            Console.Write("┃ HP ┃┃                                          ┃");
            Console.SetCursorPosition(0, 2);
            Console.Write("┗━━━━┛┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

            Console.SetCursorPosition(8, 1);
            Console.Write($"HP: {currentHP}/{maxHP}                         ");

            prevHP = currentHP; // 
        }

        public void CrashItem()
        {
            if (playerY + 1 == item.itemY)
            {
                if (playerX >= item.itemX - 2 && playerX <= item.itemX + 2)
                {
                    item.ItemLife = false;
                    if (itemCount < 3) itemCount++;

                    // 아이템을 즉시 지우기
                    if (item.prevItemX >= 0 && item.prevItemX < 80 && item.prevItemY >= 0 && item.prevItemY < 25)
                    {
                        Console.SetCursorPosition(item.prevItemX, item.prevItemY);
                        Console.Write("     ");
                    }

                    for (int i = 0; i < 20; i++)
                    {
                        if (playerBullet[i].fire && playerBullet[i].prevX >= 0 && playerBullet[i].prevX < 80 &&
                            playerBullet[i].prevY >= 0 && playerBullet[i].prevY < 25)
                        {
                            Console.SetCursorPosition(playerBullet[i].prevX, playerBullet[i].prevY);
                            Console.Write("  ");
                        }
                        playerBullet[i] = new BULLET { x = 0, y = 0, fire = false };

                        if (playerBullet2[i].fire && playerBullet2[i].prevX >= 0 && playerBullet2[i].prevX < 80 &&
                            playerBullet2[i].prevY >= 0 && playerBullet2[i].prevY < 25)
                        {
                            Console.SetCursorPosition(playerBullet2[i].prevX, playerBullet2[i].prevY);
                            Console.Write("  ");
                        }
                        playerBullet2[i] = new BULLET { x = 0, y = 0, fire = false };

                        if (playerBullet3[i].fire && playerBullet3[i].prevX >= 0 && playerBullet3[i].prevX < 80 &&
                            playerBullet3[i].prevY >= 0 && playerBullet3[i].prevY < 25)
                        {
                            Console.SetCursorPosition(playerBullet3[i].prevX, playerBullet3[i].prevY);
                            Console.Write("  ");
                        }
                        playerBullet3[i] = new BULLET { x = 0, y = 0, fire = false };
                    }
                }
            }
        }







    }

    public class Enemy //적 클래스
    {
        public int enemyX;
        public int enemyY;
        public int prevEnemyX;
        public int prevEnemyY;

        public Enemy()
        {
            enemyX = 77;
            enemyY = 12;

        }

        public void EnemyDraw()
        {
            string enemy = "<-0->";


            Console.SetCursorPosition(prevEnemyX, prevEnemyY);
            Console.Write("     ");

            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write(enemy);

            prevEnemyX = enemyX;
            prevEnemyY = enemyY;
        }

        public void EnmeyMove(Player player)
        {
            Random rand = new Random();
            enemyX--;

            if (enemyX < 2)
            {
                player.TakeDamage(10);
                enemyX = 75;
                enemyY = rand.Next(2, 22);
            }

        }

    }

    //아이템 클래스
    public class Item
    {
        public string ItemName;
        public int itemX = 0;
        public int itemY = 0;
        public bool ItemLife = false;
        public int prevItemX;    // 이전 X 위치
        public int prevItemY;    // 이전 Y 위치
        public string ItemSprite = "Item★";

        public void ItemDraw()
        {
            if (ItemLife)
            {
                // 이전 위치 지우기 (화면 범위 내에서만)
                if (prevItemX >= 0 && prevItemX < 80 && prevItemY >= 0 && prevItemY < 25)
                {
                    Console.SetCursorPosition(prevItemX, prevItemY);
                    Console.Write("     "); // 스프라이트 크기에 맞게 공백
                }

                // 새로운 위치에 그리기 (화면 범위 내에서만)
                if (itemX >= 0 && itemX < 80 && itemY >= 0 && itemY < 25)
                {
                    Console.SetCursorPosition(itemX, itemY);
                    Console.Write(ItemSprite);
                }

                // 이전 위치 업데이트
                prevItemX = itemX;
                prevItemY = itemY;
            }
            else
            {
                // 아이템 비활성화 시 이전 위치 지우기
                if (prevItemX >= 0 && prevItemX < 80 && prevItemY >= 0 && prevItemY < 25)
                {
                    Console.SetCursorPosition(prevItemX, prevItemY);
                    Console.Write("     ");
                }
            }
        }

        public void ItemMove()
        {
            if (ItemLife)
            {
                itemX--;
                // 화면 밖으로 나가면 비활성화 및 지우기
                if (itemX < 0)
                {
                    ItemLife = false;
                    if (prevItemX >= 0 && prevItemX < 80 && prevItemY >= 0 && prevItemY < 25)
                    {
                        Console.SetCursorPosition(prevItemX, prevItemY);
                        Console.Write("     ");
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.CursorVisible = false;

            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            Console.Clear();

            Player player = new Player();
            Enemy enemy = new Enemy();

            int dwTime = Environment.TickCount;

            while (true)
            {
                if (dwTime + 50 < Environment.TickCount)
                {
                    dwTime = Environment.TickCount;

                    player.GameMain();

                    if (player.itemCount == 0)
                    {
                        player.BulletDraw();
                    }
                    else if (player.itemCount == 1)
                    {
                        player.BulletDraw();
                        player.BulletDraw2();
                    }
                    else
                    {
                        player.BulletDraw();
                        player.BulletDraw2();
                        player.BulletDraw3();
                    }

                    enemy.EnmeyMove(player);
                    enemy.EnemyDraw();

                    player.ClashEnemyAndBullet(enemy);

                }
            }
        }
    }
}