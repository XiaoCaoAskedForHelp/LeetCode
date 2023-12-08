using System.Dynamic;

namespace LeetCode.贪心;

public class Solution134加油站
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        if (gas.Sum() < cost.Sum())
        {
            return -1;
        }

        int len = gas.Length;
        int[] sum = new int[len];
        sum[0] = gas[0] - cost[0];
        int min = sum[0];
        int index = 0;
        for (int i = 1; i < len; i++)
        {
            sum[i] = sum[i - 1] + gas[i] - cost[i];
            if (sum[i] < min && sum[i] < 0)
            {
                min = sum[i];
                index = i;
            }
        }

        if (min >= 0)
        {
            return 0;
        }

        return index + 1;
    }

    // 暴力模拟，从每一个点出发跑一遍，会超时
    public int CanCompleteCircuit1(int[] gas, int[] cost)
    {
        for (int i = 0; i < cost.Length; i++) {
            int rest = gas[i] - cost[i]; // 记录剩余油量
            int index = (i + 1) % cost.Length;
            while (rest > 0 && index != i) { // 模拟以i为起点行驶一圈（如果有rest==0，那么答案就不唯一了）
                rest += gas[index] - cost[index];
                index = (index + 1) % cost.Length;
            }
            // 如果以i为起点跑一圈，剩余油量>=0，返回该起始位置
            if (rest >= 0 && index == i) return i;
        }
        return -1;
    }

    // 情况一：如果gas的总和小于cost总和，那么无论从哪里出发，一定是跑不了一圈的
    //
    // 情况二：rest[i] = gas[i]-cost[i]为一天剩下的油，i从0开始计算累加到最后一站，如果累加没有出现负数，说明从0出发，油就没有断过，那么0就是起点。
    //
    // 情况三：如果累加的最小值是负数，汽车就要从非0节点出发，从后向前，看哪个节点能把这个负数填平，能把这个负数填平的节点就是出发节点
    public int CanCompleteCircuit2(int[] gas, int[] cost)
    {
        int curSum = 0;
        int min = Int32.MaxValue;
        for (int i = 0; i < gas.Length; i++)
        {
            int rest = gas[i] - cost[i];
            curSum += rest;
            if (curSum < min)
            {
                min = curSum;
            }
        }

        if (curSum < 0) return -1; //情况1
        if (min >= 0) return 0;  // 情况2
        // 情况3  ,其实我感觉不需要这样，因为如果去除了情况1和2，那么说明肯定能绕一圈
        // 那么能补齐最小值的肯定是最小累加值的后面那个，
        // 可能你会想后面那个数字如果是负的怎么办，这中情况不存在，因为如果为负就会包含在最小值里面
        for (int i = gas.Length - 1; i >= 0; i--)
        {
            int rest = gas[i] - cost[i];
            min += rest;
            if (min >= 0)
            {
                return i;
            }
        }

        return -1;
    }
    
    // 局部最优：当前累加rest[i]的和curSum一旦小于0，起始位置至少要是i+1，因为从i之前开始一定不行。全局最优：找到可以跑一圈的起始位置。
    public int CanCompleteCircuit3(int[] gas, int[] cost)
    {
        int curSum = 0;
        int totalSum = 0;
        int start = 0;
        for (int i = 0; i < gas.Length; i++)
        {
            curSum += gas[i] - cost[i];
            totalSum += gas[i] - cost[i];
            if (curSum < 0)
            {
                start = i + 1;
                curSum = 0;
            }
        }
        if (totalSum < 0) return -1;
        return start;
    }
}