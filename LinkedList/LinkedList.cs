using System;
using System.Collections;
using System.Collections.Generic;

namespace Coding.Collections.Generics
{
    public class LinkedList<T> : IEnumerable<T> where T : IComparable<T>, IEquatable<T>
    {
        private Node<T> Head {get; set;}

        public LinkedList()
        {
            Head = null;
        }

        // Length
        public int Length
        {
            get
            {
                int length = 0;
                var node = Head;

                while(node != null){
                    length++;
                    node = node.Next;
                }

                return length;
            }
            
        }

        //Add Item
        public void Add(T value)
        {
            // Create new node
            var newNode = new Node<T>(){Data = value};

            // if Head is empty, new node is Head
            if(Head == null)
            {
                Head = newNode;
                return;
            }

            // Otherwise move to end of list
            var node = Head;

            while(node.Next != null)
                node = node.Next;

            // And add new Node at end
            node.Next = newNode;

        }

        //Delete Item
        public bool Remove(T value)
        {           
            if(Head == null)
                return false;
            else if(Head.Data.Equals(value)){
                // If Head is value then move Head
                Head = Head.Next;
                return true;
            } else{
                var node = Head;
                // Search value in list
                while(node.Next != null)
                {
                    if(node.Next.Data.Equals(value)){
                        node.Next = node.Next.Next; 
                        return true;
                    }

                    node = node.Next;
                }
            }

            return false;
        }

        // Traverse Linked List and return Enumerator
        public IEnumerator<T> GetEnumerator()
        {
            var next = Head;

            while(next != null)
            {
                yield return next.Data;
                next = next.Next;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }    
}