using System;
using System.Linq;

namespace LeetCode.Problems;

public class Problem2090
{
    public int[] GetAverages(int[] nums, int k)
    {
        if (k == 0)
            return nums;
        var res = new int[nums.Length];
        Array.Fill(res, -1);
        var diameter = k * 2 + 1;
        long tempSum = 0;
        for (var i = 0; i < diameter - 1 && i < nums.Length; i++)
            tempSum += nums[i];

        for (var i = k; i < nums.Length - k; i++)
        {
            tempSum += nums[i + k];
            res[i] = (int)(tempSum / diameter);
            tempSum -= nums[i - k];
        }

        return res;
    }
}