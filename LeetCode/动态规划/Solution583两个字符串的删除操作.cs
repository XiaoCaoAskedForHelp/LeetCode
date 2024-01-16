namespace LeetCode.动态规划;

public class Solution583两个字符串的删除操作
{
    // 找出相同的最长字符串，然后用两个字符串的长度减去最长相同字符串的长度
    public int MinDistance(string word1, string word2)
    {
        int m = word1.Length, n = word2.Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (word1[i - 1] == word2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        return m + n - 2 * dp[m, n];
    }

    public int MinDistance1(string word1, string word2)
    {
        int m = word1.Length, n = word2.Length;
        int[] dp = new int[n + 1];
        for (int i = 1; i <= m; i++)
        {
            int pre = dp[0];
            for (int j = 1; j <= n; j++)
            {
                int tmp = dp[j];
                if (word1[i - 1] == word2[j - 1])
                {
                    dp[j] = pre + 1;
                }
                else
                {
                    dp[j] = Math.Max(dp[j], dp[j - 1]);
                }

                pre = tmp;
            }
        }

        return m + n - 2 * dp[n];
    }

    // 正着推 dp[i][j]：以i-1为结尾的字符串word1，和以j-1位结尾的字符串word2，想要达到相等，所需要删除元素的最少次数。
    // 当word1[i - 1] 与 word2[j - 1]相同的时候，dp[i][j] = dp[i - 1][j - 1];
    // 当word1[i - 1] 与 word2[j - 1]不相同的时候，有三种情况：
    // 情况一：删word1[i - 1]，最少操作次数为dp[i - 1][j] + 1
    // 情况二：删word2[j - 1]，最少操作次数为dp[i][j - 1] + 1
    // 情况三：同时删word1[i - 1]和word2[j - 1]，操作的最少次数为dp[i - 1][j - 1] + 2
    // 因为 dp[i][j - 1] + 1 = dp[i - 1][j - 1] + 2，所以递推公式可简化为：dp[i][j] = min(dp[i - 1][j] + 1, dp[i][j - 1] + 1);
    public int MinDistance2(string word1, string word2)
    {
        int m = word1.Length, n = word2.Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 0; i <= m; i++) dp[i, 0] = i;
        for (int j = 0; j <= n; j++) dp[0, j] = j;
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (word1[i - 1] == word2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else
                {
                    dp[i, j] = Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1);
                }
            }
        }

        return dp[m, n];
    }
}