namespace LeetCode.Problems;

public class Problem837
{
    public double New21Game(int n, int k, int maxPts)
    {
        if (k == 0 || n >= k + maxPts)
            return 1.0;

        var p = new double[n];
        p[0] = (double)1 / maxPts;

        for (var i = 1; i < n; i++)
        {
            double p1 = 0;
            for (var j = i - 1; j >= 0 && j >= i - maxPts ; j--)
            {
                p1 += p[j] * p[0];
            }

            if (i < maxPts)
                p1 += p[0];

            p[i] = p1;
        }

        double res = 0;

        for (int i = n - 1; i >= k - 1; i--)
        {
            res += p[i];
            for (int j = 0; j < n - 1 - i; j++)
                res -= p[i] / maxPts;
        }

        return res;
    }
}