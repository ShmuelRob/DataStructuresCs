namespace DataStructuresCs.Queue
{
    internal interface IQueue<T>
    {
        int Count { get; }
        bool IsEmpty { get; }
        bool IsFull { get; }
        bool EnQueue(T item);
        bool DeQueue(out T data);
        bool Peek(out T data);
    }
}
