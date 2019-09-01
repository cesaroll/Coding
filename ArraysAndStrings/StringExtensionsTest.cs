using System;
using Xunit;
using Coding.ArraysAndStrings;

namespace Coding.ArraysAndStrings.Xunit
{
    public class StringExtensionsTest
    {
        [Theory]
        [InlineData("Hola", true)]
        [InlineData("Hola Mundo!", false)]
        public void IsUniqueCharsWithBufferTest(string str, bool expected)
        {
            Assert.Equal(expected, str.IsUniqueCharsWithBuffer());
        }

        [Theory]
        [InlineData("hola", true)]
        [InlineData("holamundo", false)]
        public void IsUniqueCharWithVectorTest(string str, bool expected)
        {
            Assert.Equal(expected, str.IsUniqueCharWithVector());
        }

        [Theory]
        [InlineData("Hola Mundo!")]
        [InlineData("!Parangaricutirimicuaro@")]
        [InlineData("!Papantla tus hijos vuelan")]
        public void ReverseTest(string str)
        {
            var arr = str.ToCharArray();
            Array.Reverse(arr);
            string reversed = new string(arr);

            Assert.Equal(reversed, str.Reverse());
        }

        [Theory]
        [InlineData("god", "dog", true)]
        [InlineData("hello", "llohe", true)]
        [InlineData("world ", "dlrow", false)]
        [InlineData("world", "worldd", false)]
        public void IsPermutationWithSortTest(string str1, string str2, bool expected)
        {
            Assert.Equal(expected, str1.IsPermutationWithSort(str2));
        }

        [Theory]
        [InlineData("god", "dog", true)]
        [InlineData("hello", "llohe", true)]
        [InlineData("world ", "dlrow", false)]
        [InlineData("world", "worldd", false)]
        public void IsPermutationTest(string str1, string str2, bool expected)
        {
            Assert.Equal(expected, str1.IsPermutation(str2));
        }

        [Theory]
        [InlineData("Hello World!", ' ', "%20", "Hello%20World!")]
        [InlineData("Papantla tus hijos vuelan!", ' ', "%20", "Papantla%20tus%20hijos%20vuelan!")]
        public void ReplaceCharInlineTest(string str, char c, string newVal, string expected)
        {
            Assert.Equal(expected, str.ReplaceCharInLine(c, newVal));
        }
    }    
}
