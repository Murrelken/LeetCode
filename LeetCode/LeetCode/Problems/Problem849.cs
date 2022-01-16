using System;

namespace LeetCode.Problems
{
    public class Problem849
    {
        public int MaxDistToClosest(int[] seats)
        {
            var leftRightDistance = new (int left, int right)[seats.Length];
            var maxDistance = 1;
            var leftCounter = 1;

            for (var i = 0; i < seats.Length; i++)
            {
                if (seats[i] == 1)
                {
                    var j = i - 1;
                    var c = 1;
                    while (j >= 0 && seats[j] == 0)
                    {
                        leftRightDistance[j].right = c;

                        if (j == 0)
                            leftRightDistance[j].left = leftRightDistance[j].right;

                        var abs = Math.Abs(leftRightDistance[j].left - leftRightDistance[j].right);
                        var min = Math.Min(leftRightDistance[j].left, leftRightDistance[j].right);
                        if (abs is 0 or 1 && min > maxDistance)
                            maxDistance = min;

                        c++;
                        j--;
                    }

                    leftCounter = 1;
                }
                else
                {
                    leftRightDistance[i].left = leftCounter;

                    if (i == seats.Length - 1)
                        leftRightDistance[i].right = leftRightDistance[i].left;

                    leftCounter++;

                    var abs = Math.Abs(leftRightDistance[i].left - leftRightDistance[i].right);
                    var min = Math.Min(leftRightDistance[i].left, leftRightDistance[i].right);
                    if (abs is 0 or 1 && min > maxDistance)
                        maxDistance = min;
                }
            }

            return maxDistance;
        }
    }
}