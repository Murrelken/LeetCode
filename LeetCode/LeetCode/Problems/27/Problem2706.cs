namespace LeetCode.Problems._27
{
	internal class Problem2706
	{
		public int BuyChoco(int[] prices, int money)
		{
			var min = int.MaxValue;
			var nextMin = min;
			foreach (var p in prices)
				if (p < min)
				{
					nextMin = min;
					min = p;
				}
				else if (p < nextMin)
					nextMin = p;
			var sum = min + nextMin;
			return sum > money ? money : money - sum;
		}
	}
}
