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

    }    
}
