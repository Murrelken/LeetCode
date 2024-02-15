namespace LeetCode.Problems._21
{
	internal class Problem2149
	{
		public int[] RearrangeArray(int[] nums)
		{
			var result = new int[nums.Length];
			var pos = 0;
			var neg = 1;

			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] > 0)
				{
					result[pos] = nums[i];
					pos += 2;
				}
				else
				{
					result[neg] = nums[i];
					neg += 2;
				}
			}

			return result;
		}
	}
}
