using System;

public class Problem2849
{
    public bool IsReachableAtTime(int sx, int sy, int fx, int fy, int t)
    {
        var x_diff = Math.Abs(sx - fx);
        var y_diff = Math.Abs(sy - fy);
        return x_diff == 0 && y_diff == 0 ? t != 1 : Math.Max(x_diff, y_diff) <= t;
    }
}