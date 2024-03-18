using System;

public class Problem274
{
    public int HIndex(int[] citations)
    {
        Array.Sort(citations);
        Array.Reverse(citations);
        var result = 0;
        foreach (var c in citations)
        {
            if (c < result + 1)
                break;
            result++;
        }
        return result;
    }

    public int HIndexV2(int[] citations)
    {
        int n = citations.Length;
        int[] buckets = new int[n + 1];
        foreach (var c in citations)
        {
            if (c >= n)
                buckets[n]++;
            else
                buckets[c]++;
        }
        int count = 0;
        for (int i = n; i >= 0; i--)
        {
            count += buckets[i];
            if (count >= i)
                return i;
        }
        return 0;
    }
}