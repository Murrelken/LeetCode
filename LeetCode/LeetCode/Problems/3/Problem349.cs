using System;
using System.Collections.Generic;

namespace LeetCode.Problems._3
{
	internal class Problem349
	{
		public int[] Intersection(int[] nums1, int[] nums2)
		{
			int i = 0, j = 0, n1 = nums1.Length, n2 = nums2.Length;
			var res = new List<int>();

			Array.Sort(nums1);
			Array.Sort(nums2);

			while (i < n1 && j < n2)
				if (nums1[i] == nums2[j])
				{
					res.Add(nums1[i]);

					while (i < n1 - 1 && nums1[i] == nums1[i + 1])
						i++;
					while (j < n2 - 1 && nums2[j] == nums2[j + 1])
						j++;

					i++;
					j++;
				}
				else if (nums1[i] < nums2[j])
					i++;
				else
					j++;

			return res.ToArray();
		}
	}
}
