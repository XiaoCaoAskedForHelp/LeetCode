namespace LeetCode.周赛;

public class Solution100153需要添加的硬币的最小数量
{
    
    // 对coins数组进行排序。
    // 初始化一个变量current为1，表示当前需要构造的最小整数。
    // 遍历排序后的coins数组，并且维护一个变量sum来记录通过已有硬币能表示出的最大整数。
    // 如果当前硬币的值coins[i]小于或等于current，则将其加入到sum中，表示现在可以构造出更大的整数了。
    // 如果coins[i]大于current，这意味着我们无法通过已有的硬币构造出current。因此，我们需要添加一个面值为current的硬币，然后current更新为sum + 1。
    // 重复步骤4和5，直到current大于target。
    public int MinimumAddedCoins(int[] coins, int target)
    {
        Array.Sort(coins);
        // 初始化一个变量current为1，表示当前需要构造的最小整数。
        int current = 1, addedCoins = 0, i = 0;
        // 遍历排序后的coins数组，并且维护一个变量sum来记录通过已有硬币能表示出的最大整数。
        long sum = 0;

        while (current <= target)
        {
            if (i < coins.Length && coins[i] <= current)
            {
                sum += coins[i++];
            }
            else
            {
                addedCoins++;
                sum += current;
            }

            current = (int)sum + 1;
        }

        return addedCoins;
    }
}