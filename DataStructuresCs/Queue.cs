using DataStructuresCs.Queue;

namespace DataStructuresCs
{
    public class Queue<T> : IQueue<T>
    {
        readonly IQueue<T> queue;

        public Queue() : this(QueueImplementaion.Array) { }
        public Queue(QueueImplementaion implementaion)
        {
            switch (implementaion)
            {
                case QueueImplementaion.linkedList:
                    queue = new QueueLinkedList<T>();
                    break;
                case QueueImplementaion.doubleLinkedList:
                    queue = new QueueDoubleLinkedList<T>();
                    break;
                case QueueImplementaion.Array:
                default:
                    queue = new QueueArray<T>();
                    break;
            }
        }

        public int Count => queue.Count;
        public bool IsEmpty => queue.IsEmpty;
        public bool IsFull => queue.IsFull;
        public bool DeQueue(out T removedItem) => queue.DeQueue(out removedItem);
        public bool EnQueue(T item) => queue.EnQueue(item);
    }
}
