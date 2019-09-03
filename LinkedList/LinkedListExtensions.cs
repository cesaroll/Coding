using System;

namespace Coding.Collections.Generics
{
    public static class LinkedListExtensions
    {
        // Sum Forward
        // 0 => 1 + 0 => 0 => 2 = 0 => 1 => 2
        //  10  + 200 = 210
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
    }
}