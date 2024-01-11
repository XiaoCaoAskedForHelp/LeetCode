namespace LeetCode.动态规划;

public class Solution53最大子数组和
{
    // 包括下标i（以nums[i]为结尾）的最大连续子序列和为dp[i]。
    public int MaxSubArray(int[] nums)
    {
        int[] dp = new int[nums.Length];
        dp[0] = nums[0];
        int result = dp[0];
        for (int i = 1; i < nums.Length; i++)
        {
            dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
            if (dp[i] > result) result = dp[i];
        }

        return result;
    }

    //因为dp[i]的递推公式只与前一个值有关，所以可以用一个变量代替dp数组，空间复杂度为O(1)
    public int MaxSubArray1(int[] nums)
    {
        int res = nums[0];
        int pre = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            pre = Math.Max(pre + nums[i], nums[i]);
            res = Math.Max(res, pre);
        }

        return res;
    }

}