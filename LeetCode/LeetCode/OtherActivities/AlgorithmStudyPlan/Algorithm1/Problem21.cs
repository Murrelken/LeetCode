using LeetCode.DataStructures;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem21
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var preHead = new ListNode();
            var current = preHead;

            while (list1 is not null || list2 is not null)
            {
                if (list1?.val < list2?.val || list2 is null)
                {
                    current.next = new ListNode(list1.val);
                    list1 = list1.next;
                }
                else
                {
                    current.next = new ListNode(list2.val);
                    list2 = list2.next;
                }

                current = current.next;
            }

            return preHead.next;
        }
    }
}