namespace LeetCode.Problems;

public class Problem50
{
    public double MyPow(double x, int n)
    {
        if (x == 1)
            return 1;
        if (x == -1)
            return n % 2 == 1 ? -1 : 1;
        if (n == 0)
            return 1;

        bool isNegative = false;
        if (n < 0)
        {
            isNegative = true;
            n = ~n;
            if (n != int.MaxValue)
                n++;
        }

        var res = ReqPow(x, n);

        return isNegative
            ? 1 /
              (n == int.MaxValue
                  ? res * x
                  : res)
            : res;
    }

    private static double ReqPow(double x, int n)
    {
        if (n == 1)
            return x;
        var powOfHalfPower = ReqPow(x, n / 2);
        var res = powOfHalfPower * powOfHalfPower;
        if (n % 2 == 1)
            res *= x;
        return res;
    }
}