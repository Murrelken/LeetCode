using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems;

public class Problem1970
{
    public int LatestDayToCross(int row, int col, int[][] cells)
    {
        var rightAndBottomPossiblePaths = new[] { (0, 1), (1, 0) };
        var leftAndBottomPossiblePaths = new[] { (0, -1), (1, 0) };

        var possibleYByRow = new int[row];

        var memo = new int[row][];
        for (var i = 0; i < memo.Length; i++)
            memo[i] = new int[col];

        for (var i = 0; i < cells.Length; i++)
        {
            var blueX = cells[i][0] - 1;
            var blueY = cells[i][1] - 1;

            memo[blueX][blueY] = 1;

            var startRow = blueX == 0 ? 0 : blueX - 1;
            var endRow = blueX == row - 1 ? row - 1 : blueX + 1;

            if (!PathFoundBFS(startRow, endRow, col, memo, rightAndBottomPossiblePaths, leftAndBottomPossiblePaths, possibleYByRow))
                return i;
        }

        return -1;
    }

    private bool PathFoundBFS(int startRow, int endRow, int width, int[][] matrix,
        (int x, int y)[] rightAndBottomPossiblePaths, (int x, int y)[] leftAndBottomPossiblePaths,
        int[] possibleYByRow)
    {
        var queue = new Queue<(int x, int y, Direction direction, int startY)>();
        for (var i = 0; i < matrix[startRow].Length; i++)
            if (matrix[startRow][i] == 0)
                queue.Enqueue((startRow, i, Direction.Bottom, i));

        while (queue.Any())
        {
            var count = queue.Count;
            while (count > 0)
            {
                var (x, y, direction, startY) = queue.Dequeue();

                switch (direction)
                {
                    case Direction.RightAndBottom:
                    {
                        for (var i = 0; i < rightAndBottomPossiblePaths.Length; i++)
                        {
                            var newX = x + rightAndBottomPossiblePaths[i].x;
                            var newY = y + rightAndBottomPossiblePaths[i].y;

                            if (newY < 0 || newY >= width || matrix[newX][newY] == 1)
                                continue;

                            if (newX == endRow && possibleYByRow[newX] == newY)
                            {
                                possibleYByRow[startRow] = startY;
                                possibleYByRow[x] = startY;
                                return true;
                            }
                            
                            queue.Enqueue((newX, newY, Direction.RightAndBottom, startY));
                        }

                        break;
                    }
                    case Direction.LeftAndBottom:
                    {
                        for (var i = 0; i < leftAndBottomPossiblePaths.Length; i++)
                        {
                            var newX = x + leftAndBottomPossiblePaths[i].x;
                            var newY = y + leftAndBottomPossiblePaths[i].y;

                            if (newY < 0 || newY >= width || matrix[newX][newY] == 1)
                                continue;

                            if (newX == endRow && possibleYByRow[newX] == newY)
                            {
                                possibleYByRow[startRow] = startY;
                                possibleYByRow[x] = startY;
                                return true;
                            }
                            
                            queue.Enqueue((newX, newY, Direction.LeftAndBottom, startY));
                        }

                        break;
                    }
                    case Direction.Bottom:
                    {
                        var newX = x + 1;

                        if (matrix[newX][y] == 1)
                            break;

                        if (newX == endRow && possibleYByRow[newX] == y)
                        {
                            possibleYByRow[x] = y;
                            return true;
                        }
                        
                        queue.Enqueue((newX, y, Direction.LeftAndBottom, startY));
                        queue.Enqueue((newX, y, Direction.RightAndBottom, startY));

                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }


                count--;
            }
        }

        return false;
    }

    private enum Direction
    {
        RightAndBottom,
        LeftAndBottom,
        Bottom
    }
}