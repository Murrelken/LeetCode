using LeetCode.DataStructures;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem206
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head is null)
                return null;
            
            ListNode current, actualNext, previous;
            current = head;
            actualNext = head.next;
            current.next = null;

            while (actualNext is not null)
            {
                previous = current;
                current = actualNext;
                actualNext = actualNext.next;
                current.next = previous;
            }

            return current;
        }
    }
}