using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp56
{
    class Program
    {
        static void Main(string[] args)
        {

            string greeting = "Hello";
            string name = "Alice";

            string message = greeting + "," + name + "!";

            Console.WriteLine(message);

            Console.WriteLine($"Length of name: {name.Length}");
            Console.WriteLine($"To Upper: {name.ToUpper()}");
            Console.WriteLine($"Substring: {name.Substring(2)}");

            string text = "C# is awesome!";

            Console.WriteLine($"Contains 'awesome': {text.Contains("awesome")}");
            Console.WriteLine($"Index of 'is' : {text.IndexOf("is")} ");
            Console.WriteLine($"Replace 'awesome' with 'sucks': {text.Replace("awesome", "sucks")}");

            StringBuilder sb = new StringBuilder("Hello");
            sb.Append(",");
            sb.Append("World!");
            Console.WriteLine(sb.ToString());
        }
    }
}
