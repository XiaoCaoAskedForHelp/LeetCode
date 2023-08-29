namespace LeetCode.动态规划;

public class Solution62不同路径
{
    // 深度优先搜索  会超时
    public int UniquePaths(int m, int n)
    {
        return dfs(1, 1, m, n);
    }

    private int dfs(int i, int j, int m, int n)
    {
        if (i > m || j > n) return 0;
        if (i == m && j == n) return 1;
        return dfs(i + 1, j, m, n) + dfs(i, j + 1, m, n);
    }


    // 动态规划 递推公式dp[i][j] = dp[i - 1][j] + dp[i][j - 1]，dp[i][j]都是从其上方和左方推导而来，那么从左到右一层一层遍历就可以了。
    public int UniquePaths1(int m, int n)
    {
        int[,] dp = new int[m, n];
        for (int i = 0; i < n; i++) dp[0, i] = 1;
        for (int i = 0; i < m; i++) dp[i, 0] = 1;
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }

        return dp[m - 1, n - 1];
    }

    // 其实用一个二维数组（也可以理解是滚动数组）就可以了
    public int UniquePaths2(int m, int n)
    {
        int[,] dp = new int[2, n];
        for (int i = 0; i < n; i++) dp[0, i] = 1;
        for (int i = 1; i < m; i++)
        {
            dp[1, 0] = 1;
            for (int j = 1; j < n; j++)
            {
                dp[1, j] = dp[0, j] + dp[1, j - 1];
            }

            for (int j = 0; j < n; j++) dp[0, j] = dp[1, j];
        }

        return dp[0, n - 1];
    }

    // 其实用一个一维数组（也可以理解是滚动数组）就可以了
    public int UniquePaths3(int m, int n)
    {
        int[] dp = new int[n];
        for (int i = 0; i < n; i++) dp[i] = 1;
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[j] += dp[j - 1];
            }
        }

        return dp[n - 1];
    }
    
    // 数论方法
    // 无论怎么走，走到终点都需要 m + n - 2 步
    // 在这m + n - 2 步中，一定有 m - 1 步是要向下走的，不用管什么时候向下走。
    // 那么有几种走法呢？ 可以转化为，给你m + n - 2个不同的数，随便取m - 1个数，有几种取法。组合数问题
    public int UniquePaths4(int m, int n)
    {
        // 求组合的时候，要防止两个int相乘溢出！ 所以不能把算式的分子都算出来，分母都算出来再做除法。
        // int numerator = 1, denominator = 1;
        // int count = m - 1;
        // int t = m + n - 2;
        // while (count-- != 0) numerator *= (t--); // 计算分子，此时分子就会溢出
        // for (int i = 1; i <= m - 1; i++) denominator *= i; // 计算分母
        // return numerator / denominator;
        
        long numerator = 1; // 分子
        int denominator = m - 1; // 分母
        int count = m - 1;
        int t = m + n - 2;
        while (count-- != 0) {
            numerator *= (t--);
            while (denominator != 0 && numerator % denominator == 0) {
                numerator /= denominator;
                denominator--;
            }
        }
        return (int)numerator;
    }
}