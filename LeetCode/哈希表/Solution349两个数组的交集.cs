namespace LeetCode.哈希表;

public class Solution349两个数组的交集
{
    // 求两个set集合的交集
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        if (nums1 == null || nums1.Length == 0 || nums2 == null || nums2.Length == 0)
        {
            return new int[0];
        }

        HashSet<int> one = Insert(nums1);
        HashSet<int> two = Insert(nums2);
        one.IntersectWith(two);
        return one.ToArray();
    }

    public HashSet<int> Insert(int[] nums)
    {
        HashSet<int> one = new HashSet<int>();
        foreach (var num in nums)
        {
            one.Add(num);
        }

        return one;
    }

    // 将两个数组排序，然后双指针寻找
    public int[] Intersection1(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);
        int len1 = nums1.Length, len2 = nums2.Length;
        int[] intersection = new int[len1 + len2];
        int index = 0, index1 = 0, index2 = 0;
        while (index1 < len1 && index2 < len2)
        {
            int num1 = nums1[index1], num2 = nums2[index2];
            if (num1 == num2)
            {
                if (index == 0 || num1 != intersection[index - 1])
                {
                    intersection[index++] = num1;
                }

                index1++;
                index2++;
            }
            else if (num1 < num2)
            {
                index1++;
            }
            else
            {
                index2++;
            }
        }

        int[] res = new int[index];
        Array.Copy(intersection, 0, res, 0, index);
        return res;
    }
}