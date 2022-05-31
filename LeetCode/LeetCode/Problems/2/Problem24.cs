using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class Problem24
    {
        public ListNode SwapPairs(ListNode head)
        {
            var current = new ListNode(0, head);
            var result = head?.next ?? head;

            while (current?.next?.next is not null)
            {
                var first = current.next;
                var second = current.next.next;
                current.next = second;
                first.next = second.next;
                second.next = first;

                current = current.next.next;
            }

            return result;
        }
    }
}