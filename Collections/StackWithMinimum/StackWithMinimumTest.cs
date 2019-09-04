using System;
using Xunit;
using Coding.Collections;

namespace StackWithMinimum
{

    public class StackWithMinimumTest
    {
        [Theory]
        [InlineData(new int[]{1,2,3}, 1)]
        [InlineData(new int[]{5,10,8,4,7,1,2,3,8,4,9,1,7,2,4}, 1)]
        public void PeekMinimumTest(int[] input, int expected)
        {
            var stack = new Coding.Collections.StackWithMinimum();

            for(int i=0; i<input.Length; i++)
                stack.Push(input[i]);

            Assert.Equal(expected, stack.PeekMinimum());
        }
    }

}