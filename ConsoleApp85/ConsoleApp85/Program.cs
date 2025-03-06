using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp85
{
    class Unit
    {
        public string name;
        public int health;

        public Unit()
        {
            name = "Unknown";
            health = 0;
        }
        public virtual void Attack()
        {
            Console.WriteLine($"{name}이 기본 공격을 합니다. ");
        }
        public virtual void Heal(Unit target)
        {
            Console.WriteLine($"{name}은 치료할 수 없습니다. ");
        }
        public virtual void Move()
        {
            Console.WriteLine($"{name}이 이동합니다. ");
        }
    }

    class SCV : Unit
    {
        public SCV()
        {
            name = "SCV";
            health = 60;
        }
        public override void Attack()
        {
            Console.WriteLine("SCV가 용접기로 공격합니다.! (공격력이 약함)");
        }
        public override void Heal(Unit target)
        {
            Console.WriteLine($"SCV가 {target.name}을 수리합니다.(기계유닛만 가능)");
        }
    }

    class Marine : Unit
    {
        public Marine()
        {
            name = "마린";
            health = 40;
        }
        public override void Attack()
        {
            Console.WriteLine("마린이 소총으로 공격합니다.");
        }
    }

    class Medic : Unit
    {
        public Medic()
        {
            name = "메딕";
            health = 50;
        }

        public override void Heal(Unit target)
        {
            Console.WriteLine($"메딕이 {target.name}을 치료합니다. (생명유닛만가능)");
        }
    }

    class Tank : Unit
    {
        public Tank()
        {
            name = "Tank";
            health = 150;
        }
        public override void Attack()
        {
            Console.WriteLine("탱크가 시즈 모드로 강력한 포격!");
        }
        public override void Move()
        {
            Console.WriteLine("탱크가 천천히 움직입니다.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Unit[] units = new Unit[6];

            units[0] = new SCV();
            units[1] = new SCV();
            units[2] = new Marine();
            units[3] = new Marine();
            units[4] = new Medic();
            units[5] = new Tank();


            foreach (Unit unit in units)
            {
                unit.Move();
                unit.Attack();
                Console.WriteLine();
            }

            units[0].Heal(units[5]);

            units[4].Heal(units[2]);

        }
    }
}
