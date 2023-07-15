using System;
using System.Collections.Generic;

namespace LeetCode.Problems;

public class Problem1751
{
    public int MaxValue(int[][] events, int k)
    {
        Array.Sort(events, (a, b) => a[0].CompareTo(b[0]));
        var n = events.Length;

        var nextIndexes = new int[n];
        for (var i = 0; i < events.Length; i++)
            nextIndexes[i] = BisectRight(events, events[i][1]);

        var dp = new int?[k + 1][];
        for (var i = 0; i < dp.Length; i++)
            dp[i] = new int?[n];

        return Dfs(0, k, events, dp, nextIndexes);
    }

    private int Dfs(int curIndex, int count, int[][] events, int?[][] dp, int[] nextIs)
    {
        if (count == 0 || curIndex == events.Length)
            return 0;

        if (dp[count][curIndex] != null)
            return dp[count][curIndex].Value;

        var nextIndex = nextIs[curIndex];
        dp[count][curIndex] = Math.Max(
            Dfs(curIndex + 1, count, events, dp, nextIs),
            Dfs(nextIndex, count - 1, events, dp, nextIs) + events[curIndex][2]);

        return dp[count][curIndex].Value;
    }

    private static int BisectRight(int[][] events, int target)
    {
        int left = 0, right = events.Length;
        while (left < right)
        {
            var mid = (left + right) / 2;
            if (events[mid][0] <= target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
}