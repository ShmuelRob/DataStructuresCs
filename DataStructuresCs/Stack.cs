using DataStructuresCs.Stack;
using System;

namespace DataStructuresCs
{
    public class Stack<T> : IStack<T>
    {
        readonly IStack<T> stack;

        public Stack() : this(StackImplementaion.Array) { }
        public Stack(int length)
            : this(StackImplementaion.Array, length) { }
        public Stack(StackImplementaion implementaion)
        {
            switch (implementaion)
            {
                case StackImplementaion.LinkedList:
                    stack = new StackLinkedList<T>();
                    break;
                case StackImplementaion.DoubleLinkedList:
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
                case StackImplementaion.LinkedList:
                    stack = new StackLinkedList<T>(Math.Abs(length));
                    break;
                case StackImplementaion.DoubleLinkedList:
                    stack = new StackDoubleLinkedList<T>(Math.Abs(length));
                    break;
                case StackImplementaion.Array:
                default:
                    stack = new StackArray<T>(Math.Abs(length));
                    break;
            }
        }

        public int Count => stack.Count;
        public bool IsEmpty => stack.IsEmpty;
        public bool IsFull => stack.IsFull;
        public void Push(T item) => stack.Push(item);
        public T Pop() => stack.Pop();
        public bool Peek(out T data) => stack.Peek(out data);
    }
}
