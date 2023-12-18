namespace LeetCode.Problems._19
{
	internal class Problem1913
	{
		public int MaxProductDifference(int[] nums)
		{
			var max = int.MinValue;
			var nextMax = int.MinValue;
			var min = int.MaxValue;
			var nextMin = int.MaxValue;

			foreach (var num in nums)
			{
				if (num < min)
				{
					nextMin = min;
					min = num;
				}
				else if (num < nextMin)
				{
					nextMin = num;
				}

				if (num > max)
				{
					nextMax = max;
					max = num;
				}
				else if (num > nextMax)
				{
					nextMax = num;
				}
			}

			return max * nextMax - min * nextMin;
		}
	}
}
