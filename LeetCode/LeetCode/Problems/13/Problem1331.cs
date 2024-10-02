using System;
using System.Linq;

namespace LeetCode.Problems._13;

public class Problem1331
{
    public int[] ArrayRankTransform(int[] arr)
    {
        var sorted = arr.Distinct().ToArray();
        Array.Sort(sorted);
        
        var result = new int[arr.Length];
        for (var i = 0; i < arr.Length; i++)
        {
            result[i] = Array.BinarySearch(sorted, arr[i]) + 1;
        }

        return result;
    }
}