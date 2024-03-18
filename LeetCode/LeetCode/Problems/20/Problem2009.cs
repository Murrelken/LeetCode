using System;
using System.Collections.Generic;
using System.Linq;

public class Problem2009
{
    public int MinOperations(int[] nums)
    {
        int n = nums.Length;
        int res = n;
        var unique = new HashSet<int>(nums);

        var newNums = unique.ToArray();
        Array.Sort(newNums);

        for (int i = 0; i < newNums.Length; i++)
        {
            int left = newNums[i];
            int right = left + n - 1;
            int j = Array.BinarySearch(newNums, right);
            if (j < 0)
                j = ~j;
            else
                j++;
            int count = j - i;
            res = Math.Min(res, n - count);
        }

        return res;
    }
}