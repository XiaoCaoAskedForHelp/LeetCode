namespace LeetCode.动态规划;

public class Solution674最长连续递增序列
{
    public int FindLengthOfLCIS(int[] nums)
    {
        int[] dp = new int[nums.Length];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i-1])
            {
                dp[i] = dp[i - 1] + 1;
            }
        }

        return dp.Max() + 1;
    }

    public int FindLengthOfLCIS1(int[] nums)
    {
        if (nums.Length == 0) return 0;
        int result = 1;
        int[] dp = Enumerable.Repeat(1, nums.Length).ToArray();
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] > nums[i - 1]) { // 连续记录
                dp[i] = dp[i - 1] + 1;
            }
            if (dp[i] > result) result = dp[i];
        }
        return result;
    }

    public int FindLengthOfLCIS2(int[] nums)
    {
        if (nums.Length == 0) return 0;
        int result = 1; // 连f续子序列最少也是1
        int count = 1;
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] > nums[i - 1]) { // 连续记录
                count++;
            } else { // 不连续，count从头开始
                count = 1;
            }
            if (count > result) result = count;
        }
        return result;
    }
}