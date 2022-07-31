
namespace DataStructuresCs.Stack
{
    internal class StackDoubleLinkedList<T> : IStack<T>
    {
        readonly DoubleLinkedList<T> stack;
        readonly int? length;

        public StackDoubleLinkedList()
            => stack = new DoubleLinkedList<T>();
        public StackDoubleLinkedList(int length)
            : this() => this.length = length;

        public int Count => stack.Count;
        public bool IsEmpty => stack.Count == 0;
        public bool IsFull => length != null && stack.Count == length;
        public void Push(T item)
        {
            if (length == null || Count < length) stack.AddFirst(item);
        }
        public T Pop()
        {
            T data = stack.First;
            stack.RemoveFirst();
            return data;
        }
        public bool Peek(out T data)
        {
            data = default;
            if (IsEmpty) return false;
            data = stack.First;
            return true;
        }
    }
}
