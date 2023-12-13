namespace LeetCode.贪心;

public class Solution452用最少数量的箭引爆气球
{
    // 按照坐标从大大小排序，每次得到两者相加的区间，如果后者并不能和前者相交，就说明需要多花一支箭
    public int FindMinArrowShots(int[][] points)
    {
        points = points.OrderBy(s => s[0]).ThenBy(s => s[1]).ToArray();
        int res = 1;
        int[] point = points[0];
        for (int i = 1; i < points.Length; i++)
        {
            if (points[i][0] <= point[1])
            {
                point[0] = points[i][0];
                point[1] = Math.Min(point[1], points[i][1]);
            }
            else
            {
                res++;
                point = points[i];
            }
        }

        return res;
    }

    public int FindMinArrowShots1(int[][] points)
    {
        // 根据气球直径的开始坐标从小到大排序
        // 使用下面的排序会出先数字相减超出int范围的问题
        // Array.Sort(points, (a, b) => a[0] - b[0]);
        points = points.OrderBy(s => s[0]).ToArray();
        int cnt = 1; // points 不为空至少需要一支箭
        for (int i = 1; i < points.Length; i++)
        {
            if (points[i][0] > points[i - 1][1]) // 气球i和气球i-1不挨着，注意这里不是>=
            {
                cnt++;
            }
            else
            {
                points[i][1] = Math.Min(points[i][1], points[i - 1][1]);
            }
        }

        return cnt;
    }
}