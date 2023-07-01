namespace LeetCode.哈希表;

public class Solution350两个数组的交集II
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        IDictionary<int, int> dictionary1 = new Dictionary<int, int>();
        IDictionary<int, int> dictionary2 = new Dictionary<int, int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            dictionary1.TryAdd(nums1[i], 0);
            dictionary1[nums1[i]]++;
        }
        
        for (int i = 0; i < nums2.Length; i++)
        {
            dictionary2.TryAdd(nums2[i], 0);
            dictionary2[nums2[i]]++;
        }

        IList<int> res = new List<int>();
        foreach (var item in dictionary1)
        {
            dictionary2.TryGetValue(item.Key, out int num);
            int count = Math.Min(item.Value, num);
            for (int i = 0; i < count; i++)
            {
                res.Add(item.Key);
            }
        }

        return res.ToArray();
    }

    // 为了降低空间复杂度，首先遍历较短的数组并在哈希表中记录每个数字以及对应出现的次数，然后遍历较长的数组得到交集。
    public int[] Intersect1(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
        {
            return Intersect(nums2, nums1);
        }

        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            dict.TryAdd(nums1[i], 0);
            dict[nums1[i]]++;
        }

        int[] intersection = new int[nums1.Length];
        int index = 0;
        foreach (var num in nums2)
        {
            dict.TryGetValue(num, out int count);
            if (count > 0)
            {
                intersection[index++] = num;
                dict[num]--;
            }
        }

        int[] res = new int[index];
        Array.Copy(intersection, 0, res, 0, index);
        return res;
    }
    
    // 排序 + 双指针
    // 初始时，两个指针分别指向两个数组的头部。
    // 每次比较两个指针指向的两个数组中的数字，如果两个数字不相等，则将指向较小数字的指针右移一位，
    // 如果两个数字相等，将该数字添加到答案，并将两个指针都右移一位。
    // 当至少有一个指针超出数组范围时，遍历结束。
    public int[] Intersect2(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);
        int len1 = nums1.Length,len2 = nums2.Length;
        int[] intersection = new int[Math.Min(len1, len2)];
        int index1 = 0, index2 = 0, index = 0;
        while (index1 < len1 && index2 < len2)
        {
            if (nums1[index1] < nums2[index2])
            {
                index1++;
            }else if (nums1[index1] > nums2[index2])
            {
                index2++;
            }
            else
            {
                intersection[index++] = nums1[index1];
                index1++;
                index2++;
            }
        }
        int[] res = new int[index];
        Array.Copy(intersection, 0, res, 0, index);
        return res;
    }
}