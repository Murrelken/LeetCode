namespace LeetCode.Problems;

public class Problem1318
{
    public int MinFlips(int a, int b, int c)
    {
        var res = 0;
        while (c > 0 || a > 0 || b > 0)
        {
            var rightBitA = a % 2;
            var rightBitB = b % 2;
            var rightBitC = c % 2;

            switch (rightBitC)
            {
                case 1 when rightBitA == 0 && rightBitB == 0:
                    res++;
                    break;
                case 0:
                {
                    if (rightBitA == 1)
                        res++;
                    if (rightBitB == 1)
                        res++;
                    break;
                }
            }

            a >>= 1;
            b >>= 1;
            c >>= 1;
        }

        return res;
    }
}