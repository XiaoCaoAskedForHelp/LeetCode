namespace LeetCode.动态规划;

public class Solution72编辑距离
{
    // if (word1[i - 1] == word2[j - 1])
    // 不操作
    // if (word1[i - 1] != word2[j - 1])
    // 增
    // 删
    // 换
    // dp[i][j] 表示以下标i-1为结尾的字符串word1，和以下标j-1为结尾的字符串word2，最近编辑距离为dp[i][j]。
    public int MinDistance(string word1, string word2)
    {
        int m = word1.Length, n = word2.Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; i++) dp[i, 0] = i;
        for (int j = 1; j <= n; j++) dp[0, j] = j;
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (word1[i - 1] == word2[j - 1])
                {
                    // 相等不需要编辑
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else
                {
                    // word1删除一个元素，那么就是以下标i - 2为结尾的word1 与 j-1为结尾的word2的最近编辑距离 再加上一个操作。
                    // 即dp[i][j] = dp[i - 1][j] + 1;
                    // word2删除一个元素，那么就是以下标i - 1为结尾的word1 与 j-2为结尾的word2的最近编辑距离 再加上一个操作。
                    // 即 dp[i][j] = dp[i][j - 1] + 1;
                    // 添加操作就相当于删除操作的逆操作，word1删除一个元素，就相当于word2添加一个元素
                    // 替换元素，word1替换word1[i - 1]，使其与word2[j - 1]相同
                    // dp[i][j] = dp[i - 1][j - 1] + 1
                    dp[i, j] = Math.Max(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1]);
                }
            }
        }

        return dp[m, n];
    }

    public int MinDistance1(string word1, string word2)
    {
        int m = word1.Length, n = word2.Length;
        int[] dp = new int[n + 1];
        for (int j = 1; j <= n; j++) dp[j] = j;
        for (int i = 1; i <= m; i++)
        {
            int pre = dp[0]; // 存储dp[i - 1][j - 1]旧的，因为会被覆盖
            dp[0] = i; // 给下一轮循环使用的，dp[i]使用的是dp[i-1],所以第一轮用的是0，之后每轮都是dp[0] = i;
            for (int j = 1; j <= n; j++)
            {
                int tmp = dp[j];
                if (word1[i - 1] == word2[j - 1])
                {
                    dp[j] = pre;
                }
                else
                {
                    dp[j] = Math.Min(Math.Min(dp[j], dp[j - 1]), pre) + 1;
                }

                pre = tmp;
            }
        }

        return dp[n];
    }
}