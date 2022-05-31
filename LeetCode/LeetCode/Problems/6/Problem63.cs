namespace LeetCode.Problems
{
    public class Problem63
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var rows = obstacleGrid.Length;
            var cols = obstacleGrid[0].Length;
            var dp = new int[cols];
            dp[0] = 1;

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                    {
                        dp[j] = 0;
                    }
                    else if (j > 0)
                    {
                        dp[j] += dp[j - 1];
                    }
                }
            }

            return dp[cols - 1];
        }
    }
}