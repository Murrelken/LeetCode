using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class Problem1721
    {
        public ListNode SwapNodes(ListNode head, int k)
        {
            ListNode preBegin = new(0, head), currentRight = preBegin, preLeft = new(0, preBegin);
            int leftStep = 0, rightStep = 0;

            while (currentRight is not null)
            {
                if (leftStep != k)
                {
                    preLeft = preLeft.next;
                    leftStep++;
                }

                if (currentRight.next is not null)
                {
                    rightStep++;
                    if (currentRight.next.next is not null)
                    {
                        rightStep++;
                    }
                }

                currentRight = currentRight.next?.next;
            }

            if (rightStep % 2 == 1 && k == rightStep / 2 + 1)
                return preBegin.next;

            if (k > rightStep / 2)
            {
                preLeft = new(0, preBegin);
                leftStep = 0;
                for (int i = 0; i < rightStep - k + 1; i++)
                {
                    preLeft = preLeft.next;
                    leftStep++;
                }
            }

            var preRight = preLeft.next;
            for (var i = leftStep; i < rightStep - leftStep; i++)
            {
                preRight = preRight.next;
            }

            (preRight.next.val, preLeft.next.val) = (preLeft.next.val, preRight.next.val);

            return preBegin.next;
        }

        private static ListNode PossiblyBetterSwapNodes(ListNode head, int k)
        {
            var toReturn = new ListNode(0, head);
            
            var preFirstNodeToReplace = toReturn;
            for (var i = 0; i < k - 1; i++)
            {
                preFirstNodeToReplace = preFirstNodeToReplace.next;
            }

            var preSecondNodeToReplace = toReturn;
            var shiftedNode = toReturn;
            for (var i = 0; i < k - 1; i++)
            {
                shiftedNode = shiftedNode.next;
            }

            while (shiftedNode.next.next is not null)
            {
                preSecondNodeToReplace = preSecondNodeToReplace.next;
                shiftedNode = shiftedNode.next;
            }

            if (preSecondNodeToReplace.next == preFirstNodeToReplace)
            {
                (preSecondNodeToReplace, preFirstNodeToReplace) = (preFirstNodeToReplace, preSecondNodeToReplace);
            }
            
            if (preFirstNodeToReplace.next == preSecondNodeToReplace)
            {
                var tempSecond = preSecondNodeToReplace.next;
                
                preFirstNodeToReplace.next.next = preSecondNodeToReplace.next.next;
                tempSecond.next = preFirstNodeToReplace.next;
                preFirstNodeToReplace.next = tempSecond;
            }
            else
            {
                var tempFirstToReplace = preFirstNodeToReplace.next;
                var tempAfterSecondToReplace = preSecondNodeToReplace.next.next;
            
                preSecondNodeToReplace.next.next = preFirstNodeToReplace.next.next;
                preFirstNodeToReplace.next = preSecondNodeToReplace.next;

                tempFirstToReplace.next = tempAfterSecondToReplace;
                preSecondNodeToReplace.next = tempFirstToReplace;
            }

            return toReturn.next;
        }
    }
}