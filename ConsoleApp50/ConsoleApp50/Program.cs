using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp50
{

    class Marine
    {
        public string name { get; private set; } = "마린";
        public int mineral { get; set; } = 50;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Marine marine = new Marine();
            // marine.name = "김마린"; // 같은 class가 아니라 사용 불가능.
            Console.WriteLine($"이름: {marine.name}");


            Console.WriteLine($"미네랄: {marine.mineral}");
            marine.mineral = 500;
            Console.WriteLine($"미네랄: {marine.mineral}");


        }
    }
}

