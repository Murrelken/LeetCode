using System.Collections.Generic;
using System.Linq;
using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class Problem341
    {
        public class NestedIterator
        {
            private IEnumerator<NestedInteger> _iterator;
            private readonly Stack<IEnumerator<NestedInteger>> _previousEnumerators;
            private bool _hasNext;

            public NestedIterator(IList<NestedInteger> nestedList)
            {
                _iterator = nestedList.GetEnumerator();
                _hasNext = _iterator.MoveNext();
                _previousEnumerators = new Stack<IEnumerator<NestedInteger>>();
            }

            public bool HasNext() => _hasNext;

            public int Next()
            {
                var current = _iterator.Current;
                return current.IsInteger() ? DoIfInteger(current) : DoIfList(current);
            }

            private int DoIfInteger(NestedInteger current)
            {
                _hasNext = _iterator.MoveNext();
                while (!_hasNext && _previousEnumerators.Any())
                {
                    _iterator = _previousEnumerators.Pop();
                    _hasNext = _iterator.MoveNext();
                }

                return current.GetInteger();
            }

            private int DoIfList(NestedInteger current)
            {
                _previousEnumerators.Push(_iterator);
                _iterator = current.GetList().GetEnumerator();
                _iterator.MoveNext();
                current = _iterator.Current;
                return current.IsInteger() ? DoIfInteger(current) : DoIfList(current);
            }
        }
    }
}