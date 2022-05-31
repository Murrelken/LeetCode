using System;
using System.Collections.Generic;

namespace LeetCode.Problems
{
    public class Problem284
    {
        class PeekingIterator
        {
            private readonly IEnumerator<int> _iterator;
            private bool _hasNext;

            // iterators refers to the first element of the array.
            public PeekingIterator(IEnumerator<int> iterator)
            {
                // initialize any member here.
                _iterator = iterator;
                _hasNext = true;
            }

            // Returns the next element in the iteration without advancing the iterator.
            public int Peek()
            {
                return _iterator.Current;
            }

            // Returns the next element in the iteration and advances the iterator.
            public int Next()
            {
                var result = _iterator.Current;
                ;
                _hasNext = _iterator.MoveNext();

                return result;
            }

            // Returns false if the iterator is refering to the end of the array of true otherwise.
            public bool HasNext()
            {
                return _hasNext;
            }
        }
    }
}