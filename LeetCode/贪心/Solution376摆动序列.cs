namespace LeetCode.贪心;

public class Solution376摆动序列
{
    // 情况一：上下坡中有平坡 
    // 情况二：数组首尾两端
    // 情况三：单调坡中有平坡
    public int WiggleMaxLength(int[] nums)
    {
        if (nums.Length <= 1) return nums.Length;
        int curDiff = 0; // 当前一对差值
        int preDiff = 0; // 前一对差值
        int result = 1; // 记录峰值个数，序列默认序列最右边有一个峰值
        for (int i = 0; i < nums.Length - 1; i++)
        {
            curDiff = nums[i + 1] - nums[i];
            // 出现峰值
            if ((preDiff <= 0 && curDiff > 0) || (preDiff >= 0 && curDiff < 0))
            {
                result++;
                // 只需要在这个坡度摆动变化的时候，更新 prediff 就行，这样 prediff 在 单调区间有平坡的时候 就不会发生变化，造成我们的误判
                preDiff = curDiff;
            }
        }

        return result;
    }

    public int WiggleMaxLength1(int[] nums)
    {
        // 0 i 作为波峰的最大长度
        // 1 i 作为波谷的最大长度
        // dp[i][0] = max(dp[i][0], dp[j][1] + 1)，其中0 < j < i且nums[j] < nums[i]，表示将 nums[i]接到前面某个山谷后面，作为山峰。
        // dp[i][1] = max(dp[i][1], dp[j][0] + 1)，其中0 < j < i且nums[j] > nums[i]，表示将 nums[i]接到前面某个山峰后面，作为山谷。
        int[,] dp = new int[1005,2];
        dp[0, 0] = dp[0, 1] = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            //由于一个数可以接到前面的某个数后面，也可以以自身为子序列的起点，所以初始状态为：dp[0][0] = dp[0][1] = 1。
            dp[i, 0] = dp[i, 1] = 1;
            for (int j = 0; j < i; j++)
            {
                if (nums[j] > nums[i])
                {
                    // i 是波谷，所以需要找前面是波峰的接上去
                    dp[i, 1] = Math.Max(dp[i, 1], dp[j, 0] + 1);
                }
            }
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {
                    // i 是波峰,所以需要找前面可以是波谷的接上去
                    dp[i, 0] = Math.Max(dp[i, 0], dp[j, 1] + 1);
                }
            }
        }
        return Math.Max(dp[nums.Length - 1, 0], dp[nums.Length - 1, 1]);
    }
}