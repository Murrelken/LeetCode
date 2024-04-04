namespace LeetCode.Problems._16
{
	internal class Problem1614
	{
		public int MaxDepth(string s)
		{
			var max = 0;
			var count = 0;

			foreach (var c in s)
			{
				if (c == '(')
				{
					count++;
					if (max < count)
						max = count;
				}
				else if (c == ')')
					count--;
			}

			return max;
		}
	}
}
