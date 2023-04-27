namespace LeetCode.数学;

public class Solution136只出现一次的数字
{
    public int SingleNumber(int[] nums)
    {
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i = i + 2)
        {
            if (i + 1 < nums.Length && nums[i] != nums[i + 1])
            {
                return nums[i];
            }
        }

        return nums[nums.Length - 1];
    }
    
    // 异或运算
    public int SingleNumber1(int[] nums)
    {
        int single = 0;
        foreach (var num in nums)
        {
            single ^= num;
        }

        return single;
    }
}