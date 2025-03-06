using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] data = { 5, 2, 6, 1, 8 };

            Array.Sort(data);

            foreach (var d in data)
            {
                Console.WriteLine(d);
            }

            int target = 8;
            int index = -1;
            for(int i = 0; i < data.Length; i++)
            {
                if (data[i] == target)
                {
                    index = i;
                    break;
                }
            }

            Console.WriteLine(index >= 0 ? $"Found at index {index}" : "Not Found");
        }
    }
}
