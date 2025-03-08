using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp97
{
    class Monster
    {
        public INFO m_Monster; // 몬스터 데이터

        public void GetDamage(int iAttack)
        {
            m_Monster.iHp -= iAttack;
        }

        // INFO 클래스 타입 인자로 몬스터 데이터를 넣어준다. 
        public void SetMonster(INFO monster)
        {
            m_Monster = monster;
        }
        public INFO GetMonster()
        {
            return m_Monster;
        }

        public void Render()
        {
            Console.WriteLine("==================");
            Console.WriteLine("몬스터 이름 : " + m_Monster.strName);
            Console.WriteLine("체력: " + m_Monster.iHp + "\t공격력: " + m_Monster.iAttack);
        }

        public Monster() { } //기본 생성자
        ~Monster() { } //소멸자 
    }
}
