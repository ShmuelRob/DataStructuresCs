
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
        public void Push(T item)
        {
            if (Count == stack.Length && !canGrow) return;
            stack[ind++] = item;
            Count++;
            if (Count == stack.Length && canGrow) ReBuild();
        }
        public T Pop()
        {
            if (IsEmpty) return default;
            Count--;
            return stack[--ind];
        }
        public bool Peek(out T data)
        {
            data = default;
            if (IsEmpty) return false;
            data = stack[ind - 1];
            return true;
        }

        void ReBuild()
        {
            T[] newStack = new T[stack.Length * 2];
            for (int i = 0; i < stack.Length; i++) newStack[i] = stack[i];
            stack = newStack;
        }
    }
}
