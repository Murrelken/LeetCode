namespace LeetCode.Problems._7
{
	internal class Problem786
	{
		public int[] KthSmallestPrimeFraction(int[] arr, int k)
		{
			var n = arr.Length;
			double left = 0;
			double right = 1;
			var result = new int[2];

			while (right - left > 1e-9)
			{
				double mid = (left + right) / 2;
				double maxFraction = 0;
				var count = 0;
				var numerator = 0;
				var denominator = 0;

				for (int i = 0, j = 1; i < n - 1; i++)
				{
					while (j < n && arr[i] > mid * arr[j])
						j++;
					count += n - j;
					if (j < n && maxFraction < (double)arr[i] / arr[j])
					{
						maxFraction = (double)arr[i] / arr[j];
						numerator = arr[i];
						denominator = arr[j];
					}
				}

				if (count == k)
				{
					result[0] = numerator;
					result[1] = denominator;
					break;
				}
				else if (count < k)
					left = mid;
				else
					right = mid;
			}

			return result;
		}
	}
}
