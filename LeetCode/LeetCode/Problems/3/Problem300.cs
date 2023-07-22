using System.Collections.Generic;

namespace LeetCode.Problems;

public class Problem300
{
    public int LengthOfLIS(int[] nums)
    {
        var longestSubSequence = new List<int> { nums[0] };

        for (var i = 1; i < nums.Length; i++)
        {
            var indexToReplace = longestSubSequence.BinarySearch(nums[i]);
            if (indexToReplace < 0)
                indexToReplace = ~indexToReplace;

            if (indexToReplace >= longestSubSequence.Count)
                longestSubSequence.Add(nums[i]);
            else
                longestSubSequence[indexToReplace] = nums[i];
        }

        return longestSubSequence.Count;
    }
}