using System;
using Xunit;

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

            // Result should be 2,4,5
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
    }
}
