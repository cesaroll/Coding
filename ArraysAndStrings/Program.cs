using System;
using Coding.ArraysAndStrings;

namespace ArraysAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new int[][]{
                new int[]{1,2,3,4},
                new int[]{12,13,14,5},
                new int[]{11,16,15,6},
                new int[]{10,9,8,7}
            };

            
            Print(matrix);

            ArrayOperations.Rotate90Degrees(matrix);

            Print(matrix);

        }

        static void Print(int[][] matrix)
        {
            int len = matrix[0].Length;

            for(int i=0; i<len; i++)
            {
                for(int j=0; j<len; j++)
                {
                    Console.Write($"{matrix[i][j],2} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
