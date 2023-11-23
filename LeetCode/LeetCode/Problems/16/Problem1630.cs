using System;
using System.Collections.Generic;

namespace LeetCode.Problems._16
{
	internal class Problem1630
	{
		public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
		{
			var m = l.Length;
			var res = new bool[m];

			for (var i = 0; i < m; i++)
			{
				var currL = r[i] - l[i] + 1;
				var temp = new int[currL];
				Array.Copy(nums, l[i], temp, 0, currL);

				res[i] = isArithmetic(temp);
			}

			return res;
		}

		private bool isArithmetic(int[] arr)
		{
			Array.Sort(arr);
			var diff = arr[0] - arr[1];

			for (var i = 2; i < arr.Length; i++)
				if (diff != arr[i - 1] - arr[i])
					return false;

			return true;
		}
	}
}
