using System;

namespace LeetCode.Problems._8
{
	internal class Problem881
	{
		public int NumRescueBoats(int[] people, int limit)
		{
			Array.Sort(people);
			var boats = 0;
			var left = 0;
			var right = people.Length - 1;

			while (left <= right)
			{
				if (people[left] + people[right] <= limit)
					left++;
				right--;
				boats++;
			}

			return boats;
		}
	}
}
