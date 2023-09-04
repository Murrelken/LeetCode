using LeetCode.DataStructures;

namespace LeetCode.Problems;

public class Problem141
{
    public bool HasCycle(ListNode head) {
        while (head != null) {
            if (head.val == int.MaxValue) {
                return true;
            }
            head.val = int.MaxValue;
            head = head.next;
        }

        return false;
    }
}