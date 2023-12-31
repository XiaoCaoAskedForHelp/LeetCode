namespace LeetCode.动态规划;

public class Solution121买卖股票的最佳时机
{
    public int MaxProfit(int[] prices)
    {
        int[] dp = new int[prices.Length];
        dp[0] = 0;
        int min = prices[0];
        int res = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] > min)
            {
                res = Math.Max(res, prices[i] - min);
            }
            else
            {
                min = prices[i];
            }
        }

        return res;
    }

    //贪心
    public int MaxProfit1(int[] prices)
    {
        int low = Int32.MaxValue;
        int result = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            low = Math.Min(low, prices[i]);
            result = Math.Max(result, prices[i] - low);
        }

        return result;
    }

    //dp[i][0] 表示第i天持有股票所得最多现金 
    //dp[i][1] 表示第i天不持有股票所得最多现金
    // 如果第i天持有股票即dp[i][0]， 那么可以由两个状态推出来 
    // 第i-1天就持有股票，那么就保持现状，所得现金就是昨天持有股票的所得现金 即：dp[i - 1][0]
    // 第i天买入股票，所得现金就是买入今天的股票后所得现金即：-prices[i]
    // 那么dp[i][0]应该选所得现金最大的，所以dp[i][0] = max(dp[i - 1][0], -prices[i]);

    // 如果第i天不持有股票即dp[i][1]， 也可以由两个状态推出来
    // 第i-1天就不持有股票，那么就保持现状，所得现金就是昨天不持有股票的所得现金 即：dp[i - 1][1]
    // 第i天卖出股票，所得现金就是按照今天股票价格卖出后所得现金即：prices[i] + dp[i - 1][0]
    // 同样dp[i][1]取最大的，dp[i][1] = max(dp[i - 1][1], prices[i] + dp[i - 1][0]);
    public int MaxProfit2(int[] prices)
    {
        int len = prices.Length;
        if (len == 0) return 0;
        int[,] dp = new int[len, 2];
        dp[0, 0] -= prices[0];
        dp[0, 1] = 0;
        for (int i = 1; i < len; i++)
        {
            dp[i, 0] = Math.Max(dp[i - 1, 0], -prices[i]);
            dp[i, 1] = Math.Max(dp[i - 1, 1], prices[i] + dp[i - 1, 0]);
        }

        return dp[len - 1, 1];
    }
    
    // dp[i]只是依赖于dp[i - 1]的状态
    // 滚动数组优化
    public int MaxProfit3(int[] prices)
    {
        int len = prices.Length;
        int[,] dp = new int[2, 2];
        dp[0, 0] = -prices[0];
        dp[0, 1] = 0;
        for (int i = 1; i < len; i++)
        {
            dp[i % 2, 0] = Math.Max(dp[(i - 1) % 2, 0], -prices[i]);
            dp[i % 2, 1] = Math.Max(dp[(i - 1) % 2, 1], dp[(i - 1) % 2, 0] + prices[i]);
        }

        return dp[(len - 1) % 2, 1];
    }

}