using LeetCode.DataStructures;

namespace LeetCode.Problems._14
{
	internal class Problem1457
	{
		public int PseudoPalindromicPaths(TreeNode root)
		{
			return CountPseudoPalindromicPaths(root, 0);
		}

		private int CountPseudoPalindromicPaths(TreeNode node, int count)
		{
			if (node == null)
				return 0;

			count ^= 1 << (node.val - 1);

			if (node.left == null && node.right == null)
				return (count & (count - 1)) == 0 ? 1 : 0;

			int leftPaths = CountPseudoPalindromicPaths(node.left, count);
			int rightPaths = CountPseudoPalindromicPaths(node.right, count);

			return leftPaths + rightPaths;
		}
	}
}
