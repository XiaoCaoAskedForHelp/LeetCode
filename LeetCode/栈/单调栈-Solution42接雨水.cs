namespace LeetCode.栈;

public class 单调栈_Solution42接雨水
{
    // 双指针，   按列计算体积，将每一列的体积相加
    // 记录左边柱子的最高高度 和 右边柱子的最高高度，就可以计算当前位置的雨水面积
    // 把每一个位置的左边最高高度记录在一个数组上（maxLeft），右边最高高度记录在一个数组上（maxRight）
    // 左边的最高高度是前一个位置的左边最高高度和本高度的最大值。
    public int Trap(int[] height)
    {
        if (height.Length <= 2) return 0;
        int[] maxLeft = new int[height.Length];
        int[] maxRight = new int[height.Length];

        int len = height.Length;
        maxLeft[0] = height[0];
        for (int i = 1; i < len; i++)
        {
            maxLeft[i] = Math.Max(height[i], maxLeft[i - 1]);
        }

        maxRight[len - 1] = height[len - 1];
        for (int i = len - 2; i >= 0; i--)
        {
            maxRight[i] = Math.Max(maxRight[i + 1], height[i]);
        }

        int sum = 0;
        for (int i = 0; i < len; i++)
        {
            int count = Math.Min(maxRight[i], maxLeft[i]) - height[i];
            if (count > 0) sum += count;
        }

        return sum;
    }

    // 单调栈 递增栈（从栈头到栈尾） 
    // 一旦发现添加的柱子高度大于栈头元素了，此时就出现凹槽了，
    // 栈头元素就是凹槽底部的柱子，栈头第二个元素就是凹槽左边的柱子，而添加的元素就是凹槽右边的柱子
    // 如果当前遍历的元素（柱子）高度等于栈顶元素的高度，要跟更新栈顶元素，因为遇到相相同高度的柱子，需要使用最右边的柱子来计算宽度。
    public int Trap1(int[] height)
    {
        Stack<int> stack = new Stack<int>();
        int sum = 0;
        for (int i = 0; i < height.Length; i++)
        {
            while (stack.Any() && height[i] > height[stack.Peek()])
            {
                int mid = stack.Pop();
                if (stack.Any())
                {
                    // 雨水高度是 min(凹槽左边高度, 凹槽右边高度) - 凹槽底部高度
                    int h = Math.Min(height[stack.Peek()], height[i]) - height[mid];
                    // 雨水的宽度是 凹槽右边的下标 - 凹槽左边的下标 - 1
                    int w = i - stack.Peek() - 1;
                    sum += h * w;
                }
            }

            // 其实这一句可以不加，效果是一样的，计算高度时是0
            // if (stack.Any() && height[i] == height[stack.Peek()])
            // {
            //     stack.Pop();
            //     stack.Push(i);
            // }

            stack.Push(i);
        }

        return sum;
    }
}