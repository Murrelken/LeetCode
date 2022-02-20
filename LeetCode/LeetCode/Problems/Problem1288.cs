using System.Linq;

namespace LeetCode.Problems
{
    public class Problem1288
    {
        public int RemoveCoveredIntervals(int[][] intervals)
        {
            var removeCount = 0;
            for (var i = 0; i < intervals.Length; i++)
            {
                var outer = intervals[i];
                for (var j = 0; j < intervals.Length; j++)
                {
                    if(i == j)
                        continue;

                    var inner = intervals[j];
                    if (inner[0] <= outer[0] && outer[1] <= inner[1])
                    {
                        removeCount++;
                        break;
                    }
                }
            }

            return intervals.Length - removeCount;
        }

        public int RemoveCoveredIntervalsFaster(int[][] intervals)
        {
            intervals = intervals
                .OrderBy(x => x[0])
                .ThenByDescending(x => x[1])
                .ToArray();

            int cnt = 0, prevEnd = 0;
        
            foreach (var t in intervals)
            {
                if(t[1] > prevEnd)
                {
                    cnt++;
                    prevEnd = t[1];
                }
            }
        
            return cnt;
        }
    }
}