using System;
using System.Collections.Generic;

namespace LeetCode.Problems;

public class Problem714
{
    public int MaxProfit(int[] prices, int fee)
    {
        var n = prices.Length;
        var memoryWhenHandsEmpty = new int[n];
        var memoryWhenStockOnHands = new int[n];
        memoryWhenStockOnHands[0] = -prices[0];

        for (var i = 1; i < n; i++)
        {
            memoryWhenHandsEmpty[i] =
                Math.Max(memoryWhenHandsEmpty[i - 1], memoryWhenStockOnHands[i - 1] + prices[i] - fee);
            memoryWhenStockOnHands[i] =
                Math.Max(memoryWhenStockOnHands[i - 1], memoryWhenHandsEmpty[i - 1] - prices[i]);
        }

        return memoryWhenHandsEmpty[n-1];
    }
}