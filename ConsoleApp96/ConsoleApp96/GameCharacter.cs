using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp96
{
    public abstract class GameCharacter
    {
        public string name;
        public int health;
        public int attack;
        public int defence;

        protected GameCharacter(string name, int health, int attack, int defence)
        {
            this.name = name;
            this.health = health;
            this.attack = attack;
            this.defence = defence;
        }

        // 추상 메서드 : 모든 캐릭터가 구현해야하는 기본 공격
        public abstract void BasicAttack(GameCharacter target);
        // 추상 메서드 : 모든 캐릭터가 구현해야하는 특수 공격
        public abstract void SpecialAttack(GameCharacter target);
        // 일반 메서드 : 모든 캐릭터가 공유하는 피격 기능
        public void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(1, damage - defence);

            health = Math.Max(0, health - actualDamage);

            Console.WriteLine($"{name}이 {actualDamage}의 피해를 입었습니다. 남은 체력 {health}");

        }

    }
}
