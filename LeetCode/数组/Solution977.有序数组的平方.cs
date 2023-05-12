namespace LeetCode.数组;

public class Solution977_有序数组的平方
{
    //暴力
    public int[] SortedSquares(int[] nums)
    {
        int[] ans = new int[nums.Length];
        for (int i = 0; i < nums.Length; ++i) {
            ans[i] = nums[i] * nums[i];
        }
        Array.Sort(ans);
        return ans;
    }
    
    // 双指针
    public int[] SortedSquares2(int[] nums)
    {
        int n = nums.Length;
        int negative = -1;
        for (int k = 0; k < n; ++k) {
            if (nums[k] < 0) {
                negative = k;
            } else {
                break;
            }
        }
        int[] ans = new int[n];
        int index = 0, i = negative, j = negative + 1;
        while (i >= 0 || j < n) {
            if (i < 0) {
                ans[index] = nums[j] * nums[j];
                ++j;
            } else if (j == n) {
                ans[index] = nums[i] * nums[i];
                --i;
            } else if (nums[i] * nums[i] < nums[j] * nums[j]) {
                ans[index] = nums[i] * nums[i];
                --i;
            } else {
                ans[index] = nums[j] * nums[j];
                ++j;
            }
            ++index;
        }

        return ans;
    }
    
    
    // 双指针
    public int[] SortedSquares1(int[] nums)
    {
        int[] res = new int[nums.Length];
        int left = 0, right = nums.Length - 1;
        int index = nums.Length - 1;
        while (left <= right)
        {
            int lres = nums[left] * nums[left];
            int rres = nums[right] * nums[right];
            if (lres >= rres)
            {
                res[index] = lres;
                left++;
            }
            else
            {
                res[index] = rres;
                right--;
            }

            index--;
        }

        return res;
    }
}