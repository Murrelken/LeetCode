using System;

public class Problem1921
{
    public int EliminateMaximum(int[] dist, int[] speed)
    {
        var n = dist.Length;

        for (int i = 0; i < n; i++)
            dist[i] = dist[i] / speed[i] + (dist[i] % speed[i] > 0 ? 1 : 0);

        Array.Sort(dist);

        for (int i = 0; i < n; i++)
            if (i >= dist[i])
                return i;

        return n;
    }
}