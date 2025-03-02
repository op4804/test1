using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp48
{
    class Mineral
    {
        int amount;

        public Mineral()
        {
            this.amount = 1500;
        }
    }

    class Marine
    {
        public string name;
        public int attack;
        public int hp;
        public int costMineral;
        public bool isHero;

        public Marine()
        {
            this.name = "마린";
            this.attack = 10;
            this.hp = 100;
            this.costMineral = 50;
            this.isHero = false;
        }
        public Marine(string name)
        {
            this.name = name;
            this.attack = 20;
            this.hp = 200;
            this.costMineral = 200;
            this.isHero = true;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"유닛 이름: {name} / 공격력: {attack} / 체력: {hp} {(isHero ? "/ 영웅유닛" : "")}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Marine m1 = new Marine();
            m1.ShowInfo();

            Marine zim = new Marine("짐 레이너");
            zim.ShowInfo();

            // 클래스의 배열
            Mineral[] minerals = new Mineral[7];
            for(int i = 0; i < minerals.Length; i++)
            {
                minerals[i] = new Mineral();
            }

       }
    }
}
