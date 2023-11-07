using System;
using System.Linq;

public class Problem1921
{
    public int EliminateMaximum(int[] dist, int[] speed)
    {
        var minutesToReach = dist.Zip(speed)
            .Select(x =>
            {
                var dist = x.First;
                var speed = x.Second;
                return dist / speed + (dist % speed > 0 ? 1 : 0);
            })
            .ToArray();

        Array.Sort(minutesToReach);

        var n = minutesToReach.Length;

        for (int i = 0; i < n; i++)
        {
            if (i >= minutesToReach[i])
                return i;
        }

        return n;
    }
}