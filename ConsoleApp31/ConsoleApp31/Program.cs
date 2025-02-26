using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iArray = new int[25];
            int size = 5;

            for (int i = 0; i < iArray.Length; i++)
            {
                iArray[i] = i + 1;
            }

            int a = default;
            int b = default;
            int temp = default;
            Random rand = new Random();

            int cnt = 0;
            int bingo = 0;

            for (int i = 0; i < 100; i++)
            {
                a = rand.Next(0, 25);
                b = rand.Next(0, 25);

                temp = iArray[a];
                iArray[a] = iArray[b];
                iArray[b] = temp;
            }
            while (true)
            {
                // 출력부
                Console.Clear();
                for (int i = 0; i < size; i++)
                {
                    for(int j = 0; j < size; j++)
                    {
                        if (iArray[i * 5 + j] == 0)
                        {
                            Console.Write($"*  ");
                        }
                        else
                        {
                            Console.Write($"{iArray[i * 5 + j].ToString("D2")} ");
                        }
                    }
                    Console.WriteLine();
                }


                // 빙고 체크
                // 가로
                for (int i = 0; i < 5; i++)
                {
                    cnt = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        if (iArray[i * 5 + j] == 0)
                        {
                            cnt++;
                        }                      
                    }
                    if (cnt == 5)
                    {
                        bingo++;
                    }
                }
                // 세로
                for (int i = 0; i < 5; i++)
                {
                    cnt = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        if (iArray[i + 5 * j] == 0)
                        {
                            cnt++;
                        }                        
                    }
                    if (cnt == 5)
                    {
                        bingo++;
                    }
                }
                // 대각선 체크
                /*
                00 01 02 03 04
                05 06 07 08 09
                10 11 12 13 14
                15 16 17 18 19
                20 21 22 23 24
                 
                 */
                if (iArray[0] == 0 && iArray[6] == 0 && iArray[12] == 0 && iArray[18] ==0 && iArray[24] == 0)
                {
                    bingo++;
                }
                if (iArray[4] == 0 && iArray[8] == 0 && iArray[12] == 0 && iArray[16] == 0 && iArray[20] == 0)
                {
                    bingo++;
                }

                // 입력부
                Console.WriteLine();
                Console.WriteLine("-------------------------");
                Console.WriteLine($"빙고 수: {bingo}");
                Console.Write("번호를 입력해주세요: ");
                string input = default;
                input = Console.ReadLine();
                for (int i = 0; i < iArray.Length; i++)
                {
                    if (iArray[i] == int.Parse(input))
                    {
                        iArray[i] = 0;
                    }
                }
                bingo = 0;
            }
        }
    }
}
