using System.Collections;
using System.Drawing;

namespace LeetCode.栈;

public class 单调栈_Solution84柱状图中最大的矩形
{
    // 暴力解法，列举每一种情况进行比较
    public int LargestRectangleArea(int[] heights)
    {
        int sum = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            int left = i;
            int right = i;
            for (; left >= 0; left--)
            {
                if (heights[left] < heights[i]) break;
            }

            for (; right < heights.Length; right++)
            {
                if (heights[right] < heights[i]) break;
            }

            int w = right - left - 1;
            int h = heights[i];
            sum = Math.Max(sum, w * h);
        }

        return sum;
    }

    // 双指针解法
    // 使用数组记录每个柱子 左边第一个小于该柱子的下标，而不是左边第一个小于该柱子的高度
    public int LargestRectangleArea1(int[] heights)
    {
        var len = heights.Length;
        // 记录每个柱子 左边第一个小于该柱子的下标
        int[] left = new int[len];
        // 记录每个柱子 右边第一个小于该柱子的下标
        int[] right = new int[len];
        left[0] = -1;
        for (int i = 1; i < len; i++)
        {
            int t = i - 1;
            while (t >= 0 && heights[t] >= heights[i])
            {
                // t--;
                // t下标的高度大于此时i下标的高度，而left[t]记录的是大于此时t下标高度的最左边坐标。可以直接跳。
                t = left[t];
            }

            left[i] = t;
        }

        right[len - 1] = len;
        for (int i = len - 2; i >= 0; i--)
        {
            int t = i + 1;
            while (t < len && heights[t] >= heights[i])
            {
                // t++;
                t = right[t];
            }

            right[i] = t;
        }


        int result = 0;
        // 求和
        for (int i = 0; i < len; i++)
        {
            int sum = heights[i] * (right[i] - left[i] - 1);
            result = Math.Max(sum, result);
        }

        return result;
    }

    // 单调栈
    // 找每个柱子左右两边第一个小于该柱子的柱子，所以从栈头（元素从栈头弹出）到栈底的顺序应该是从大到小的顺序
    public int LargestRectangleArea2(int[] heights)
    {
        int[] newHeights = new int[heights.Length + 2];
        Array.Copy(heights, 0, newHeights, 1, heights.Length);
        newHeights[newHeights.Length - 1] = 0; // 结尾加一个0，就会让栈里的所有元素，走到情况三的逻辑(计算结果的那一步)。
        newHeights[0] = 0; //避免最后left空栈取值，直接跳过了计算结果的逻辑。

        int result = 0;
        Stack<int> stack = new Stack<int>();

        stack.Push(0);
        for (int i = 1; i < newHeights.Length; i++)
        {
            if (newHeights[i] > newHeights[stack.Peek()])
            {
                stack.Push(i);
            }
            else if (newHeights[i] == newHeights[stack.Peek()])
            {
                stack.Pop();
                stack.Push(i);
            }
            else
            {
                while (stack.Any() && newHeights[i] < newHeights[stack.Peek()])
                {
                    int mid = stack.Pop();
                    if (stack.Any())
                    {
                        int left = stack.Peek();
                        int right = i;
                        int w = right - left - 1;
                        int h = newHeights[mid];
                        result = Math.Max(result, w * h);
                    }
                }

                stack.Push(i);
            }
        }

        return result;
    }

    // 单调栈
    public int LargestRectangleArea3(int[] heights)
    {
        int[] newHeights = new int[heights.Length + 2];
        Array.Copy(heights, 0, newHeights, 1, heights.Length);
        newHeights[newHeights.Length - 1] = 0; // 结尾加一个0，就会让栈里的所有元素，走到情况三的逻辑(计算结果的那一步)。
        newHeights[0] = 0; //避免最后left空栈取值，直接跳过了计算结果的逻辑。

        int result = 0;
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < newHeights.Length; i++)
        {
            while (stack.Any() && newHeights[i] < newHeights[stack.Peek()])
            {
                int mid = stack.Pop();
                int w = i - stack.Peek() - 1;
                int h = newHeights[mid];
                result = Math.Max(w * h, result);
            }
            stack.Push(i);
        }

        return result;
    }
}