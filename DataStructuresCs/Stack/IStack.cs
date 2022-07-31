namespace DataStructuresCs.Stack
{
    internal interface IStack<T>
    {
        int Count { get; }
        bool IsEmpty { get; }
        bool IsFull { get; }
        void Push(T item);
        T Pop();
        bool Peek(out T data);
    }
}
