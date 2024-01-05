namespace LeetCode.动态规划;

public class Solution714买卖股票的最佳时机含手续费
{
    public int MaxProfit(int[] prices, int fee)
    {
        int len = prices.Length;
        int[,] dp = new int[len, 2];
        dp[0, 0] = -prices[0];
        for (int i = 1; i < len; i++)
        {
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] - prices[i]);
            dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] + prices[i] - fee);
        }

        return dp[len - 1, 1];
    }

    public int MaxProfit1(int[] prices, int fee)
    {
        int[] dp = new int[2];
        dp[0] = -prices[0];
        dp[1] = 0;
        for (int i = 1; i <= prices.Length; i++) {
            dp[0] = Math.Max(dp[0], dp[1] - prices[i - 1]);
            dp[1] = Math.Max(dp[1], dp[0] + prices[i - 1] - fee);
        }
        return dp[1];
    }
}