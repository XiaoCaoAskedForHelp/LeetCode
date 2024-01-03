namespace LeetCode.动态规划;

public class Solution188买卖股票的最佳时机IV
{
    public int MaxProfit(int k, int[] prices)
    {
        int len = prices.Length;
        if (len == 0) return 0;
        int[,] dp = new int[len, k * 2 + 1];
        for (int i = 0; i < k; i++)
        {
            dp[0, 2 * i + 1] = -prices[0];
        }

        for (int i = 1; i < len; i++)
        {
            for (int j = 0; j < k; j++)
            {
                dp[i, 2 * j + 1] = Math.Max(dp[i - 1, 2 * j + 1], dp[i - 1, 2 * j] - prices[i]);
                dp[i, 2 * j + 2] = Math.Max(dp[i - 1, 2 * j + 2], dp[i - 1, 2 * j + 1] + prices[i]);
            }
        }

        return dp[len - 1, k * 2];
    }

    // 使用二维数组 dp[i][j] ：第i天的状态为j，所剩下的最大现金是dp[i][j]
    //
    // j的状态表示为：
    //
    // 0 表示不操作
    // 1 第一次买入
    // 2 第一次卖出
    // 3 第二次买入
    // 4 第二次卖出

    // 第二次买入依赖于第一次卖出的状态，其实相当于第0天第一次买入了，第一次卖出了，然后在买入一次（第二次买入），那么现在手头上没有现金，只要买入，现金就做相应的减少。
    //
    // 所以第二次买入操作，初始化为：dp[0][3] = -prices[0];
    public int MaxProfit1(int k, int[] prices)
    {
        if (prices.Length == 0) return 0;
        int[,] dp = new int[prices.Length, 2 * k + 1];
        for (int i = 1; i < 2 * k; i += 2)
        {
            dp[0, i] = -prices[0];
        }

        for (int i = 1; i < prices.Length; i++)
        {
            for (int j = 1; j < 2 * k; j += 2)
            {
                dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - 1] - prices[i]);
                dp[i, j + 1] = Math.Max(dp[i - 1, j + 1], dp[i - 1, j] + prices[i]);
            }
        }

        return dp[prices.Length - 1, 2 * k];
    }

    public int MaxProfit2(int k, int[] prices)
    {
        if (prices.Length == 0 || k == 0)
        {
            return 0;
        }

        int[] dp = new int[k * 2 + 1];
        for (int i = 1; i < 2 * k + 1; i += 2)
        {
            dp[i] = -prices[0];
        }

        for (int i = 1; i < prices.Length; i++)
        {
            for (int j = 1; j < 2 * k + 1; j++)
            {
                // 奇数天买入
                if (j % 2 == 1)
                {
                    dp[j] = Math.Max(dp[j], dp[j - 1] - prices[i]);
                }
                else
                {
                    // 偶数天卖出
                    dp[j] = Math.Max(dp[j], dp[j - 1] + prices[i]);
                }
            }
        }

        return dp[2 * k];
    }
}