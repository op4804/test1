using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp78
{

    class Player
    {
        public string name;

        public void Render()
        {
            Console.WriteLine($"플레이어 : {name}");
        }
    }

    class Wizard : Player
    {
        public string job;

        public void Render2()
        {
            Console.WriteLine($"직업은 {job} 입니다.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player();

            p.name = "강나단";
            p.Render();
            // p.Render2(); 자식 꺼 못쓴다. 

            Wizard w = new Wizard();

            w.name = "사우론";
            w.job = "흑마법사";

            w.Render();
            w.Render2();


        }
    }
}
