using LeetCode.DataStructures;
using System.Collections.Generic;

namespace LeetCode.Problems._9
{
	internal class Problem94
	{
		public IList<int> InorderTraversal(TreeNode root)
		{
			var res = new List<int>();
			if (root != null) 
				RecursiveTraversal(root, res);
			return res;
		}

		public void RecursiveTraversal(TreeNode node, List<int> result)
		{
			if (node.left != null)
				RecursiveTraversal(node.left, result);

			result.Add(node.val);

			if (node.right != null)
				RecursiveTraversal(node.right, result);
		}
	}
}
