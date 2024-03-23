using LeetCode.DataStructures;

namespace LeetCode.Problems._1
{
	internal class Problem143
	{
		public void ReorderList(ListNode head)
		{
			if (head == null || head.next == null)
			{
				return;
			}

			ListNode middle = MidNode(head);
			ListNode newHead = middle.next;
			middle.next = null;

			newHead = ReverseLinkedList(newHead);

			ListNode c1 = head;
			ListNode c2 = newHead;
			ListNode f1 = null;
			ListNode f2 = null;

			while (c1 != null && c2 != null)
			{
				// Backup
				f1 = c1.next;
				f2 = c2.next;

				// Linking
				c1.next = c2;
				c2.next = f1;

				// Move
				c1 = f1;
				c2 = f2;
			}
		}

		private ListNode MidNode(ListNode head)
		{
			ListNode slow = head;
			ListNode fast = head;

			while (fast.next != null && fast.next.next != null)
			{
				slow = slow.next;
				fast = fast.next.next;
			}
			return slow;
		}

		private ListNode ReverseLinkedList(ListNode head)
		{
			ListNode prev = null;
			ListNode curr = head;
			ListNode forw = null;

			while (curr != null)
			{
				forw = curr.next;
				curr.next = prev;
				prev = curr;
				curr = forw;
			}
			return prev;
		}
	}
}
