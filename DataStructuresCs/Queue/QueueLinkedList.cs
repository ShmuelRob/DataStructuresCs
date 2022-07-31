
namespace DataStructuresCs.Queue
{
    internal class QueueLinkedList<T> : IQueue<T>
    {
        readonly LinkedList<T> queue;
        readonly int? length;

        public QueueLinkedList() // O(1)
            => queue = new LinkedList<T>();
        public QueueLinkedList(int length) //
            : this() => this.length = length;

        public int Count => queue.Count;
        public bool IsEmpty => queue.IsEmpty;
        public bool IsFull => length != null && queue.Count == length;
        public bool EnQueue(T item)
        {
            throw new System.NotImplementedException();
        }
        public bool DeQueue(out T data)
        {
            throw new System.NotImplementedException();
        }
        public bool Peek(out T data)
        {
            throw new System.NotImplementedException();
        }
    }
}
