namespace LeetCode.动态规划;

public class Solution343整数拆分
{
    // dp[i]：分拆数字i，可以得到的最大乘积为dp[i]
    // 其实可以从1遍历j，然后有两种渠道得到dp[i].
    //一个是j * (i - j) 直接相乘。
    //一个是j * dp[i - j]，相当于是拆分(i - j)
    public int IntegerBreak(int n)
    {
        int[] dp = new int[n + 1];
        dp[2] = 1;
        for (int i = 3; i <= n; i++)
        {
            // 为什么要减一，当j<i时，当j = i-1时，
            // 首先我们没有dp[1]，这种情况不存在,其次j=1时也已经算过这种情况了
            // for (int j = 1; j < i - 1; j++)
            // {
            //     dp[i] = Math.Max(dp[i], Math.Max(j * (i - j), j * dp[i - j]));
            // }

            // 拆分一个数n 使之乘积最大，那么一定是拆分成m个近似相同的子数相乘才是最大的
            for (int j = 1; j <= i / 2; j++)
            {
                dp[i] = Math.Max(dp[i], Math.Max((i - j) * j, dp[i - j] * j));
            }
        }

        return dp[n];
    }

    // 贪心
    // 尽量将数字拆分成较多的较小因子：较小的因子相乘可以得到较大的乘积。这是因为较小的数相乘，它们的乘积增长得更快。
    // 使用质数因子：质数是不能再分解为更小因子的整数，因此，如果你的目标是最大化乘积，尽量使用质数作为因子。这是因为任何非质数因子都可以进一步分解成更小的因子，从而降低乘积的大小。
    // 使用均值不等式：均值不等式是数学中的一个基本原理，它指出，对于一组正数，它们的算术平均值大于等于它们的几何平均值。这意味着，如果你需要将一个数分成两部分，你应该尽量让这两部分接近，而不是差距太大，以最大化它们的乘积。
    
    //每次拆成n个3，如果剩下是4，则保留4，然后相乘
    public int IntegerBreak1(int n)
    {
        if (n == 2) return 1;
        if (n == 3) return 2;
        if (n == 4) return 4;
        int result = 1;
        while (n > 4)
        {
            result *= 3;
            n -= 3;
        }

        result *= n;
        return result;
    }
}