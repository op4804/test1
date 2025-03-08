using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp105
{
    class Ball
    {
        BallData myBallData = new BallData();

        // C# 공의 방향 배열 정의
        int[,] wallCollission = new int[4, 6]
        {
            {  3,  2, -1, -1 ,-1 , 4 },
            { -1, -1, -1, -1,  2,  1 },
            { -1,  5,  4, -1, -1, -1 },
            { -1, -1,  1,  0,  5, -1 }
        };

        Bar myBar;

        // Bar클래스 가져오기
        public void SetBar(Bar bar) { myBar = bar; }

        public void ScrrenWall()
        {
            Program.GoToXY(0, 0);
            Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Program.GoToXY(0, 1);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 2);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 3);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 4);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 5);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 6);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 7);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 8);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 9);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 10);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 11);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 12);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 13);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 14);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 15);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 16);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 17);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 18);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 19);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 20);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 21);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 22);
            Console.Write("┃                                                                             ┃");
            Program.GoToXY(0, 23);
            Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

        }

        public int Collision(int x, int y)
        {
            //벽충돌
            if (y == 0)
            {
                myBallData.dir = wallCollission[0, myBallData.dir];
                return 1; //공의 방향이 바뀌면 1리턴 
            }

            if (x == 1)
            {
                myBallData.dir = wallCollission[1, myBallData.dir];
                return 1;
            }

            if (x == 77)
            {
                myBallData.dir = wallCollission[2, myBallData.dir];
                return 1;
            }

            if (y == 23)
            {
                myBallData.dir = wallCollission[3, myBallData.dir];
                return 1;
            }

            //Bar충돌처리
            if (x >= myBar.myBar.xs[0] && x <= myBar.myBar.xs[2] + 1 &&
                y == (myBar.myBar.y)) //바 위 충돌
            {
                if (myBallData.dir == 1)
                    myBallData.dir = 2;
                else if (myBallData.dir == 2)
                    myBallData.dir = 1;
                else if (myBallData.dir == 5)
                    myBallData.dir = 4;
                else if (myBallData.dir == 4)
                    myBallData.dir = 5;

                return 1; //방향이 바뀐다.
            }

            if (x >= myBar.myBar.xs[0] && x <= myBar.myBar.xs[2] + 1 &&
              y == (myBar.myBar.y + 1)) //바 아래 충돌
            {
                if (myBallData.dir == 1)
                    myBallData.dir = 2;
                else if (myBallData.dir == 2)
                    myBallData.dir = 1;
                else if (myBallData.dir == 5)
                    myBallData.dir = 4;
                else if (myBallData.dir == 4)
                    myBallData.dir = 5;

                return 1; //방향이 바뀐다.
            }

            return 0;        
        }

        public BallData GetBall()
        {
            return myBallData;
        }
        public void SetX(int x)
        {
            myBallData.x += x;
        }
        public void SetY(int y)
        {
            myBallData.y += y;
        }
        public void SetBall(BallData ballData)
        {
            myBallData = ballData;
        }
        public void SetReady(int ready)
        {
            myBallData.isReady = ready;
        }
        public void Initialize()
        {
            myBallData.isReady = 0;
            myBallData.dir = 1;
            myBallData.x = 30;
            myBallData.y = 10;


        }

        public void Progress()
        {
            if (myBallData.isReady == 0)
            {
                switch (myBallData.dir)
                {
                    case 0: // 위
                        if(Collision(myBallData.x,myBallData.y - 1) == 0)
                        {
                            myBallData.y--;
                        }
                        break;
                    case 1: // 오른쪽 위
                        if (Collision(myBallData.x + 1, myBallData.y - 1) == 0)
                        {
                            myBallData.x++;
                            myBallData.y--;
                        }                            
                        break;
                    case 2: // 오른쪽 아래
                        if (Collision(myBallData.x, myBallData.y + 1) == 0)
                        {
                            myBallData.x++;
                            myBallData.y++;
                        }
                        break;
                    case 3: // 아래
                        if (Collision(myBallData.x, myBallData.y + 1) == 0)
                        {
                            myBallData.y++;                            
                        }                            
                        break;
                    case 4: // 왼쪽 아래
                        if (Collision(myBallData.x - 1, myBallData.y + 1) == 0)
                        {
                            myBallData.x--;
                            myBallData.y++;
                        }
                        break;
                    case 5:
                        if (Collision(myBallData.x - 1, myBallData.y - 1) == 0)
                        {
                            myBallData.x--;
                            myBallData.y--;
                        }
                        break;
                }
            }
        }
        public void Render()
        {
            ScrrenWall();
            Program.GoToXY(myBallData.x, myBallData.y);
            Console.Write("⊙");
        }


        public void Release()
        {

        }
    }
}
