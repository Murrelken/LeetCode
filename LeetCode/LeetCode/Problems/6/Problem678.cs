namespace LeetCode.Problems._6
{
	internal class Problem678
	{
		public bool CheckValidString(string s)
		{
			var leftMin = 0;
			var leftMax = 0;

			foreach (char c in s)
			{
				if (c == '(')
				{
					leftMin++;
					leftMax++;
				}
				else if (c == ')')
				{
					leftMin--;
					leftMax--;
				}
				else
				{
					leftMin--;
					leftMax++;
				}
				if (leftMax < 0) return false;
				if (leftMin < 0) leftMin = 0;
			}

			return leftMin == 0;
		}
	}
}
