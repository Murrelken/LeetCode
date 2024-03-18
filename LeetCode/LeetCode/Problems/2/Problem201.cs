namespace LeetCode.Problems._2
{
	internal class Problem201
	{
		public int RangeBitwiseAnd(int left, int right)
		{
			var shift = 0;
			while (left != right)
			{
				left >>= 1;
				right >>= 1;
				shift++;
			}
			return left << shift;
		}
	}
}
