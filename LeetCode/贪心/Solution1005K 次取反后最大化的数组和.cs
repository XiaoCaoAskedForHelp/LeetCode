namespace LeetCode.贪心;

public class Solution1005K_次取反后最大化的数组和
{
    public int LargestSumAfterKNegations(int[] nums, int k) {
        Array.Sort(nums);
        int index = 0;
        while (index < k && index < nums.Length && nums[index] < 0)
        {
            nums[index] = -nums[index];
            index++;
        }

        if (index < k)
        {
            Array.Sort(nums);
            if ((k - index) % 2 == 1)
            {
                nums[0] = -nums[0];
            }
        }
        

        return nums.Sum();
    }

    //第一步：将数组按照绝对值大小从大到小排序，注意要按照绝对值的大小
    //第二步：从前向后遍历，遇到负数将其变为正数，同时K--
    //第三步：如果K还大于0，那么反复转变数值最小的元素，将K用完
    //第四步：求和
    public int LargestSumAfterKNegations1(int[] nums, int k)
    {
        Array.Sort(nums,(a,b)=> Math.Abs(b) - Math.Abs(a));
        for (int i = 0; i < nums.Length && k > 0; i++)
        {
            //从前向后遍历，遇到负数将其变为正数，同时K--
            if (nums[i] < 0)
            {
                nums[i] = -nums[i];
                k--;
            }
        }

        // 这时候要么k耗尽，要么全部全部负数都变为正数
        // 如果K还大于0，那么反复转变数值最小的元素，将K用完
        if (k % 2 == 1) nums[^1] = -nums[^1];
        return nums.Sum();
    }
}