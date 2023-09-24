using LeetCode.DataStructures;

public class Problem83
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        var preHead = new ListNode(-101, head);
        var prev = preHead;

        while (head != null)
        {
            if (head.val == prev.val)
            {
                prev.next = head.next;
                head = head.next;
            }
        }

        return prev.next;
    }
}