using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresCs
{
    public class LinkedList<T> : IList<T>, IEnumerable<T>, ICollection<T>
    {
        LinkedListNode<T> first;
        LinkedListNode<T> last;

        public T First { get => first.value; set => first.value = value; }
        public T Last { get => last.value; set => last.value = value; }
        public int Count { get; private set; }
        public bool IsEmpty => first == null;
        public bool IsReadOnly { get; set; }

        public LinkedList()
        {
            first = null;
            last = null;
        }
        public LinkedList(T item) => AddFirst(item);
        public LinkedList(params T[] items)
        {
            for (int i = 0; i < items.Length; i++) AddLast(items[i]);
        }
        public LinkedList(LinkedList<T> previousList)
        {
            first = previousList.first;
            last = previousList.last;
        }

        public void AddFirst(T item)
        {
            if (IsReadOnly) return;
            if (last == null)
            {
                first = new LinkedListNode<T>(item);
                last = first;
            }
            else
            {
                var temp = new LinkedListNode<T>(item) { next = first };
                first = temp;
            }
            Count++;
        }
        public void AddLast(T item)
        {
            if (IsReadOnly) return;
            if (last == null) AddFirst(item);
            else
            {
                LinkedListNode<T> newLast = new LinkedListNode<T>(item);
                last.next = newLast;
                last = newLast;
                Count++;
            }
        }
        public bool RemoveFirst() => RemoveFirst(out _);
        public bool RemoveFirst(out T data)
        {
            data = default;
            if (IsReadOnly) return false;
            if (first == null) return false;
            data = first.value;
            first = first.next;
            Count--;
            return true;
        }
        public bool RemoveLast() => RemoveLast(out _);
        public bool RemoveLast(out T data)
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
            LinkedListNode<T> temp = first;
            while (temp.next != last) temp = temp.next;
            data = temp.next.value;
            temp.next = null;
            Count--;
            return true;
        }
        public void Add(params T[] items)
        {
            foreach (var item in items) Add(item);
        }
        public void Add(T item) => AddLast(item);
        public void Clear()
        {
            if (Count == 0) return;
            first.next = null;
            first = null;
            last = null;
        }
        public bool Contains(T item)
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
        public void CopyTo(T[] array) => CopyTo(array, 0);
        public void CopyTo(T[] array, int arrayIndex)
        {
            var temp = first;
            while (temp != null && arrayIndex < array.Length)
            {
                array[arrayIndex++] = temp.value;
                temp = temp.next;
            }
        }
        public bool Remove(T item)
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
        public int IndexOf(T item)
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
        public void Insert(int index, T item)
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

            var newNode = new LinkedListNode<T>(item)
            {
                next = tempPrevious.next
            };
            tempPrevious.next = newNode;

            Count++;
        }
        public void RemoveAt(int index)
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
        public DoubleLinkedList<T> ToDoubleLinkedList()
        {
            DoubleLinkedList<T> list = new DoubleLinkedList<T>();
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
            LinkedListNode<T> temp = first;
            while (temp != null)
            {
                yield return temp.value;
                temp = temp.next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
