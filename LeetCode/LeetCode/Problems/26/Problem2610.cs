using System.Collections.Generic;

namespace LeetCode.Problems._26
{
	internal class Problem2610
	{
		public IList<IList<int>> FindMatrix(int[] nums)
		{
			List<IList<int>> result = new() { new List<int>() };
			int[] frequency = new int[nums.Length + 1];
			int maxFrequency = 0;

			foreach (int num in nums)
			{
				int currentFrequency = frequency[num]++;
				if (currentFrequency > maxFrequency)
				{
					maxFrequency = currentFrequency;
					result.Add(new List<int> { num });
				}
				else
					result[currentFrequency].Add(num);
			}

			return result;
		}
	}
}
