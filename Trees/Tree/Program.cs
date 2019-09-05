using System;
using Coding.Trees;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree();

            tree.Add(100,20,500,10,30,40);

            Console.WriteLine("InOrder:");
            tree.InOrder(x => {Console.Write($"{x}, ");});
            Console.WriteLine("\nPreOrder:");
            tree.PreOrder(x => {Console.Write($"{x}, ");});
            Console.WriteLine("\nPostOrder:");
            tree.PostOrder(x => {Console.Write($"{x}, ");});
        }
    }
}
