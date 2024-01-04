namespace LeetCode.动态规划;

public class Solution309买卖股票的最佳时机含冷冻期
{
    // 不操作 [买入, 卖出, 冷冻期]
    public int MaxProfit(int[] prices)
    {
        int len = prices.Length;
        if (len == 0 || len == 1) return 0;
        int k = 1 + len;
        int[,] dp = new int[len, k];
        for (int i = 1; i < k; i += 3)
        {
            dp[0, i] = -prices[0];
        }

        for (int i = 1; i < len; i++)
        {
            for (int j = 1; j < k; j++)
            {
                if (j % 3 == 0)
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else if (j % 3 == 1)
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - 1] - prices[i]);
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - 1] + prices[i]);
                }
            }
        }

        return Math.Max(Math.Max(dp[len - 1, k - 1], dp[len - 1, k - 2]), dp[len - 1, k - 3]);
    }

    // dp[i][j]，第i天状态为j，所剩的最多现金为dp[i][j]。
    // 达到买入股票状态
    // 达到保持卖出股票状态
    // 达到今天就卖出股票状态
    // 达到冷冻期状态
    public int MaxProfit1(int[] prices)
    {
        int n = prices.Length;
        if (n == 0) return 0;
        int[,] dp = new int[n, 4];
        dp[0, 0] = -prices[0]; //持有股票
        for (int i = 1; i < n; i++)
        {
            dp[i, 0] = Math.Max(Math.Max(dp[i - 1, 0], dp[i - 1, 3] - prices[i]), dp[i - 1, 1] - prices[i]);
            dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 3]);
            dp[i, 2] = dp[i - 1, 0] + prices[i];
            dp[i, 3] = dp[i - 1, 2];
        }

        return Math.Max(Math.Max(dp[n - 1, 1], dp[n - 1, 2]), dp[n - 1, 3]);
    }

    // 二维数组优化
    public int MaxProfit2(int[] prices)
    {
        // 1. [i][0] holding the stock
        // 2. [i][1] after cooldown but stil not buing the stock
        // 3. [i][2] selling the stock
        // 4. [i][3] cooldown

        int len = prices.Length;
        int[,] dp = new int[2, 4];
        dp[0, 0] = -prices[0];
        for (int i = 1; i < len; i++)
        {
            dp[i % 2, 0] = Math.Max(Math.Max(dp[(i - 1) % 2, 0], dp[(i - 1) % 2, 3] - prices[i]),
                dp[(i - 1) % 2, 1] - prices[i]);
            dp[i % 2, 1] = Math.Max(dp[(i - 1) % 2, 1], dp[(i - 1) % 2, 3]);
            dp[i % 2, 2] = dp[(i - 1) % 2, 0] + prices[i];
            dp[i % 2, 3] = dp[(i - 1) % 2, 2];
        }

        return Math.Max(Math.Max(dp[(len - 1) % 2, 1], dp[(len - 1) % 2, 2]), dp[(len - 1) % 2, 3]);
    }

    // 一维数字优化
    public int MaxProfit3(int[] prices)
    {
        int[] dp = new int[4];

        dp[0] = -prices[0];
        dp[1] = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            // 使用临时变量来保存dp[0], dp[2]
            // 因为马上dp[0]和dp[2]的数据都会变 
            int temp = dp[0];
            int temp1 = dp[2];
            dp[0] = Math.Max(dp[0], Math.Max(dp[3], dp[1]) - prices[i]);
            dp[1] = Math.Max(dp[1], dp[3]);
            dp[2] = temp + prices[i];
            dp[3] = temp1;
        }

        return Math.Max(dp[3], Math.Max(dp[1], dp[2]));
    }
}