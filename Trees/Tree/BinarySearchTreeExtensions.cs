using System;

namespace Coding.Trees
{
    public static class BinarySearchTreeExtensions
    {
        public static void Modify(this BinarySearchTree tree, Func<Node,bool> tweek, Action<int> read)
        {
            Modify(tree.Root, tweek, read);
        }

        private static void Modify(Node node, Func<Node,bool> tweek, Action<int> read)
        {
            if(node == null)
                return;

            if(tweek != null && tweek(node))
                return;

            Modify(node.Left, tweek, read);

            if(read != null)
                read(node.Data);

            Modify(node.Right, tweek, read);
        }
    }
}