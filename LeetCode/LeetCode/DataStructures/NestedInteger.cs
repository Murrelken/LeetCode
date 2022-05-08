using System.Collections;
using System.Collections.Generic;

namespace LeetCode.DataStructures
{
    public class NestedInteger
    {
        private readonly int _number;
        private readonly IList<NestedInteger> _list;
        public NestedInteger(int number)
        {
            _number = number;
            _list = null;
        }
        public NestedInteger(IList<NestedInteger> list)
        {
            _list = list;
            _number = int.MinValue;
        }

        public bool IsInteger() => _number != int.MinValue;

        public int GetInteger() => _number;

        public IList<NestedInteger> GetList() => _list;
    }
}