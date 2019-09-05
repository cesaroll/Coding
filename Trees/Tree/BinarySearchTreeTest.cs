using System;
using Xunit;

namespace Coding.Trees.Test
{
    public class BinarySearchTreeTest
    {
        [Theory]
        [InlineData(100,20,500,10,30,40)]
        public void InOrderTest(params int[] input)
        {
            var tree = new BinarySearchTree();
            tree.Add(input);

            Array.Sort(input);

            var expected = input;
            int idx = 0;

            tree.InOrder((x) => {
                    Assert.Equal(expected[idx++], x);
                });

        }
    }
}
