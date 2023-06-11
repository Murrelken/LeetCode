using System;

namespace LeetCode.Problems;

public class Problem1502
{
    public bool CanMakeArithmeticProgression(int[] arr)
    {
        Array.Sort(arr);
        var v = arr[1] - arr[0];
        for (var i = 2; i < arr.Length; i++)
        {
            if (arr[i] - arr[i - 1] != v)
                return false;
        }

        return true;
    }
}