namespace DataStructuresCs
{
    internal class LinkedListNode<T>
    {
        internal T value;
        internal LinkedListNode<T> next;
        public LinkedListNode(T val) // O(1)
        {
            value = val;
            next = null;
        }
    }
}
