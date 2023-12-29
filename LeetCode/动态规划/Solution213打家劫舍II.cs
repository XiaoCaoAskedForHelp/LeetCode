using System.Runtime.Intrinsics.Arm;

namespace LeetCode.动态规划;

public class Solution213打家劫舍II
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        int[] dp = new int[nums.Length];
        int[] dp2 = new int[nums.Length];
        dp[0] = nums[0]; // 偷了第一间房子
        dp[1] = nums[0]; //第二间房子没法偷
        // 最后一间房子也没法偷
        for (int i = 2; i < nums.Length - 1; i++)
        {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
        }

        dp2[0] = 0; // 偷了第一间房子
        dp2[1] = nums[1]; //第二间房子没法偷
        // 最后一间房子可以偷
        for (int i = 2; i < nums.Length; i++)
        {
            dp2[i] = Math.Max(dp2[i - 1], dp2[i - 2] + nums[i]);
        }

        return Math.Max(dp[nums.Length - 2], dp2[nums.Length - 1]);
    }

    // 情况一：考虑不包含首尾元素
    // 情况二：考虑包含首元素，不包含尾元素
    // 情况三：考虑包含尾元素，不包含首元素
    // 例如情况三，虽然是考虑包含尾元素，但不一定要选尾部元素！ 
    // 而情况二 和 情况三 都包含了情况一了，所以只考虑情况二和情况三就可以了
    public int Rob1(int[] nums)
    {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        int result1 = RobRange(nums, 0, nums.Length - 2);
        int result2 = RobRange(nums, 1, nums.Length - 1);
        return Math.Max(result1, result2);
    }

    int RobRange(int[] nums, int start, int end)
    {
        if (start == end) return nums[start];
        int[] dp = new int[nums.Length];
        dp[start] = nums[start];
        dp[start + 1] = Math.Max(nums[start], nums[start + 1]);
        for (int i = start + 2; i < end; i++)
        {
            dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
        }

        return dp[end];
    }

}