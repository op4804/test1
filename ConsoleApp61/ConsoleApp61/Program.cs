using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp61
{
    class Cup<T>
    {
        public T content { get; set; }

        public void ShowContent()
        {
            Console.WriteLine($"content: {content}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cup<string> cupOfString = new Cup<string> { content = "Coffee" };
            Cup<int> cupOfInt = new Cup<int> { content = 42 };

            cupOfString.ShowContent();
            cupOfInt.ShowContent();

            Stack<int> stack = new Stack<int>();

            stack.Push(30);
            stack.Push(20);
            stack.Push(10);

            while(stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
            names.Add("Dave");

            foreach(var name in names)
            {
                Console.WriteLine(name);
            }

            // IEnumerator
            // C# 컬렉션 순회 반복할 수 있는 인터페이스

            ArrayList list = new ArrayList { "Apple", "Banana", "Cherry" };

            IEnumerator enumerator = list.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

        }

    }
}

