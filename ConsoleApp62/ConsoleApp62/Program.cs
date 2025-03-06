using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp62
{
    class SimpleCollection : IEnumerable<int>
    {
        private int[] data = { 1, 2, 3, 4, 5 };

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new SimpleCollection();

            foreach (var i in collection)
            {
                Console.WriteLine(i);
            }

            Dictionary<string, int> axes = new Dictionary<string, int>();

            axes["금도끼"] = 10;
            axes["은도끼"] = 5;
            axes["돌도끼"] = 1;


            foreach (var pair in axes)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }

        }
    }

}
