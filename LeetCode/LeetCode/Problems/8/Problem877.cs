namespace LeetCode.Problems;

public class Problem877
{
    public bool StoneGame(int[] piles)
    {
        var dp = new bool?[piles.Length, piles.Length];

        var res = Req(dp, piles, piles.Length - 1);

        return res;
    }

    private bool Req(bool?[,] dpArr, int[] piles, int right, int left = 0, int alice = 0, int bob = 0, bool aliceTurn = true)
    {
        if(left > right){
            return alice > bob;
        }

        if (dpArr[left, right] is not null)
            return dpArr[left, right].Value;

        bool res;
        if (aliceTurn)
            res = Req(dpArr, piles, right, left + 1, alice + piles[left], bob, false)
                   || Req(dpArr, piles, right - 1, left, alice + piles[right], bob, false);
        else
            res = Req(dpArr, piles, right, left + 1, alice, bob + piles[left])
                   || Req(dpArr, piles, right - 1, left, alice, bob + piles[right]);

        dpArr[left, right] = res;
        return res;
    }
}