namespace LeetCode;

/// <summary>
/// 1040. 移动石子直到连续 II
/// </summary>
public class Solution28移动石子
{
    public int[] NumMovesStonesII(int[] stones)
    {
        // 最大操作数就是两端点不断向内移动，比如最左端点移动临近位置后一个空位中，不断向内移动，右端点也是这样，然后比较两者就能结论
        // 最小操作数就是你已经确定的需要长度为n的连续序列，所以你滑动窗口找到能包含最多离散点的一段，假设包含k个，然后其他n-k个空位就将其他石子移入这一段就行。
        int n = stones.Length;
        Array.Sort(stones);
        if (stones[n - 1] - stones[0] + 1 == n)
        {
            return new int[] { 0, 0 };
        }

        int max = Math.Max(stones[n - 2] - stones[0] + 1, stones[n - 1] - stones[1] + 1) - (n - 1);
        int min = n;
        for (int i = 0, j = 0; i < n && j + 1 < n; i++)
        {
            while (j + 1 < n && stones[j + 1] - stones[i] + 1 <= n)
            {
                j++;
            }

            if (j - i + 1 == n - 1 && stones[j] - stones[i] + 1 == n - 1)
            {
                min = Math.Min(min, 2);
            }
            else
            {
                min = Math.Min(min, n - (j - i + 1));
            }
        }

        return new int[] { min, max };
    }
}