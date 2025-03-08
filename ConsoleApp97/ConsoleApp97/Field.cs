using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp97
{
    class Field
    {
        Player m_Player;
        Monster m_Monster;

        public void SetPlayer(ref Player pPlayer)
        {
            m_Player = pPlayer;
        }
        public void Progress()
        {
            int iInput = 0;

            while (true)
            {
                Console.Clear();
                m_Player.Render();
                DrawMap();

                iInput = int.Parse(Console.ReadLine());

                if (iInput <= 3)
                {
                    //몬스터를 만들고
                    //1번일때 초보몬스터
                    //2번일때 중급몬스터
                    //3번일때 고급몬스터
                    CreateMonster(iInput);
                    //싸운다
                    Fight();
                }
                if (iInput == 4)
                {
                    break;
                }

            }
        }
        public void Create(string _strName, int _iHp, int _iAttack, out Monster pMonster)
        {
            pMonster = new Monster(); //몬스터 생성
            INFO monster = new INFO(); //몬스터데이터 메모리 주기 객체 생성

            monster.strName = _strName; //초보몬스터 ,중,고
            monster.iHp = _iHp; //체력
            monster.iAttack = _iAttack; //공격력

            pMonster.SetMonster(monster); //생성된 데이터 INFO 클래스타입 이자로 데이터 세팅

        }

        public void CreateMonster(int input)
        {
            switch (input)
            {
                case 1:
                    //공장처럼 찍어내준다. 
                    //디자인패턴 팩토리 메서드 패턴
                    Create("초보몹", 30, 3, out m_Monster);
                    break;
                case 2:
                    Create("중수몹", 60, 6, out m_Monster);
                    break;
                case 3:
                    Create("고수몹", 90, 9, out m_Monster);
                    break;
            }


        }

        public void Fight()
        {
            int iInput = 0;

            while (true)
            {
                Console.Clear(); //콘솔화면 지움
                m_Player.Render(); //플레이어 정보 출력
                m_Monster.Render(); //몬스터 정보출력


                Console.WriteLine("1.공격 2.도망 : "); //1,2 선택 표시
                iInput = int.Parse(Console.ReadLine());

                if (iInput == 1)
                {
                    //플레이어 데미지 주기 몬스터공격력 넣어서 데미지
                    m_Player.GetDamage(m_Monster.GetMonster().iAttack);
                    //몬스터 데미지 주기 플레이어 공격력 넣기
                    m_Monster.GetDamage(m_Player.GetInfo().iAttack);

                    if (m_Player.GetInfo().iHp <= 0) //플레이어 체력이 0이하이면
                    {
                        m_Player.SetHp(100);
                        break;
                    }
                }

                if (iInput == 2 || m_Monster.GetMonster().iHp <= 0)
                {
                    m_Monster = null;
                    break; //탈출
                }
            }
        }

        public void DrawMap()
        {
            Console.WriteLine("1. 초보맵");
            Console.WriteLine("2. 중수맵");
            Console.WriteLine("3. 고수맵");
            Console.WriteLine("4. 전단계");
            Console.WriteLine("=============");
            Console.WriteLine("맵을 선택하세요 :");
        }
    }
}
