using System;

namespace Coding.Collections.Generics
{
    public class LinkedList<T> where T : class
    {
        private Node<T> Head {get; set;}

        public LinkedList()
        {
            Head = null;
        }

        //Add Item
        public void Add(T value)
        {
            var next = Head;

            // Move to end of list
            while(next != null)
                next = next.Next;

            // Add new node
            next = new Node<T>(){Data = value};
        }
        
        
    }    
}