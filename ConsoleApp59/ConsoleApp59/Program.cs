using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp59
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> names = new List<string> { "Alice", "Bob", "Chalie" };

            names.Add("Dave");
            names.Remove("Bob");

            foreach(var name in names)
            {
                Console.WriteLine(name);
            }

            List<int> list = new List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Insert(1, 100);
            list[3] = 4;
            Console.WriteLine(list.Count);

            foreach(int i in list)
            {
                Console.WriteLine(i);
            }

            Stack stack = new Stack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            while(stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
