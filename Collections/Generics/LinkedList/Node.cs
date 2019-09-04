namespace Coding.Collections.Generics
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next {get; set;}
    }
}