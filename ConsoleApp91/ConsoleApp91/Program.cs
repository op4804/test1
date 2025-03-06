using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp91
{
    class MyResource
    {
        ~MyResource()
        {
            Console.WriteLine("삭제됩니다");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyResource r = new MyResource();
            // 가비지 콜렉터에 의해 소멸자 호출
        }
    }
}
