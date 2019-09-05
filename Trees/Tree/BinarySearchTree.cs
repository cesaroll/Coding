using System;

namespace Coding.Trees
{
    public class BinarySearchTree
    {
        private Node Root {get; set;}
        private Action<int> Read {get; set;}

        public BinarySearchTree()
        {
            Root = null;
        }

        public void Add(params int[] data)
        {
            for(int i=0; i<data.Length; i++)
                Add(data[i]);
        }

        // Add Recursive
        public void Add(int data)
        {
            var newNode = new Node(data);

            if(Root == null){
                Root = newNode;
                return;
            }

            Add(Root, newNode);
        }

        private void Add(Node current, Node newNode)
        {
            if(current.Data > newNode.Data){
                if(current.Left == null){
                    current.Left = newNode;
                    return;
                }
                else{
                    Add(current.Left, newNode);
                }
            }
            else{
                if(current.Right == null){
                    current.Right = newNode;
                    return;
                }
                else{
                    Add(current.Right, newNode);
                }
            }

        }

        // Add Iterative
        /*public void Add(int data)
        {
            var newNode = new Node(data);
            
            if(Root == null){
                Root = newNode;
                return;
            }

            var current = Root;

            while(current != null)
            {
                if(current.Data > newNode.Data){
                    if(current.Left == null){
                        current.Left = newNode;
                        return;
                    }
                    else{
                        current = current.Left;
                    }
                }
                else{
                    if(current.Right == null){
                        current.Right = newNode;
                        return;
                    }
                    else{
                        current = current.Right;
                    }
                }
            }

        }*/

        // inOrder Iterative

        public void InOrder(Action<int> read)
        {
            Read = read;
            InOrder(Root);
            Read = null;
        }

        public void InOrder(Node current)
        {
            if(current == null)
                return;

            InOrder(current.Left);
            Read(current.Data);
            InOrder(current.Right);

        }

        public void PreOrder(Action<int> read)
        {
            Read = read;
            PreOrder(Root);
            Read = null;

        }

        private void PreOrder(Node current)
        {
            if(current == null)
                return;

            Read(current.Data);
            PreOrder(current.Left);
            PreOrder(current.Right);
        }

        public void PostOrder(Action<int> read)
        {
            Read = read;
            PostOrder(Root);
            Read = null;
        }

        private void PostOrder(Node current)
        {
            if(current == null)
                return;

            PostOrder(current.Left);
            PostOrder(current.Right);
            Read(current.Data);
        }

    }

}