using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp104
{
    class Program
    {
        static void SayHello()
        {
            Console.WriteLine("안녕하세요");
        }

        static void ShowNotification()
        {
            Console.WriteLine("중요한 알림이 있습니다.");
        }

        static void HelloWorld(string message)
        {
            Console.WriteLine("안녕하세요 " + message);
        }

        static void Main(string[] args)
        {
            // Action은 매개변수가 없고 반환값이 없는 메서드를 참조
            // 메서드 이름에 변수를 저장한다고 생각하면 쉬움. 
            Action action = SayHello;
            action();

            action += ShowNotification;

            action?.Invoke();

            action();

            Action<string> action1 = null;
            action1 += HelloWorld;
            action1 += HelloWorld;
            action1("ttt");

            // 람다식
            Action action2 = null;
            action2 += () => Console.WriteLine("람다식 액션");
            action2();

            Action<int> action3 = null;
            action3 += num => Console.WriteLine("람다식 인자 액션 제곱: " + num * num);
            action3(5);

        }
    }
}
