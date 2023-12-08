namespace LeetCode.Problems._19
{
	internal class Problem1903
	{
		public string LargestOddNumber(string num)
		{
			var lastOdd = -1;

			for (var i = num.Length - 1; i >= 0; i--)
			{
				if ((num[i] - '0') % 2 == 1)
				{
					lastOdd = i;
					break;
				}
			}

			return lastOdd == -1 ? string.Empty : num.Substring(0, lastOdd + 1);
		}
	}
}
