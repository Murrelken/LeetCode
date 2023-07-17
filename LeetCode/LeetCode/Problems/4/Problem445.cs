using LeetCode.DataStructures;

namespace LeetCode.Problems;

public class Problem445
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var (l1Length, l2Length) = GetListOneAndListTwoLengths(l1, l2);

        // Reverse these variables just to know that l1 is always longer than l2 (or in fact not shorter).
        if (l2Length > l1Length)
        {
            (l1, l2) = (l2, l1);
            (l1Length, l2Length) = (l2Length, l1Length);
        }

        // Prepend dummy nodes to the shorter list so we could use them as corresponding ranks for the longer number.
        // in the recursive method called later
        var newL2PreHead = new ListNode(0, l2);
        if (l2Length != l1Length)
        {
            var tempL2Head = newL2PreHead;

            for (var i = 0; i < l1Length - l2Length; i++)
            {
                tempL2Head.next = new ListNode();
                tempL2Head = tempL2Head.next;
            }

            tempL2Head.next = l2;
        }

        var headOverflowed = SumEachRankAndWriteToL1(l1, newL2PreHead.next);

        return headOverflowed ? new ListNode(1, l1) : l1;
    }

    private static (int l1Length, int l2Length) GetListOneAndListTwoLengths(ListNode l1, ListNode l2)
    {
        var tempNode = new ListNode(0, l1);
        var l1Length = 0;
        while (tempNode.next != null)
        {
            tempNode = tempNode.next;
            l1Length++;
        }

        tempNode = new ListNode(0, l2);
        var l2Length = 0;
        while (tempNode.next != null)
        {
            tempNode = tempNode.next;
            l2Length++;
        }

        return (l1Length, l2Length);
    }

    private static bool SumEachRankAndWriteToL1(ListNode l1, ListNode l2)
    {
        var nextOverflowed = false;
        // Doesn't matter which next node to check. The l1 and l2 have the same length at this point.
        // First, fall down to the latest pair of elements.
        if (l1.next != null)
            nextOverflowed = SumEachRankAndWriteToL1(l1.next, l2.next);

        // Once it's the latest pair of elements, or the recursive call returned something,
        // just write the modulo of the sum to the l1 list.
        // The nextOverflowed explanation is below.
        var sum = l1.val + l2.val + (nextOverflowed ? 1 : 0);
        l1.val = sum % 10;
        // If the sum of this rank is more than 10 we consider this rank as overflowed,
        // and the higher rank needs to add 1 to itself.
        return sum >= 10;
    }
}