namespace LeetCode.动态规划;

// 1.确定dp数组（dp table）以及下标的含义
// dp[i][j]：最多有i个0和j个1的strs的最大子集的大小为dp[i][j]。
//
// 2.确定递推公式
// dp[i][j] 可以由前一个strs里的字符串推导出来，strs里的字符串有zeroNum个0，oneNum个1。
// dp[i][j] 就可以是 dp[i - zeroNum][j - oneNum] + 1。
// 然后我们在遍历的过程中，取dp[i][j]的最大值。
// 所以递推公式：dp[i][j] = max(dp[i][j], dp[i - zeroNum][j - oneNum] + 1);
// 此时大家可以回想一下01背包的递推公式：dp[j] = max(dp[j], dp[j - weight[i]] + value[i]);
// 对比一下就会发现，字符串的zeroNum和oneNum相当于物品的重量（weight[i]），字符串本身的个数相当于物品的价值（value[i]）。
// 这就是一个典型的01背包！ 只不过物品的重量有了两个维度而已。
public class Solution474一和零
{
    public int FindMaxForm(string[] strs, int m, int n)
    {
        
        int[,] dp = new int[m + 1, n + 1];// dp[,]表示当有i个0和j个Q有多少个数字
        for (int i = 0; i < strs.Length; i++)
        {
            int zero_num = 0, one_num = 0;
            for (int j = 0; j < strs[i].Length; j++)
            {
                if (strs[i][j] == '0')
                {
                    zero_num++;
                }
                else
                {
                    one_num++;
                }
            }

            for (int j = m; j >= zero_num; j--)
            {
                for (int k = n; k >= one_num; k--)
                {
                    dp[j, k] = Math.Max(dp[j, k], dp[j - zero_num, k - one_num] + 1);
                }
            }
        }

        return dp[m, n];
    }
}