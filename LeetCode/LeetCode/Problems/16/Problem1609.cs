using LeetCode.DataStructures;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._16
{
	internal class Problem1609
	{
		public bool IsEvenOddTree(TreeNode root)
		{
			var isEven = true;
			var queue = new Queue<TreeNode>();
			queue.Enqueue(root);
			while (queue.Any())
			{
				var res = isEven ? CheckEven(queue) : CheckOdd(queue);
				if (!res) return false;
				isEven = !isEven;
			}

			return true;
		}

		private static bool CheckEven(Queue<TreeNode> queue)
		{
			var c = queue.Count;
			var prev = int.MinValue;
			while (c > 0)
			{
				c--;
				var current = queue.Dequeue();
				if (current == null) continue;
				if (current.val % 2 == 0 || current.val <= prev) return false;
				prev = current.val;
				queue.Enqueue(current.left);
				queue.Enqueue(current.right);
			}
			return true;
		}

		private static bool CheckOdd(Queue<TreeNode> queue)
		{
			var c = queue.Count;
			var prev = int.MaxValue;
			while (c > 0)
			{
				c--;
				var current = queue.Dequeue();
				if (current == null) continue;
				if (current.val % 2 != 0 || current.val >= prev) return false;
				prev = current.val;
				queue.Enqueue(current.left);
				queue.Enqueue(current.right);
			}
			return true;
		}
	}
}
