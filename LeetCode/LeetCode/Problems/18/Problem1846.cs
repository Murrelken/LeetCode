using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._18
{
	internal class Problem1846
	{
		public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
		{
			Array.Sort(arr);
			var res = 1;
			for (int i = 1; i < arr.Length; i++)
				if (arr[i] >= res)
					res++;
			return res;
		}
	}
}
