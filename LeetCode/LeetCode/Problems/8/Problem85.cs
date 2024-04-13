using System;
using System.Collections.Generic;

namespace LeetCode.Problems._8
{
	internal class Problem85
	{
		public int MaximalRectangle(char[][] matrix)
		{
			if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) return 0;

			var rows = matrix.Length;
			var cols = matrix[0].Length;
			var maxArea = 0;
			var heights = new int[cols];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
					heights[j] = matrix[i][j] == '1' ? heights[j] + 1 : 0;
				maxArea = Math.Max(maxArea, LargestRectangleArea(heights));
			}

			return maxArea;
		}

		private int LargestRectangleArea(int[] heights)
		{
			var stack = new Stack<int>();
			var maxArea = 0;
			var i = 0;

			while (i < heights.Length)
				if (stack.Count == 0 || heights[stack.Peek()] <= heights[i])
					stack.Push(i++);
				else
				{
					var top = stack.Pop();
					var area = heights[top] * (stack.Count == 0 ? i : i - stack.Peek() - 1);
					maxArea = Math.Max(maxArea, area);
				}

			while (stack.Count > 0)
			{
				var top = stack.Pop();
				var area = heights[top] * (stack.Count == 0 ? i : i - stack.Peek() - 1);
				maxArea = Math.Max(maxArea, area);
			}

			return maxArea;
		}
	}
}
