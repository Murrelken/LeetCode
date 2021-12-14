using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem994
    {
        public int OrangesRotting(int[][] grid)
        {
            var maxI = grid.Length;
            var maxJ = grid[0].Length;

            if (!ContainsAnyFresh(grid))
                return 0;

            var counter = -1;

            var queue = new Queue<(int i, int j)>();

            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == (int)OrangeState.Rotten)
                        queue.Enqueue((i, j));
                }
            }

            while (queue.Any())
            {
                counter++;

                var currentCount = queue.Count;

                while (currentCount > 0)
                {
                    currentCount--;

                    var (i, j) = queue.Dequeue();

                    for (short adjI = -1; adjI < 2; adjI++)
                    {
                        for (short adjJ = -1; adjJ < 2; adjJ++)
                        {
                            if (Math.Abs(adjI) == Math.Abs(adjJ)) continue;
                            if (i + adjI < 0 ||
                                i + adjI >= maxI ||
                                j + adjJ < 0 ||
                                j + adjJ >= maxJ ||
                                grid[i + adjI][j + adjJ] != (int)OrangeState.Fresh) continue;

                            grid[i + adjI][j + adjJ] = (int)OrangeState.Rotten;

                            queue.Enqueue((i + adjI, j + adjJ));
                        }
                    }
                }
            }

            return ContainsAnyFresh(grid) ? -1 : counter;
        }

        private static bool ContainsAnyFresh(int[][] grid)
        {
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == (int)OrangeState.Fresh)
                        return true;
                }
            }

            return false;
        }

        private enum OrangeState
        {
            NoOrange,
            Fresh,
            Rotten
        }
    }
}