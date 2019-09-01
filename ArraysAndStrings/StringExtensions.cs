using System;

namespace Coding.ArraysAndStrings
{
    public static class StringExtensions
    {
        // Search if string is unique, ASCII only with help of array
        public static bool IsUniqueCharsWithBuffer(this string str)
        {
            // ASCII 256 chars

            if(str.Length > 256)
                return false; // There are already more than 256 characters, that means there are duplicates

            var found = new bool[256];

            for(int i=0; i < str.Length; i++)
            {
                char c = str[i];

                if(found[c])
                    return false;

                found[c] = true;
            }

            return true;
        }

        
        // USe vector for find unique for lowercase letters only
        public static bool IsUniqueCharWithVector(this string str)
        {
            if(str.Length > 26)
                return false;

            int vector = 0; //vector

            for(int i=0; i < str.Length; i++)
            {
                int bitval = 1 << (str[i] - 'a');

                if((vector & bitval) > 0)
                    return false;

                vector |= bitval;
            }

            return true;
        }
    }
}