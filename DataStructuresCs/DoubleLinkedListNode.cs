namespace DataStructuresCs
{
    internal class DoubleLinkedListNode<T>
    {
        internal T value;
        internal DoubleLinkedListNode<T> next;
        internal DoubleLinkedListNode<T> prev;
        internal DoubleLinkedListNode(T val)
        {
            value = val;
            next = null;
            prev = null;
        }
    }
}
