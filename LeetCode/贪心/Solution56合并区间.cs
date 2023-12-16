namespace LeetCode.贪心;

public class Solution56合并区间
{
    public int[][] Merge(int[][] intervals)
    {
        intervals = intervals.OrderBy(s => s[0]).ToArray();
        List<int[]> res = new List<int[]>();
        int start = intervals[0][0];
        int end = intervals[0][1];
        for (int i = 1; i < intervals.Length; i++)
        {
            if (end >= intervals[i][0])
            {
                end = Math.Max(end, intervals[i][1]);
            }
            else
            {
                res.Add(new[] { start, end });
                end = intervals[i][1];
                start = intervals[i][0];
            }
        }
        res.Add(new[] { start, end });

        return res.ToArray();
    }

}