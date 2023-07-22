using System;

namespace LeetCode.Problems;

public class Problem1493
{
    public int LongestSubarray(int[] nums)
    {
        var max = 0;
        var left = 0;
        var right = 0;
        
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
                right++;
            else
            {
                max = Math.Max(max, left + right);

                left = right;
                right = 0;
            }
        }

        max = Math.Max(max, left + right);

        return max == nums.Length ? max - 1 : max;
    }
}