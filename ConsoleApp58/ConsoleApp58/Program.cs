using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp58
{
    class Program
    {
        static void Main(string[] args)
        {
            // 예외 처리
            // try catch

            int[] numbers = { 1, 2, 3 };
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Console.WriteLine(numbers[i]);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            // finally 블록은 예외 발생 여부와 상관 없이 항상 실행

            try
            {
                int number = int.Parse("NotANumber");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Format Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("항상 실행 ");
            }

            try
            {
                int age = -5;
                if(age < 0)
                {
                    throw new ArgumentException("age cannot be negative");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

        }
    }
}
