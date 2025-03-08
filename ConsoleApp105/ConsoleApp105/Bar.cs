using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp105
{
    class Bar
    {
        public BarData myBar = new BarData();
        int isCatch; //공을 잡았는지 체크

        const int LEFTKEY = 75; // 상수로 만들어준다.  변수에 값 대입 x

        public void Initialize()
        {
            isCatch = 0;

            myBar.y = 18;
            myBar.xs[0] = 12;
            myBar.xs[1] = 14;
            myBar.xs[2] = 16;

        }

        //공의 객체를 가지고와서 잡았는지 판단및 움직임도 줘야함 ref 로 인자값 전달 참조 
        public void Progress(ref Ball pBall)
        {
            int nKey = 0;

            if (Console.KeyAvailable)
            {
                nKey = Program._getch(); //키눌림 값

                switch (nKey)
                {
                    case LEFTKEY: //왼쪽 
                        myBar.xs[0]--;
                        myBar.xs[1]--;
                        myBar.xs[2]--;

                        if (pBall.GetBall().isReady == 1 && isCatch == 1)
                        {
                            //공이 잡힌상태
                            pBall.SetX(-1); //공왼쪽으로 움직이게 값주기
                        }

                        break;
                    case 77:
                        myBar.xs[0]++;
                        myBar.xs[1]++;
                        myBar.xs[2]++;

                        if (pBall.GetBall().isReady == 1 && isCatch == 1)
                        {
                            //공이 잡힌상태
                            pBall.SetX(1);//공오른쪽으로 움직이게 값주기
                        }
                        break;
                    case 'a':
                        pBall.SetReady(0); //공이움직임 
                        isCatch = 0;
                        break;
                    case 's':
                        if (pBall.GetBall().x >= myBar.xs[0] &&
                            pBall.GetBall().x <= myBar.xs[2] + 1 &&
                            pBall.GetBall().y == (myBar.y - 1))
                        {
                            pBall.SetReady(1);
                            isCatch = 1;
                        }
                        break;
                }
            }
        }

        public void Render()
        {
            for (int i = 0; i < 3; i++)
            {
                Program.GoToXY(myBar.xs[i], myBar.y);
                Console.Write("▥");
            }
        }
        public void Release()
        {
        }
    }
}
