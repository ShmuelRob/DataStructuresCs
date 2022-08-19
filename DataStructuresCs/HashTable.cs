using DataStructuresCs.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresCs
{
    public class HashTable<TKey, TValue>
    {
        LinkedList<HashData<TKey, TValue>>[] hashArray;
        public int itemsCnt;

        public HashTable(int capacity)
        {
            hashArray = new LinkedList<HashData<TKey, TValue>>[capacity];
            itemsCnt = 0;
        }

        public void Add(TKey key, TValue value)
        {
            int index = HashFunc(key);
            var d = new HashData<TKey, TValue>(key, value);
            if (hashArray[index] == null)
            {
                hashArray[index] = new LinkedList<HashData<TKey, TValue>>();
            }
            else
            {
                foreach (var data in hashArray[index])
                {
                    if (data.key.Equals(key)) throw new ArgumentException("An item with the same key has already been added");
                }
            }
            hashArray[index].AddFirst(d);
            itemsCnt++;
        }

        int HashFunc(TKey key) =>
            Math.Abs(key.GetHashCode()) % hashArray.Length;
    }
}
