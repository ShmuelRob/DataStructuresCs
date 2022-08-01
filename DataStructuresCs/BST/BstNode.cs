using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresCs.BST
{
    internal class BstNode<T>
    {
        internal T value;
        internal BstNode<T> left;
        internal BstNode<T> right;
        internal BstNode(T val)
        {
            value = val;
            left = right = null;
        }
        public bool IsLeaf => left == null && right == null;
        public override string ToString() => value.ToString();
    }
}
