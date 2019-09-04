using System;

namespace Coding.Collections.Generics
{
    public static class LinkedListExtensions
    {
        // Sum Forward When number is backwards
        // 0 => 1   +   0 => 0   =>   2 = 0 => 1 => 2
        //   10     +     200    =    210
        public static LinkedList<int> SumForward(this LinkedList<int> list1, LinkedList<int> list2)
        {
            var result = new LinkedList<int>();
            
            var node1 = list1.Head;
            var node2 = list2.Head;

            while(node1 != null || node2 != null)
            {
                int sum = 0;

                if(node1 != null )
                {
                    sum += node1.Data;
                    node1 = node1.Next;
                }

                if(node2 != null)
                {
                    sum += node2.Data;
                    node2 = node2.Next;
                }

                result.Add(sum);

            }

            return result;
        }

        // Sum BAckwards When number is forward
        // 1 => 0   +   2 => 0 => 0   =   2 => 1 => 0
        //   10     +        200      =   210
        public static LinkedList<int> SumBackwards(this LinkedList<int> list1, LinkedList<int> list2)
        {
            var result = new LinkedList<int>();
            
            // Get Length of each list
            int l1 = list1.Length;
            int l2 = list2.Length;
            int depth = Math.Max(l1, l2);

            var n1 = list1.Head;
            var n2 = list2.Head;

            while(depth > 0)
            {
                int sum =0;
                
                if(l1 == depth){
                    sum += n1.Data;
                    l1--;
                    n1 = n1.Next;
                }

                if(l2 == depth){
                    sum += n2.Data;
                    l2--;
                    n2 = n2.Next;
                }

                result.Add(sum);

                depth--;
            }

            return result;

        }

        // Get List depth.
        private static int GetDepth(Node<int> node)
        {
            int depth = 0;

            while(node != null)
            {
                depth++;
                if(node.Next != null)
                    node = node.Next;
                else
                    break;
            }

            return depth;
        }

        // Convert List into Circular List
        public static void MakeCircular(this LinkedList<int> list, int val)
        {
            Node<int> loopStart = null;
            Node<int> lastNode = null;

            // Find last node
            Node<int> node = list.Head;
            while(node != null)
            {
                lastNode = node;
                if(node.Data == val)
                    loopStart = node; // Get Loop start

                node = node.Next;
            }

            if(lastNode != null && loopStart != null)
            {
                lastNode.Next = loopStart;
            }
        }

        // Find Starting point of circular list
        // Data Items in list must be different
        public static int FindStartingPointOfCircularList(this LinkedList<int> list)
        {
            
            if(list == null || list.Head == null)
                throw new ArgumentNullException();

            var node = list.Head;
            var runner = list.Head;

            // Move node one at a time and runner twice at a time
            while(node != null && runner != null)
            {
                //Move node
                node = node.Next;
                
                // Move runner
                if(runner.Next != null)
                    runner = runner.Next.Next;
                else
                    throw new Exception("LinkedList is not Circular");

                // Verify if runner met node
                if(node.Data == runner.Data)
                {
                    //make node point to Head
                    node = list.Head;
                    break;
                }

            }

            // Move both node and runner one at a time, start of loop will be when they met again
            while(node.Data != runner.Data)
            {
                node = node.Next;
                runner = runner.Next;
            }

            return node.Data;
        }


        // Function that returns true if linked list is a pallindrome
        public static bool IsPalindrome(this LinkedList<int> list)
        {
            if(list == null || list.Head == null)
                return false;

            var stack = new System.Collections.Generic.Stack<int>();
            var sr = list.Head; // Slow Runner
            var fr = list.Head; // Fast Runner
            int cnt = 0;

            while(fr != null)
            {
                cnt++;
                stack.Push(sr.Data);                

                if(fr.Next != null)
                {
                    cnt++;
                    sr = sr.Next;
                    fr = fr.Next.Next;
                }
                else{
                    break;
                }
            }

            // Compare Stack to rest of list
            while(sr != null)
            {
                int val = stack.Pop();

                if(val != sr.Data)
                    return false;

                sr = sr.Next;
            }

            return true;
        }
    }
}