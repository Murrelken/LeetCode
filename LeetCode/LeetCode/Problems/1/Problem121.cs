public class Problem121
{
    public int MaxProfit(int[] prices)
    {
        var min = prices[0];
        var target = min;
        for (var i = 1; i < prices.Length; i++)
        {
            if (prices[i] < min)
            {
                target -= min - prices[i];
                min = prices[i];
            }
            else if (prices[i] > target)
            {
                target = prices[i];
            }
        }

        return target - min;
    }
}