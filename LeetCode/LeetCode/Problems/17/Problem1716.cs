namespace LeetCode.Problems._17
{
	internal class Problem1716
	{
		public int TotalMoney(int n)
		{
			var fullWeeks = n / 7;
			var res = fullWeeks * 28;
			for (var i = 1; i < fullWeeks; i++)
				res += 7 * i;
			for (var i = 1; i <= n % 7; i++)
				res += fullWeeks + i;
			return res;
		}
	}
}
