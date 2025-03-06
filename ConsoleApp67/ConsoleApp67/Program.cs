using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp67
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fruits = new List<string>();
            fruits.Add("사과");
            fruits.Add("바나나");
            fruits.Add("포도");

            foreach(string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }

            Queue<string> works = new Queue<string>();
            works.Enqueue("첫 번째 작업");
            works.Enqueue("두 번째 작업");
            works.Enqueue("세 번째 작업");

            while(works.Count > 0)
            {
                Console.WriteLine($"{works.Dequeue()}");
            }

            Stack<int> istack = new Stack<int>();
            istack.Push(10);
            istack.Push(20);
            istack.Push(30);

            while (istack.Count > 0)
            {
                Console.WriteLine($"{istack.Pop()}");
            }


        }
    }
}
