namespace LeetCode.Problems._14
{
	internal class Problem1464
	{
		public int MaxProduct(int[] nums)
		{
			var max = int.MinValue;
			var nextMax = int.MinValue;

            foreach (var item in nums)
            {
                if (item > max)
				{
					nextMax = max;
					max = item;
				}
				else if (item > nextMax)
				{
					nextMax = item;
				}
            }

			return (max - 1) * (nextMax - 1);
        }
	}
}
