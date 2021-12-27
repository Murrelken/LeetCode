using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem130
    {
        private static int _m;
        private static int _n;

        public void Solve(char[][] board)
        {
            _m = board.Length;
            _n = board[0].Length;

            var tempBoard = new char[_m][];
            for (var i = 0; i < _m; i++)
            {
                tempBoard[i] = new char[_n];
                for (var j = 0; j < _n; j++)
                {
                    tempBoard[i][j] = board[i][j];
                }
            }

            for (var i = 0; i < _m; i++)
            {
                for (var j = 0; j < _n; j++)
                {
                    if (tempBoard[i][j] == 'O')
                    {
                        var refVar = new List<(int i, int j)>();
                        if (!SearchForBorder(tempBoard, i, j, ref refVar))
                        {
                            foreach (var (i1, j1) in refVar)
                            {
                                board[i1][j1] = 'X';
                            }
                        }
                    }
                }
            }
        }

        private static bool SearchForBorder(char[][] mat, int initialI, int initialJ, ref List<(int i, int j)> listToFlip)
        {
            var borderFound = false;

            var queue = new Queue<(int i, int j)>();
            queue.Enqueue((initialI, initialJ));
            mat[initialI][initialJ] = 'X';

            while (queue.Any())
            {
                var currentCount = queue.Count;

                while (currentCount > 0)
                {
                    currentCount--;

                    var (i, j) = queue.Dequeue();
                    listToFlip.Add((i, j));

                    for (short adjI = -1; adjI < 2; adjI++)
                    {
                        for (short adjJ = -1; adjJ < 2; adjJ++)
                        {
                            if (Math.Abs(adjI) == Math.Abs(adjJ)) continue;
                            var newI = i + adjI;
                            var newJ = j + adjJ;
                            if (newI < 0 ||
                                newI >= _m ||
                                newJ < 0 ||
                                newJ >= _n)
                            {
                                borderFound = true;
                                continue;
                            }
                            if (mat[newI][newJ] == 'X') continue;

                            mat[newI][newJ] = 'X';
                            queue.Enqueue((newI, newJ));
                        }
                    }
                }
            }

            return borderFound;
        }
    }
}