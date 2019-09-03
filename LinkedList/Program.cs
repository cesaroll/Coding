using System;
using Coding.Collections.Generics;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>(new int[]{5,4,3,2,1});

            Display(list);

            list.PartitionByValue(3);

            Display(list);

        }

        static void Display(LinkedList<int> list)
        {
            foreach(var item in list)
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine();
        }
    }
}
