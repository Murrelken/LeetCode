using LeetCode.DataStructures;

namespace LeetCode.Problems._24
{
	internal class Problem2487
	{
		public ListNode RemoveNodes(ListNode head) => RR(head);

		private static ListNode RR(ListNode node)
		{
			if (node.next == null)
				return node;

			var next = RR(node.next);

			if (next.val <= node.val)
			{
				node.next = next;
				return node;
			}
			else
				return next;
		}
	}
}
