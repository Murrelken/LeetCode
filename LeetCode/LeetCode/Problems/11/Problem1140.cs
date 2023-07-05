using System;

namespace LeetCode.Problems;

public class Problem1140
{
    public int StoneGameII(int[] piles)
    {
        var n = piles.Length;
        var dp = new int?[n, n];
        var sums = new int[n];
        sums[n - 1] = piles[n - 1];

        for (var i = piles.Length - 2; i >= 0; i--)
        {
            sums[i] = sums[i + 1] + piles[i];
        }

        return Req(piles, sums, dp, 0, 1);
    }

    private int Req(int[] piles, int[] sums, int?[,] dpArr, int start, int m)
    {
        if (start == piles.Length)
        {
            return 0;
        }

        var twiceM = m << 1;

        if (start + twiceM >= piles.Length)
            return sums[start];

        if (dpArr[start, m] is not null)
            return dpArr[start, m].Value;


        var min = int.MaxValue;

        for (var j = 1; j <= twiceM; j++)
            min = Math.Min(min, Req(piles, sums, dpArr, start + j, Math.Max(j, m)));


        dpArr[start, m] = sums[start] - min;
        return dpArr[start, m].Value;
    }
}