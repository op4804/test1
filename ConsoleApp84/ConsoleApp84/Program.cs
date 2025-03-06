using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp84
{
    class Player
    {
        protected string name;

        public Player()
        {
            name = "플레이어";
            Console.WriteLine("부모 생성자 입니다. ");
        }
    }

    class Wizard : Player
    {
        public Wizard()
        {
            name = "마법사";
            Console.WriteLine("자식 생성자 입니다.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player();
            Wizard w = new Wizard();

        }
    }
}
