using System;

namespace LeetCode.Problems
{
    public class Problem1465
    {
        public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            var maxHorizontal = 0L;
            var maxVertical = 0L;
            Array.Sort(horizontalCuts);
            Array.Sort(verticalCuts);
            
            for (var i = 0; i <= horizontalCuts.Length; i++)
            {
                var horizontalStep = i == 0
                    ? horizontalCuts[i]
                    : i == horizontalCuts.Length
                        ? h - horizontalCuts[i - 1]
                        : horizontalCuts[i] - horizontalCuts[i - 1];
                maxHorizontal = Math.Max(maxHorizontal, horizontalStep);
            }

            for (var j = 0; j <= verticalCuts.Length; j++)
            {
                var verticalStep = j == 0
                    ? verticalCuts[j]
                    : j == verticalCuts.Length
                        ? w - verticalCuts[j - 1]
                        : verticalCuts[j] - verticalCuts[j - 1];

                maxVertical = Math.Max(maxVertical, verticalStep);
            }

            return (int)(maxHorizontal * maxVertical % 1000000007);
        }
    }
}