namespace DataStructuresCs.Queue
{
    public interface IQueue<T>
    {
        int Count { get; }
        bool IsEmpty { get; }
        bool IsFull { get; }
        bool EnQueue(T item);
        T DeQueue();
        T Peek();
    }
}