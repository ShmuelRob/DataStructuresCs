using DataStructuresCs.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresCs
{
    public class HashTable<TKey, TValue>
    {
        const int defaultCap = 17;
        LinkedList<HashData<TKey, TValue>>[] hashArray;
        int hashCount;
        readonly Func<TKey, int> hashFunction;

        public int Count => hashCount;
        public TKey[] Keys
        {
            get
            {
                TKey[] keys = new TKey[Count];
                int count = 0;
                for (int i = 0; i < hashArray.Length; i++)
                {
                    if (hashArray[i] is null) continue;
                    foreach (var item in hashArray[i])
                    {
                        keys[count++] = item.key;
                    }
                }
                return keys;
            }
        }
        public TValue[] Values
        {
            get
            {
                TValue[] values = new TValue[Count];
                int count = 0;
                for (int i = 0; i < hashArray.Length; i++)
                {
                    if (hashArray[i] is null) continue;
                    foreach (var item in hashArray[i])
                    {
                        values[count++] = item.value;
                    }
                }
                return values;
            }
        }

        public HashTable(int capacity)
            : this(capacity, null) { }
        public HashTable(int capacity, Func<TKey, int> hashFunc)
        {
            if (capacity <= 0) capacity = defaultCap;
            hashArray = new LinkedList<HashData<TKey, TValue>>[capacity];
            hashCount = 0;
            if (hashFunc is null)
                hashFunc = DefaultHashFunction;
            this.hashFunction = hashFunc;
        }

        public void Add(TKey key, TValue value)
        {
            int index = HashFunction(key);
            var d = new HashData<TKey, TValue>(key, value);
            if (hashArray[index] is null)
            {
                hashArray[index] = new LinkedList<HashData<TKey, TValue>>();
            }
            else
            {
                foreach (var data in hashArray[index])
                {
                    if (data.key.Equals(key))
                        throw new ArgumentException("An item with the same key has already been added");
                }
            }
            hashArray[index].AddFirst(d);
            hashCount++;
            if (hashCount > 0.75 * hashArray.Length) ReHash();
        }
        public bool Remove(TKey key)
        {
            int index = HashFunction(key);
            if (hashArray[index] == null)
                return false;
            foreach (var data in hashArray[index])
            {
                if (data.key.Equals(key))
                {
                    hashArray[index].Remove(data);
                    hashCount--;
                    return true;
                }
            }
            return false;
        }
        public void Clear()
        {
            for (int i = 0; i < hashArray.Length; i++)
            {
                hashArray[i] = null;
            }
            hashCount = 0;
        }
        public bool ContainsKey(TKey key)
        {
            int ind = HashFunction(key);
            if (hashArray[ind] == null) return false;
            foreach (var item in hashArray[ind])
                if (item.key.Equals(key)) return true;
            return false;
        }
        public bool ContainsValue(TValue value)
        {
            foreach (var list in hashArray)
            {
                if (list is null) continue;
                foreach (var hash in list)
                {
                    if (hash.value.Equals(value))
                        return true;
                }
            }
            return false;
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default;
            if (!ContainsKey(key)) return false;
            int index = HashFunction(key);
            value = hashArray[index].First(d => d.key.Equals(key)).value;
            return true;
        }
        public TValue this[TKey key]
        {
            get
            {
                int ind = HashFunction(key);
                if (hashArray[ind] is null)
                    throw new KeyNotFoundException($"The given key {key} was not present in the dictionary");
                HashData<TKey, TValue> foundData = hashArray[ind].FirstOrDefault(d => d.key.Equals(key));
                if (foundData is null)
                    throw new KeyNotFoundException($"The given key {key} was not present in the dictionary");
                return foundData.value;
            }
            set
            {
                if (!ContainsKey(key))
                    Add(key, value);
                else
                {
                    int ind = HashFunction(key);
                    var foundData = hashArray[ind].First(d => d.key.Equals(key));
                    foundData.value = value;
                    //foundData = new HashData<TKey, TValue>(key, value);
                }
            }
        }

        void ReHash()
        {
            LinkedList<HashData<TKey, TValue>>[] oldArray = hashArray;
            hashArray = new LinkedList<HashData<TKey, TValue>>[hashCount * 2];
            hashCount = 0;
            for (int i = 0; i < oldArray.Length; i++)
            {
                if (oldArray[i] == null) continue;
                foreach (var data in oldArray[i])
                    Add(data.key, data.value);
            }
        }
        int DefaultHashFunction(TKey key) => key.GetHashCode();
        int HashFunction(TKey key) =>
            Math.Abs(hashFunction(key)) % hashArray.Length;
    }
}
