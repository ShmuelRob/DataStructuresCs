using DataStructuresCs.Stack;

namespace DataStructuresCs
{
    public class Stack<T> : IStack<T>
    {
        IStack<T> stack;

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
        public void ChangeStrategy(IStack<T> newStack)
        {
            IStack<T> tempStack = new Stack<T>();
            while (!stack.IsEmpty) tempStack.Push(stack.Pop());
            while (!newStack.IsEmpty) newStack.Push(tempStack.Pop());
            stack = newStack;
        }
    }
}
