using System;

namespace DataStructuresCs.Queue
{
    public class QueueLinkedList<T> : IQueue<T>
    {
        readonly LinkedList<T> queue;
        readonly int? length;

        public QueueLinkedList() => queue = new LinkedList<T>();
        public QueueLinkedList(int length)
            : this() => this.length = Math.Abs(length);

        public int Count => queue.Count;
        public bool IsEmpty => queue.IsEmpty;
        public bool IsFull => length != null && queue.Count == length;
        public bool EnQueue(T item)
        {
            if (IsFull) return false;
            queue.AddLast(item);
            return true;
        }
        public T DeQueue()
        {
            if (queue.Count <= 0) return default;
            T data = queue.First;
            queue.RemoveFirst();
            return data;
        }
        public T Peek() => IsEmpty ? default : queue.First;
    }
}
