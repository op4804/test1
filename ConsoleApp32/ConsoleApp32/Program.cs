using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp32
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 5;
            int[,] bingo = new int[size, size];
            bool[,] bingoCheck = new bool[size, size];

            // 기본값 입력
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    bingo[i, j] = i * size + j + 1;
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    bingoCheck[i, j] = false;
                }
            }

            // 셔플링
            Random rand = new Random();
            int a, b, c, d;
            int temp;
            for (int i = 0; i < 100; i++)
            {
                a = rand.Next(0, size);
                b = rand.Next(0, size);
                c = rand.Next(0, size);
                d = rand.Next(0, size);
                temp = bingo[a, b];
                bingo[a, b] = bingo[c, d];
                bingo[c, d] = temp;
            }

            int bingoCount = 0;
            int lineCount = 0;
            int diagonalR = 0;
            int diagonalL = 0;

            while (true)
            {
                // 빙고 체크
                for (int i = 0; i < size; i++)
                {
                    lineCount = 0;
                    for (int j = 0; j < size; j++)
                    {
                        if (bingoCheck[i, j])
                        {
                            lineCount++;
                        }
                    }
                    if (lineCount == size)
                    {
                        bingoCount++;
                    }
                }
                for (int i = 0; i < size; i++)
                {
                    lineCount = 0;
                    for (int j = 0; j < size; j++)
                    {
                        if (bingoCheck[j, i])
                        {
                            lineCount++;
                        }
                    }
                    if (lineCount == size)
                    {
                        bingoCount++;
                    }
                }
                // 대각선 체크
                diagonalL = 0;
                diagonalR = 0;
                for (int i = 0; i < size; i++)
                {
                    if (bingoCheck[i, i])
                    {
                        diagonalR++;
                    }
                    if (bingoCheck[size - i - 1, i])
                    {
                        diagonalL++;
                    }
                }
                if (diagonalL == size)
                {
                    bingoCount++;
                }
                if (diagonalR == size)
                {
                    bingoCount++;
                }
                if (bingoCount < 5)
                {
                    Console.Clear();
                    bingoCount = 0;
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (bingoCheck[i, j])
                            {
                                Console.Write("*  ");
                            }
                            else
                            {
                                Console.Write($"{bingo[i, j].ToString("D2")} ");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine("------------------------");
                    Console.WriteLine($"빙고 갯수: {bingoCount}");
                    Console.Write("숫자를 입력하세요: ");
                    string input = "";
                    input = Console.ReadLine();
                    if (int.TryParse(input, out int num))
                    {
                        if (num > 0 && num < size * size + 1)
                        {
                            for (int i = 0; i < size; i++)
                            {
                                for (int j = 0; j < size; j++)
                                {
                                    if (bingo[i, j] == num)
                                    {
                                        bingoCheck[i, j] = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("wrong number");
                        }
                    }
                    else
                    {
                        Console.WriteLine("wrong input");
                    }
                }
                else
                {
                    break;
                }
            }
            Console.Clear();
            Console.WriteLine("5빙고 완성! 고생하셨습니다.");
        }
    }
}
