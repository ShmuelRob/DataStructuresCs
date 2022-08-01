namespace DataStructuresCs.Stack
{
    public interface IStack<T>
    {
        int Count { get; }
        bool IsEmpty { get; }
        bool IsFull { get; }
        bool Push(T item);
        T Pop();
        T Peek();
    }
}
