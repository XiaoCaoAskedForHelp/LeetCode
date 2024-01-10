namespace LeetCode.动态规划;

public class Solution1035不相交的线
{
    // 和Solution1143最长公共子序列一样
    public int MaxUncrossedLines(int[] nums1, int[] nums2) {
        int m = nums1.Length, n = nums2.Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (nums1[i-1] == nums2[j-1])
                {
                    dp[i,j] = dp[i-1,j-1] + 1;
                }
                else
                {
                    dp[i,j] = Math.Max(dp[i-1,j], dp[i,j-1]);
                }
            }
        }
        return dp[m,n];
    }

    public int MaxUncrossedLines1(int[] nums1, int[] nums2)
    {
        int m = nums1.Length, n = nums2.Length;
        int[] dp = new int[n + 1];
        for (int i = 1; i <= m; i++)
        {
            int pre = dp[0];
            for (int j = 1; j <= n; j++)
            {
                int temp = dp[j];
                if (nums1[i-1] == nums2[j-1])
                {
                    dp[j] = pre + 1;
                }
                else
                {
                    dp[j] = Math.Max(dp[j], dp[j-1]);
                }
                pre = temp;
            }
        }
        return dp[n];
    }

}