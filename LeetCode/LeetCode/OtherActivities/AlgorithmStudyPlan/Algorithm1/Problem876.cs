using LeetCode.DataStructures;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem876
    {
        public ListNode MiddleNode(ListNode head)
        {
            ListNode middle, current;
            middle = current = head;

            while (current?.next is not null)
            {
                middle = middle.next;
                current = current.next.next;
            }
            
            return middle;
        }
    }
}