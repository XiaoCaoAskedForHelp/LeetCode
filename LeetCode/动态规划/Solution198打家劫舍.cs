namespace LeetCode.动态规划;

public class Solution198打家劫舍
{
    // dp表示考虑下标i（包括i）以内的房屋，最多可以偷窃的金额为dp[i]。
    public int Rob(int[] nums)
    {
        int n = nums.Length;
        int[] dp = (int[])nums.Clone();

        for (int i = 0; i < n; i++)
        {
            int max = dp[i];
            for (int j = 0; j <= i - 2; j++)
            {
                max = Math.Max(max, dp[i] + dp[j]);
            }

            dp[i] = max;
        }

        return dp.Max();
    }

    // dp[i]：考虑下标i（包括i）以内的房屋，最多可以偷窃的金额为dp[i]。
    // 决定dp[i]的因素就是第i房间偷还是不偷。
    // 如果偷第i房间，那么dp[i] = dp[i - 2] + nums[i] ，即：第i-1房一定是不考虑的，找出 下标i-2（包括i-2）以内的房屋，最多可以偷窃的金额为dp[i-2] 加上第i房间偷到的钱。
    // 如果不偷第i房间，那么dp[i] = dp[i - 1]，即考 虑i-1房，（注意这里是考虑，并不是一定要偷i-1房，这是很多同学容易混淆的点）
    // 然后dp[i]取最大值，即dp[i] = max(dp[i - 2] + nums[i], dp[i - 1]);
    public int Rob1(int[] nums)
    {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        int[] dp = new int[nums.Length];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);
        for (int i = 2; i < nums.Length; i++)
        {
            // 偷或者不偷
            dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
        }

        return dp[nums.Length - 1];
    }

    public int Rob2(int[] nums)
    {
        int len = nums.Length;

        if (len == 0) return 0;
        else if (len == 1) return nums[0];
        else if (len == 2) return Math.Max(nums[0], nums[1]);


        int[] result = new int[3]; //存放选择的结果
        result[0] = nums[0];
        result[1] = Math.Max(nums[0], nums[1]);


        for (int i = 2; i < len; i++)
        {
            result[2] = Math.Max(result[1], result[0] + nums[i]);
            result[0] = result[1];
            result[1] = result[2];
        }

        return result[2];
    }

    // 进一步对滚动数组的空间优化 dp数组只存与计算相关的两次数据
    public int Rob3(int[] nums)
    {
        if (nums.Length == 1)  {
            return nums[0];
        }
        // 初始化dp数组
        // 优化空间 dp数组只用2格空间 只记录与当前计算相关的前两个结果
        int[] dp = new int[2];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0],nums[1]);
        int res = 0;
        // 遍历
        for (int i = 2; i < nums.Length; i++) {
            res = Math.Max((dp[0] + nums[i]) , dp[1] );
            dp[0] = dp[1];
            dp[1] = res;
        }
        // 输出结果
        return dp[1];
    }

}