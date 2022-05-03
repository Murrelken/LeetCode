using System;

namespace LeetCode.Problems
{
    public class Problem581
    {
        public int FindUnsortedSubarray(int[] nums)
        {
            int min = int.MaxValue, max = int.MinValue;
            var flag = false;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                    flag = true;
                if (flag)
                    min = Math.Min(min, nums[i]);
            }

            flag = false;
            for (var i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] > nums[i + 1])
                    flag = true;
                if (flag)
                    max = Math.Max(max, nums[i]);
            }

            int l, r;
            for (l = 0; l < nums.Length; l++)
            {
                if (min < nums[l])
                    break;
            }

            for (r = nums.Length - 1; r >= 0; r--)
            {
                if (max > nums[r])
                    break;
            }

            return r - l < 0 ? 0 : r - l + 1;
        }
    }
}