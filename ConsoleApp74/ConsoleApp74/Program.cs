using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp74
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] scores = { 90, 70, 50, 70, 60 };

            for (int i = 0; i < scores.Length; i++)
            {
                int rank = 1;

                for (int j = 0; j < scores.Length; j++)
                {
                    if (scores[j] > scores[i])
                    {
                        rank++;
                    }

                }
                Console.WriteLine($"score: {scores[i]} rank: {rank}");
            }
        }
    }
}
