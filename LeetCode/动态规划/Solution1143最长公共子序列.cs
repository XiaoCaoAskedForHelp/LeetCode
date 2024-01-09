namespace LeetCode.动态规划;

public class Solution1143最长公共子序列
{
    // 长度为[0, i - 1]的字符串text1与长度为[0, j - 1]的字符串text2的最长公共子序列为dp[i][j]
    // 如果text1[i - 1] 与 text2[j - 1]相同，那么找到了一个公共元素，所以dp[i][j] = dp[i - 1][j - 1] + 1;
    // 如果text1[i - 1] 与 text2[j - 1]不相同，那就看看text1[0, i - 2]与text2[0, j - 1]的最长公共子序列 和 text1[0, i - 1]与text2[0, j - 2]的最长公共子序列，取最大的。
    public int LongestCommonSubsequence(string text1, string text2)
    {
        int m = text1.Length, n = text2.Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (text1[i - 1] == text2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        return dp[m, n];
    }
    
    // 一维dp数组
    public int longestCommonSubsequence(String text1, String text2)
    {
        int m = text1.Length, n = text2.Length;
        int[] dp = new int[n + 1];
        for (int i = 1; i <= m; i++)
        {
            // 这里pre相当于 dp[i - 1][j - 1]
            int pre = dp[0];
            for (int j = 1; j <= n; j++)
            {
                int temp = dp[j];
                if (text1[i-1] == text2[j-1])
                {
                    dp[j] = pre + 1;
                }
                else
                {
                    dp[j] = Math.Max(dp[j], dp[j - 1]);
                }
                pre = temp;
            }
        }   
        return dp[n];
    }
}