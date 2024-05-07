using LeetCode.DataStructures;

namespace LeetCode.Problems._28
{
	internal class Problem2816
	{
		public ListNode DoubleIt(ListNode head)
		{
			var prev = RR(head);
			if (prev == 1)
				head = new ListNode(1, head);
			return head;
		}

		private static int RR(ListNode node)
		{
			var previous = 0;
			if (node.next != null)
				previous = RR(node.next);

			var newCurrent = node.val * 2 + previous;

			node.val = newCurrent % 10;
			return newCurrent / 10;
		}
	}
}
