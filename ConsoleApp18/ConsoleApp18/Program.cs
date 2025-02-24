using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c = default;
            string input = default;
            Console.WriteLine("세 정수를 입력해 주세요.");
            Console.Write("a 의 값 입력: ");
            input = Console.ReadLine();
            a = Int32.Parse(input);
            Console.Write("b 의 값 입력: ");
            input = Console.ReadLine();
            b = Int32.Parse(input); 
            Console.Write("c 의 값 입력: ");
            input = Console.ReadLine();
            c = Int32.Parse(input);

            int d = a > b ? a : b;
            int max = d > c ? d : c;

            Console.WriteLine($"입력한 세 정수는 각각 a {a}, b {b}, c {c}이고, ");
            Console.WriteLine($"입력한 세 정수증 가장 큰 수는 {max} 입니다.");
            Console.WriteLine();
            Console.WriteLine();

            int score = default;
            Console.Write("시험 점수를 입력해 주세요: ");
            input = Console.ReadLine();
            score = Int32.Parse(input);

            if(score >= 90)
            {
                Console.WriteLine("당신은 A학점입니다.");
            }
            else if(score >= 80)
            {
                Console.WriteLine("당신은 B 학점입니다.");
            }
            else if (score >= 70)
            {
                Console.WriteLine("당신은 C 학점입니다.");
            }
            else if (score >= 60)
            {
                Console.WriteLine("당신은 D 학점입니다.");
            }
            else
            {
                Console.WriteLine("당신은 F 학점입니다. 재수강을 해주세요.");
            }

            Console.WriteLine();
            Console.WriteLine();

            float x, y = default;

            Console.WriteLine("간단한 계산기입니다. 두가지 숫자와 사칙연산(+,-,*./)를 입력해 주세요.");
            Console.Write("첫번째 숫자를 입력해 주세요: ");
            input = Console.ReadLine();
            x = float.Parse(input);
            Console.Write("첫번째 숫자를 입력해 주세요: ");
            input = Console.ReadLine();
            y = float.Parse(input);
            Console.Write("사칙 연산기호를 입력해 주세요(+,-,*./): ");
            input = Console.ReadLine();
            if(input == "+")
            {
                Console.WriteLine($"{x} + {y} = {x + y}");
            }
            else if (input == "-")
            {
                Console.WriteLine($"{x} - {y} = {x - y}");
            }
            else if (input == "*")
            {
                Console.WriteLine($"{x} * {y} = {x * y}");
            }
            else if (input == "/")
            {
                if(y == 0)
                {
                    Console.WriteLine("0으로 나눌 수 없습니다. ");
                }
                else
                {
                    Console.WriteLine($"{x} / {y} = {x / y}");
                }
            }
            else
            {
                Console.WriteLine("기호를 잘못입력 하셨습니다. ");
            }





        }
    }
}
