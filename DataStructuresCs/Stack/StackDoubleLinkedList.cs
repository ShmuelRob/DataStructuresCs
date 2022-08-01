using System;

namespace DataStructuresCs.Stack
{
    public class StackDoubleLinkedList<T> : IStack<T>
    {
        readonly DoubleLinkedList<T> stack;
        readonly int? length;

        public StackDoubleLinkedList() => stack = new DoubleLinkedList<T>();
        public StackDoubleLinkedList(int length)
            : this() => this.length = Math.Abs(length);

        public int Count => stack.Count;
        public bool IsEmpty => stack.Count == 0;
        public bool IsFull => length != null && stack.Count == length;
        public bool Push(T item)
        {
            if (length == null || Count < length)
            {
                stack.AddFirst(item);
                return true;
            }
            return false;
        }
        public T Pop()
        {
            T data = stack.First;
            stack.RemoveFirst();
            return data;
        }
        public T Peek() => IsEmpty ? default : stack.First;
    }
}
