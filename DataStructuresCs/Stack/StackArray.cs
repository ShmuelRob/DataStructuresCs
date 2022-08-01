
using System;

namespace DataStructuresCs.Stack
{
    public class StackArray<T> : IStack<T>
    {
        T[] stack;
        int ind;
        readonly bool canGrow;
        const int ARRAY_LENGTH = 17;

        public StackArray(int length) => stack = new T[Math.Abs(length)];
        public StackArray()
        {
            stack = new T[ARRAY_LENGTH];
            canGrow = true;
        }

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;
        public bool IsFull => !canGrow && Count == stack.Length;
        public bool Push(T item)
        {
            if (Count == stack.Length && !canGrow) return false;
            stack[ind++] = item;
            Count++;
            if (Count == stack.Length && canGrow) ReBuild();
            return true;
        }
        public T Pop()
        {
            if (IsEmpty) return default;
            Count--;
            return stack[--ind];
        }
        public T Peek() => IsEmpty ? default : stack[ind - 1];

        void ReBuild()
        {
            T[] newStack = new T[stack.Length * 2];
            for (int i = 0; i < stack.Length; i++) newStack[i] = stack[i];
            stack = newStack;
        }
    }
}
