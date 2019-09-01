namespace Coding.Collections.Generics
{
    public class LinkedList<T>
    {
        private Node<T> Head {get; set;}

        public LinkedList()
        {
            Head = null;
        }

        //Add Node
        public void Add(T value)
        {
            if(Head == null) // If Head is null create Head
                Head = new Node<T>(){Data = value};
            else 
            { // Otherwise node is Head
                var node = Head;

                // mode node to end of list
                while(node.Next != null)
                    node = node.Next;
                // Add new node
                node.Next = new Node<T>(){Data = value};

            }
        }        
    }    
}