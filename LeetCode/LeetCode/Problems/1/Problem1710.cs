using System;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem1710
    {
        public int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            var sum = 0;
            foreach (var ints in boxTypes.OrderByDescending(x => x[1]))
            {
                if (truckSize <= 0)
                    break;

                sum += Math.Min(truckSize, ints[0]) * ints[1];
                truckSize -= ints[0];
            }

            return sum;
        }
    }
}