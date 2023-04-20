namespace LeetCode.双指针;

public class Solution27移除元素
{
    public int RemoveElement(int[] nums, int val)
    {
        // 简单双指针
        int init = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[init++] = nums[i];
            }
        }

        return init;
    }
    
    // 双指针优化
    // 前提：「元素的顺序可以改变」
    // 实现方面，我们依然使用双指针，两个指针初始时分别位于数组的首尾，向中间移动遍历该序列。
    // 这样的方法两个指针在最坏的情况下合起来只遍历了数组一次。与方法一不同的是，方法二避免了需要保留的元素的重复赋值操作。
    public int RemoveElement1(int[] nums, int val)
    {
        int left = 0, right = nums.Length - 1;
        while (left <= right)
        {
            if (nums[left] == val)
            {
                nums[left] = nums[right];
                right--;
            }
            else
            {
                left++;
            }
        }

        return left;
    }
}