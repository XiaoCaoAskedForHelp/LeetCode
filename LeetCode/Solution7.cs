namespace LeetCode;

//1326. 灌溉花园的最少水龙头数目
public class Solution7
{
    public int MinTaps(int n, int[] ranges)
    {
        // 动态规划
        // int[][] intervals = new int[n + 1][];
        // for (int i = 0; i <= n; i++)
        // {
        //     int start = Math.Max(0, i - ranges[i]);
        //     int end = Math.Min(n, i + ranges[i]);
        //     intervals[i] = new[] { start, end };
        // }
        //
        // Array.Sort(intervals, (a, b) => a[0] - b[0]);
        // int[] dp = new int[n + 1];
        // Array.Fill(dp, Int32.MaxValue);
        // dp[0] = 0;
        // foreach (int[] interval in intervals)
        // {
        //     int start = interval[0], end = interval[1];
        //     if (dp[start] == int.MaxValue)
        //     {
        //         return -1;
        //     }
        //
        //     for (int j = start; j <= end; j++)
        //     {
        //         dp[j] = Math.Min(dp[j], dp[start] + 1);
        //     }
        // }
        //
        // return dp[n];

        //贪心
        int[] rightMost = new int[n+1];
        for (int i = 0; i <= n; i++)
        {
            rightMost[i] = i;
        }
        // rightMost[i]指的是第i个位置能到达的最远的右端点
        for (int i = 0; i <= n; i++)
        {
            int start = Math.Max(0, i - ranges[i]);
            int end = Math.Min(n, i + ranges[i]);
            rightMost[start] = Math.Max(rightMost[start], end);
        }

        // 需要的最少数量
        int result = 0;
        // current当前覆盖的最远距离下标
        // next当前区间所能到达的下一次跳跃的最远距离下标
        int current = 0, next = 0;
        for (int i = 0; i < n; i++)
        {
            next = Math.Max(rightMost[i], next);
            if (i == current)
            {
                if (i == next)
                {
                    return -1;
                }
                result++;
                current = next;
            }
        }

        return result;
    }
}