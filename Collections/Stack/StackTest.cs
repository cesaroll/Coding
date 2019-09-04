using System;
using Xunit;
using Coding.Collections;

namespace Coding.Collections.Test
{
    public class StackTest
    {
        [Theory]
        [InlineData(new int[]{1,2,3}, 3)]
        public void PushPeekTest(int[] input, int expected)
        {
            var stack = new Stack();

            for(int i=0; i<input.Length; i++)
                stack.Push(input[i]);

            Assert.Equal(expected, stack.Peek());
        }

        [Theory]
        [InlineData(new int[]{1,2,3})]
        [InlineData(new int[]{5,10,8,4,7,1,2,3,8,4,9,1,7,2,4})]
        public void PushPopTest(int[] input)
        {
            var stack = new Stack();

            for(int i=0; i<input.Length; i++)
                stack.Push(input[i]);

            Array.Reverse(input);

            var expected = input;

            for(int i=0; i<expected.Length; i++)
                Assert.Equal(expected[i], stack.Pop());
        }
    }
}
