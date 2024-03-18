using System;
using System.Collections.Generic;
using System.Linq;

public class Problem380
{
    public class RandomizedSet
    {
        private HashSet<int> _set = new();
        private Random _rnd = new();

        public bool Insert(int val)
        {
            return _set.Add(val);
        }

        public bool Remove(int val)
        {
            return _set.Remove(val);
        }

        public int GetRandom()
        {
            return _set.ElementAt(_rnd.Next(_set.Count));
        }
    }
}