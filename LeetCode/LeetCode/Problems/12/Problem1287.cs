namespace LeetCode.Problems._12
{
	internal class Problem1287
	{
		public int FindSpecialInteger(int[] arr)
		{
			var n = arr.Length;
			var candidates = new[] { arr[n / 4], arr[n / 2], arr[3 * n / 4] };
			var target = n / 4;

			foreach (var candidate in candidates)
			{
				var left = LowerBound(arr, candidate);
				var right = UpperBound(arr, candidate) - 1;
				if (right - left + 1 > target)
				{
					return candidate;
				}
			}

			return -1;
		}

		private static int UpperBound(int[] arr, int target)
		{
			var left = 0;
			var right = arr.Length;
			while (left < right)
			{
				var mid = left + (right - left) / 2;
				if (arr[mid] > target)
				{
					right = mid;
				}
				else
				{
					left = mid + 1;
				}
			}

			return left;
		}

		private static int LowerBound(int[] arr, int target)
		{
			var left = 0;
			var right = arr.Length;
			while (left < right)
			{
				int mid = left + (right - left) / 2;
				if (arr[mid] >= target)
				{
					right = mid;
				}
				else
				{
					left = mid + 1;
				}
			}

			return left;
		}
	}
}
