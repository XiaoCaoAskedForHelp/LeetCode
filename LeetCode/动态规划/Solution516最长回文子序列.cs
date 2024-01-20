namespace LeetCode.动态规划;

public class Solution516最长回文子序列
{
    public int LongestPalindromeSubseq(string s)
    {
        int len = s.Length;
        // dp[i][j] 表示以下标i-1为结尾的字符串s，和以下标j-1为结尾的字符串s，最长回文子序列的长度为dp[i][j]。
        // 依赖于dp[i + 1][j - 1]，所以i从大到小，j从小到大
        int[,] dp = new int[len, len];
        for (int i = len - 1; i >= 0; i--)
        {
            for (int j = i; j < len; j++)
            {
                if (s[i] == s[j])
                {
                    if (j - i <= 1)
                    {
                        // 情况一(一个字符) 和 情况二（两个字符）
                        dp[i, j] = j - i + 1;
                    }
                    else
                    {
                        // 情况三  中间加两头
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    }
                }
                else
                {
                    // 如果两头不相等，那么最佳长度也不是中间，而是比较加中间+两头中间的一个的最大值，这样能涵盖中间
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                }
            }
        }
        return dp[0, len - 1];
    }

    // dp[i][j]：字符串s在[i, j]范围内最长的回文子序列的长度为dp[i][j]
    // 如果s[i]与s[j]相同，那么dp[i][j] = dp[i + 1][j - 1] + 2;
    // 如果s[i]与s[j]不相同，说明s[i]和s[j]的同时加入 并不能增加[i,j]区间回文子序列的长度，那么分别加入s[i]、s[j]看看哪一个可以组成最长的回文子序列。
    // 递推公式是计算不到 i 和j相同时候的情况,需要手动初始化一下为1
    public int LongestPalindromeSubseq1(string s)
    {
        int len = s.Length;
        int[,] dp = new int[len, len];
        for (int i = len - 1; i >= 0; i--)
        {
            dp[i, i] = 1;// 初识化
            for (int j = i + 1; j < len; j++)
            {
                if (s[i] == s[j])
                {
                    dp[i, j] = dp[i + 1, j - 1] + 2;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                }
            }
        }
        return dp[0, len - 1];
    }
}