using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int integerNum = 10;
            float floatNum = 3.14f;
            double doubleNum = 3.141414;

            long lognNum = 12345666L;

            Console.WriteLine(integerNum);
            Console.WriteLine(floatNum);
            Console.WriteLine(doubleNum);

            sbyte signedByte = -50;
            short signedShort = -32000;
            int signedInt = -2000000000;

            Console.WriteLine(signedByte);
            Console.WriteLine(signedShort);
            Console.WriteLine(signedInt);

            byte unsignedByte = 50;
            ushort unsignedShort = 32000;
            uint unsignedInt = 2000000000;

            Console.WriteLine(unsignedByte);
            Console.WriteLine(unsignedShort);
            Console.WriteLine(unsignedInt);

            float singlePrecision = 3.14f;
            double doublePrecision = 3.1435848;
            decimal highPrecision = 3.14234928374982379482739m;

            Console.WriteLine(singlePrecision);
            Console.WriteLine(doublePrecision);
            Console.WriteLine(highPrecision);

            int integerValue = 100;
            long longValue = 100L;
            float floatValue = 3.14f;
            double doubleValue = 3.14;
            decimal decimalValue = 3.14m;

            char letter = 'A';
            char symbol = '#';
            char number = '9';

            string greetring = "hello~";
            string name = "Alice";

            bool isRungning = true;
            bool isFinished = false;






        }
    }
}
