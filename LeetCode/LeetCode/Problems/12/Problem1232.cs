namespace LeetCode.Problems;

public class Problem1232
{
    public bool CheckStraightLine(int[][] c)
    {
        var v = (c[1][0]-c[0][0], c[1][1]-c[0][1]);
        for(var i=2;i<c.Length;i++)
        {
            var diffX = c[i][0]-c[i-1][0];
            var diffY = c[i][1]-c[i-1][1];
            if(diffX == v.Item1 && diffY == v.Item2 || diffX == 0 && v.Item1 ==0||diffY==0&&v.Item2==0)
                continue;
            if(diffX/(double)v.Item1!=diffY/(double)v.Item2)
                return false;
        }
        return true;
    }
}