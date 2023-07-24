namespace LeetCode.栈;

public class Solution503下一个更大元素
{
    // 单调栈  通过两次循环遍历，第一次将能找到最大值的找到，第二次将栈中剩下的元素的最大值找到。
    public int[] NextGreaterElements(int[] nums)
    {
        int[] res = new int[nums.Length];
        Array.Fill(res, -1);
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            while (stack.Any() && nums[i] > nums[stack.Peek()])
            {
                res[stack.Peek()] = nums[i];
                stack.Pop();
            }

            stack.Push(i);
        }

        for (int i = 0; i < nums.Length && stack.Any(); i++)
        {
            while (stack.Any() && nums[i] > nums[stack.Peek()])
            {
                res[stack.Peek()] = nums[i];
                stack.Pop();
            }
        }

        return res;
    }

    // 直接模拟走两遍，将两个for循环写在一个里面减少代码量
    public int[] NextGreaterElements2(int[] nums)
    {
        int[] res = new int[nums.Length];
        Array.Fill(res, -1);
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < nums.Length * 2; i++)
        {
            while (stack.Any() && nums[i % nums.Length] > nums[stack.Peek()])
            {
                res[stack.Peek()] = nums[i % nums.Length];
                stack.Pop();
            }

            stack.Push(i % nums.Length);
        }

        return res;
    }

    // 将两个nums数组拼接在一起，使用单调栈计算出每一个元素的下一个最大值，最后再把结果集即result数组resize到原数组大小就可以了。
    // 做了很多无用操作，例如修改了nums数组，而且最后还要把result数组resize回去。
    public int[] NextGreaterElements1(int[] nums)
    {
        int[] temp = nums.Concat(nums).ToArray();
        int[] res = new int[temp.Length];
        Array.Fill(res, -1);
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < temp.Length; i++)
        {
            while (stack.Any() && temp[i] > temp[stack.Peek()])
            {
                res[stack.Peek()] = temp[i];
                stack.Pop();
            }

            stack.Push(i);
        }

        int[] result = new int[nums.Length];
        Array.Copy(res, 0, result, 0, nums.Length);
        return result;
    }
}