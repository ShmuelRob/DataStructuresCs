namespace DataStructuresCs.Queue
{
    internal class QueueArray<T> : IQueue<T>
    {
        T[] queue;

        int firstInd;
        int lastInd;
        readonly bool canGrow;

        const int QUEUE_CAPACITY = 17;

        public bool IsEmpty => firstInd == -1;
        public bool IsFull => !canGrow && firstInd == lastInd && firstInd != -1;
        public int Count { get; private set; }

        public QueueArray() : this(QUEUE_CAPACITY) { }
        public QueueArray(int capacity)
        {
            queue = new T[capacity];
            firstInd = lastInd = -1;
        }

        public bool EnQueue(T item) // insert
        {
            if (IsFull) return false;
            if (firstInd == lastInd && !canGrow) ReBuild();

            if (IsEmpty) lastInd = firstInd = 0;
            queue[lastInd] = item;

            lastInd = (lastInd + 1) % queue.Length;
            return true;
        }

        public bool DeQueue(out T removedItem)
        {
            removedItem = default;
            if (IsEmpty) return false;

            removedItem = queue[firstInd];
            firstInd = (firstInd + 1) % queue.Length;

            if (firstInd == lastInd) firstInd = lastInd = -1;
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
