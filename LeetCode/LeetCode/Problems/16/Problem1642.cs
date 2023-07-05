using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem1642
    {
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            var heightsNeededToCover = new SortedList<int, int>();
            var totalCount = 0;

            int i;
            for (i = 0; i < heights.Length - 1; i++)
            {
                if(heights[i+1] <= heights[i]) continue;

                var diff = heights[i + 1] - heights[i];
                if (heightsNeededToCover.ContainsKey(diff))
                    heightsNeededToCover[diff]++;
                else
                    heightsNeededToCover.Add(diff, 1);
                totalCount++;

                if(totalCount <= ladders) continue;

                var min = heightsNeededToCover.First().Key;
                bricks -= min;
                
                if(bricks < 0) break;

                totalCount--;
                if (heightsNeededToCover[min] == 1)
                    heightsNeededToCover.Remove(min);
                else
                    heightsNeededToCover[min]--;
            }

            return i;
        }
    }
}