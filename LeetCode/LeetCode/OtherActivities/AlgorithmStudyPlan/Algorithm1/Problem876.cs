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


    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}