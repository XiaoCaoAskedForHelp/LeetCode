namespace LeetCode.贪心;

public class Solution45跳跃游戏II
{
    // 贪心 每一步都选能跨越的最大的步幅
    public int Jump(int[] nums)
    {
        if (nums.Length == 1)
        {
            return 0;
        }

        int reach = 0;
        int res = 0;
        for (int i = 0; i <= reach; i++)
        {
            int max = i;
            for (int j = i; j <= reach; j++)
            {
                max = Math.Max(max, j + nums[j]);
            }

            res++;
            if (max >= nums.Length - 1)
            {
                return res;
            }
            
            reach = max;
        }

        return res;
    }

    public int Jump1(int[] nums)
    {
        if (nums.Length == 1)
        {
            return 0;
        }

        int curDistance = 0;  // 当前覆盖最远距离下标
        int ans = 0;          // 记录走的最大步数
        int nextDistance = 0; // 下一步覆盖最远距离下标
        for (int i = 0; i < nums.Length; i++)
        {
            nextDistance = Math.Max(nums[i] + i, nextDistance);  // 更新下一步覆盖最远距离下标
            if (i == curDistance)    // 遇到当前覆盖最远距离下标
            {
                ans++;               // 需要走下一步
                curDistance = nextDistance;       // 更新当前覆盖最远距离下标
                if (nextDistance >= nums.Length - 1) break;    // 当前覆盖最远距到达集合终点，不用做ans++操作了，直接结束
            }
        }

        return ans;
    }



    //针对于方法一的特殊情况，可以统一处理，即：移动下标只要遇到当前覆盖最远距离的下标，直接步数加一，不考虑是不是终点的情况。
    public int Jump2(int[] nums)
    {
        int curDistance = 0;    // 当前覆盖的最远距离下标
        int ans = 0;            // 记录走的最大步数
        int nextDistance = 0;   // 下一步覆盖的最远距离下标
        for (int i = 0; i < nums.Length - 1; i++)   // 注意这里是小于nums.size() - 1，这是关键
        {
            nextDistance = Math.Max(nums[i] + i, nextDistance); // 更新下一步覆盖的最远距离下标
            if (i == curDistance) {                 // 遇到当前覆盖的最远距离下标
                curDistance = nextDistance;         // 更新当前覆盖的最远距离下标
                ans++;
            }
        }

        return ans;
    }
}