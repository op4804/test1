using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp30
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] mat = new int[2, 3]{{1, 2, 3}, {2, 3, 4}};          

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.WriteLine(i.ToString() + " " + j.ToString() + " " + mat[i, j]);
                }
            }
            int[][] mat1 = new int[2][];

            mat1[0] = new int[3];
            mat1[1] = new int[3];

            mat1[0][0] = 1;
            mat1[0][1] = 2;
            mat1[0][2] = 3;
            mat1[1][0] = 4;
            mat1[1][1] = 5;
            mat1[1][2] = 6;

            for(int i = 0; i < mat1.Length; i++)
            {
                for(int j = 0; j < mat1[i].Length; j++)
                {
                    Console.WriteLine(mat1[i][j]);
                }
            }

            Console.WriteLine("가변 배열");
            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = new int[] { 1, 2 };
            jaggedArray[1] = new int[] { 3, 4, 5 };
            jaggedArray[2] = new int[] { 6 };


            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write($"{jaggedArray[i][j]}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("var 키워드 사용");
            var numbers = new[] { 1, 2, 3, 4, 5 };
            Console.WriteLine($"배열 타입: {numbers.GetType()}");
        }
    }
}
