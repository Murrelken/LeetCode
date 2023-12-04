using System;

namespace LeetCode.Problems._22
{
	internal class Problem2264
	{
		public string LargestGoodInteger(string num)
		{
			var max = -1;
			for (var i = 0; i < num.Length - 2; i++)
			{
				var converted = int.Parse(num[i].ToString());
				if (num[i] == num[i + 1] && num[i] == num[i + 2] && converted > max)
					max = converted;
			}
			return max == -1 ? string.Empty : (max.ToString() + max + max);
		}
	}
}
