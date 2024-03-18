using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems._16
{
	internal class Problem1611
	{
		public int MinimumOneBitOperations(int n)
		{
			if (n == 0)
				return 0;

			int k = 0;
			int curr = 1;
			while (curr * 2 <= n)
			{
				curr *= 2;
				k++;
			}

			return (1 << (k + 1)) - 1 - MinimumOneBitOperations(n ^ curr);
		}
	}
}
