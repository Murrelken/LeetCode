using LeetCode.DataStructures;

namespace LeetCode.Problems;

public class Problem445_2
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var (difference, isSecondLonger) = GetListOneAndListTwoLengthDifferenceAndIsSecondLonger(l1, l2);

        // Reverse these variables just to know that l1 is always longer than l2 (or in fact not shorter).
        if (isSecondLonger)
            (l1, l2) = (l2, l1);

        // Prepend dummy nodes to the shorter list so we could use them as corresponding ranks for the longer number.
        // in the recursive method called later
        var newL2PreHead = new ListNode(0, l2);
        if (difference > 0)
        {
            var tempL2Head = newL2PreHead;

            for (var i = 0; i < difference; i++)
            {
                tempL2Head.next = new ListNode();
                tempL2Head = tempL2Head.next;
            }

            tempL2Head.next = l2;
        }

        var headOverflowed = SumEachRankAndWriteToL1(l1, newL2PreHead.next);

        return headOverflowed ? new ListNode(1, l1) : l1;
    }

    private static (int difference, bool isSecondLonger) GetListOneAndListTwoLengthDifferenceAndIsSecondLonger(
        ListNode l1, ListNode l2)
    {
        var difference = 0;
        var isSecondLonger = false;
        var checkedIsSecondLonger = false;
        var firstListTempNode = new ListNode(0, l1);
        var secondListTempNode = new ListNode(0, l2);
        while (firstListTempNode?.next != null || secondListTempNode?.next != null)
        {
            if (firstListTempNode?.next == null || secondListTempNode?.next == null)
            {
                if (!checkedIsSecondLonger)
                {
                    if (firstListTempNode?.next == null)
                        isSecondLonger = true;
                    checkedIsSecondLonger = true;
                }

                difference++;
            }

            firstListTempNode = firstListTempNode?.next;
            secondListTempNode = secondListTempNode?.next;
        }

        return (difference, isSecondLonger);
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