using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp96
{
    class Warrior : GameCharacter
    {
        public Warrior(string name) : base(name, 100, 15, 10)
        {

        }
        public override void BasicAttack(GameCharacter target)
        {
            Console.WriteLine($"{name}이 {target.name}에게 기본 공격을 시도합니다.!");
            target.TakeDamage(attack);
        }

        public override void SpecialAttack(GameCharacter target)
        {
            Console.WriteLine($"{name}이 {target.name}에게 휠윈드 시전합니다.");
            target.TakeDamage(attack * 2);
        }
    }
}
