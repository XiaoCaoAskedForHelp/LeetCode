namespace LeetCode.动态规划;

// 有N件物品和一个最多能背重量为W的背包。第i件物品的重量是weight[i]，得到的价值是value[i] 。每件物品都有无限个（也就是可以放入背包多次），求解将哪些物品装入背包里物品价值总和最大。
//
// 完全背包和01背包问题唯一不同的地方就是，每种物品有无限件。

// 01背包内嵌的循环是从大到小遍历，为了保证每个物品仅被添加一次。
// 全背包的物品是可以添加多次的，所以要从小到大去遍历

// 01背包中二维dp数组的两个for遍历的先后循序是可以颠倒了，一维dp数组的两个for循环先后循序一定是先遍历物品，再遍历背包容量
// 在完全背包中，对于一维dp数组来说，其实两个for循环嵌套顺序是无所谓的！
// 因为dp[j] 是根据 下标j之前所对应的dp[j]计算出来的。 只要保证下标j之前的dp[j]都是经过计算的就可以了。

public class Solution完全背包理论基础
{
    public void testCompletePack()
    {
        int[] weight = { 1, 3, 4 };
        int[] value = { 15, 20, 30 };
        int bagWeight = 4;
        int[] dp = new int[bagWeight + 1];
        for (int i = 0; i < weight.Length; i++) // 遍历物品
        {
            for (int j = weight[i]; j <= bagWeight; j++) // 遍历背包容量
            {
                dp[j] = Math.Max(dp[j], dp[j - weight[i]] + value[i]);
            }
        }

        foreach (var maxValue in dp)
        {
            Console.WriteLine(maxValue + " ");
        }
    }
    
    // 先遍历背包在遍历物品
    public void testCompletePack1()
    {
        int[] weight = { 1, 3, 4 };
        int[] value = { 15, 20, 30 };
        int bagWeight = 4;
        int[] dp = new int[bagWeight + 1];
        for (int i = 1; i <= bagWeight; i++)
        {
            for (int j = 0; j < weight.Length; j++)
            {
                if (i-weight[j] >= 0)
                {
                    dp[i] = Math.Max(dp[i], dp[i - weight[j]] + value[j]);
                }
            }
        }
        foreach (var maxValue in dp)
        {
            Console.WriteLine(maxValue + " ");
        }
    }
}