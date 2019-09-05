using System;
using System.Linq;
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

        [Theory]
        [InlineData(100,20,500,10,30,40, 3)]
        [InlineData(4,2,6,1,3,5,7, 2)]
        public void HeightTest(params int[] input)
        {
            long expected = input[input.Length-1];

            var tree = new BinarySearchTree();
            tree.Add(input.Take(input.Length-1).ToArray());

            Assert.Equal(expected, tree.Height);

        }

        [Theory]
        [InlineData(new int[]{100,20,500,10,30,40}, new int[]{100,20,10,500})]
        public void TopViewTest(int[] input, int[] expected)
        {
            var tree = new BinarySearchTree();
            tree.Add(input);

            int idx=0;
            tree.TopView(x => {
                Assert.Equal(expected[idx++], x);
            });

        }
    }
}
