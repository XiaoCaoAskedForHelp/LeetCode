namespace LeetCode.动态规划;

public class Solution多重背包理论基础
{
    public void testMultiplePack()
    {
        int bagWeight = 10;
        int[] weight = new int[] { 1, 3, 4 };
        int[] value = new int[] { 15, 20, 30 };
        int[] nums = new int[] { 2, 3, 2 };
        int[] dp = new int[bagWeight + 1];
        for (int i = 0; i < weight.Length; i++) // 遍历物品
        {
            for (int j = bagWeight; j >= weight[i]; j--) // 遍历背包容量
            {
                // 以上是01背包，然后加一个遍历个数
                for (int k = 1; k <= nums[i] && j - k * weight[i] >= 0; k++)
                {
                    dp[j] = Math.Max(dp[j], dp[j - k * weight[i]] + k * value[i]);
                }
            }
        }

        Console.WriteLine(dp[bagWeight]);
    }
}