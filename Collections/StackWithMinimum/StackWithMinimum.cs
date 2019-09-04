using System;

namespace Coding.Collections
{
    public class StackWithMinimum : Stack
    {
        private Stack MinimumStack {get; set;}

        public StackWithMinimum()
        {
            MinimumStack = new Stack();
        }

        public int PeekMinimum()
        {
            return MinimumStack.Peek();
        }

        public override void Push(int value)
        {
            base.Push(value);

            if(MinimumStack.IsEmpty || value <= MinimumStack.Peek())
                MinimumStack.Push(value);
        }

        public override int Pop()
        {
            if(this.Peek() == MinimumStack.Peek())
                MinimumStack.Pop();

            return base.Pop();
        }
        
        
    }
}