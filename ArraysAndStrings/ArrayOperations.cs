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

        
    }
}