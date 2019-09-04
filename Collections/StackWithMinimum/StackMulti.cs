using System;


namespace Coding.Collections
{
    public class StackMulti
    {
        private const int MAX_STACK_ELEMENTS = 1000;
        private int MaxStackElements {get; set;}
        private System.Collections.Generic.List<Stack> Stacks{get; set;}

        private Stack LastStack{ get{return Stacks[Stacks.Count-1];}}

        public StackMulti() : this(MAX_STACK_ELEMENTS)
        {
        }
        public StackMulti(int maxStackElements)
        {
            this.MaxStackElements = maxStackElements;

            this.Stacks = new System.Collections.Generic.List<Stack>();

            this.Stacks.Add(new Stack());
        }

        public void Push(int value)
        {
            // Get last stack
            var stack = this.LastStack;
            
            // If last stack is full create a new one
            if(stack.Length >= MaxStackElements){
                stack = new Stack();
                Stacks.Add(stack);
            }

            stack.Push(value);

        }

        public int Peek()
        {
            return this.LastStack.Peek();
        }

        public int Pop()
        {
            // Get last stack
            var stack = this.LastStack;

            // Find out if last stack is empty
            if(stack.Length == 0)
            {
                this.Stacks.RemoveAt(Stacks.Count-1);
                stack = this.LastStack;
            }

            // Pop last stack
            int value = stack.Pop();

            return value;
        }

        public int PopAt(int idx)
        {
            if(idx < 0 || (Stacks.Count-1) < idx)
                throw new Exception("Invalid Index");

            return Stacks[idx].Pop();
        }

    }
}