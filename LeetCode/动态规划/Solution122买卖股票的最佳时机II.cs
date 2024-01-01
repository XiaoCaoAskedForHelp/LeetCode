namespace LeetCode.动态规划;

public class Solution122买卖股票的最佳时机II
{
    // 动态规划
    public int MaxProfit(int[] prices)
    {
        int[] dp = new int[prices.Length];
        dp[0] = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            dp[i] = Math.Max(dp[i - 1], prices[i] - prices[i - 1] + dp[i - 1]);
        }

        return dp[prices.Length - 1];
    }

    // dp[i][0] 表示第i天持有股票所得现金。
    // dp[i][1] 表示第i天不持有股票所得最多现金
    public int MaxProfit1(int[] prices)
    {
        int len = prices.Length;
        int[,] dp = new int[len, 2];
        dp[0, 0] = -prices[0];
        dp[0, 1] = 0;
        for (int i = 1; i < len; i++)
        {
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] - prices[i]);
            dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] + prices[i]);
        }

        return dp[len - 1, 1];
    }

    public int MaxProfit2(int[] prices)
    {
        int len = prices.Length;
        int[,] dp = new int[2, 2];
        dp[0, 0] = -prices[0];
        dp[0, 1] = 0;
        for (int i = 1; i < len; i++)
        {
            dp[i % 2, 0] = Math.Max(dp[(i - 1) % 2, 0], dp[(i - 1) % 2, 1] - prices[i]);
            dp[i % 2, 1] = Math.Max(dp[(i - 1) % 2, 1], dp[(i - 1) % 2, 0] + prices[i]);
        }

        return dp[(len - 1) % 2, 1];
    }
}