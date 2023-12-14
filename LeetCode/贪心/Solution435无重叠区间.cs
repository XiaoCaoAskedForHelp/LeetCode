using System.Drawing.Printing;

namespace LeetCode.贪心;

public class Solution435无重叠区间
{
    // 需要移除的区间个数（使的变为无重叠区间） = 总区间个数 - 重叠区间个数（就是最小的可以不重叠的区间）
    public int EraseOverlapIntervals(int[][] intervals)
    {
        intervals = intervals.OrderBy(s => s[0]).ThenBy(s=>s[1]).ToArray();
        int res = 1;
        int[] interval = intervals[0];
        for (int i = 1; i < intervals.Length; i++)
        {
            if (interval[1] > intervals[i][0])
            {
                interval[0] = intervals[i][0];
                interval[1] = Math.Min(interval[1], intervals[i][1]);
            }
            else
            {
                interval = intervals[i];
                res++;
            }
        }

        return intervals.Length - res;
    }

    public int EraseOverlapIntervals1(int[][] intervals)
    {
        if (intervals.Length == 0) return 0;
        intervals = intervals.OrderBy(s => s[0]).ToArray();
        int count = 0;
        int end = intervals[0][1];  // 记录区间分割点
        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] >= end) end = intervals[i][1]; // 无重叠情况
            else  // 重叠情况
            {
                end = Math.Min(end, intervals[i][1]);
                count++;    // 这是统计直接统计要移除的区间个数
            }
        }

        return count;
    }
    
    
    //  用 intervals[i][1] 替代 end变量，只判断 重叠情况就好
    public int EraseOverlapIntervals2(int[][] intervals)
    {
        if (intervals.Length == 0) return 0;
        intervals = intervals.OrderBy(s => s[0]).ToArray();
        int count = 0;
        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] < intervals[i - 1][1])
            {
                intervals[i][1] = Math.Min(intervals[i - 1][1], intervals[i][1]);
                count++;
            }
        }

        return count;
    }
}