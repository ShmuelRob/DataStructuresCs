using DataStructuresCs.Stack;

namespace DataStructuresCs
{
    public class Stack<T> : IStack<T>
    {
        readonly IStack<T> stack;

        public Stack() : this(StackImplementaion.Array) { }
        public Stack(int length) : this(StackImplementaion.Array, length) { }
        public Stack(StackImplementaion implementaion)
        {
            switch (implementaion)
            {
                case StackImplementaion.linkedList:
                    stack = new StackLinkedList<T>();
                    break;
                case StackImplementaion.doubleLinkedList:
                    stack = new StackDoubleLinkedList<T>();
                    break;
                case StackImplementaion.Array:
                default:
                    stack = new StackArray<T>();
                    break;
            }
        }
        public Stack(StackImplementaion implementaion, int length)
        {
            switch (implementaion)
            {
                case StackImplementaion.linkedList:
                    stack = new StackLinkedList<T>(length);
                    break;
                case StackImplementaion.doubleLinkedList:
                    stack = new StackDoubleLinkedList<T>(length);
                    break;
                case StackImplementaion.Array:
                default:
                    stack = new StackArray<T>(length);
                    break;
            }
        }

        public int Count => stack.Count;
        public bool IsEmpty => stack.IsEmpty;

        public bool Peek(out T data) => stack.Peek(out data);
        public T Pop() => stack.Pop();
        public void Push(T data) => stack.Push(data);
    }
}
