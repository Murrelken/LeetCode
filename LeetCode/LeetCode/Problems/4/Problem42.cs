namespace LeetCode.Problems._4
{
	internal class Problem42
	{
		public int Trap(int[] height)
		{
			var n = height.Length;
			if (n == 0) return 0;

			var left = 0;
			var right = n - 1;
			var leftMax = 0;
			var rightMax = 0;
			var waterTrapped = 0;

			while (left < right)
			{
				if (height[left] < height[right])
				{
					if (height[left] >= leftMax)
						leftMax = height[left];
					else
						waterTrapped += leftMax - height[left];
					left++;
				}
				else
				{
					if (height[right] >= rightMax)
						rightMax = height[right];
					else
						waterTrapped += rightMax - height[right];
					right--;
				}
			}

			return waterTrapped;
		}
	}
}
