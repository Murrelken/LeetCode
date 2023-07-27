using System;

namespace LeetCode.Problems._21;

public class Problem2141
{
    public long MaxRunTime(int n, int[] batteries)
    {
        Array.Sort(batteries);
        long extra = 0;
        for (var i = 0; i < batteries.Length - n; i++)
            extra += batteries[i];

        var live = new int[n];
        Array.Copy(batteries, batteries.Length - n, live, 0, live.Length);

        for (var i = 0; i < n - 1; i++)
        {
            if (extra < (long)(i + 1) * (live[i + 1] - live[i]))
                return live[i] + extra / (i + 1);

            extra -= (long)(i + 1) * (live[i + 1] - live[i]);
        }

        return live[n - 1] + extra / n;
    }
}