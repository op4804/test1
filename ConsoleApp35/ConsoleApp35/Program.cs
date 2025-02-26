using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("02-26 오늘의 문제");
            Console.WriteLine();

            // Q1
            Console.WriteLine("Q1. ");
            int[] iArray1 = new int[5];
            iArray1[0] = 10;
            iArray1[1] = 20;
            iArray1[2] = 30;
            iArray1[3] = 40;
            iArray1[4] = 50;

            for (int i = 0; i < iArray1.Length; i++)
            {
                Console.Write($"{iArray1[i]} ");
            }
            Console.WriteLine();

            // Q2
            Console.WriteLine("Q2. ");

            int[] iArray2 = new int[5];
            string input;
            int sum = 0;
            Console.WriteLine("5개의 정수를 입력해 주세요.");
            for (int i = 0; i < iArray2.Length; i++)
            {
                Console.Write($"{i + 1}번째 정수를 입력 해 주세요: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out int num))
                {
                    iArray2[i] = num;
                    sum += num;
                }
                else
                {
                    Console.WriteLine("잘못 입력하셨습니다. 다시 입력해 주세요.");
                    i--;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"입력한 숫자는 {iArray2[0]}, {iArray2[1]}, {iArray2[2]}, {iArray2[3]}, {iArray2[4]} 이고 총 합은 {sum}입니다.");
            Console.WriteLine();

            // Q3
            Console.WriteLine("Q3. ");
            int[] iArray3 = { 3, 8, 15, 6, 2 };
            int max = iArray3[0];
            for (int i = 0; i < iArray3.Length; i++)
            {
                if (max < iArray3[i])
                {
                    max = iArray3[i];
                }
            }
            Console.Write("배열은 [ ");
            for (int i = 0; i < iArray1.Length; i++)
            {
                Console.Write($"{iArray1[i]} ");
            }
            Console.Write($"] 이고 최댓값은 {max}입니다.");
            Console.WriteLine();

            // Q4
            Console.WriteLine("Q4. ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i + 1} ");
            }
            Console.WriteLine();

            // Q5
            Console.WriteLine("Q5. ");
            int cnt = 0;

            while (cnt < 10)
            {
                cnt++;
                if (cnt % 2 != 0)
                {
                    continue;
                }
                else
                {
                    Console.Write($"{cnt} ");
                }
            }
            Console.WriteLine();

            // Q6
            Console.WriteLine("Q6. ");
            int[] iArray4 = { 1, 2, 3, 4, 5 };

            foreach (int arr in iArray4)
            {
                Console.Write($"{arr} ");
            }
            Console.WriteLine();

            // Q7
            Console.WriteLine("Q7. ");
            int[] nums = new int[2];
            Console.WriteLine("두 개의 정수를 입력해 주세요");

            for (int i = 0; i < 2; i++)
            {
                Console.Write($"{i + 1} 번째 정수를 입력 해 주세요: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out int num))
                {
                    nums[i] = num;
                }
                else
                {
                    Console.WriteLine("잘못 입력하셨습니다. 다시 입력해 주세요.");
                    i--;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"두 정수는 {nums[0]}, {nums[1]} 두 정수의 합은 {Add(nums[0], nums[1])}입니다.");
            int Add(int a, int b)
            {
                return a + b;
            }
            Console.WriteLine();

            // Q8
            Console.WriteLine("Q8. ");
            Console.Write("문자열을 입력해 주세요: ");
            input = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"입력하신 문자열은 {input} 문자열의 길이는 {GetLenthString(input)}입니다.");
            int GetLenthString(string str)
            {
                int strCnt = 0;
                foreach (char a in str)
                {
                    strCnt++;
                }
                return strCnt;
            }
            Console.WriteLine();

            // Q9
            Console.WriteLine("Q9. ");
            int[] iArray5 = new int[3];
            Console.WriteLine("3개의 정수를 입력 해 주세요");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i + 1} 번째 정수를 입력 해 주세요: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out int num))
                {
                    iArray5[i] = num;
                }
                else
                {
                    Console.WriteLine("잘못 입력하셨습니다. 다시 입력해 주세요.");
                    i--;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"세 정수는 {iArray5[0]}, {iArray5[1]}, {iArray5[2]} 이고 가장 큰 수는 {MaxThree(iArray5[0], iArray5[1], iArray5[2])}입니다.");
            int MaxThree(int a, int b, int c)
            {
                int threeMax = 0;
                threeMax = a > b ? a : b;
                threeMax = threeMax > c ? threeMax : b;
                return threeMax;
            }
            Console.WriteLine();
        }
    }
}
