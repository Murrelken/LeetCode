namespace LeetCode.Problems._19
{
	internal class Problem1915
	{
		public long WonderfulSubstrings(string word)
		{
			var result = 0L;
			var count = new int[1024];
			count[0] = 1;
			var mask = 0;

			foreach (char c in word)
			{
				mask ^= 1 << (c - 'a');
				result += count[mask];
				for (var i = 0; i < 10; i++)
					result += count[mask ^ (1 << i)];
				count[mask]++;
			}

			return result;
		}
	}
}
