using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp97
{
    class MainGame
    {
        public Player m_player;

        // 필드
        public Field m_field;

        public void Initialize()
        {
            m_player = new Player();
            m_player.SelectJob();
        }

        // 게임의 전체적인 과정 정리
        public void Progress()
        {
            int iInput = 0;

            while (true)
            {
                Console.Clear();
                m_player.Render(); // 플레이어 출력
                Console.WriteLine("1.사냥터 2.종료");
                iInput = int.Parse(Console.ReadLine());

                if(iInput == 1)
                {
                    if (m_field == null)
                    {
                        m_field = new Field();
                        //필드로 갈때 플레이어 넣어주기
                        m_field.SetPlayer(ref m_player);
                    }
                    m_field.Progress();
                }

                if(iInput == 2)
                {
                    break;
                }
            }
        }
        public MainGame() { }

        ~MainGame() { }
    }
}
