namespace LeetCode.动态规划;

public class Solution494目标和
{
    // 既然为target，那么就一定有 left组合 - right组合 = target。
    // left + right = sum，而sum是固定的。right = sum - left
    // 公式来了， left - (sum - left) = target 推导出 left = (target + sum)/2 。
    // target是固定的，sum是固定的，left就可以求出来。
    // 此时问题就是在集合nums中找出和为left的组合。
    public int FindTargetSumWays(int[] nums, int target)
    {
        int sum = nums.Sum();
        if (Math.Abs(target) > sum) return 0; // 此时没有方案
        if ((target + sum) % 2 == 1) return 0; // 此时没有方案
        target = (target + nums.Sum()) / 2;
        int[] dp = new int[target + 1];
        dp[0] = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = target; j >= nums[i]; j--)
            {
                dp[j] += dp[j - nums[i]];
            }
        }

        return dp[target];
    }
}