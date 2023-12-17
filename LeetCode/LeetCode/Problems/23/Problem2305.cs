using System;
using System.Linq;

namespace LeetCode.Problems._23;

public class Problem2305
{
    public int DistributeCookies(int[] cookies, int k)
    {
        var bags = new int[k];

        return Dfs(0, bags, cookies, k, k);
    }

    private int Dfs(int i, int[] bags, int[] cookies, int k, int zeroCount)
    {
        if (cookies.Length - i < zeroCount)
            return int.MaxValue;

        if (i == cookies.Length)
            return bags.Max();

        var answer = int.MaxValue;
        for (var j = 0; j < k; ++j)
        {
            zeroCount -= bags[j] == 0 ? 1 : 0;
            bags[j] += cookies[i];

            answer = Math.Min(answer, Dfs(i + 1, bags, cookies, k, zeroCount));

            bags[j] -= cookies[i];
            zeroCount += bags[j] == 0 ? 1 : 0;
        }

        return answer;
    }
}