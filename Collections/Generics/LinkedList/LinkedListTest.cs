using System;
using Xunit;
using Coding.Collections.Generics;

namespace Coding.Collections.Generics.Tests
{
    public class LinkedListTest
    {
        [Fact]
        public void LengthTest()
        {
            var list = new LinkedList<int>();

            list.Add(1);
            Assert.Equal(1, list.Length);

            list.Add(2);
            Assert.Equal(2, list.Length);

            list.Add(3);
            Assert.Equal(3, list.Length);

        }

        [Theory]
        [InlineData(1,2,3,4,5,6)]
        public void AddTest(params int[] input)
        {
            var list = new LinkedList<int>();

            for(int i=0; i<input.Length; i++)
                list.Add(input[i]);

            var expected = input;
            int idx =0;

            Assert.Equal(expected.Length, list.Length);

            foreach(int item in list){
                Assert.Equal(item, expected[idx++]);
            }
        }

        [Fact]
        public void RemoveTest()
        {
            var list = new LinkedList<int>();

            list.Remove(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Remove(1);
            list.Add(4);
            list.Remove(3);
            list.Add(5);
            list.Add(6);
            list.Remove(6);

            // Result should be 2,4,5
            var expected = new int[]{2,4,5};
            int idx =0;

            Assert.Equal(expected.Length, list.Length);
            
            foreach(int item in list){
                Assert.Equal(item, expected[idx++]);
            }
        }

        [Theory]
        [InlineData(new int[]{1,2,5,2,3}, new int[]{1,2,5,3})]
        [InlineData(new int[]{1,2,5,2,3,3,4,5,6}, new int[]{1,2,5,3,4,6})]
        public void RemoveDuplicatesTest(int[] input, int[] expected)
        {
            var list = new LinkedList<int>();

            for(int i=0; i<input.Length; i++)
                list.Add(input[i]);

            list.RemoveDuplicates();

            Assert.Equal(expected.Length, list.Length);

            int idx=0;
            foreach(int item in list){
                Assert.Equal(item, expected[idx++]);
            }

        }

        [Theory]
        [InlineData(5, 2, 4)]
        [InlineData(2, 2, 1)]
        public void RemoveKtElementFromEndTest(int size, int k, int expected)
        {
            var list = new LinkedList<int>();

            for(int i=1; i<=size; i++)
                list.Add(i);

            Assert.Equal(expected, list.RemoveKtElementFromEnd(k));
        }

        
        [Theory]
        [InlineData(new int[]{5,4,3,2,1}, 3, new int[]{2,1,3,5,4})]
        [InlineData(new int[]{5,4,3,2,1,8,7,10}, 3, new int[]{2,1,3,5,4,8,7,10})]
        public void PartitionByValueTest(int[] input, int value,  int[] expected)
        {
            var list = new LinkedList<int>(input);
            list.PartitionByValue(value);

            Assert.Equal(list.Length, expected.Length);

            int idx=0;
            foreach(var item in list) {
                Assert.Equal(expected[idx++], item);
            }
        }

        [Theory]
        [InlineData(new int[]{0,0,1}, new int[]{0,0,2}, new int[]{0,0,3} )]
        [InlineData(new int[]{0,1}, new int[]{0,0,2}, new int[]{0,1,2} )]
        public void SumForwardTest(int[] input1, int[] input2, int[] expected)
        {
            var list1 = new LinkedList<int>(input1);
            var list2 = new LinkedList<int>(input2);

            var result = list1.SumForward(list2);

            Assert.Equal(expected.Length, result.Length);

            int idx=0;
            foreach(var item in result)
                Assert.Equal(expected[idx++], item);

        }

        [Theory]
        [InlineData(new int[]{1,0,0}, new int[]{2,0,0}, new int[]{3,0,0} )]
        [InlineData(new int[]{1,0}, new int[]{2,0,0}, new int[]{2,1,0} )]
        public void SumBackwardsTest(int[] input1, int[] input2, int[] expected)
        {
            var list1 = new LinkedList<int>(input1);
            var list2 = new LinkedList<int>(input2);
            
            var result = list1.SumBackwards(list2);

            Assert.Equal(expected.Length, result.Length);

            int idx=0;
            foreach(var item in result)
                Assert.Equal(expected[idx++], item);

        }
       

        [Theory]
        [InlineData(new int[]{1,2,3,3,2,1}, true)]
        [InlineData(new int[]{1,2,3,3,2}, false)]
        [InlineData(new int[]{1,2,3,2,1}, true)]
        public void IsPAlindromeTest(int[] input, bool expected)
        {
            var list = new LinkedList<int>(input);

            Assert.Equal(expected, list.IsPalindrome());
        }

    }
}
