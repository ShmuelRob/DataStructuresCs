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
        public bool Push(T item) => stack.Push(item);
        public T Pop() => stack.Pop();
        public T Peek() => stack.Peek();

        public void ChangeStrategy(IStack<T> newStack)
        {
            IStack<T> tempStack = new Stack<T>();
            while (!stack.IsEmpty) tempStack.Push(stack.Pop());
            while (!tempStack.IsEmpty) newStack.Push(tempStack.Pop());
            stack = newStack;
        }
    }
}
