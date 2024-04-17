using LeetCode.DataStructures;
using System.Collections.Generic;

namespace LeetCode.Problems._9
{
	internal class Problem988
	{
		public string SmallestFromLeaf(TreeNode root)
		{
			var queue = new Queue<TreeNode>();
			var nodeToSuffix = new Dictionary<TreeNode, string>();
			queue.Enqueue(root);
			nodeToSuffix.Add(root, ((char)('a' + root.val)).ToString());

			string result = null;

			while (queue.Count > 0)
			{
				var node = queue.Dequeue();
				var suffix = nodeToSuffix[node];

				if (node.left == null && node.right == null)
					if (result == null || suffix.CompareTo(result) < 0)
						result = suffix;

				if (node.left != null)
				{
					queue.Enqueue(node.left);
					nodeToSuffix[node.left] = ((char)('a' + node.left.val)) + suffix;
				}

				if (node.right != null)
				{
					queue.Enqueue(node.right);
					nodeToSuffix[node.right] = ((char)('a' + node.right.val)) + suffix;
				}
			}

			return result;
		}
	}
}
