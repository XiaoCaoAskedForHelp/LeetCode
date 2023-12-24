namespace LeetCode.动态规划;

public class Solution377组合总和_
{
    // 元素相同顺序不同的组合算两个组合，其实就是求排列！
    public int CombinationSum4(int[] nums, int target)
    {
        int[] dp = new int[target + 1];
        dp[0] = 1;
        for (int i = 1; i <= target; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (i - nums[j] >= 0)
                {
                    dp[i] += dp[i - nums[j]];
                }
            }
        }

        return dp[target];
    }
}