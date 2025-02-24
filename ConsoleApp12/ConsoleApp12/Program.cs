using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            int korean = default;
            int english = default;
            int math = default;
            string input = default;
            Console.Write("국어 점수를 입력해 주세요: ");
            input = Console.ReadLine();
            korean = Int32.Parse(input);
            Console.Write("영어 점수를 입력해 주세요: ");
            input = Console.ReadLine();
            english = Int32.Parse(input);
            Console.Write("수학 점수를 입력해 주세요: ");
            input = Console.ReadLine();
            math = Int32.Parse(input);

            Console.WriteLine($"국어 점수는 {korean}점, 영어 점수는 {english}점 수학 점수는 {math}점 입니다.");
            int sum = korean + english + math;
            float average = (float)sum / 3;
            Console.WriteLine($"총점은 {sum}점 / 300점, 평균 점수는 {average.ToString("F2")}점 입니다.");


            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            Console.Write("정수를 입력하세요: ");
            input = Console.ReadLine();
            int num = Int32.Parse(input);
            string decimalStr = Convert.ToString(num, 2);
            int decimalInt = Int32.Parse(decimalStr);
            Console.WriteLine($"입력한 정수: {num}, 이진 값: {decimalInt.ToString("D32")}");
            Console.WriteLine($"변환한 정수: {~num}, 이진 값: {Convert.ToString(~num, 2)}");


        }
    }
}
