using LeetCode.DataStructures;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem19
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head.next is null)
                return null;
            var target = head;
            var current = head;

            while (current.next is not null)
            {
                current = current.next;

                if (n == 0)
                    target = target.next;
                else
                {
                    n--;
                    if (n == 1 && current.next == null)
                        return head.next;
                }
            }

            target.next = target.next.next;

            return head;
        }
    }
}