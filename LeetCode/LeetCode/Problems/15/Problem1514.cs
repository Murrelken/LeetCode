using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems;

public class Problem1514
{
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
    {
        var memo = new double[n];
        memo[start] = 1;

        for (var i = 0; i < n - 1; i++)
        {
            var hasUpdated = false;
            for (var j = 0; j < edges.Length; j++)
            {
                var firstNode = edges[j][0];
                var secondNode = edges[j][1];
                var pathProb = succProb[j];

                if (memo[firstNode] * pathProb > memo[secondNode])
                {
                    memo[secondNode] = memo[firstNode] * pathProb;
                    hasUpdated = true;
                }

                if (memo[secondNode] * pathProb > memo[firstNode])
                {
                    memo[firstNode] = memo[secondNode] * pathProb;
                    hasUpdated = true;
                }
            }

            if (!hasUpdated)
            {
                break;
            }
        }

        return memo[end];
    }
}