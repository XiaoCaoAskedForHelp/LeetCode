namespace LeetCode.栈;

public class Solution496下一个更大元素I
{
    // 暴力 双重循环，第一次找到两个元素的相等的下标，第二次向后遍历找到更大的值
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        int len1 = nums1.Length, len2 = nums2.Length;
        int[] res = new int[len1];
        for (int i = 0; i < len1; i++)
        {
            int j = 0;
            while (j < len2 && nums2[j] != nums1[i])
            {
                j++;
            }

            j++;
            while (j < len2 && nums2[j] <= nums1[i])
            {
                j++;
            }

            res[i] = j < len2 ? nums2[j] : -1;
        }

        return res;
    }

    // 单调栈（递增） 和739每日温度几乎一样，就多了一个哈希表查找
    public int[] NextGreaterElement1(int[] nums1, int[] nums2)
    {
        Stack<int> stack = new Stack<int>();
        int[] res = new int[nums1.Length];
        Array.Fill(res, -1);
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            dict.Add(nums1[i], i);
        }

        for (int i = 0; i < nums2.Length; i++)
        {
            while (stack.Any() && nums2[i] > nums2[stack.Peek()])
            {
                if (dict.ContainsKey(nums2[stack.Peek()]))
                {
                    int index = dict[nums2[stack.Peek()]]; //栈顶小的元素的下标，找到元素，在通过元素在哈希表中找到nums1中的下标，也就是结果数组的下标。
                    res[index] = nums2[i]; // 结果数组的值就是现在这个比栈顶元素大的值。
                }

                stack.Pop();
            }

            stack.Push(i); // 往单调栈中添加是元素的下标
        }

        return res;
    }
}