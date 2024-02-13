namespace LeetCode.Problems._21
{
	internal class Problem2108
	{
		public string FirstPalindrome(string[] words)
		{
			foreach (var w in words)
			{
				var l = 0;
				var r = w.Length - 1;
				while (l <= r)
				{
					if (w[l] != w[r])
						break;
					l++;
					r--;
				}
				if (l > r)
					return w;
			}
			return string.Empty;
		}
	}
}
