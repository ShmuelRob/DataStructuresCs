namespace DataStructuresCs.Nodes
{
    internal class HashData<TKey, TValue>
    {
        internal TKey key;
        internal TValue value;

        public HashData(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
