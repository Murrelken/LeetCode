using LeetCode.DataStructures;

namespace LeetCode.Problems._4
{
	internal class Problem404
	{
		public int SumOfLeftLeaves(TreeNode root) => Help(root, false);

		private int Help(TreeNode node, bool isLeft)
		{
			if (node == null) return 0;

			if (isLeft && node is { left: null, right: null }) return node.val;

			return Help(node.left, true) + Help(node.right, false);
		}
	}
}
