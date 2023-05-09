namespace LeetCode.数组;

public class Solution283移动零
{
    public void MoveZeroes(int[] nums)
    {
        // 双指针
        //使用双指针，左指针指向当前已经处理好的序列的尾部，右指针指向待处理序列的头部。
        //右指针不断向右移动，每次右指针指向非零数，则将左右指针对应的数交换，同时左指针右移。
        int init = 0, temp = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                temp = nums[i];
                nums[i] = nums[init];
                nums[init] = temp;
                init++;
            }
        }
    }

    // Leetcode官方
    public void MoveZeroes1(int[] nums)
    {
        int left = 0, right = 0, temp = 0;
        while (right < nums.Length)
        {
            if (nums[right] != 0)
            {
                temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
                left++;
            }

            right++;
        }
    }
}