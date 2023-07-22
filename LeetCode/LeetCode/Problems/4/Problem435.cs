using System;

namespace LeetCode.Problems;

public class Problem435
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        if (intervals.Length == 1)
            return 0;

        Array
            .Sort(intervals, (a, b) => a[0] - b[0]);

        var res = 0;
        var previousMostRightBorder = int.MinValue;

        for (var i = 0; i < intervals.Length; i++)
        {
            var interval = intervals[i];

            if (interval[0] >= previousMostRightBorder)
                previousMostRightBorder = interval[1];
            else
            {
                res++;
                previousMostRightBorder = Math.Min(previousMostRightBorder, interval[1]);
            }
        }

        return res;
    }
}