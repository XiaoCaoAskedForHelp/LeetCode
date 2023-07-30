namespace LeetCode.动态规划;

public class Solution746使用最小花费爬楼梯
{
    public int MinCostClimbingStairs(int[] cost)
    {
        //dp[i]的定义：到达第i台阶所花费的最少体力为dp[i]。
        int len = cost.Length;
        int[] dp = new[] { 0, 0 };

        for (int i = 2; i <= len; i++)
        {
            int min = Math.Min(dp[0] + cost[i - 2], dp[1] + cost[i - 1]);
            dp[0] = dp[1];
            dp[1] = min;
        }

        return dp[1];
    }

    public int MinCostClimbingStairs1(int[] cost)
    {
        int len = cost.Length;
        int[] dp = new int[len + 1];

        // 从下标为 0 或下标为 1 的台阶开始，因此支付费用为0
        dp[0] = 0;
        dp[1] = 0;

        // 计算到达每一层台阶的最小费用
        for (int i = 2; i <= len; i++) {
            dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
        }

        return dp[len];
    }
}