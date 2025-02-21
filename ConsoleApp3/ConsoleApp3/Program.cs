using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("이름을 입력하세요: ");
            string userName = Console.ReadLine();

            Console.WriteLine($"안녕하세요, {userName}님!");

            Console.Write("나이를 입력하세요: ");
            string input = Console.ReadLine();
            int age = int.Parse(input);

            Console.WriteLine($"내년에는 {age + 1} 살이 되겠군요!");
            Console.WriteLine("내년에는 " + age + "살이 되겠군요!");
            Console.WriteLine("내년에는 {0} 살이 되겠군요!", age);

        }
    }
}
