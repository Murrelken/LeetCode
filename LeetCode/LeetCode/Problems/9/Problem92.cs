using LeetCode.DataStructures;

namespace LeetCode.Problems;

public class Problem92
{
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        var preHead = new ListNode(0, head);
        var resultPreHead = preHead;
        
        while (left > 1)
        {
            left--;
            right--;
            preHead = preHead.next;
        }

        var preReverse = preHead;
        preHead = preHead.next;
        right--;

        var lastInOriginal = preHead;
        var tempRight = right;
        while (tempRight > 0)
        {
            tempRight--;
            lastInOriginal = lastInOriginal.next;
        }

        var afterReverse = lastInOriginal.next;

        var lastInReversed = Req(preHead, right);

        lastInReversed.next = afterReverse;
        preReverse.next = lastInOriginal;

        return resultPreHead.next;
    }

    private ListNode Req(ListNode preHead, int right)
    {
        if (right == 0)
        {
            return preHead;
        }

        var prevNext = Req(preHead.next, right - 1);

        prevNext.next = preHead;

        return preHead;
    }
}