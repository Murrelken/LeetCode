using LeetCode.DataStructures;
using System.Linq;
using System.Text;

namespace LeetCode.Problems._2
{
	internal class Problem234
	{
		public bool IsPalindrome(ListNode head)
		{
			if (head.next == null)
				return true;
			var center = head;
			var doubled = head.next;
			bool even;

			while (true)
			{
				if (doubled.next == null)
				{
					even = true;
					break;
				}

				if (doubled.next.next == null)
				{
					even = false;
					center = center.next;
					break;
				}
				center = center.next;
				doubled = doubled.next.next;
			}

			var firstHalfSb = new StringBuilder();

			while (head != center)
			{
				firstHalfSb.Append(head.val);
				head = head.next;
			}

			if (even)
				firstHalfSb.Append(head.val);

			var secondHalfSb = new StringBuilder();
			center = center.next;

			while (center != null)
			{
				secondHalfSb.Append(center.val);
				center = center.next;
			}

			var f = new string(firstHalfSb.ToString().Reverse().ToArray());
			var s = secondHalfSb.ToString();

			return f == s;
		}
	}
}
