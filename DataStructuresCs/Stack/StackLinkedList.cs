using System;

namespace DataStructuresCs.Stack
{
    public class StackLinkedList<T> : IStack<T>
    {
        readonly LinkedList<T> stack;
        readonly int? length;

        public StackLinkedList()
            => stack = new LinkedList<T>();
        public StackLinkedList(int length)
            : this() => this.length = Math.Abs(length);

        public int Count => stack.Count;
        public bool IsEmpty => stack.IsEmpty;
        public bool IsFull => length != null && stack.Count == length;
        public void Push(T item)
        {
            if (length == null || Count < length)
                stack.AddFirst(item);
        }
        public T Pop()
        {
            stack.RemoveFirst(out T data);
            return data;
        }
        public bool Peek(out T data)
        {
            data = default;
            if (stack.Count == 0) return false;
            data = stack.First;
            return true;
        }
    }
}
