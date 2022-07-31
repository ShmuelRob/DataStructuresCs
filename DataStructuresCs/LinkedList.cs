using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresCs
{
    public class LinkedList<T> : IList<T>, IEnumerable<T>, ICollection<T>
    {
        Node first;
        Node last;

        public T First { get => first.value; set => first.value = value; }
        public T Last { get => last.value; set => last.value = value; }
        public int Count { get; private set; }
        public bool IsEmpty => first == null;
        public bool IsReadOnly { get; set; }

        public LinkedList() // O(1)
        {
            first = null;
            last = null;
        }
        public LinkedList(T val) => AddFirst(val); // O(1)
        public LinkedList(params T[] vals) // O(m)
        {
            for (int i = 0; i < vals.Length; i++) AddLast(vals[i]);
        }
        public LinkedList(LinkedList<T> prevList) // O(1)
        {
            first = prevList.first;
            last = prevList.last;
        }

        public void AddFirst(T val) // O(1)
        {
            if (IsReadOnly) return;
            if (last == null)
            {
                first = new Node(val);
                last = first;
            }
            else
            {
                var temp = new Node(val) { next = first };
                first = temp;
            }
            Count++;
        }
        public void AddLast(T val) // O(1)
        {
            if (IsReadOnly) return;
            if (last == null) AddFirst(val);
            else
            {
                Node newLast = new Node(val);
                last.next = newLast;
                last = newLast;
                Count++;
            }
        }
        public bool RemoveFirst() => RemoveFirst(out _); // O(1)
        public bool RemoveFirst(out T data) // O(1)
        {
            data = default;
            if (IsReadOnly) return false;
            if (first == null) return false;
            data = first.value;
            first = first.next;
            Count--;
            return true;
        }
        public bool RemoveLast() => RemoveLast(out _); // O(n)
        public bool RemoveLast(out T data) // O(n)
        {
            data = default;
            if (IsReadOnly) return false;
            if (first == null) return false;
            if (first == last) return RemoveFirst(out data);
            if (first.next == last)
            {
                data = last.value;
                first.next = null;
                Count--;
                return true;
            }
            Node temp = first;
            while (temp.next != last) temp = temp.next;
            data = temp.next.value;
            temp.next = null;
            Count--;
            return true;
        }
        public void Add(params T[] items)
        {
            foreach (var item in items) Add(item);
        } // O(m)
        public void Add(T item) => AddLast(item); // O(1)
        public void Clear() // O(1)
        {
            if (Count == 0) return;
            first.next = null;
            first = null;
            last = null;
        }
        public bool Contains(T item) // O(n)
        {
            if (first == null) return false;
            var temp = first;
            while (temp != null)
            {
                if (temp.value.Equals(item)) return true;
                temp = temp.next;
            }
            return false;
        }
        public void CopyTo(T[] array) => CopyTo(array, 0); // O(m)
        public void CopyTo(T[] array, int arrayIndex) // O(m)
        {
            var temp = first;
            while (temp != null && arrayIndex < array.Length)
            {
                array[arrayIndex++] = temp.value;
                temp = temp.next;
            }
        }
        public bool Remove(T item) // O(n)
        {
            if (IsEmpty) return false;
            if (first.value.Equals(item)) return RemoveFirst();
            var temp = first;
            while (temp.next != null)
            {
                if (temp.next.value.Equals(item))
                {
                    temp.next = temp.next.next;
                    return true;
                }
                temp = temp.next;
            }
            return false;
        }
        public int IndexOf(T item) // O(n)
        {
            if (IsEmpty) return -1;
            int ind = 0;
            var temp = first;
            while (temp != null)
            {
                if (temp.value.Equals(item)) return ind;
                ind++;
                temp = temp.next;
            }
            return -1;
        }
        public void Insert(int index, T item) // O(n)
        {
            if (index == 0)
            {
                AddFirst(item);
                return;
            }
            if (IsEmpty)
            {
                AddFirst(item);
                return;
            }
            if (index >= Count)
            {
                AddLast(item);
                return;
            }

            var tempPrevious = first;
            for (int i = 0; i < index - 1; i++)
                tempPrevious = tempPrevious.next;

            var newNode = new Node(item)
            {
                next = tempPrevious.next
            };
            tempPrevious.next = newNode;

            Count++;
        }
        public void RemoveAt(int index) // O(n)
        {
            if (index < 0 || index >= Count) return;
            else if (index == 0) RemoveFirst();
            else if (index == Count - 1) RemoveLast();
            else
            {
                var temp = first;
                for (int i = 1; i < index; i++)
                    temp = temp.next;
                temp.next = temp.next.next;
                Count--;
            }
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
        public DoubleLinkedList<T> ToDoubleLinkedList() // O(n)
        {
            DoubleLinkedList<T> list = new DoubleLinkedList<T>(this);
            var temp = first;
            while (temp != null)
            {
                list.AddLast(temp.value);
                temp = temp.next;
            }
            return list;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException("index");
                var temp = first;
                for (int i = 0; i < index; i++)
                    temp = temp.next;
                return temp.value;
            }
            set
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException("index");
                var temp = first;
                for (int i = 0; i < index; i++)
                    temp = temp.next;
                temp.value = value;
            }
        }
        public IEnumerator<T> GetEnumerator()
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
            public Node(T val) // O(1)
            {
                value = val;
                next = null;
            }
        }
    }
}
