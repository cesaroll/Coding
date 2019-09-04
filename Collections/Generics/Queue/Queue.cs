using System;

namespace Coding.Collections.Generic
{
    public class Queue<T> where T : IEquatable<T>, IComparable<T>
    {
        private Node<T> First {get; set;}
        private Node<T> Last {get; set;}

        public void Enqueue(T value)
        {
            var node = new Node<T>(){Data = value};

            if(Last == null){
                First = node;
                Last = node;
            }
            else{
                Last.Next = node;
                Last = node;
            }
        }

        public T Dequeue()
        {
            if(First == null)
                return default(T);

            var value = First.Data;
            First = First.Next;

            if(First == null)
                Last = First;

            return value;
        }
    }
}