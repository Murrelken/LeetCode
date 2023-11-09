using System.Linq;

public class Problem1759
{

    public int CountHomogenous(string s)
    {
        var result = 0;
        var count = 0;
        const int MOD = 1_000_000_007;
        for (var i = 0; i < s.Length; i++)
        {
            if (i == 0 || s[i] == s[i - 1])
                count++;
            else
                count = 1;

            result = (result + count) % MOD;
        }

        return result;
    }
}