using System;
using Xunit;
using Coding.Collections.Generic;

namespace Coding.Collectinos.Generics.Test
{
    public class QueueTest
    {
        [Theory]
        [InlineData(new int[]{1,2,3}, 1)]
        public void EnqueueDequeueTest(int[] input, int expected)
        {
            var queue = new Queue<int>();

            for(int i=0; i<input.Length; i++)
                queue.Enqueue(input[i]);

            Assert.Equal(expected, queue.Dequeue());
            Assert.Equal(++expected, queue.Dequeue());
            Assert.Equal(++expected, queue.Dequeue());

        }
    }
}
