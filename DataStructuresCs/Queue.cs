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
        public T DeQueue() => queue.DeQueue();
        public T Peek() => queue.Peek();
        public void ChangeStrategy(IQueue<T> newQueue)
        {
            while (!queue.IsEmpty)
                newQueue.EnQueue(queue.DeQueue());
            queue = newQueue;
        }
    }
}
