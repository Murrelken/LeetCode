using LeetCode.DataStructures;

namespace LeetCode.Problems._1
{
	internal class Problem129
	{
		public int SumNumbers(TreeNode root) => Dfs(root, 0);

		private int Dfs(TreeNode node, int num)
		{
			if (node == null) return 0;
			if (node.left == null && node.right == null)
				return num * 10 + node.val;
			return Dfs(node.left, num * 10 + node.val) + Dfs(node.right, num * 10 + node.val);
		}
	}
}
