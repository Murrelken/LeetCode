using System;
using System.Collections.Generic;

namespace LeetCode.Problems._5
{
	internal class Problem514
	{
		public int FindRotateSteps(string ring, string key) => DFS(ring, key, 0, new Dictionary<string, int>());

		private static int DFS(string ring, string key, int index, Dictionary<string, int> memo)
		{
			if (index == key.Length) return 0;
			var keyRing = ring + index.ToString();
			if (memo.ContainsKey(keyRing)) return memo[keyRing];

			var target = key[index];
			var minSteps = int.MaxValue;

			for (var i = 0; i < ring.Length; i++)
				if (ring[i] == target)
				{
					var stepsToRotate = Math.Min(i, ring.Length - i);
					var rotatedRing = RotateRing(ring, i);
					var steps = stepsToRotate + 1 + DFS(rotatedRing, key, index + 1, memo);
					minSteps = Math.Min(minSteps, steps);
				}

			memo[keyRing] = minSteps;
			return minSteps;
		}

		private static string RotateRing(string ring, int steps) => ring[steps..] + ring[..steps];
	}
}
