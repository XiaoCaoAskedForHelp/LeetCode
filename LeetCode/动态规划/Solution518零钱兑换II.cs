namespace LeetCode.动态规划;

public class Solution518零钱兑换II
{
    //本题是求凑出来的方案个数，且每个方案个数是为组合数。元素之间明确要求没有顺序
    // 所以只能先遍历物品再遍历容量，这样先把1加入计算，然后再把5加入计算，得到的方法数量只有{1, 5}这种情况。而不会出现{5, 1}的情况。
    // 如果内外层遍历反过来，背包容量的每一个值，都是经过 1 和 5 的计算，包含了{1, 5} 和 {5, 1}两种情况。此时dp[j]里算出来的就是排列数！
    public int Change(int amount, int[] coins)
    {
        int[] dp = new int[amount + 1];
        dp[0] = 1;
        for (int i = 0; i < coins.Length; i++)
        {
            for (int j = coins[i]; j <= amount; j++)
            {
                dp[j] += dp[j - coins[i]];
            }
        }

        return dp[amount];
    }


    // 二维dp数组
    public int Change1(int amount, int[] coins)
    {
        int[,] dp = new int[coins.Length, amount + 1];
        // 只有一种硬币的情况
        for (int i = 0; i <= amount; i += coins[0])
        {
            dp[0, i] = 1;
        }

        for (int i = 1; i < coins.Length; i++)
        {
            // 不能这么写了，因为可以取多次，但是这样写只能取一次
            // for (int j = coins[i]; j <= amount; j++)
            // {
            //     dp[i, j] += dp[i - 1, j - coins[i]];
            // }
            for (int j = 0; j <= amount; j++)
            {
                // 第i种硬币使用0~k次，求和
                for (int k = 0; k * coins[i] <= j; k++)
                {
                    dp[i, j] += dp[i - 1, j - k * coins[i]];
                }
            }
        }

        return dp[coins.Length - 1, amount];
    }
}