namespace LeetCode.Problems._5
{
	internal class Problem58
	{
		public int LengthOfLastWord(string s)
		{
			var n = s.Length;
			var right = n - 1;

			while (s[right] == ' ')
				right--;

			var res = 0;
			while (right >= 0 && s[right] != ' ')
			{
				res++;
				right--;
			}

			return res;
		}
	}
}
