using System;
using System.Collections.Generic;

namespace LeetCode.Problems
{
    public class Problem1695
    {
        public int MaximumUniqueSubarray(int[] nums)
        {
            int tempResult = 0, result = 0, left = 0, right = 0;
            var hash = new HashSet<int>();

            while (right < nums.Length)
            {
                if (!hash.Contains(nums[right]))
                {
                    hash.Add(nums[right]);
                    tempResult += nums[right];
                    result = Math.Max(result, tempResult);
                    right++;
                }
                else
                {
                    tempResult -= nums[left];
                    hash.Remove(nums[left]);
                    left++;
                }
            }

            return result;
        }
    }
}