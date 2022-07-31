using DataStructuresCs.Queue;
using System;

namespace DataStructuresCs
{
    public class Queue<T> : IQueue<T>
    {
        readonly IQueue<T> queue;

        public Queue() : this(QueueImplementaion.Array) { }
        public Queue(int length) 
            : this(QueueImplementaion.Array, length) { }
        public Queue(QueueImplementaion implementaion)
        {
            switch (implementaion)
            {
                case QueueImplementaion.LinkedList:
                    queue = new QueueLinkedList<T>();
                    break;
                case QueueImplementaion.DoubleLinkedList:
                    queue = new QueueDoubleLinkedList<T>();
                    break;
                case QueueImplementaion.Array:
                default:
                    queue = new QueueArray<T>();
                    break;
            }
        }
        public Queue(QueueImplementaion implementaion, int length)
        {
            switch (implementaion)
            {
                case QueueImplementaion.LinkedList:
                    queue = new QueueLinkedList<T>(Math.Abs(length));
                    break;
                case QueueImplementaion.DoubleLinkedList:
                    queue = new QueueDoubleLinkedList<T>(Math.Abs(length));
                    break;
                case QueueImplementaion.Array:
                default:
                    queue = new QueueArray<T>(Math.Abs(length));
                    break;
            }
        }

        public int Count => queue.Count;
        public bool IsEmpty => queue.IsEmpty;
        public bool IsFull => queue.IsFull;
        public bool EnQueue(T item) => queue.EnQueue(item);
        public bool DeQueue(out T data) => queue.DeQueue(out data);
        public bool Peek(out T data) => queue.Peek(out data);
    }
}
