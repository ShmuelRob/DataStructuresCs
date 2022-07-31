
namespace DataStructuresCs.Stack
{
    internal class StackLinkedList<T> : IStack<T>
    {
        readonly LinkedList<T> stack;
        readonly int? length;
        public int Count => stack.Count; // O(1)
        public bool IsEmpty => stack.IsEmpty; // O(1)

        public StackLinkedList()
            => stack = new LinkedList<T>(); // O(1)
        public StackLinkedList(int length) // O(1)
            : this() => this.length = length;

        public void Push(T data) // O(1)
        {
            if (length == null || Count < length) stack.AddFirst(data);
        }
        public T Pop() // O(1)
        {
            stack.RemoveFirst(out T data);
            return data;
        }
        public bool Peek(out T data) // O(1)
        {
            data = default;
            if (stack.Count == 0) return false;
            data = stack.First;
            return true;
        }
    }
}
