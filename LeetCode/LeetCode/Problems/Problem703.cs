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
}