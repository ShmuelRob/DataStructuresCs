using DataStructuresCs.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresCs
{
    public class BST<T> : IEnumerable<T> where T : IComparable<T>
    {
        BstNode<T> root;
        public T Root => root.value;
        public bool IsEmpty => root == null;
        public int Levels => GetLevels(root);

        int GetLevels(BstNode<T> temp)
        {
            if (temp == null) return 0;
            int lef = GetLevels(temp.left);
            int rig = GetLevels(temp.right);
            return Math.Max(lef, rig) + 1;
        }
        public void Add(T item)
        {
            if (IsEmpty)
            {
                root = new BstNode<T>(item);
                return;
            }
            BstNode<T> temp = root;
            while (true)
            {
                if (item.CompareTo(temp.value) < 0)
                {
                    if (temp.left == null)
                    {
                        temp.left = new BstNode<T>(item);
                        break;
                    }
                    temp = temp.left;
                }
                else
                {
                    if (temp.right == null)
                    {
                        temp.right = new BstNode<T>(item);
                        break;
                    }
                    temp = temp.right;
                }
            }
        }
        public bool Search(T item, out T foundItem) => Search(root, item, out foundItem);
        bool Search(BstNode<T> temp, T item, out T foundItem)
        {
            foundItem = default;
            if (temp == null) return false;
            if (item.CompareTo(temp.value) == 0)
            {
                foundItem = temp.value;
                return true;
            }
            else if (item.CompareTo(temp.value) < 0) return Search(temp.left, item, out foundItem);
            else return Search(temp.right, item, out foundItem);
        }
        public bool Remove(T value)
        {
            root = Remove(root, value, out bool isRemoved);
            return isRemoved;
        }
        BstNode<T> Remove(BstNode<T> parent, T val, out bool isRemoved)
        {
            isRemoved = false;
            if (parent == null) return parent;

            if (parent.value.CompareTo(val) > 0)
                parent.left = Remove(parent.left, val, out isRemoved);
            else if (parent.value.CompareTo(val) < 0)
                parent.right = Remove(parent.right, val, out isRemoved);
            else
            {
                if (parent.left == null)
                {
                    isRemoved = true;
                    return parent.right;
                }
                else if (parent.right == null)
                {
                    isRemoved = true;
                    return parent.left;
                }
                parent.value = Replacer(parent.right);
                parent.right = Remove(parent.right, parent.value, out _);
                isRemoved = true;
            }
            return parent;
        }
        T Replacer(BstNode<T> parent)
        {
            if (parent.IsLeaf) return parent.value;
            BstNode<T> temp = parent;
            while (temp.left != null)
            {
                parent = temp;
                temp = temp.left;
            }
            parent.left = null;
            return temp.value;
        }

        public IEnumerator<T> GetEnumerator() => GetEnumeratorInOrder().GetEnumerator();
        public IEnumerable<T> GetEnumeratorInOrder() => GetEnumeratorInOrder(root);
        public IEnumerable<T> GetEnumeratorPreOrder() => GetEnumeratorPreOrder(root);
        public IEnumerable<T> GetEnumeratorPostOrder() => GetEnumeratorPostOrder(root);

        IEnumerable<T> GetEnumeratorInOrder(BstNode<T> tempRoot)
        {
            if (tempRoot.left != null)
            {
                foreach (T item in GetEnumeratorInOrder(tempRoot.left))
                    yield return item;
            }
            yield return tempRoot.value;
            if (tempRoot.right != null)
            {
                foreach (T item in GetEnumeratorInOrder(tempRoot.right))
                    yield return item;
            }
        }
        IEnumerable<T> GetEnumeratorPreOrder(BstNode<T> tempRoot)
        {
            yield return tempRoot.value;
            if (tempRoot.left != null)
            {
                foreach (T item in GetEnumeratorPreOrder(tempRoot.left))
                    yield return item;
            }
            if (tempRoot.right != null)
            {
                foreach (T item in GetEnumeratorPreOrder(tempRoot.right))
                    yield return item;
            }
        }
        IEnumerable<T> GetEnumeratorPostOrder(BstNode<T> tempRoot)
        {
            if (tempRoot.left != null)
            {
                foreach (T item in GetEnumeratorPostOrder(tempRoot.left))
                    yield return item;
            }
            if (tempRoot.right != null)
            {
                foreach (T item in GetEnumeratorPostOrder(tempRoot.right))
                    yield return item;
            }
            yield return tempRoot.value;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
