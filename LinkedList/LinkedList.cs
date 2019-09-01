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
        
        //Delete Item
        public bool Delete(T value)
        {
            if(Head == null)
                return false;
            else if(Head.Data == value){
                // If Head is value then move Head
                Head = Head.Next;
                return true;
            } else{
                var node = Head;

                // Search value in list
                while(node.Next != null){
                    if(node.Next.Data == value){
                        node.Next = node.Next.Next;
                        return true;
                    }
                }
            }

            return false;
        }
    }    
}