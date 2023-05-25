using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1;

namespace LeetCode.Problems
{
    public class Problem703
    {
        public class KthLargest
        {
            private int _k;
            private List<int> _nums;
            private Problem35 _searcher;

            public KthLargest(int k, int[] nums)
            {
                _k = k;
                Array.Sort(nums);
                _nums = nums.ToList();
                var searcher = new Problem35();
                _searcher = searcher;
            }

            public int Add(int val)
            {
                _nums.Insert(_searcher.SearchInsert(_nums.ToArray(), val), val);
                return _nums[^_k];
            }
        }
    }

    public class KthLargestSlower
    {
        private readonly int?[] _kLargestValues;
        private readonly int _k;

        public KthLargestSlower(int k, int[] nums)
        {
            _k = k;
            _kLargestValues = new int?[k];

            for (var i = 0; i < nums.Length; i++)
            {
                var numberToAssign = nums[i];
                AddElementToSortedArray(numberToAssign);
            }
        }

        public int Add(int val)
        {
            AddElementToSortedArray(val);
            return _kLargestValues.First(x => x is not null).Value;
        }

        private void AddElementToSortedArray(int numberToAssign)
        {
            int? tempNumberToAssign = numberToAssign;
            for (var j = _k - 1; j >= 0; j--)
            {
                if (tempNumberToAssign <= _kLargestValues[j] && _kLargestValues[j] is not null)
                    continue;

                (tempNumberToAssign, _kLargestValues[j]) = (_kLargestValues[j], tempNumberToAssign);
            }
        }
    }
}