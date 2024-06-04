namespace LeetCode.Problems._4
{
	internal class Problem409
	{
		public int LongestPalindrome(string s)
		{
			var charCount = new int[128];

			foreach (char c in s)
				charCount[c]++;

			var length = 0;
			var hasOddCount = false;

			foreach (var count in charCount)
				if (count % 2 == 0)
					length += count;
				else
				{
					length += count - 1;
					hasOddCount = true;
				}

			if (hasOddCount)
				length += 1;

			return length;
		}
	}
}
