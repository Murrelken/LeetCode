using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace LeetCode.Problems
{
    public class Problem705
    {
        public class MyHashSet
        {
            private readonly BucketItem[] _buckets = new BucketItem[10000];

            public MyHashSet()
            {
            }

            public void Add(int key)
            {
                var hash = GetHash(key);
                if (_buckets[hash] == null)
                    _buckets[hash] = new BucketItem { Items = { key } };
                else if (!_buckets[hash].Items.Contains(key))
                    _buckets[hash].Items.Add(key);
            }

            public void Remove(int key)
            {
                var hash = GetHash(key);
                if (_buckets[hash] != null)
                    _buckets[hash].Items.Remove(key);
            }

            public bool Contains(int key)
            {
                var hash = GetHash(key);
                return _buckets[hash] != null && _buckets[hash].Items.Contains(key);
            }

            private int GetHash(int key)
                => key % _buckets.Length;

            private class BucketItem
            {
                public readonly List<int> Items = new();
            }
        }
    }
}