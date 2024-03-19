using System;

namespace LeetCode.Problems._6
{
	internal class Problem621
	{
		public int LeastInterval(char[] tasks, int n)
		{
			int[] frequencies = new int[26];
			foreach (char task in tasks)
				frequencies[task - 'A']++;

			Array.Sort(frequencies);

			int maxFrequency = frequencies[25] - 1;
			int idleSlots = maxFrequency * n;

			for (int i = 24; i >= 0 && frequencies[i] > 0; i--)
				idleSlots -= Math.Min(frequencies[i], maxFrequency);

			return Math.Max(idleSlots, 0) + tasks.Length;
		}
	}
}
