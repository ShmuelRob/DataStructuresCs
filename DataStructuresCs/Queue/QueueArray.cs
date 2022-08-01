using System;

namespace DataStructuresCs.Queue
{
    public class QueueArray<T> : IQueue<T>
    {
        const int QUEUE_CAPACITY = 17;
        T[] queue;
        int firstInd;
        int lastInd;
        readonly bool canGrow;

        public QueueArray() : this(QUEUE_CAPACITY)
        {
            canGrow = true;
        }
        public QueueArray(int length)
        {
            queue = new T[Math.Abs(length)];
            if (length != 0)
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
        public T DeQueue()
        {
            if (IsEmpty) return default;
            T data = queue[firstInd];
            firstInd = (firstInd + 1) % queue.Length;
            if (firstInd == lastInd) firstInd = lastInd = -1;
            Count--;
            return data;
        }
        public T Peek() => IsEmpty ? default : queue[firstInd];

        public void ReBuild()
        {
            T[] newQueue = new T[queue.Length * 2];
            int ind = 0;
            while (!IsEmpty) newQueue[ind++] = DeQueue();
            firstInd = 0;
            lastInd = ind % newQueue.Length;
            queue = newQueue;
        }
    }
}
