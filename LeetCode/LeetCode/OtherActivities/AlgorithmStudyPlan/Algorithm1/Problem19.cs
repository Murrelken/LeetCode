using LeetCode.DataStructures;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem19
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode target;
            var current = target = head;

            for (var i = 0; i < n; i++)
            {
                current = current?.next;
            }

            if (current == null)
                return head.next;

            while (current.next != null)
            {
                current = current.next;
                target = target.next;
            }

            target.next = target.next.next;

            return head;
        }
    }
}