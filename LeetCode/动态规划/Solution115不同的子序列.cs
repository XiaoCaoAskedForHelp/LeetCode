namespace LeetCode.动态规划;

public class Solution115不同的子序列
{
    public int NumDistinct(string s, string t)
    {
        int m = s.Length, n = t.Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 0; i < s.Length; i++) dp[i, 0] = 1;
        for (int i = 1; i < t.Length; i++) dp[0, i] = 0;
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (s[i - 1] == t[j - 1])
                {
                    // 当s[i - 1] 与 t[j - 1]相等时，dp[i][j]可以有两部分组成。
                    // 一部分是用s[i - 1]来匹配，那么个数为dp[i - 1][j - 1]。即不需要考虑当前s子串和t子串的最后一位字母，所以只需要 dp[i-1][j-1]。
                    // 一部分是不用s[i - 1]来匹配，个数为dp[i - 1][j]。
                    dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j];
                }
                else
                {
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }

        return dp[m, n];
    }
}