using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp38
{
    class Program
    {

        enum DayOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday,
        }

        enum StatusCode
        {
            Sucess = 200,
            BadRequest = 400,
            Unauthorized = 401,
            NotFound = 404,
        }


        static void Main(string[] args)
        {
            // Math클래스 사용
            // 수학적 계산 
            Console.WriteLine($"Pi: {Math.PI}");
            Console.WriteLine($"Square root of 25: {Math.Sqrt(25)}");
            Console.WriteLine($"Power (2^3): {Math.Pow(2, 3)}");
            Console.WriteLine($"Round(3.75): {Math.Round(3.75)}");

            DayOfWeek today = DayOfWeek.Wednesday;

            //숫자를 직접 사용하지 않고, 의미 있는 이름으로 관리 가능
            Console.WriteLine(today);
            Console.WriteLine((int)today);

            StatusCode status = StatusCode.NotFound;
            Console.WriteLine(status);
            Console.WriteLine((int)status);



        }
    }
}
