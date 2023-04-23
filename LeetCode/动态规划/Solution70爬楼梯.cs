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
}