using System;
using System.Collections.Generic;

namespace LeetCode.Problems._5
{
	internal class Problem506
	{
		public string[] FindRelativeRanks(int[] score)
		{
			var scoreDict = new Dictionary<int, int>();
			for (var i = 0; i < score.Length; i++)
				scoreDict[score[i]] = i;

			Array.Sort(score, (x, y) => y.CompareTo(x));
			var result = new string[score.Length];
			for (int i = 0; i < score.Length; i++)
				if (i == 0)
					result[scoreDict[score[i]]] = "Gold Medal";
				else if (i == 1)
					result[scoreDict[score[i]]] = "Silver Medal";
				else if (i == 2)
					result[scoreDict[score[i]]] = "Bronze Medal";
				else
					result[scoreDict[score[i]]] = (i + 1).ToString();

			return result;
		}
	}
}
