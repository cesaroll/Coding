using System;

namespace Coding.Collections
{
    public class Stack
    {
        private Node Top {get; set;}

        public bool IsEmpty
        {
            get
            {
                return Top == null;
            }
        }
        public virtual void Push(int value)
        {
            var node = new Node(){Data=value};

            if(Top != null)
                node.Next = Top;

            Top = node;
        }

        public int Peek()
        {
            if(Top == null)
                throw new Exception("Stack is empty");

            return Top.Data;
        }

        public virtual int Pop()
        {
            if(Top == null)
                throw new Exception("Stack is empty");

            int value = Top.Data;
            Top = Top.Next;
            return value;
        }
    }
}