using Hello;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    public class Say
    {
        public void SayHello()
        {
            Console.WriteLine("안녕");
        }
    }
}

namespace ConsoleApp88
{
    class Program
    {
        static void Main(string[] args)
        {
            Say say = new Say();
            say.SayHello();
        }
    }
}
