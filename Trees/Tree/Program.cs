using System;
using Coding.Trees;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[]{100,20,500,10,30,40};

            var tree = new BinarySearchTree();

            for(int i=0; i<arr.Length; i++)
                tree.Add(arr[i]);

            tree.InOrder((x) => {Console.Write($"{x}, ");});
        }
    }
}
