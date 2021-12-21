using LeetCode.DataStructures;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem82
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            var preBegin = new ListNode();
            var currentRepeatValue = int.MinValue;
            var currentOfNew = preBegin;
            var currentIterate = head;

            while (currentIterate != null)
            {
                if (currentIterate.val == currentRepeatValue)
                {
                    currentIterate = currentIterate.next;
                    continue;
                }

                if (currentIterate.next == null || currentIterate.next.val != currentIterate.val)
                {
                    currentOfNew.next = new ListNode(currentIterate.val);
                    currentOfNew = currentOfNew.next;
                    currentIterate = currentIterate.next;
                }
                else
                {
                    currentRepeatValue = currentIterate.val;
                    currentIterate = currentIterate.next;
                }
            }

            return preBegin.next;
        }

        public ListNode DeleteDuplicatesMutate(ListNode head)
        {
            var currentRepeatValue = int.MinValue;
            ListNode currentOfNew = null;
            ListNode first = null;

            while (head != null)
            {
                if (head.val == currentRepeatValue)
                {
                    if (head.next == null && currentOfNew != null)
                        currentOfNew.next = null;
                    head = head.next;
                    continue;
                }
            
                if (head.next == null || head.next.val != head.val)
                {
                    if (currentOfNew == null)
                    {
                        currentOfNew = head;
                        first = currentOfNew;
                    }
                    else
                    {
                        currentOfNew.next = head;
                        currentOfNew = currentOfNew.next;
                    }
                    head = head.next;
                }
                else
                {
                    currentRepeatValue = head.val;
                    head = head.next;
                }
            }

            return first;
        }
    }
}