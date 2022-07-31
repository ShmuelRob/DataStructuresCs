using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace DataStructuresCs
{
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        Node first;
        Node last;

        public T First { get => first.value; }
        public T Last { get => last.value; }
        public int Count { get; private set; }

        public DoubleLinkedList() // O(1)
        {
            first = null;
            last = null;
            Count = 0;
        }
        public DoubleLinkedList(T item) => AddFirst(item); // O(1)
        public DoubleLinkedList(params T[] items) // O(m)
        {
            for (int i = 0; i < items.Length; i++) AddLast(items[i]);
        }
        public DoubleLinkedList(DoubleLinkedList<T> previousList) // O(1)
        {
            first = previousList.first;
            last = previousList.last;
            Count = previousList.Count;
        }
        public DoubleLinkedList(LinkedList<T> previousList) => previousList.ToDoubleLinkedList(); // O(m)

        public void AddFirst(T item) // O(1)
        {
            if (first == null)
            {
                first = new Node(item);
                last = first;
                Count = 1;
            }
            else
            {
                var temp = new Node(item) { next = first };
                first.prev = temp;
                first = temp;
                Count++;
            }
        }
        public void AddLast(T item) // O(1)
        {
            if (last == null) AddFirst(item);
            else
            {
                Node newLast = new Node(item);
                last.next = newLast;
                newLast.prev = last;
                last = newLast;
                Count++;
            }
        }
        public bool RemoveFirst() => RemoveFirst(out _);
        public bool RemoveFirst(out T data) // O(1)
        {
            data = default;
            if (first == null) return false;
            data = first.value;
            if (first.next == null)
            {
                first = null;
                Count = 0;
                return true;
            }
            first = first.next;
            first.prev = null;
            Count--;
            return true;
        }
        public bool RemoveLast() => RemoveLast(out _);
        public bool RemoveLast(out T data) // O(1)
        {
            data = default;
            if (last == null) return false;
            data = last.value;
            if (last.prev == null)
            {
                last = null;
                Count--;
                return true;
            }
            last = last.prev;
            last.next = null;
            Count--;
            return true;
        }

        public LinkedList<T> ToLinkedList() // O(n)
        {
            LinkedList<T> list = new LinkedList<T>();
            var temp = first;
            while (temp != null)
            {
                list.AddLast(temp.value);
                temp = temp.next;
            }
            return list;
        }
        public override string ToString() // O(n)
        {
            StringBuilder sb = new StringBuilder();
            var temp = first;
            while (temp != null)
            {
                sb.Append($"{temp.value} ");
                temp = temp.next;
            }
            return sb.ToString();
        }

        public IEnumerator<T> GetEnumerator() // O(n)
        {
            Node temp = first;
            while (temp != null)
            {
                yield return temp.value;
                temp = temp.next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        internal class Node
        {
            internal T value;
            internal Node next;
            internal Node prev;
            internal Node(T val)
            {
                value = val;
                next = null;
                prev = null;
            }
        }
    }
}
