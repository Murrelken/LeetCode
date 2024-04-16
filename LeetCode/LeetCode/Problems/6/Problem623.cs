using LeetCode.DataStructures;
using System.Collections.Generic;

namespace LeetCode.Problems._6
{
	internal class Problem623
	{
		public TreeNode AddOneRow(TreeNode root, int val, int depth)
		{
			if (depth == 1)
			{
				var newRoot = new TreeNode(val)
				{
					left = root
				};
				return newRoot;
			}

			var queue = new Queue<TreeNode>();
			queue.Enqueue(root);
			var currentDepth = 1;

			while (queue.Count > 0 && currentDepth < depth - 1)
			{
				var levelSize = queue.Count;
				for (var i = 0; i < levelSize; i++)
				{
					var node = queue.Dequeue();
					if (node.left != null) queue.Enqueue(node.left);
					if (node.right != null) queue.Enqueue(node.right);
				}
				currentDepth++;
			}

			while (queue.Count > 0)
			{
				var node = queue.Dequeue();
				var leftChild = new TreeNode(val)
				{
					left = node.left
				};
				node.left = leftChild;

				var rightChild = new TreeNode(val)
				{
					right = node.right
				};
				node.right = rightChild;
			}

			return root;
		}
	}
}
