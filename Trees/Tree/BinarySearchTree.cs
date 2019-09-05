using System;

namespace Coding.Trees
{
    public class BinarySearchTree
    {
        #region : Private variables
        private long _height;        
        #endregion

        #region : Private Properties        
        private Node Root {get; set;}
        private Action<int> Read {get; set;}

        #endregion

        #region : Public Properties

        public long Height {
            get
            {
                if(_height < 0){

                    if(Root == null)
                        _height = 0;
                    else
                        _height = GetHeigth(Root, -1);
                    
                }
                    

                return _height;
            }
        }

        #endregion

        #region : Constructors
        public BinarySearchTree()
        {
            Root = null;
            _height = -1;
        }
        #endregion

        #region : Add

        #region : Add Array
        // Add array
        public void Add(params int[] data)
        {
            for(int i=0; i<data.Length; i++)
                Add(data[i]);
        }
        #endregion

        #region : Add Recursive
        // Add Recursive
        public void Add(int data)
        {
            var newNode = new Node(data);

            if(Root == null){
                Root = newNode;
                return;
            }

            Add(Root, newNode);

            _height = -1;
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
        #endregion
        
        #region : Add Iterative
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

        #endregion

        #endregion

        #region : Traversals

        #region : InOrder
        // InOrder 
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
        #endregion

        #region : PreOrder
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
        #endregion

        #region : PostOrder
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
        #endregion

        #region : TopView Traversal

        public void TopView(Action<int> read)
        {
            Read = read;
            TopView(Root, Direction.Both);
            Read = null;

        }

        private void TopView(Node curr, Direction direction)
        {
            if(curr == null)
                return;

            Read(curr.Data);

            switch(direction)
            {
                case Direction.Left:
                    TopView(curr.Left, Direction.Left);
                    break;
                case Direction.Right:
                    TopView(curr.Right, Direction.Right);
                    break;
                case Direction.Both:
                    TopView(curr.Left, Direction.Left);
                    TopView(curr.Right, Direction.Right);
                    break;                    
            }
        }

        #endregion        

        #endregion

        #region : Height

        private long GetHeigth(Node current, long _height)
        {
            if(current == null)
                return _height;

            _height++;

            var leftHeight = GetHeigth(current.Left, _height);
            var rightHeight = GetHeigth(current.Right, _height);

            return Math.Max(leftHeight, rightHeight);
        }

        #endregion


        #region : Enumerations
        private enum Direction
        {
            Left,
            Right,
            Both
        }
        #endregion

    }

}