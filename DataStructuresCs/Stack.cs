using DataStructuresCs.Stack;

namespace DataStructuresCs
{
    public class Stack<T> : IStack<T>
    {
        readonly IStack<T> stack;

        public Stack() : this(new StackArray<T>()) { }
        public Stack(int length)
            : this(new StackArray<T>(length)) { }
        public Stack(IStack<T> stack) => this.stack = stack;

        public int Count => stack.Count;
        public bool IsEmpty => stack.IsEmpty;
        public bool IsFull => stack.IsFull;
        public void Push(T item) => stack.Push(item);
        public T Pop() => stack.Pop();
        public bool Peek(out T data) => stack.Peek(out data);
    }
}
