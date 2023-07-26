namespace LeetCode.Problems._18;

public class Problem1870
{
    public int MinSpeedOnTime(int[] dist, double hour)
    {
        if (dist.Length > hour / 1 + (hour % 1 > 0 ? 1 : 0)) return -1;
        if (!TryGetLeftAndRightBordersOfSpeedToCheck(dist, hour, out var left, out var right)) return -1;
        if (left == 0) return 1;

        while (right - left > 1)
        {
            var mid = (right + left) / 2;
            var time = GetTotalTimeBySpeed(dist, mid);

            if (time > hour)
                left = mid;
            else
                right = mid;
        }

        return GetTotalTimeBySpeed(dist, left) <= hour ? left : right;
    }

    private static bool TryGetLeftAndRightBordersOfSpeedToCheck
        (int[] dist, double hour, out int prevSpeed, out int speed)
    {
        var prevTimeWithoutLastElement = long.MaxValue;
        prevSpeed = 0;
        speed = 1;
        while (true)
        {
            var time = GetTimeBySpeed(dist, speed);

            if (time.timeWithoutLastElement == prevTimeWithoutLastElement && hour < prevTimeWithoutLastElement)
                return false;

            prevTimeWithoutLastElement = time.timeWithoutLastElement;

            if (time.totalTime <= hour)
                break;

            prevSpeed = speed;
            speed *= 2;
        }

        return true;
    }

    private static double GetTotalTimeBySpeed(int[] dist, int speed) => GetTimeBySpeed(dist, speed).totalTime;

    private static (long timeWithoutLastElement, double totalTime) GetTimeBySpeed(int[] dist, int speed)
    {
        var timeWithoutLastElement = 0L;
        for (var i = 0; i < dist.Length - 1; i++)
        {
            var x = dist[i];
            var currTime = x / speed;
            if (x % speed > 0)
                currTime++;
            timeWithoutLastElement += currTime;
        }

        var time = timeWithoutLastElement + (double)dist[^1] / speed;
        return (timeWithoutLastElement, time);
    }
}