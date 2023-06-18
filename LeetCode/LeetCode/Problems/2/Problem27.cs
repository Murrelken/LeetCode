using System;

namespace LeetCode.Problems;

public class Problem27
{
    public int RemoveElement(int[] nums, int val)
    {
        var length = nums.Length;
        var i = 0;
        var valCount = 0;

        for (var j = length - 1; j >= 0; j--)
        {
            if (nums[j] == val)
                valCount++;
            else
                break;
        }


        while (i < length)
        {
            if (i > length - 1 - valCount || nums[i] != val)
            {
                i++;
                continue;
            }

            (nums[i], nums[length - 1 - valCount]) = (nums[length - 1 - valCount], nums[i]);
            valCount++;
            if (nums[i] != val)
                i++;
        }

        return length - valCount;
    }
}