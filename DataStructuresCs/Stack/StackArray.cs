namespace DataStructuresCs.Stack
{
    internal class StackArray<T> : IStack<T>
    {
        T[] stack;
        int ind;
        readonly bool canGrow;
        const int ARRAY_LENGTH = 17;

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0; // O(1)

        public StackArray(int length) => stack = new T[length]; // O(1)
        public StackArray() // O(1)
        {
            stack = new T[ARRAY_LENGTH];
            canGrow = true;
        }

        public void Push(T data) // O(1)
        {
            if (Count == stack.Length && !canGrow) return;
            stack[ind++] = data;
            Count++;
            if (Count == stack.Length) ReBuild();
        }
        public T Pop() // O(1)
        {
            if (IsEmpty) return default;
            Count--;
            return stack[--ind];
        }
        public bool Peek(out T data) // O(1)
        {
            data = default;
            if (IsEmpty) return false;
            data = stack[ind - 1];
            return true;
        }

        void ReBuild() // O(n)
        {
            T[] newArr = new T[stack.Length * 2];
            for (int i = 0; i < stack.Length; i++) newArr[i] = stack[i];
            stack = newArr;
        }
    }
}
