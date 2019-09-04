using System;
using Coding.Collections;

namespace StackWithMinimum
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[]{5,10,8,4,7,1,2,3,8,4,9,1,7,2,4};

            var stack = new Coding.Collections.StackWithMinimum();

            for(int i=0; i<arr.Length; i++)
            {
                stack.Push(arr[i]);

                Console.WriteLine($" Add: {arr[i]} Min: {stack.PeekMinimum()}");
            }
            
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~\n");

            while(!stack.IsEmpty)
            {
                Console.WriteLine($" Pop: {stack.Peek()} Min: {stack.PeekMinimum()}");
                stack.Pop();
            }
            

        }
    }
}
