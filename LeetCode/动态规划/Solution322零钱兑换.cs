namespace LeetCode.动态规划;

public class Solution322零钱兑换
{
    public int CoinChange(int[] coins, int amount)
    {
        if (amount == 0)
        {
            return 0;
        }

        int[] dp = new int[amount + 1];
        int MAX = (int)Math.Pow(10, 4) + 1;
        for (int i = 1; i <= amount; i++)
        {
            dp[i] = MAX;
        }
        // int[] dp = Enumerable.Repeat(MAX, amount + 1).ToArray();

        for (int j = 1; j <= amount; j++)
        {
            for (int i = 0; i < coins.Length; i++)
            {
                if (j >= coins[i])
                {
                    dp[j] = Math.Min(dp[j], dp[j - coins[i]] + 1);
                }
            }
        }

        return dp[amount] == MAX ? -1 : dp[amount];
    }

    public int CoinChange1(int[] coins, int amount)
    {
        int[] dp = Enumerable.Repeat(Int32.MaxValue, amount + 1).ToArray();
        dp[0] = 0;
        for (int i = 0; i < coins.Length; i++) { // 遍历物品
            for (int j = coins[i]; j <= amount; j++) { // 遍历背包
                if (dp[j - coins[i]] != Int32.MaxValue) { // 如果dp[j - coins[i]]是初始值则跳过
                    dp[j] = Math.Min(dp[j - coins[i]] + 1, dp[j]);
                }
            }
        }
        if (dp[amount] == Int32.MaxValue) return -1;
        return dp[amount];
    }

    public int CoinChange2(int[] coins, int amount)
    {
        int[] dp = Enumerable.Repeat(Int32.MaxValue, amount + 1).ToArray();
        dp[0] = 0;
        for (int i = 1; i <= amount; i++) {  // 遍历背包
            for (int j = 0; j < coins.Length; j++) { // 遍历物品
                if (i - coins[j] >= 0 && dp[i - coins[j]] != Int32.MaxValue ) {
                    dp[i] = Math.Min(dp[i - coins[j]] + 1, dp[i]);
                }
            }
        }
        if (dp[amount] == Int32.MaxValue) return -1;
        return dp[amount];
    }
}