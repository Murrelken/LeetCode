namespace LeetCode.Problems._24
{
	internal class Problem2485
	{
		public int PivotInteger(int n)
		{
			var ls = n * (n + 1) / 2;
			var rs = 0;

			while (ls > rs)
			{
				rs += n;
				if (rs == ls) return n;
				ls -= n;
				n--;
			}

			return -1;
		}
	}
}
