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

        var currentMinute = 0;
        var result = 0;

        foreach (var minute in minutesToReach)
        {
            if (currentMinute >= minute)
                break;

            result++;
            currentMinute++;
        }

        return result;
    }
}