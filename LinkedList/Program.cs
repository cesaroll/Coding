using System;
using Coding.Collections.Generics;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Linked List!");

            var list = new LinkedList<int>();

            list.Remove(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Remove(1);
            list.Add(4);
            list.Remove(3);
            list.Add(5);
            list.Add(6);
            list.Remove(6);

            foreach(var item in list){
                Console.WriteLine($"    Retrieving: {item}");
            }

        }
    }
}
