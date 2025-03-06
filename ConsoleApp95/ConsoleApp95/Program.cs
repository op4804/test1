using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp95
{
    class Parent
    {
        protected string name;
        public Parent(string name)
        {
            this.name = name;
            Console.WriteLine($"부모 생성자 이름 {name}");

        }
    }

    class Child : Parent
    {
        private int age;

        public Child(string name, int age):base(name)
        {
            this.age = age;
            Console.WriteLine($"자식 생성자 나이 {age}");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름: {name}, 나이: {age}");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Child c = new Child("김정만", 42);
            c.ShowInfo();
        }
    }
}
