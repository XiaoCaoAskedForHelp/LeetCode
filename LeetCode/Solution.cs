using System.IO.Pipes;

namespace LeetCode;

public class Solution
{
    // 表现良好的最长时间段
    // 输入：hours = [9,9,6,0,6,6,9]
    // 输出：3
    // 解释：最长的表现良好时间段是 [9,9,6]。
    public int LongestWPI(int[] hours)
    {
        int length = hours.Length;
        int count = 0;

        // 单调栈
        // Stack<int> stack = new Stack<int>();
        // stack.Push(0);
        //
        // // 前缀和,因为只有两种状态所以可以转换成1和-1
        // var sum = new int[length + 1];
        // for (var i = 0; i < length; i++)
        // {
        //     sum[i + 1] = sum[i] + (hours[i] > 8 ? 1 : -1);
        //     if (sum[i + 1] < sum[stack.Peek()]) stack.Push(i + 1);
        // }
        //
        // for (int i = length; i > 0; i--)
        // {
        //     while (stack.Any() && sum[i] > sum[stack.Peek()])
        //     {
        //         count = Math.Max(count, i - stack.Pop());
        //     }
        // }

        // 利用前缀和连续性
        // 前缀和>0,那么i=0就是最远的左端点
        // 前缀和<=0,那么最远的左端点就是 前缀和-1 第一次出现的下标
        // pos用来记录 前缀和-1 第一次出现的下标
        var pos = new int[length + 2];
        int sum = 0;
        for (int i = 1; i <= length; i++)
        {
            // 防止数组越界，所以将值翻转
            sum -= hours[i - 1] > 8 ? 1 : -1;
            if (sum < 0)
            {
                // 这种情况能取到肯定是最长的，所以不用做判断
                count = i;
            }
            else
            {
                if (pos[sum + 1] > 0) count = Math.Max(count, i - pos[sum + 1]);
                if (pos[sum] == 0) pos[sum] = i;
            }
        }

        return count;
    }
}