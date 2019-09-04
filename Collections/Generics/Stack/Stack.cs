using System;

namespace Coding.Collections.Generics
{

    public class Stack<T> where T : IEquatable<T>, IComparable<T>
    {
        Node<T> Top {get; set;}

        public void Push(T value)
        {
            var node = new Node<T>(){Data = value};

            if(Top != null)
                node.Next = Top;

            Top = node;
        }

        public T Peek()
        {
            if(Top != null)
                return Top.Data;

            return default(T);
        }

        public T Pop()
        {
            if(Top != null)
            {
                var data = Top.Data;
                Top = Top.Next;
                return data;
            }

            return default(T);
        }


    }

}