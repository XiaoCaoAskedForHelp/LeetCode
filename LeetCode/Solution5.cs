using System.Collections;

namespace LeetCode;

public class Solution5
{
    public double MaxAverageRatio(int[][] classes, int extraStudents)
    {
        // 优先队列
        double getPriority(int[] c) => -((double)(c[0] + 1) / (double)(c[1] + 1) - (double)c[0] / (double)c[1]);

        var queue = new PriorityQueue<int[], double>();
        foreach (var item in classes)
        {
            queue.Enqueue(item,getPriority(item));
        }

        while (extraStudents-- > 0)
        {
            queue.TryDequeue(out var item, out double priority);
            item[0]++;
            item[1]++;
            queue.Enqueue(item,getPriority(item));
        }

        return classes.Select(s => (double)s[0] / (double)s[1]).Sum() / (double)classes.Length;
    }
}