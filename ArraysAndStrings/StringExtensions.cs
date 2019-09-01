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

        
        // Use vector for find unique for lowercase letters only
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

        // Reverse string
        public static string Reverse(this string str)
        {
            var arr = str.ToCharArray();
            int end = arr.Length-1;
            int i = 0;

            while(i < end)
            {
                char tmp = arr[i];
                arr[i++] = arr[end];
                arr[end--] = tmp;
            }

            return new string(arr);
        }

        // Verify if one string is permutation of other using sort
        public static bool IsPermutationWithSort(this string str1, string str2)
        {
            if(str1.Length != str2.Length)
                return false;

            str1 = str1.ToSortedString();
            str2 = str2.ToSortedString();

            return str1 == str2;
        }

        // Sort a string
        private static string ToSortedString(this string str)
        {
            var arr = str.ToCharArray();
            Array.Sort(arr);
            return new string(arr);
        }

        // Verify if one string is permutation of other
        public static bool IsPermutation(this string str1, string str2)
        {
            if(str1.Length != str2.Length)
                return false;

            var counter = new int[256]; // Assume ASCII

            for(int i=0; i<str1.Length; i++)
            {
                counter[str1[i]]++;
                counter[str2[i]]--;
            }

            for(int i=0; i<counter.Length; i++)
            {
                if(counter[i] != 0)
                    return false;
            }

            return true;
        }

        // Replace spacein line using array
        public static string ReplaceCharInLine(this string str, char c, string newVal)
        {
            // First count values to replace
            int count = 0;
            var origArr = str.ToCharArray();
            
            for(int i=0; i<origArr.Length; i++)
            {
                if(origArr[i] == c)
                    count++;
            }

            var newArr = new char[str.Length + count*(newVal.Length-1)];

            Array.Copy(origArr, newArr, origArr.Length);

            int newEnd = newArr.Length-1;
            for(int i=origArr.Length-1; i >= 0; i-- )
            {
                if(origArr[i] == c)
                {
                    for(int j=newVal.Length-1; j>=0; j--)
                    {
                        newArr[newEnd--] = newVal[j];
                    }
                }
                else{
                    newArr[newEnd--] = origArr[i];
                }
            }

            return new string(newArr);

        }
    }
}