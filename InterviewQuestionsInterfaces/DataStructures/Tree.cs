using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.DataStructures
{
    class Tree
    {
        class Node
        {
            public Node Left;
            public Node Right;
            public int Value;
        }

        // IsBinarySearchTree(root, int.MinValue, int.MaxValue)
        bool IsBinarySearchTree(Node node, int min, int max)
        {
            if (node.Left != null)
            {
                if (node.Left.Value >= node.Value || node.Left.Value <= min)
                    return false;
                if (!IsBinarySearchTree(node.Left, min, node.Value))
                    return false;
            }
            if (node.Right != null)
            {
                if (node.Right.Value >= max || node.Right.Value <= node.Value)
                    return false;
                if (!IsBinarySearchTree(node.Right, node.Value, max))
                    return false;
            }
            return true;
        }
    }


}
