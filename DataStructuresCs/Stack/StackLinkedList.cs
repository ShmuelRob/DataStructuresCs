using System;

namespace DataStructuresCs.Stack
{
    public class StackLinkedList<T> : IStack<T>
    {
        readonly LinkedList<T> stack;
        readonly int? length;

        public StackLinkedList() => stack = new LinkedList<T>();
        public StackLinkedList(int length)
            : this() => this.length = Math.Abs(length);

        public int Count => stack.Count;
        public bool IsEmpty => stack.IsEmpty;
        public bool IsFull => length != null && stack.Count == length;
        public bool Push(T item)
        {
            if (length is null || Count < length)
            {
                stack.AddFirst(item);
                return true;
            }
            return false;
        }
        public T Pop()
        {
            stack.RemoveFirst(out T data);
            return data;
        }
        public T Peek() => IsEmpty ? default : stack.First;
    }
}
