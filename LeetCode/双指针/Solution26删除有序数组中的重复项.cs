namespace LeetCode.双指针;

public class Solution26删除有序数组中的重复项
{
    //双指针，slow代表不重复的数组，当遇到不重复的数组时，在slow指针位置进行插入，并且slow+1
    //fast用于查询不重复的数字，由于数组时有序的，只需要将fast指向的数字与前一个数字进行比较，不同则为新数字
    public int RemoveDuplicates(int[] nums)
    {
        int n = nums.Length;
        if (n == 0)
        {
            return 0;
        }

        int fast = 1, slow = 1;
        while (fast < n)
        {
            if (nums[fast] != nums[fast - 1])
            {
                nums[slow] = nums[fast];
                slow++;
            }

            fast++;
        }

        return slow;
    }
}