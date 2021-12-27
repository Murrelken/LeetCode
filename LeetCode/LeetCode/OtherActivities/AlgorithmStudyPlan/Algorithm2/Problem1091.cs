using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem1091
    {
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            var n = grid.Length;
            var startIsZero = grid[0][0] == 0;
            if (n == 1 && startIsZero)
                return 1;
            var path = 0;
            var queue = new Queue<(int i, int j)>();
            if (startIsZero)
                queue.Enqueue((0, 0));

            while (queue.Any())
            {
                path++;
                var queueCount = queue.Count;

                while (queueCount > 0)
                {
                    queueCount--;

                    var (i, j) = queue.Dequeue();

                    for (short adjI = -1; adjI < 2; adjI++)
                    {
                        for (short adjJ = -1; adjJ < 2; adjJ++)
                        {
                            var newI = i + adjI;
                            var newJ = j + adjJ;
                            if (adjI == 0 && adjJ == 0 ||
                                newI < 0 ||
                                newI >= n ||
                                newJ < 0 ||
                                newJ >= n ||
                                grid[newI][newJ] != 0) continue;

                            if (newI == n - 1 && newJ == n - 1)
                                return path + 1;
                            grid[newI][newJ] = -1;
                            queue.Enqueue((newI, newJ));
                        }
                    }
                }
            }

            return -1;
        }
    }
}