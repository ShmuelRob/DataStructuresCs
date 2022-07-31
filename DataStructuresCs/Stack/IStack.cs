namespace DataStructuresCs.Stack
{
    internal interface IStack<T>
    {
        int Count { get; }
        bool IsEmpty { get; }
        void Push(T data);
        T Pop();
        bool Peek(out T data);
    }
}
