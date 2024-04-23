using System.Collections.Generic;

namespace LeetCode.Problems._3
{
	internal class Problem310
	{
		public IList<int> FindMinHeightTrees(int n, int[][] edges)
		{
			if (n == 1) return new List<int> { 0 };

			var adj = new List<HashSet<int>>(n);
			for (var i = 0; i < n; i++)
				adj.Add(new HashSet<int>());

			foreach (var edge in edges)
			{
				adj[edge[0]].Add(edge[1]);
				adj[edge[1]].Add(edge[0]);
			}

			var indegree = new int[n];
			var queue = new Queue<int>();

			for (var i = 0; i < n; i++)
			{
				indegree[i] = adj[i].Count;
				if (indegree[i] == 1) queue.Enqueue(i);
			}

			while (n > 2)
			{
				var size = queue.Count;
				n -= size;
				for (var i = 0; i < size; i++)
				{
					var node = queue.Dequeue();
					foreach (var neighbor in adj[node])
					{
						indegree[neighbor]--;
						if (indegree[neighbor] == 1) queue.Enqueue(neighbor);
					}
				}
			}

			var result = new List<int>();
			while (queue.Count > 0)
				result.Add(queue.Dequeue());

			return result;
		}
	}
}
