using LeetCode.DataStructures;
using System;

namespace LeetCode.Problems._23
{
	internal class Problem2385
	{
		private int _result;
		public int AmountOfTime(TreeNode root, int start)
		{
			DFS(root, start);
			return _result;
		}

		private int DFS(TreeNode node, int start)
		{
			if (node == null) return 0;

			int leftDepth = DFS(node.left, start);
			int rightDepth = DFS(node.right, start);

			if (node.val == start)
			{
				_result = Math.Max(leftDepth, rightDepth);
				return -1;
			}
			else if (leftDepth >= 0 && rightDepth >= 0)
				return Math.Max(leftDepth, rightDepth) + 1;

			_result = Math.Max(_result, Math.Abs(leftDepth - rightDepth));
			return Math.Min(leftDepth, rightDepth) - 1;
		}
	}
}
