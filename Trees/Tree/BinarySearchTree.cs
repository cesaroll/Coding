using System;

namespace Coding.Trees
{
    public class BinarySearchTree
    {
        #region : Private variables
        private long _height;        
        #endregion

        #region : Private Properties        
        internal Node Root {get; set;}
        private Action<int> Read {get; set;}

        #endregion

        #region : Public Properties

        public long Height {
            get
            {
                if(_height < 0)
                    _height = GetHeigth(Root);                    

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

        #region : Level Order Traversal

        public void LevelOrderTraversal(Action<int> action)
        {
            if(Root == null)
                return;

            var q = new System.Collections.Generic.Queue<Node>();

            while(q.Count > 0)
            {
                var node = q.Dequeue();

                action(node.Data);

                if(node.Left != null)
                    q.Enqueue(node.Left);

                if(node.Right != null)
                    q.Enqueue(node.Right);
            }

        }

        #endregion

        #endregion

        #region : Height

        private long GetHeigth(Node current)
        {
            if(current == null)
                return 0;

            var leftHeight = GetHeigth(current.Left);
            var rightHeight = GetHeigth(current.Right);

            return Math.Max(leftHeight, rightHeight) + 1; // Add one for this node
        }

        #endregion

        
        #region : IsBinarySearch Tree

        // Is Binary Search Tree using Lambda
        // It will allways be true unless we tweek it
        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(Root, null);
        }

        private bool IsBinarySearchTree(Node node, Func<int, bool> isInvalid)
        {
            if(node == null)
                return true;

            if(isInvalid != null && isInvalid(node.Data))
                return false;

            return IsBinarySearchTree(node.Left, x => x > node.Data) && IsBinarySearchTree(node.Right, x => x < node.Data);
                
        }


        #endregion


        #region : IsBalanced

        // Is this a balanced Tree

        public bool IsBalanced()
        {
            return IsBalanced(Root);
        }
        private bool IsBalanced(Node node)
        {
            // A tree is balanced if the heights of all its nodes do not differ for more than one

            if(GetHeigthIfBalanced(node) >= 0)
                return true;

            return false;
        }

        // Get height if balanced otherwise return -1
        private long GetHeigthIfBalanced(Node node)
        {
            if(node == null)
                return 0;
            
            var leftHeigth = GetHeigthIfBalanced(node.Left);
            if(leftHeigth == -1)
                return -1;

            var rightHeigth = GetHeigthIfBalanced(node.Right);
            if(rightHeigth == -1)
                return -1;

            if(Math.Abs(leftHeigth - rightHeigth) > 1)
                return -1;

            return Math.Max(leftHeigth, rightHeigth) + 1;
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