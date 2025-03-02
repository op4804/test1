using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49
{

    class Person
    {
        private string name;

        // Setter
        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름: {name}");
        }
    }

    class PPerson
    {
        private string name;
        private int count = 100;

        public string pname { get; set; }
        public string Name
        {
            get { return name; } // getter
            set { name = value; } // setter
        }

        public int Count
        {
            get { return count; }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름: {name}");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.SetName("김만수");
            p1.ShowInfo();

            PPerson p2 = new PPerson();
            p2.Name = "박철수";
            p2.ShowInfo();
            Console.WriteLine($"{p2.Name}");

            PPerson p3 = new PPerson();
            p3.pname = "김낙";
            Console.WriteLine($"{p3.pname}");

            int pCount;
            pCount = p2.Count;
            // p2.Count = 300; // 읽기 전용이라 할당할 수 없다.
        }
    }
}
