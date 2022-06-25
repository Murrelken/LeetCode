using System;

namespace LeetCode.Problems
{
    public class Problem215
    {
        public int FindKthLargest(int[] nums, int k)
        {
            Array.Sort(nums);
            return nums[^k];
        }
    }
}