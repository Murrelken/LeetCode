using System.Linq;

public class Problem1759
{
    private const int MOD = 1_000_000_007;

    public int CountHomogenous(string s)
    {
        var result = 0;
        var current = s[0];
        var count = 1;
        foreach (var c in s.Skip(1))
        {
            if (c ==current) 
                count++;
            else
            {
                result += GetSumOfUpToN(count);
                result %= MOD;
                current = c;
                count = 1;
            }
        }
        result += GetSumOfUpToN(count);
        result %= MOD;

        return result;
    }

    private static int GetSumOfUpToN(int n)
    {
        var sum = 0;
        for (var i = 1; i <= n; i++)
        {
            sum += i;
            sum %= MOD;
        }
        return sum;
    }
}