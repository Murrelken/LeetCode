using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem706
    {
        public class MyHashMap
        {
            private readonly BucketItem<int, int>[] _buckets = new BucketItem<int, int>[10000];

            public MyHashMap()
            {
            }

            public void Put(int key, int value)
            {
                var hash = GetHash(key);
                if (_buckets[hash] == null)
                    _buckets[hash] = new BucketItem<int, int> { Items = { new KeyValueItem<int, int>(key, value) } };
                else if (!_buckets[hash].Items.Select(x => x.Key).Contains(key))
                    _buckets[hash].Items.Add(new KeyValueItem<int, int>(key, value));
                else
                    _buckets[hash].Items.First(x => x.Key == key).Value = value;
            }

            public int Get(int key)
            {
                var hash = GetHash(key);
                if(_buckets[hash] == null || !_buckets[hash].Items.Select(x => x.Key).Contains(key))
                    return -1;

                return _buckets[hash].Items.First(x => x.Key == key).Value;
            }

            public void Remove(int key)
            {
                var hash = GetHash(key);
                if(_buckets[hash] == null || !_buckets[hash].Items.Select(x => x.Key).Contains(key))
                    return;

                var itemToRemove = _buckets[hash].Items.First(x => x.Key == key);
                _buckets[hash].Items.Remove(itemToRemove);
            }

            private int GetHash(int key)
                => key % _buckets.Length;
            
            private class BucketItem<TKey, TValue>
            {
                public readonly List<KeyValueItem<TKey, TValue>> Items = new();
            }

            private class KeyValueItem<TKey, TValue>
            {
                public KeyValueItem(TKey key, TValue value)
                {
                    Key = key;
                    Value = value;
                }

                public TKey Key { get; set; }
                public TValue Value { get; set; }
            }
        }
    }
}