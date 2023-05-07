namespace LeetCode.数组;

// 二分查找最重要的就是定义区间的范围，[left,right]或者[right,left)
public class Solution704二分查找
{
    //[left, right]
    public int Search(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1, mid = 0;
        while (left <= right)
        {
            mid = (left + right) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }

    //[left, right) 
    public int Search2(int[] nums, int target)
    {
        int left = 0, right = nums.Length, mid = 0; //right和上面不一样
        while (left < right) //判断条件和上面不一样
        {
            mid = (left + right) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return -1;
    }
}