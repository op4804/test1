using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp79
{
    class Animal
    {
        public string name { get; set; }


        public virtual void Speak()
        {
            Console.WriteLine("동물이 소리를 냅니다. ");
        }
    }

    class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine($"{name}이(가) 짖습니다.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 오버라이딩

            Animal myAnimal = new Animal();
            myAnimal.name = "일반동물";
            myAnimal.Speak(); //부모클래스의 기본메서드 실행


            Dog myDog = new Dog();
            myDog.name = "바둑이";
            myDog.Speak();  //오버라이딩된 메서드 실행
        }
    }
}
