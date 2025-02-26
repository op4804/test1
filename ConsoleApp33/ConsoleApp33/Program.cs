using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp33
{
    class Program
    {
        // 기본
        static void Loading()
        {
            Console.WriteLine("로딩 중.");
        }
        // 값 전달
        static void AttackFunc(int _attack)
        {
            Console.WriteLine($"공격력: {_attack}");
        }
        // 값 반환
        static int EnhanceAttack(int _attack)
        {
            int enhancingAttack = 10;
            _attack += enhancingAttack;

            return _attack;
        }

        static void Main(string[] args)
        {

            Loading();
            Console.WriteLine("메인 화면");

            int attack = 0;
            Console.Write("캐릭터의 공격력을 입력: ");
            attack = int.Parse(Console.ReadLine());

            AttackFunc(attack);
            attack = EnhanceAttack(attack);
            AttackFunc(attack);

        }
    }
}
