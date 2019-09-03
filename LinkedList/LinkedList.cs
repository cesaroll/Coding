using System;
using System.Collections;
using System.Collections.Generic;

namespace Coding.Collections.Generics
{
    public class LinkedList<T> : IEnumerable<T> where T : IComparable<T>, IEquatable<T>
    {
        internal Node<T> Head {get; set;}

        public LinkedList(T[] arr) : this()
        {
            for(int i=0; i<arr.Length; i++)
                this.Add(arr[i]);

        }
        public LinkedList()
        {
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

        // Remove Duplicates
        public void RemoveDuplicates()
        {
            // use current and runner
            var current = Head;

            while(current != null)
            {
                var runner = current;
                while(runner.Next != null)
                {
                    if(current.Data.Equals(runner.Next.Data)){
                        runner.Next = runner.Next.Next;
                    }
                    else{
                        runner = runner.Next;
                    }
                }

                current = current.Next;
            }
        }


        // Remove Kth element from End
        public T RemoveKtElementFromEnd(int k)
        {
            if(k < 1 || Head == null)
                return default(T);

            var prev = Head;
            var node = Head;
            var runner = Head;

            // Move runner k elements
            for(int i=1; i<k; i++)
            {
                runner = runner.Next;
                if(runner == null)
                    return default(T);
            }

            //Move runner to end of list
            while(runner.Next != null)
            {
                runner = runner.Next;
                prev = node;
                node = node.Next;
            }

            prev.Next = runner;

            return node.Data;

        }

        // Partition Linked List
        // Given a value move values lesser than to the left and bigger values to the righ
        public void PartitionByValue(T value)
        {
            // Create 2 separate Linked Lists and then Merge at the End

            if(Head == null || Head.Next == null)
                return;

            var left = new LinkedList<T>();
            var right = new LinkedList<T>();
            int searchedCount = 0;

            var node = Head;

            
            while(node != null)
            {
                
                int res = node.Data.CompareTo(value);

                if(res < 0)
                {
                    left.Add(node.Data);
                }
                else if(res > 0)
                {
                    right.Add(node.Data);
                }
                else {
                    searchedCount++;
                }

                node = node.Next;
            }

            // Add Searched Node
            while(0 < searchedCount--)
                left.Add(value);

            //Merge linked lists

            var merged = Merge(left, right);

            this.Head = merged.Head;
        }


        // Merge with other LinkedList
        public static LinkedList<T> Merge(LinkedList<T> left, LinkedList<T> right)
        {
            var leftEnd = left.LastNode();

            leftEnd.Next = right.Head;

            return left;
        }

        // Find Last Value
        public T GetLast()
        {
            var node = LastNode();

            if(node != null)
                return node.Data;

            return default(T);
        }
        // Find Last Node
        private Node<T> LastNode()
        {
            if(Head == null)
                return null;

            var node = Head;

            while(node.Next != null)
                node = node.Next;

            return node;
        }
        
    }    
}