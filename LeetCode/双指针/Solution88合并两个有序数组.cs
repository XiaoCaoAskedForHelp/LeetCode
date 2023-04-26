namespace LeetCode.双指针;

public class Solution88合并两个有序数组
{
    //直接合并后排序
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        for (int i = 0; i < n; i++)
        {
            nums1[m + i] = nums2[i];
        }

        Array.Sort(nums1);
    }

    //双指针,每次从两个数组头部取出比较小的数字放到结果中
    public void Merge2(int[] nums1, int m, int[] nums2, int n)
    {
        int p1 = 0, p2 = 0;
        int[] sort = new int[m + n];
        int cur;
        while (p1 < m || p2 < n)
        {
            if (p1 == m)
            {
                cur = nums2[p2++];
            }
            else if (p2 == n)
            {
                cur = nums1[p1++];
            }
            else if (nums1[p1] < nums2[p2])
            {
                cur = nums1[p1++];
            }
            else
            {
                cur = nums2[p2++];
            }

            sort[p1 + p2 - 1] = cur;
        }

        for (int i = 0; i < m+n; i++)
        {
            nums1[i] = sort[i];
        }
    }
    
    // 逆向双指针
    //方法二中，之所以要使用临时变量,是因为会在取出之前被覆盖
    public void Merge3(int[] nums1, int m, int[] nums2, int n)
    {
        int p1 = m - 1, p2 = n - 1;
        int tail = m + n - 1;
        int cur;
        while (p1 >= 0 || p2 >= 0) {
            if (p1 == -1) {
                cur = nums2[p2--];
            } else if (p2 == -1) {
                cur = nums1[p1--];
            } else if (nums1[p1] > nums2[p2]) {
                cur = nums1[p1--];
            } else {
                cur = nums2[p2--];
            }
            nums1[tail--] = cur;
        }
    }
}