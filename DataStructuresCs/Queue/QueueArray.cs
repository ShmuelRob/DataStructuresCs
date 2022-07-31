namespace DataStructuresCs.Queue
{
    internal class QueueArray<T> : IQueue<T>
    {
        readonly T[] array;

        int firstInd; // to be placed at the "oldest" item in Queue
        int lastInd;  // to be placed at next available index
        const int QueueCapacity = 17;
        public bool IsEmpty => firstInd == -1;
        public bool IsFull => firstInd == lastInd && firstInd != -1;
        public int Count { get; private set; }

        public QueueArray() : this(QueueCapacity) { }
        public QueueArray(int capacity)
        {
            array = new T[capacity];
            firstInd = lastInd = -1;
        }

        public bool EnQueue(T item) // insert
        {
            if (IsFull) return false;

            if (IsEmpty) lastInd = firstInd = 0;
            array[lastInd] = item;

            lastInd = (lastInd + 1) % array.Length;
            return true;
        }

        public bool DeQueue(out T removedItem)
        {
            removedItem = default;
            if (IsEmpty) return false;

            removedItem = array[firstInd];
            firstInd = (firstInd + 1) % array.Length;

            //last item is removed from the queue
            if (firstInd == lastInd) firstInd = lastInd = -1;
            return true;
        }
    }
}
