using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems;

public class Problem1218
{
    public int LongestSubsequence(int[] arr, int difference)
    {
        var dp = new Dictionary<int, int>();
        var answer = 1;
        
        for (var i = 0; i < arr.Length; i++)
        {
            var el = arr[i];
            dp.TryGetValue(el - difference, out var previousCount);
            if (!dp.TryAdd(el, previousCount + 1))
                dp[el] = previousCount + 1;
            answer = Math.Max(answer, dp[el]);
        }
        
        return answer;
    }
}