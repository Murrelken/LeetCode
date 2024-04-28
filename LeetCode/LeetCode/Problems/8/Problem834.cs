using System.Collections.Generic;

namespace LeetCode.Problems._8
{
	internal class Problem834
	{
		public int[] SumOfDistancesInTree(int n, int[][] edges)
		{
			var graph = new List<int>[n];

			for (var i = 0; i < n; i++)
				graph[i] = new List<int>();

			foreach (var edge in edges)
			{
				var u = edge[0];
				var v = edge[1];
				graph[u].Add(v);
				graph[v].Add(u);
			}

			var count = new int[n];
			var ans = new int[n];

			DFS(0, -1, graph, count, ans);

			DFS2(0, -1, graph, count, ans);

			return ans;
		}

		private void DFS(int node, int parent, List<int>[] graph, int[] count, int[] ans)
		{
			count[node] = 1;
			foreach (int child in graph[node])
				if (child != parent)
				{
					DFS(child, node, graph, count, ans);
					count[node] += count[child];
					ans[node] += ans[child] + count[child];
				}
		}

		// DFS to update answers for each node
		private void DFS2(int node, int parent, List<int>[] graph, int[] count, int[] ans)
		{
			foreach (int child in graph[node])
				if (child != parent)
				{
					ans[child] = ans[node] - count[child] + count.Length - count[child];
					DFS2(child, node, graph, count, ans);
				}
		}
	}
}
