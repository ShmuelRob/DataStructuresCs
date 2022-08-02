namespace DataStructuresCs.Nodes
{
    internal class LinkedListNode<T>
    {
        internal T value;
        internal LinkedListNode<T> next;
        internal LinkedListNode(T value)
        {
            this.value = value;
            next = null;
        }
    }
}
