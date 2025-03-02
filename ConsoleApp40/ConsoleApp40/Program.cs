using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp40
{
    struct Point
    {
        // public 누구나 사용 가능
        // private 나만 사용 가능
        public int x;
        public int y;

        public void Print()
        {
            Console.WriteLine($"좌표 : {x}, {y}");
        }
    }

    struct Rectangle
    {
        public int height;
        public int width;

        public int GetArea() => height * width;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point p;
            p.x = 10;
            p.y = 20;

            p.Print();

            Rectangle myRectangle1 = new Rectangle()
            {
                width = 5,
                height = 10,
            };

            Rectangle myRectangle2;
            myRectangle2.width = 20;
            myRectangle2.height = 10;
            Console.WriteLine($"Area = {myRectangle2.GetArea()}");

            Point[] points = new Point[2];

            points[0].x = 10;
            points[0].y = 10;
            
            points[1].x = 20;
            points[1].y = 30;

            for(int i = 0; i< points.Length; i++)
            {
                Console.WriteLine($"{i + 1}번째 구조체의 좌표 x: {points[i].x} y: {points[i].y}");
            }
        }
    }
}
