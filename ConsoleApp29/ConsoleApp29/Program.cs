using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{
    class Program
    {
        static void Main(string[] args)
        {
            // 배열 Array

            int[] num = new int[3]; // 3개 메모리 할당.

            num[0] = 10;
            num[1] = 20;
            num[2] = 30;

            for (int i = 0; i < num.Length; i++)
            {
                Console.WriteLine(num[i]);
            }

            int[] numbers1 = { 1, 2, 3 }; // 간단한 선언과 초기화
            int[] numbers2 = new int[3]; // 크기만 지정 (0으로 초기화)
            int[] numbers3 = new int[] { 1, 2, 3 }; // 초기화와 함께 선언

            for (int i = 0; i < numbers2.Length; i++)
            {
                Console.WriteLine(numbers2[i]);
            }

            string[] fruits = { "사과", "바나나", "오렌지" };

            for(int i = 0; i < fruits.Length; i++)
            {
                Console.WriteLine(fruits[i]);
            }

            double value = 123.456789;

            Console.WriteLine(value.ToString("F2"));
            Console.WriteLine($"소수 셋째: {value:F3}");
            Console.WriteLine(String.Format("소숫점 넷째 자리: {0:F4}", value));

            Console.WriteLine(value.ToString("F0"));

            value = 1234235.123124;

            Console.WriteLine(value.ToString("N2")); // 3번째 자리마다 쉼표

            float[] p1 = new float[5];
            float[] p2 = new float[5];
            float[] p3 = new float[5];

            string subject = default;

            string input = default;
            Console.WriteLine("3명의 국어, 영어, 수학 점수를 입력해 주세요");

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    subject = "국어";
                }
                else if (i == 1)
                {
                    subject = "영어";
                }
                else
                {
                    subject = "수학";
                }
                Console.Write($"첫 번째 사람의 {subject}점수: ");
                input = Console.ReadLine();
                p1[i] = int.Parse(input);
            }
            p1[3] = p1[0] + p1[1] + p1[2];
            p1[4] = p1[3] / 3;

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    subject = "국어";
                }
                else if (i == 1)
                {
                    subject = "영어";
                }
                else
                {
                    subject = "수학";
                }
                Console.Write($"두 번째 사람의 {subject}점수: ");
                input = Console.ReadLine();
                p2[i] = int.Parse(input);
            }
            p2[3] = p2[0] + p2[1] + p2[2];
            p2[4] = p2[3] / 3;

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    subject = "국어";
                }
                else if (i == 1)
                {
                    subject = "영어";
                }
                else
                {
                    subject = "수학";
                }
                Console.Write($"세 번째 사람의 {subject}점수: ");
                input = Console.ReadLine();
                p3[i] = int.Parse(input);
            }
            p3[3] = p3[0] + p3[1] + p3[2];
            p3[4] = p3[3] / 3;

            Console.WriteLine($"첫번째 사람의 국어점수는 {p1[0]}점, 영어 점수는 {p1[1]}점, 수학 점수는 {p1[2]}점, 총점은 {p1[3]}점, 평균은 {p1[4].ToString("F2")}점 입니다");
            Console.WriteLine($"첫번째 사람의 국어점수는 {p2[0]}점, 영어 점수는 {p2[1]}점, 수학 점수는 {p2[2]}점, 총점은 {p2[3]}점, 평균은 {p2[4].ToString("F2")}점 입니다");
            Console.WriteLine($"첫번째 사람의 국어점수는 {p3[0]}점, 영어 점수는 {p3[1]}점, 수학 점수는 {p3[2]}점, 총점은 {p3[3]}점, 평균은 {p3[4].ToString("F2")}점 입니다");




        }
    }
}
