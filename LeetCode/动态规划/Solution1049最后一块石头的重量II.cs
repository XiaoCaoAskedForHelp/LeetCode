namespace LeetCode.动态规划;

public class Solution1049最后一块石头的重量II
{
    // 本质就是要找到质量最相近的两堆
    public int LastStoneWeightII(int[] stones)
    {
        if (stones.Length == 1)
        {
            return stones[0];
        }

        int sum = stones.Sum();
        int half = sum / 2;
        int[] dp = new int[half + 1];
        for (int i = 0; i < stones.Length; i++)
        {
            for (int j = half; j >= stones[i]; j--)
            {
                if (dp[j - stones[i]] + stones[i] > half)
                {
                    continue;
                }

                dp[j] = Math.Max(dp[j], dp[j - stones[i]] + stones[i]);
            }
        }

        for (int i = half; i >= 0; i--)
        {
            if (dp[i] != 0)
            {
                return sum - dp[i] * 2;
            }
        }

        return -1;
    }


    public int LastStoneWeightII1(int[] stones)
    {
        int sum = stones.Sum();
        int target = sum >> 1;
        //初始化dp数组
        int[] dp = new int[target + 1];
        for (int i = 0; i < stones.Length; i++)
        {
            //采用倒序
            for (int j = target; j >= stones[i]; j--)
            {
                //两种情况，要么放，要么不放,这种情况其实就保证了容量为j的背包不会背价值大于容量的石头
                dp[j] = Math.Max(dp[j], dp[j - stones[i]] + stones[i]);
            }
        }

        return sum - 2 * dp[target];
    }


    // 二维数组的版本
    public int LastStoneWeightII2(int[] stones)
    {
        int sum = stones.Sum();

        int target = sum / 2;
        //初始化，dp[i][j]为可以放0-i物品，背包容量为j的情况下背包中的最大价值
        int[,] dp = new int[stones.Length, target + 1];
        //dp[i][0]默认初始化为0
        //dp[0][j]取决于stones[0]
        for (int j = stones[0]; j <= target; j++)
        {
            dp[0, j] = stones[0];
        }

        for (int i = 1; i < stones.Length; i++)
        {
            for (int j = 1; j <= target; j++)
            {
                //注意是等于
                if (j >= stones[i])
                {
                    //不放:dp[i - 1][j] 放:dp[i - 1][j - stones[i]] + stones[i]
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - stones[i]] + stones[i]);
                }
                else
                {
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }

        return (sum - dp[stones.Length - 1, target]) - dp[stones.Length - 1, target];
    }
}