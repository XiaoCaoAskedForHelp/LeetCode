using System.ComponentModel;

namespace LeetCode.贪心;

public class Solution53最大子数组和
{
    // 暴力解法超时
    public int MaxSubArray(int[] nums)
    {
        int result = Int32.MinValue;
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            count = 0;
            for (int j = i; j < nums.Length; j++)
            {
                count += nums[j];
                result = count > result ? count : result;
            }
        }

        return result;
    }
    
    // 贪心法
    // 局部最优：当前“连续和”为负数的时候立刻放弃，从下一个元素重新计算“连续和”，因为负数加上下一个元素 “连续和”只会越来越小。
    public int MaxSubArray1(int[] nums)
    {
        int result = Int32.MinValue;
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            count += nums[i];
            if (count > result)
            {
                result = count;
            }

            // 如果 count 一旦加上 nums[i]变为负数，那么就应该从 nums[i+1]开始从 0 累积 count 了，
            // 因为已经变为负数的 count，只会拖累总和。
            if (count <= 0) count = 0;
        }

        return result;
    }
    
    // 动态规划  如果前面的累加和加上本身比自己本身还小，那就说明前面的累加和是小于零的，那就没必要和前面相加了
    public int MaxSubArray2(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

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
}