namespace DataStructuresCs.Nodes
{
    internal class DoubleLinkedListNode<T>
    {
        internal T value;
        internal DoubleLinkedListNode<T> next;
        internal DoubleLinkedListNode<T> prev;
        internal DoubleLinkedListNode(T value)
        {
            this.value = value;
            next = null;
            prev = null;
        }
    }
}
