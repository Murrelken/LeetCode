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
}