namespace DataStructuresCs.Nodes
{
    internal class LinkedListNode<T>
    {
        internal T value;
        internal LinkedListNode<T> next;
        internal LinkedListNode(T val) // O(1)
        {
            value = val;
            next = null;
        }
    }
}
