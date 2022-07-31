namespace DataStructuresCs.Stack
{
    internal class StackLinkedList<T> : IStack<T>
    {
        readonly LinkedList<T> stack;
        public int Count => stack.Count; // O(1)
        public bool IsEmpty => stack.IsEmpty; // O(1)

        public StackLinkedList() => stack = new LinkedList<T>(); // O(1)
        public StackLinkedList(int length) => stack = new LinkedList<T>(); // O(1)

        public void Push(T data) => stack.AddFirst(data); // O(1)
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
