using System.Collections.Generic;

namespace LeetCode.Problems;

public class Problem146
{
    public class LRUCache
    {
        private LinkedList<(int val, int key)> _keysToDelete = new();
        private Dictionary<int, LinkedListNode<(int val, int key)>> _cache = new();
        private int _capacity;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (!_cache.TryGetValue(key, out var node)) return -1;
            _keysToDelete.Remove(node);
            _keysToDelete.AddFirst(node);
            return node.Value.val;
        }

        public void Put(int key, int value)
        {
            if (_cache.TryGetValue(key, out LinkedListNode<(int val, int key)> node))
            {
                node.Value = (value, key);
                _keysToDelete.Remove(node);
                _keysToDelete.AddFirst(node);
                return;
            }

            if (_keysToDelete.Count == _capacity)
            {
                _cache.Remove(_keysToDelete.Last!.Value.key);
                _keysToDelete.RemoveLast();
            }

            var newNode = _keysToDelete.AddFirst((value, key));
            _cache.Add(key, newNode);
        }
    }
}