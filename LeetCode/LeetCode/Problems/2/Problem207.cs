using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems;

public class Problem207
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        IList<int>[] graph = new IList<int>[numCourses];
        for (var i = 0; i < graph.Length; i++)
            graph[i] = new List<int>();

        for (var i = 0; i < prerequisites.Length; i++)
            graph[prerequisites[i][0]].Add(prerequisites[i][1]);

        var memo = new bool?[graph.Length];
        var visited = new bool?[graph.Length];
        for (var i = 0; i < graph.Length; i++)
            if (!Req(graph, memo, visited, i).Value)
                return false;

        return true;
    }

    private static bool? Req(IReadOnlyList<IList<int>> graph, bool?[] memo, bool?[] visited, int i)
    {
        if (memo[i] != null)
            return memo[i].Value;

        if (visited[i].HasValue && visited[i].Value)
            return memo[i] = false;

        visited[i] = true;

        if (!graph[i].Any())
            return memo[i] = true;

        var result = true;

        for (var j = 0; j < graph[i].Count; j++)
            result = result && Req(graph, memo, visited, graph[i][j]).Value;

        return memo[i] = result;
    }
}