namespace LeetCode.贪心;

public class Solution122买卖股票的最佳时机II
{
    // 只要后一天的股票比前一天的上涨那这收益我就加进来
    // 把利润分解为每天为单位的维度，而不是从 0 天到第 3 天整体去考虑
    public int MaxProfit(int[] prices)
    {
        int result = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            // if (prices[i] > prices[i - 1])
            // {
            //     result += (prices[i] - prices[i - 1]);
            // }
            // 或者
            result += Math.Max(0, prices[i] - prices[i - 1]);
        }

        return result;
    }
}