using System.Linq;

namespace LeetCode.Problems
{
    public class Problem1423
    {
        public int MaxScore(int[] cardPoints, int k)
        {
            var max = 0;
            for (var i = 1; i <= k; i++)
            {
                max += cardPoints[^i];
            }

            var sum = max;
            for (var i = 0; i < k; i++)
            {
                sum -= cardPoints[cardPoints.Length - k + i];
                sum += cardPoints[i];
                if (sum > max)
                    max = sum;
            }

            return max;
        }
    }
}