using LeetCode.DataStructures;
using System;

namespace LeetCode.Problems._10
{
	internal class Problem1026
	{
		private int _result = 0;
		public int MaxAncestorDiff(TreeNode root)
		{
			Dfs(root);
			return _result;
		}

		private (int min, int max) Dfs(TreeNode node)
		{
			var min = node.val;
			var max = node.val;
			if (node.left == null && node.right == null) 
				return (min, max);
			if (node.left != null)
			{
				var (leftMin, leftMax) = Dfs(node.left);
				min = Math.Min(leftMin, min);
				max = Math.Max(leftMax, max);
			}
			if (node.right != null)
			{
				var (rightMin, rightMax) = Dfs(node.right);
				min = Math.Min(rightMin, min);
				max = Math.Max(rightMax, max);
			}
			var maxForCurrentNode = Math.Max(node.val - min, max - node.val);
			_result = Math.Max(_result, maxForCurrentNode);
			return (min, max);
		}
	}
}
