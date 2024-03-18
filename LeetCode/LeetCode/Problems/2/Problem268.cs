using System.Linq;

namespace LeetCode.Problems
{
	public class Problem268
	{
		public int MissingNumber(int[] nums)
		{
			var n = nums.Length;
			var total = (int)(((double)(1 + n)) / 2 * n);
			return total - nums.Sum();
		}
	}
}