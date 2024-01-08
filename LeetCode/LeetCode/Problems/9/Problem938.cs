using LeetCode.DataStructures;

namespace LeetCode.Problems._9
{
	internal class Problem938
	{
		public int RangeSumBST(TreeNode root, int low, int high)
		{
			return Dfs(root, low, high);
		}

		private static int Dfs(TreeNode node, int min, int max)
		{
			var result = 0;
			if (node == null) return result;
			if (node.val < max)
				result += Dfs(node.right, min, max);
			if (node.val > min)
				result += Dfs(node.left, min, max);
			if (node.val <= max && node.val >= min)
				result += node.val;
			return result;
		}
	}
}
