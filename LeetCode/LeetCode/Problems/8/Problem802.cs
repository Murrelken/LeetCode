using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems;

public class Problem802
{
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        var memo = new bool?[graph.Length];
        for (var i = 0; i < graph.Length; i++)
            Req(graph, memo, new HashSet<int>(), i);

        var result = new List<int>();

        for (var i = 0; i < memo.Length; i++)
            if (memo[i] == true)
                result.Add(i);

        return result;
    }

    private static bool? Req(int[][] graph, bool?[] memo, HashSet<int> visited, int i)
    {
        if (memo[i] != null)
            return memo[i].Value;

        if (visited.Contains(i))
            return memo[i] = false;

        visited.Add(i);

        if (!graph[i].Any())
            return memo[i] = true;

        var result = true;

        for (var j = 0; j < graph[i].Length; j++)
            result = result && Req(graph, memo, visited, graph[i][j]).Value;

        return memo[i] = result;
    }
}