using System;

namespace LeetCode.Problems
{
    public class Problem289
    {
        public void GameOfLife(int[][] board)
        {
            var vertLength = board.Length;
            var horLength = board[0].Length;

            // 2 - alive to dead
            // 3 - dead to alive
            for (var i = 0; i < vertLength; i++)
            {
                for (var j = 0; j < horLength; j++)
                {
                    var count = 0;

                    for (short adjI = -1; adjI < 2; adjI++)
                    {
                        for (short adjJ = -1; adjJ < 2; adjJ++)
                        {
                            var newI = i + adjI;
                            var newJ = j + adjJ;
                            if (adjI == 0 && adjJ == 0 ||
                                newI < 0 ||
                                newI >= vertLength ||
                                newJ < 0 ||
                                newJ >= horLength) continue;

                            if (board[newI][newJ] is 1 or 2)
                                count++;
                        }
                    }

                    if (board[i][j] == 0)
                    {
                        if (count == 3)
                            board[i][j] = 3;
                    }
                    else if (count is not 2 and not 3)
                    {
                        board[i][j] = 2;
                    }
                }
            }


            foreach (var ints in board)
            {
                Console.WriteLine();
                foreach (var i in ints)
                {
                    Console.Write(i + ",");
                }
            }

            for (var i = 0; i < vertLength; i++)
            {
                for (var j = 0; j < horLength; j++)
                {
                    if (board[i][j] == 2)
                        board[i][j] = 0;
                    if (board[i][j] == 3)
                        board[i][j] = 1;
                }
            }
        }
    }
}