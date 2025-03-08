using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp106
{

    class Program
    {
        static void Main(string[] args)
        {
            int width = 80;
            int height = 40;
            Console.SetWindowSize(width,height); 
            Console.SetBufferSize(width,height);

            Console.CursorVisible = false;

            Console.SetCursorPosition(0, 0);
            Console.WriteLine();
            
            
        }
    }
}
