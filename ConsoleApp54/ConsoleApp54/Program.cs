using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp54
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("프로그램 종료");

            string path = Environment.GetEnvironmentVariable("PATH");
            // Console.WriteLine($"PATH: {path}");
            //Environment.Exit(0);

            Random random = new Random();

            int randomNumber = random.Next(1, 101);
            Console.WriteLine("랜덤 숫자 : " + randomNumber);

            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 100; i++)
            {
                // Thread.Sleep(1);
            }

            stopwatch.Stop();

            Console.WriteLine($"for 시간 {stopwatch.ElapsedMilliseconds}ms");


            string input = "Hello, my phone number is 010-1234-5678";
            string pattern = @"\d{3}-\d{4}-\d{4}$";

            bool isMatch = Regex.IsMatch(input, pattern);
            Console.WriteLine($"Is valid phone number: {isMatch}");

            // [접근 지정자]
            // public(공개)       
            // private(비공개)       
            // protected(상속된 대상만 공개)

            // [수정자]
            // abstract 추상 클래스
            // seald 상속 불가능
            // static 정적

            // 클래스 이름

            // : 부모클래스 , 인터페이스
            // : BaseClass  ,IComparable




        }
    }
}
