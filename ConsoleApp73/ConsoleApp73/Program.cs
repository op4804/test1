using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp73
{
    class Program
    {
        static void Main(string[] args)
        {
            //근삿값 구하기: NEAR 알고리즘
            //배열에서 특정 값에 가장 가까운 값을 찾는 예제

            int[] data = { 10, 12, 20, 25, 30 };
            int target = 22;
            int nearest = data[0];

            foreach (var d in data)
            {
                if (Math.Abs(d - target) < Math.Abs(nearest - target))
                    nearest = d;
            }


            Console.WriteLine($"Nearest to {target}: {nearest}");
        }
    }
}
