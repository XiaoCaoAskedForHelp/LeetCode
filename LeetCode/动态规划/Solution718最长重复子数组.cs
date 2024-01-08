namespace LeetCode.动态规划;

public class Solution718最长重复子数组
{
    // dp[i][j] ：以下标i - 1为结尾的A，和以下标j - 1为结尾的B，最长重复子数组长度为dp[i][j]。 
    public int FindLength(int[] nums1, int[] nums2)
    {
        int m = nums1.Length, n = nums2.Length;
        int[,] dp = new int[m + 1, n + 1];
        int res = 0;
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (nums1[i - 1] == nums2[j - 1])
                {
                    // 以i-1和j-1结尾的最长重复子数组长度 + 1
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                    if (dp[i, j] > res)
                    {
                        res = dp[i, j];
                    }
                }
            }
        }

        return res;
    }

    public int FindLength1(int[] nums1, int[] nums2)
    {
        int[] dp = new int[nums2.Length + 1];
        int res = 0;
        for (int i = 1; i <= nums1.Length; i++)
        {
            // 从后向前遍历，这样避免重复覆盖。
            for (int j = nums2.Length; j > 0; j--)
            {
                if (nums1[i - 1] == nums2[j - 1])
                {
                    dp[j] = dp[j - 1] + 1;
                }
                else
                {
                    dp[j] = 0;
                }

                if (dp[j] > res)
                {
                    res = dp[j];
                }
            }
        }

        return res;
    }
}