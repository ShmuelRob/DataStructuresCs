namespace DataStructuresCs.Queue
{
    internal class QueueArray<T> : IQueue<T>
    {
        T[] queue;
        int firstInd;
        int lastInd;
        readonly bool canGrow;
        const int QUEUE_CAPACITY = 17;

        public QueueArray() : this(QUEUE_CAPACITY)
        {
            canGrow = true;
        }
        public QueueArray(int capacity)
        {
            queue = new T[capacity];
            if (capacity != 0)
                firstInd = lastInd = -1;
        }

        public int Count { get; private set; }
        public bool IsEmpty => firstInd == -1;
        public bool IsFull => !canGrow && firstInd == lastInd && firstInd != -1;
        public bool EnQueue(T item)
        {
            if (IsFull) return false;
            if (firstInd == lastInd && canGrow) ReBuild();
            if (IsEmpty) lastInd = firstInd = 0;
            queue[lastInd] = item;
            lastInd = (lastInd + 1) % queue.Length;
            Count++;
            return true;
        }
        public bool DeQueue(out T data)
        {
            data = default;
            if (IsEmpty) return false;
            data = queue[firstInd];
            firstInd = (firstInd + 1) % queue.Length;
            if (firstInd == lastInd) firstInd = lastInd = -1;
            Count--;
            return true;
        }
        public bool Peek(out T data)
        {
            data = default;
            if (IsEmpty) return false;
            data = queue[firstInd];
            return true;
        }

        public void ReBuild()
        {
            T[] newQueue = new T[queue.Length * 2];
            int ind = 0;
            while (!IsEmpty)
            {
                DeQueue(out var item);
                newQueue[ind++] = item;
            }
            firstInd = 0;
            lastInd = ind % newQueue.Length;
            queue = newQueue;
        }
    }
}
