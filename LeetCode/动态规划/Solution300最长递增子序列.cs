namespace LeetCode.动态规划;

public class Solution300最长递增子序列
{
    // dp[i]表示i之前包括i的以nums[i]结尾的最长递增子序列的长度
    // 位置i的最长升序子序列等于j从0到i-1各个位置的最长升序子序列 + 1 的最大值。
    public int LengthOfLIS(int[] nums)
    {
        int[] dp = new int[nums.Length];
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = 1;
        }

        for (int i = 1; i < dp.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        return dp.Max();
    }

    public int LengthOfLIS1(int[] nums)
    {
        int[] dp = new int[nums.Length];
        int res = 1;
        Array.Fill(dp, 1);
        for (int i = 1; i < dp.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }

                res = Math.Max(res, dp[i]);
            }
        }

        return res;
    }
}