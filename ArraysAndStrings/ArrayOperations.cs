using System;

namespace Coding.ArraysAndStrings
{
    public static class ArrayOperations
    {
        // Rotate Matrix 90 degrees in place
        public static void Rotate90Degrees(int[][] matrix)
        {
            int n = matrix[0].Length;

            for(int layer=0; layer < n/2; layer++)
            {
                int first = layer;
                int last = n-layer-1;

                for(int i=first; i<last; i++)
                {
                    int offset = i - first;
                    // Get Top
                    int top = matrix[first][i];

                    // Left => Top
                    matrix[first][i] = matrix[last-offset][first];

                    // Botton => Left
                    matrix[last-offset][first] = matrix[last][last-offset];

                    // Right => Botton
                    matrix[last][last-offset] = matrix[i][last];

                    // Top => Right
                    matrix[i][last] = top;
                }
                
            }

        }

        // If zero found, set row and column to zeroes
        public static void SetZeroes(int[][] matrix)
        {
            int len = matrix[0].Length;

            var rows = new bool[len];
            var cols = new bool[len];

            for(int i=0; i<len; i++)
            {
                for(int j=0; j<len; j++)
                {
                    if(matrix[i][j] == 0)
                    {
                        rows[i] = true;
                        cols[j] = true;
                    }
                }
            }

            for(int i=0; i<len; i++){
                if(rows[i])
                {
                    for(int j=0; j<len; j++)
                    {
                        matrix[i][j] = 0;
                    }
                }
                if(cols[i])
                {
                    for(int j=0; j<len; j++)
                    {
                        matrix[j][i] = 0;
                    }
                }
            }

        }
    }
}