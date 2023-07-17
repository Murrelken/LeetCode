using LeetCode.DataStructures;

namespace LeetCode.Problems;

public class Problem445_3
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var (difference, isSecondLonger) = GetListOneAndListTwoLengthDifferenceAndIsSecondLonger(l1, l2);

        // Reverse these variables just to know that l1 is always longer than l2 (or in fact not shorter).
        if (isSecondLonger)
            (l1, l2) = (l2, l1);

        var headOverflowed = SumEachRankAndWriteToL1(l1, l2, difference);

        return headOverflowed ? new ListNode(1, l1) : l1;
    }

    private static (int difference, bool isSecondLonger)
        GetListOneAndListTwoLengthDifferenceAndIsSecondLonger(ListNode l1, ListNode l2)
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

    private static bool SumEachRankAndWriteToL1(ListNode l1, ListNode l2, int remainingDifference)
    {
        // Define dummy l2 nodes like this, without actually creating nodes.
        var useL2Dummy = remainingDifference > 0;
        var nextL2Node = useL2Dummy ? l2 : l2.next;

        var nextOverflowed = false;
        // Doesn't matter which next node to check. The l1 and l2 will end at the same time.
        // First, fall down to the latest pair of elements.
        if (l1.next != null)
            nextOverflowed = SumEachRankAndWriteToL1(l1.next, nextL2Node, remainingDifference - 1);

        var currentL2Value = useL2Dummy ? 0 : l2.val;
        // Once it's the latest pair of elements, or the recursive call returned something,
        // just write the modulo of the sum to the l1 list.
        // The nextOverflowed explanation is below.
        var sum = l1.val + currentL2Value + (nextOverflowed ? 1 : 0);
        l1.val = sum % 10;
        // If the sum of this rank is more than 10 we consider this rank as overflowed,
        // and the higher rank needs to add 1 to itself.
        return sum >= 10;
    }
}