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
        [InlineData(100,20,500,10,30,40, 4)]
        [InlineData(4,2,6,1,3,5,7, 3)]
        public void HeightTest(params int[] input)
        {
            long expected = input[input.Length-1];

            var tree = new BinarySearchTree();
            tree.Add(input.Take(input.Length-1).ToArray());

            Assert.Equal(expected, tree.Height);

        }

        [Theory]
        [InlineData(new int[]{100,20,500,10,30,40}, new int[]{100,20,10,500})]
        [InlineData(new int[]{1,2,5,3,6,4}, new int[]{1,2,5,6})]
        public void TopViewTest(int[] input, int[] expected)
        {
            var tree = new BinarySearchTree();
            tree.Add(input);

            int idx=0;
            tree.TopView(x => {
                Assert.Equal(expected[idx++], x);
            });

        }

        [Theory]
        [InlineData(new int[]{100,20,500,10,30,40})]
        [InlineData(new int[]{1,2,5,3,6,4})]
        [InlineData(new int[]{100,20,200,25,75,150,250,10,35,60,80,225,300,210,235})]
        public void LevelOrderTraversalTest(int[] input)
        {
            var tree = new BinarySearchTree();
            tree.Add(input);

            var expected = input;

            int idx=0;
            tree.LevelOrderTraversal(x => Assert.Equal(expected[idx++], x));
        }

        [Theory]
        [InlineData(new int[]{100,20,500,10,30,40})]
        public void IsBinarySearchTreeTest(int[] input)
        {
            var tree = new BinarySearchTree();
            tree.Add(input);

            // is is Binary Search tree
            Assert.True(tree.IsBinarySearchTree());

            // Modify one node to make it an invalid Ninary Search tree
            tree.Modify(n => {
                if(n.Data == 30){
                    n.Data = 15;
                    return true;
                }
                return false;
            },null);

            // It is not a BST
            Assert.False(tree.IsBinarySearchTree());
        }

        [Theory]
        [InlineData(new int[]{100,20,500,10,30,40}, false)]
        [InlineData(new int[]{4,2,6,1,3,5,7}, true)]
        [InlineData(new int[]{4,2,6,1,3,5}, true)]
        [InlineData(new int[]{4,2,6,1,3,}, true)]
        public void IsBalancedTest(int[] input, bool expected)
        {
            var tree = new BinarySearchTree();
            tree.Add(input);

            if(expected)
                Assert.True(tree.IsBalanced());
            else
                Assert.False(tree.IsBalanced());
        }
    }
}
