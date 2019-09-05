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

        [Theory]
        [InlineData(new int[]{100,20,500,10,30,40}, new int[]{100,20,10,30,40,500})]
        public void PreOrderTest(int[] input, int[] expected)
        {
            var tree = new BinarySearchTree();
            tree.Add(input);

            int idx = 0;

            tree.PreOrder((x) => {
                    Assert.Equal(expected[idx++], x);
                });

        }

        [Theory]
        [InlineData(new int[]{100,20,500,10,30,40}, new int[]{10,40,30,20,500,100})]
        public void PostOrderTest(int[] input, int[] expected)
        {
            var tree = new BinarySearchTree();
            tree.Add(input);

            int idx = 0;

            tree.PostOrder((x) => {
                    Assert.Equal(expected[idx++], x);
                });

        }
    }
}
