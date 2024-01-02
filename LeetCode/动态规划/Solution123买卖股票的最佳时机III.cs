namespace LeetCode.动态规划;

public class Solution123买卖股票的最佳时机III
{
    // 一天一共就有五个状态，
    // 没有操作 （其实我们也可以不设置这个状态）
    // 第一次持有股票
    // 第一次不持有股票
    // 第二次持有股票
    // 第二次不持有股票
    // dp[i][j]中 i表示第i天，j为 [0 - 4] 五个状态，dp[i][j]表示第i天状态j所剩最大现金。
    public int MaxProfit(int[] prices)
    {
        int len = prices.Length;
        int[,] dp = new int[len, 5];
        // dp[0,0] 表示的第一次购买股票钱不持有股票的状态   dp[0,4] 表示第二次购买股票后不持有股票的状态
        // 表示的是第一次卖出股票后不持有股票的状态
        dp[0, 1] = -prices[0];
        // 第0天第二次买入操作，初始值应该是多少呢？
        // 第二次买入依赖于第一次卖出的状态，其实相当于第0天第一次买入了，第一次卖出了，然后再买入一次（第二次买入），那么现在手头上没有现金，只要买入，现金就做相应的减少。
        dp[0, 3] = -prices[0];
        for (int i = 1; i < prices.Length; i++)
        {
            dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]);
            dp[i, 2] = Math.Max(dp[i - 1, 2], dp[i - 1, 1] + prices[i]);
            dp[i, 3] = Math.Max(dp[i - 1, 3], dp[i - 1, 2] - prices[i]);
            dp[i, 4] = Math.Max(dp[i - 1, 4], dp[i - 1, 3] + prices[i]);
        }

        return dp[len - 1, 4];
    }

    public int MaxProfit1(int[] prices)
    {
        if (prices.Length == 0) return 0;
        int[] dp = new int[5];
        dp[1] = -prices[0];  // 第一次买入股票持有的状态
        dp[3] = -prices[0];  // 第二次买入股票持有的状态
        for (int i = 1; i < prices.Length; i++)
        {
            dp[1] = Math.Max(dp[1], dp[0] - prices[i]);
            dp[2] = Math.Max(dp[2], dp[1] + prices[i]);
            dp[3] = Math.Max(dp[3], dp[2] - prices[i]);
            dp[4] = Math.Max(dp[4], dp[3] + prices[i]);
        }

        return dp[4];
    }
    
    public int MaxProfit2(int[] prices)
    {
        if (prices.Length == 0) return 0;
        int[] dp = new int[4];
        dp[0] = -prices[0];  // 第一次买入股票持有的状态
        dp[2] = -prices[0];  // 第二次买入股票持有的状态
        for (int i = 1; i < prices.Length; i++)
        {
            dp[0] = Math.Max(dp[0], - prices[i]);
            dp[1] = Math.Max(dp[1], dp[0] + prices[i]);
            dp[2] = Math.Max(dp[2], dp[1] - prices[i]);
            dp[3] = Math.Max(dp[3], dp[2] + prices[i]);
        }

        return dp[3];
    }
}