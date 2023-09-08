namespace LeetCode.动态规划;

public class Solution0_1背包
{
    /// <summary>
    /// 二位数组解决0-1背包问题
    /// </summary>
    /// <param name="weight">物品的重量</param>
    /// <param name="value">物品的质量</param>
    /// <param name="bagSize">背包的重量</param>
    /// <returns></returns>
    public void Package0_1(int[] weight, int[] value, int bagSize)
    {
        // 获取物品的数量
        int goods = weight.Length;
        // 创建dp数组
        int[,] dp = new int[goods, bagSize + 1];

        // 初始化,当只有第一个物品0时，只要背包重量大于物品0，那么此时价值就是物品0的价值
        for (int j = weight[0]; j <= bagSize; j++)
        {
            dp[0, j] = value[0];
        }

        // 填充dp数组,当有i个商品时，通过此时背包的重量计算最大价值
        for (int i = 1; i < goods; i++)
        {
            for (int j = 1; j <= bagSize; j++)
            {
                if (j < weight[i])
                {
                    // 当前背包的容量都没有当前物品i大的时候，是不放物品i的
                    // 那么前i-1个物品能放下的最大价值就是当前情况的最大价值
                    dp[i, j] = dp[i - 1, j];
                }
                else
                {
                    // 当前背包的容量可以放下物品i
                    // 那么此时分两种情况：
                    //    1、不放物品i
                    //    2、放物品i
                    // 比较这两种情况下，哪种背包中物品的最大价值最大
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - weight[i]] + value[i]);
                }
            }
        }

        for (int i = 0; i < goods; i++)
        {
            for (int j = 0; j <= bagSize; j++)
            {
                Console.Write(dp[i, j] + "\t");
            }

            Console.Write("\n");
        }
    }

    public void Package0_12(int[] weight, int[] value, int bagSize)
    {
        // 初始化 dp 数组做了简化(给物品增加冗余维)。这样初始化dp数组，默认全为0即可。
        // dp[i][j] 表示从下标为[0 - i-1]的物品里任意取，放进容量为j的背包，价值总和最大是多少。
        // 其实是模仿背包重量从 0 开始，背包容量 j 为 0 的话，即dp[i][0]，无论是选取哪些物品，背包价值总和一定为 0。
        // 可选物品也可以从无开始，也就是没有物品可选，即dp[0][j]，这样无论背包容量为多少，背包价值总和一定为 0。

        // 创建dp数组
        int goods = weight.Length; // 获取物品的数量
        int[,] dp = new int[goods + 1, bagSize + 1]; // 给物品增加冗余维，i = 0 表示没有物品可选

        //填充dp数组
        for (int i = 1; i <= goods; i++)
        {
            for (int j = 1; j <= bagSize; j++)
            {
                if (j < weight[i - 1])
                {
                    // i - 1 对应物品 i
                    // 当前背包的容量都没有当前物品i大的时候，是不放物品i的
                    // 那么前i-1个物品能放下的最大价值就是当前情况的最大价值
                    dp[i, j] = dp[i - 1, j];
                }
                else
                {
                    // 当前背包的容量可以放下物品i 
                    //那么此时分两种情况：
                    //   1、不放物品i
                    //   2、放物品i
                    //比较这两种情况下，哪种背包中物品的最大价值最大
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - weight[i - 1]] + value[i - 1]); // i - 1 对应物品 i
                }
            }
        }

        for (int i = 0; i < goods; i++)
        {
            for (int j = 0; j <= bagSize; j++)
            {
                Console.Write(dp[i, j] + "\t");
            }

            Console.Write("\n");
        }
    }
}