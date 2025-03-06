using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp60
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayList arrayList = new ArrayList();

            arrayList.Add(1);
            arrayList.Add("Hello");
            arrayList.Add(3.14);

            Console.WriteLine("");
            foreach(var item in arrayList)
            {
                Console.WriteLine(item);
            }

            arrayList.Remove(1);

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            // 해쉬 테이블

            Hashtable hashtable = new Hashtable();

            hashtable["Alice"] = 25;
            hashtable["Bob"] = 30;
            hashtable["포션"] = 20;

            Console.WriteLine("Hashtable:");

            foreach(DictionaryEntry entry in hashtable)
            {
                Console.WriteLine($"Key: {entry.Key} Value: {entry.Value}");
            }

            //특정 키의 값 가져오기
            Console.WriteLine($"Alice의 나이 : {hashtable["Alice"]}");

            //요소제거
            hashtable.Remove("Bob");

            Console.WriteLine("Remove Bob");
            Console.WriteLine("Hashtable:");
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine($"Key : {entry.Key}, Value : {entry.Value}");
            }


            Cup<string> cupOfString = new Cup<string> { content = "Coffee" };
            Cup<int> cupOfInt = new Cup<int> { content = 42 };

            cupOfString.ShowContent();
            cupOfInt.ShowContent();

        }
        class Cup<T>
        {
            public T content { get; set; }

            public void ShowContent()
            {
                Console.WriteLine($"content: {content}");
            }
        }
    }
}
