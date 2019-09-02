using System;
using Coding.ArraysAndStrings;

namespace ArraysAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "aabcccccaaa";
            Console.WriteLine($"Input: {str} Compressed: {str.Compress()}");
        }
    }
}
