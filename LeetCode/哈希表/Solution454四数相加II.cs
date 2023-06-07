namespace LeetCode.哈希表;

public class Solution454四数相加II
{
    // 分组 + 哈希表
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach (var i in nums1)
        {
            foreach (var j in nums2)
            {
                int sum = i + j;
                if (dict.ContainsKey(sum))
                {
                    dict[sum]++;
                }
                else
                {
                    dict.Add(sum, 1);
                }
            }
        }

        int res = 0;
        foreach (var a in nums3)
        {
            foreach (var b in nums4)
            {
                int sum = a + b;
                if (dict.TryGetValue(-sum, out var result))
                {
                    res += result;
                }
            }
        }

        return res;
    }
}