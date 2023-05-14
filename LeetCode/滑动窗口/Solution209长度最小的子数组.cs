namespace LeetCode.滑动窗口;

public class Solution209长度最小的子数组
{
    // 暴力法，枚举每一个下标，然后向后查找能满足条件的结束下标
    public int MinSubArrayLen(int target, int[] nums)
    {
        int n = nums.Length;
        if (n == 0)
        {
            return 0;
        }

        int ans = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            int sum = 0;
            for (int j = i; j < n; j++)
            {
                sum += nums[j];
                if (sum >= target)
                {
                    ans = Math.Min(ans, j - i + 1);
                    break;
                }
            }
        }

        return ans == int.MaxValue ? 0 : ans;
    }

    // 滑动窗口     主要是通过子数组的结束指针
    public int MinSubArrayLen1(int target, int[] nums)
    {
        int n = nums.Length;
        if (n == 0)
        {
            return 0;
        }

        int ans = int.MaxValue;
        int start = 0, end = 0;
        int sum = 0;
        while (end < n)
        {
            sum += nums[end];
            while (sum >= target)
            {
                ans = Math.Min(ans, end - start + 1);
                sum -= nums[start];
                ++start;
            }

            end++;
        }

        return ans == int.MaxValue ? 0 : ans;
    }

    private int LowerBound(int[] a, int l, int r, int target)
    {
        int mid = -1;
        while (l < r)
        {
            mid = (l + r) >> 1;
            if (a[mid] < target)
            {
                l = mid + 1;
            }
            else
            {
                r = mid;
            }
        }

        return a[l] >= target ? l : -1;
    }

    // 前缀和 + 二分查找   遍历初始位置，通过二分查找将第二次循环变为logn
    public int MinSubArrayLen2(int s, int[] nums)
    {
        int n = nums.Length;
        if (n == 0)
        {
            return 0;
        }

        int ans = int.MaxValue;
        int[] sum = new int[n + 1];
        // 为了方便计算，令 size = n + 1 
        // sums[0] = 0 意味着前 0 个元素的前缀和为 0
        // sums[1] = A[0] 前 1 个元素的前缀和为 A[0]
        // 以此类推
        for (int i = 1; i <= n; i++)
        {
            sum[i] = sum[i - 1] + nums[i - 1];
        }

        for (int i = 1; i <= n; i++)
        {
            int target = s + sum[i - 1];
            int bound = LowerBound(sum, i, n, target);
            if (bound != -1)
            {
                ans = Math.Min(ans, bound - i + 1);
            }
        }

        return ans == int.MaxValue ? 0 : ans;
    }
}