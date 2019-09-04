using System;
using Xunit;

namespace Coding.Collections.Generics.Test
{
    public class StackTest
    {

        [Theory]
        [InlineData(new int[]{1,2,3}, 3)]
        public void PushPeekTest(int[] input, int expected)
        {
            var stack = new Stack<int>();

            for(int i=0; i<input.Length; i++)
                stack.Push(input[i]);

            Assert.Equal(expected, stack.Peek());
        }

        [Theory]
        [InlineData(new int[]{1,2,3}, 3)]
        public void PushPopTest(int[] input, int expected)
        {
            var stack = new Stack<int>();

            for(int i=0; i<input.Length; i++)
                stack.Push(input[i]);

            Assert.Equal(expected, stack.Pop());
        }
    }
}
