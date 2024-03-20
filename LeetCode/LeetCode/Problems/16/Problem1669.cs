using LeetCode.DataStructures;

namespace LeetCode.Problems._16
{
	internal class Problem1669
	{
		public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
		{
			var list2End = list2;
			while (list2End.next != null)
				list2End = list2End.next;

			var current = 0;
			var list1Temp = list1;

			while (current < a - 1)
			{
				current++;
				list1Temp = list1Temp.next;
			}

			var preDelete = list1Temp;

			while (current <= b)
			{
				current++;
				list1Temp = list1Temp.next;
			}

			list2End.next = list1Temp;
			preDelete.next = list2;

			return list1;
		}
	}
}
