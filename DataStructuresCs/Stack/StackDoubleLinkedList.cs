namespace DataStructuresCs.Stack
{
    internal class StackDoubleLinkedList<T> : IStack<T>
    {
        readonly DoubleLinkedList<T> stack;
        readonly int length;
        public int Count => stack.Count; // O(1)
        public bool IsEmpty => stack.Count == 0; // O(1)
        public StackDoubleLinkedList()
        {

        }
        public StackDoubleLinkedList(int length) // O(1)
        {
            this.length = length;
            stack = new DoubleLinkedList<T>();
        }

        public void Push(T data) //O(1)
        {
            if (Count < length) stack.AddFirst(data);
        }
        public T Pop() // O(1)
        {
            T data = stack.First;
            stack.RemoveFirst();
            return data;
        }
        public bool Peek(out T data) // O(1)
        {
            data = default;
            if (IsEmpty) return false;
            data = stack.First;
            return true;
        }
    }
}
