using System.Collections.Generic;
using System.Collections;
using System.Text;
using DataStructuresCs.Nodes;

namespace DataStructuresCs
{
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        DoubleLinkedListNode<T> first;
        DoubleLinkedListNode<T> last;

        public T First { get => first.value; }
        public T Last { get => last.value; }
        public int Count { get; private set; }

        public DoubleLinkedList()
        {
            first = null;
            last = null;
            Count = 0;
        }
        public DoubleLinkedList(T item) => AddFirst(item);
        public DoubleLinkedList(params T[] items)
        {
            for (int i = 0; i < items.Length; i++) AddLast(items[i]);
        }
        public DoubleLinkedList(DoubleLinkedList<T> previousList)
        {
            first = previousList.first;
            last = previousList.last;
            Count = previousList.Count;
        }
        public DoubleLinkedList(LinkedList<T> previousList) => previousList.ToDoubleLinkedList();

        public void AddFirst(T item)
        {
            if (first == null)
            {
                first = new DoubleLinkedListNode<T>(item);
                last = first;
                Count = 1;
            }
            else
            {
                var temp = new DoubleLinkedListNode<T>(item) { next = first };
                first.prev = temp;
                first = temp;
                Count++;
            }
        }
        public void AddLast(T item)
        {
            if (last == null) AddFirst(item);
            else
            {
                DoubleLinkedListNode<T> newLast = new DoubleLinkedListNode<T>(item);
                last.next = newLast;
                newLast.prev = last;
                last = newLast;
                Count++;
            }
        }
        public bool RemoveFirst() => RemoveFirst(out _);
        public bool RemoveFirst(out T data)
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
        public bool RemoveLast(out T data)
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
        public LinkedList<T> ToLinkedList()
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
        public override string ToString()
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

        public IEnumerator<T> GetEnumerator()
        {
            DoubleLinkedListNode<T> temp = first;
            while (temp != null)
            {
                yield return temp.value;
                temp = temp.next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
