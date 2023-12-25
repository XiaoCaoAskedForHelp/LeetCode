namespace LeetCode.动态规划;

public class Solution70爬楼梯_进阶版_
{
    public void ClimbStairs()
    {
        int m = Console.Read(); // 表示可以爬1-m个台阶
        int n = Console.Read(); // 表示一共有n个楼梯
        int[] dp = new int[n + 1];
        dp[0] = 1;
        for (int j = 0; j <= n; j++)
        {
            for (int i = 1; i <= m; i++)
            {
                if (j - i >= 0)
                {
                    dp[j] += dp[j - i];
                }
            }
        }

        Console.WriteLine(dp[n]);
    }
}