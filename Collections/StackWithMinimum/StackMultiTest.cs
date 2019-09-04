using System;
using Xunit;
using Coding.Collections;

namespace Coding.Collections.Test
{
    public class StackMultiTest
    {
        [Fact]
        public void PushAndPeekTest()
        {
            var stackMulti = new StackMulti(5);

            // Push
            for(int i=0; i<15; i++)
                stackMulti.Push(i);

            //Peek
            Assert.Equal(14, stackMulti.Peek());

        }

        [Fact]
        public void PushAndPopTest()
        {
            var stackMulti = new StackMulti(5);

            // Push and Pop
            for(int i=0; i<50; i++)
            {
                stackMulti.Push(i); //Push

                if(i % 4 == 0 || i % 6 == 0) // Pop
                {
                    int val = stackMulti.Pop();
                    Assert.Equal(i,val);
                }
            }
        }

        [Fact]
        public void PopAtTest()
        {
            var stackMulti = new StackMulti(5);

            // Push
            for(int i=0; i<25; i++)
                stackMulti.Push(i);

            Assert.Equal(4, stackMulti.PopAt(0));
            Assert.Equal(9, stackMulti.PopAt(1));
            Assert.Equal(14, stackMulti.PopAt(2));
        }
    }
}