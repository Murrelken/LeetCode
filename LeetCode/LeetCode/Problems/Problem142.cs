using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class Problem142
    {
        public ListNode DetectCycle(ListNode head)
        {
            if (head is null)
                return null;
            var cycleCurrent = head;
            for (var i = 0; i < 10000; i++)
            {
                if (cycleCurrent.next is null)
                    return null;
                cycleCurrent = cycleCurrent.next;
            }

            var reference = cycleCurrent;

            var current = head;
            while (true)
            {
                if (cycleCurrent == current)
                    return current;
                cycleCurrent = cycleCurrent.next;
                while (cycleCurrent != reference)
                {
                    if (cycleCurrent == current)
                        return current;
                    cycleCurrent = cycleCurrent.next;
                }

                current = current.next;
            }
        }
    }
}