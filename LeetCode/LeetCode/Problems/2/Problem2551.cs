using System;

namespace LeetCode.Problems;

public class Problem2551
{
    public long PutMarbles(int[] weights, int k)
    {
        var pairWeights = new int[weights.Length - 1];
        for (var i = 0; i < pairWeights.Length; i++)
        {
            pairWeights[i] = weights[i] + weights[i + 1];
        }

        Array.Sort(pairWeights);

        var answer = 0L;
        for (var i = 0; i < k - 1; i++)
            answer += pairWeights[^(i + 1)] - pairWeights[i];

        return answer;
    }
}