using System.Drawing.Printing;

namespace LeetCode.动态规划;

// 滚动数组
public class Solution0_1背包2
{
    // 在使用二维数组的时候，递推公式：dp[i][j] = max(dp[i - 1][j], dp[i - 1][j - weight[i]] + value[i]);
    // 其实可以发现如果把dp[i - 1]那一层拷贝到dp[i]上，表达式完全可以是：dp[i][j] = max(dp[i][j], dp[i][j - weight[i]] + value[i]);
    // 与其把dp[i - 1]这一层拷贝到dp[i]上，不如只用一个一维数组了，只用dp[j]（一维数组，也可以理解是一个滚动数组）。
    
    // 在一维dp数组中，dp[j]表示：容量为j的背包，所背的物品价值可以最大为dp[j]。
    public void testWeightBagProblem(int[] weight, int[] value, int bagWeight)
    {
        int len = weight.Length;
        int[] dp = new int[bagWeight + 1];
        // 遍历顺序，先遍历物品，在遍历背包容量
        for (int i = 0; i < len; i++)
        {
            for (int j = bagWeight; j >= weight[i]; j--)
            {
                //一维dp遍历的时候，背包是从大到小,倒序遍历是为了保证物品i只被放入一次,防止被覆盖
                dp[j] = Math.Max(dp[j], dp[j - weight[i]] + value[i]);
            }
        }

        for (int j = 0; j <= bagWeight; j++)
        {
            Console.Write(dp[j] + " ");
        }
    }
}