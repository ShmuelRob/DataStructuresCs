namespace DataStructuresCs.Nodes
{
    internal class HashData<TKey, TValue>
    {
        public TKey key;
        public TValue value;

        public HashData(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
