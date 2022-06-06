using System.Collections.Generic;
using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class Problem160
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode result = null;
            var stackA = new Stack<ListNode>();
            var stackB = new Stack<ListNode>();
            while (headA is not null)
            {
                stackA.Push(headA);
                headA = headA.next;
            }
            while (headB is not null)
            {
                stackA.Push(headB);
                headB = headB.next;
            }

            while (stackA.TryPop(out var a) && stackB.TryPop(out var b) && a == b)
            {
                result = a;
            }

            return result;
        }
    }
}