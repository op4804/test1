using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp97
{
    class Player
    {
        public INFO m_Info;

        // 데미지 피격 함수
        public void GetDamage(int iAttack)
        {
            m_Info.iHp -= iAttack;
        }

        // 플레이어 정보 출력 함수
        public INFO GetInfo()
        {
            return m_Info;
        }

        // hp 재설정 함수
        public void SetHp(int iHp)
        {
            m_Info.iHp = iHp;
        }

        //직업선택
        public void SelectJob()
        {
            m_Info = new INFO();

            Console.WriteLine("직업을 선택하세요. 1.기사 2.마법사 3.도적");
            Console.Write("번호를 입력해 주세요: ");
            int iInput = 0;

            iInput = int.Parse(Console.ReadLine());

            switch (iInput)
            {
                case 1:
                    m_Info.strName = "기사";
                    m_Info.iHp = 100;
                    m_Info.iAttack = 10;
                    break;
                case 2:
                    m_Info.strName = "마법사";
                    m_Info.iHp = 80;
                    m_Info.iAttack = 20;
                    break;
                case 3:
                    m_Info.strName = "도적";
                    m_Info.iHp = 90;
                    m_Info.iAttack = 15;
                    break;
            }
        }



        public void Render()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("직업 이름 : " + m_Info.strName);
            Console.WriteLine("체력 : " + m_Info.iHp + "\t공격력 :  " + m_Info.iAttack);
        }


        public Player() { }

        ~Player() { } //소멸자
    }
}
