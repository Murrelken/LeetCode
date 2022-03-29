using System;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem287
    {
        public int FindDuplicate(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            var n = nums.Length - 1;

            var left = 1;
            var right = nums.Length;
            while (left < right)
            {
                var mid = left + (right - left) / 2;
                var cnt = nums.Count(num => num <= mid);

                if (cnt <= mid)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return right;
        }
    }
}