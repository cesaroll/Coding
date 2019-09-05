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

            tree.InOrder((x) => {Console.Write($"{x}, ");});
        }
    }
}
