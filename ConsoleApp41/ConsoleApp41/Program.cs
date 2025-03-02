using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp41
{
    struct Student
    {
        public string name;

        public int gradeKorean;
        public int gradeEnglish;
        public int gradeMath;

        public void Print()
        {
            Console.WriteLine($"{name, -4}{gradeKorean, 6}{gradeEnglish, 6}{gradeMath,6}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[3];

            students[0].name = "홍길동";
            students[0].gradeKorean = 100;
            students[0].gradeEnglish = 80;
            students[0].gradeMath = 70;

            students[1].name = "홍길란";
            students[1].gradeKorean = 90;
            students[1].gradeEnglish = 10;
            students[1].gradeMath = 20;

            students[2].name = "홍길순";
            students[2].gradeKorean = 20;
            students[2].gradeEnglish = 55;
            students[2].gradeMath = 70;

            Console.WriteLine($"이름      국어  영어  수학");
            for (int i = 0; i < students.Length; i++)
            {
                students[i].Print();
            }

        }
    }
}
