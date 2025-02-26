using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = 3;
            switch (day)
            {
                case 1:
                    Console.WriteLine("월요일");
                    break;
                case 2:
                    Console.WriteLine("화요일");
                    break;
                case 3:
                    Console.WriteLine("수요일");
                    break;
                case 4:
                    Console.WriteLine("목요일");
                    break;
                case 5:
                    Console.WriteLine("금요일");
                    break;
                case 6:
                    Console.WriteLine("토요일");
                    break;
                case 7:
                    Console.WriteLine("일요일");
                    break;
                default:
                    Console.WriteLine("유효하지 않은 요일입니다.");
                    break;
            }
        }
    }
}
