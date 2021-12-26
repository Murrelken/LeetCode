using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem547
    {
        public int FindCircleNum(int[][] isConnected)
        {
            var m = isConnected.Length;
            var n = isConnected[0].Length;
            var hash = new HashSet<int>();
            var queue = new Queue<int>();
            var count = 0;

            for (var i = 0; i < m; i++)
            {
                if (hash.Contains(i)) continue;
                queue.Enqueue(i);

                while (queue.Any())
                {
                    var queueCount = queue.Count;

                    while (queueCount > 0)
                    {
                        queueCount--;
                        
                        var q = queue.Dequeue();
                        if (hash.Contains(q)) continue;
                        hash.Add(q);

                        for (var j = 0; j < n; j++)
                        {
                            if (isConnected[q][j] == 1)
                                queue.Enqueue(j);
                        }
                    }
                }

                count++;
            }

            return count;
        }
    }
}