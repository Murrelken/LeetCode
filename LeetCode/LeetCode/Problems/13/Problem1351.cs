namespace LeetCode.Problems;

public class Problem1351
{
    public int CountNegatives(int[][] grid)
    {
        var res=0;
        var height=grid.Length;
        var width=grid[0].Length;
        var nextI=width-1;
        for(var row=0;row<height;row++)
        for(var i=nextI;i>=0;i--)
        {
            if(grid[row][i]>=0)
            {
                res+=(nextI-i)*(height-row);
                nextI=i;
                break;
            }
            if(i==0)
                return res + (nextI+1)*(height-row);
        }
        return res;
    }
}