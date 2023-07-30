namespace LeetCode.动态规划;

public class Solution70爬楼梯
{
    // 动态规划f(x)=f(x−1)+f(x−2)
    public int ClimbStairs(int n)
    {
        int p = 0, q = 0, r = 1;
        for (int i = 1; i <= n; i++)
        {
            p = q;
            q = r;
            r = p + q;
        }

        return r;
    }

    public int ClimbStairs1(int n)
    {
        if (n <= 1) return n; // 因为下面直接对dp[2]操作了，防止空指针
        int[] dp = new int[3];
        dp[1] = 1; // 一层台阶只有一种方法
        dp[2] = 2; // 两层台阶有两种方法
        for (int i = 3; i <= n; i++)
        {
            int sum = dp[1] + dp[2];
            dp[1] = dp[2];
            dp[2] = sum;
        }

        return dp[2];
    }
}