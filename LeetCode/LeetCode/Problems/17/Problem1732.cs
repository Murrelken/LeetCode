namespace LeetCode.Problems;

public class Problem1732
{
    public int LargestAltitude(int[] gain)
    {
        int max = 0, cur = 0;
        foreach (var t in gain)
            if ((cur += t) > max)
                max = cur;

        return max;
    }
}