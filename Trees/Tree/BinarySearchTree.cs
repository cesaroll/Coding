using System;

namespace Coding.Trees
{
    public class BinarySearchTree
    {
        private Node Root {get; set;}

        public delegate void ReadDelegate(int data);

        private ReadDelegate Read{get; set;}

        public BinarySearchTree()
        {
            Root = null;
        }

        public void Add(int data)
        {
            Root = Add(Root, new Node(data));
        }

        private Node Add(Node current, Node newNode)
        {
            if(current == null){
                return newNode;
            }

            if(newNode.Data <= current.Data)
                current.Left = Add(current.Left, newNode);
            else
                current.Right = Add(current.Right, newNode);

            return current;
        }

        public void InOrder(ReadDelegate read)
        {
            Read = read;
            InOrder(Root);
        }

        public void InOrder(Node current)
        {
            if(current == null)
                return;

            InOrder(current.Left);
            Read(current.Data);
            InOrder(current.Right);

        }

    }

}