using DataStructuresCs.Queue;

namespace DataStructuresCs
{
    public class Queue<T> : IQueue<T>
    {
        IQueue<T> queue;

        public Queue() : this(new QueueArray<T>()) { }
        public Queue(int length)
            : this(new QueueArray<T>(length)) { }
        public Queue(IQueue<T> queue) => this.queue = queue;

        public int Count => queue.Count;
        public bool IsEmpty => queue.IsEmpty;
        public bool IsFull => queue.IsFull;
        public bool EnQueue(T item) => queue.EnQueue(item);
        public bool DeQueue(out T data) => queue.DeQueue(out data);
        public bool Peek(out T data) => queue.Peek(out data);
        public void ChangeState(IQueue<T> newQueue)
        {
            while (queue.DeQueue(out var data))
                newQueue.EnQueue(data);
            queue = newQueue;
        }
    }
}
